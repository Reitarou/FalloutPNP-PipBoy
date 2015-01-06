using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fallout_PNP_Helper.Properties;
using System.Threading;

namespace Fallout_PNP_Helper
{
    public partial class HackingDlg : Form
    {
        private Color c_DefaultBackgroundColor = System.Drawing.Color.FromArgb(255, 0, 30, 0);
        private Color c_DefaultBackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
        private Color c_HighlightBackColor = System.Drawing.Color.FromArgb(180, 0, 255, 0);
        private Color c_DefaultForeColor = System.Drawing.Color.FromArgb(150, 0, 255, 0);
        private Color c_HighlightForeColor = System.Drawing.Color.FromArgb(200, 0, 100, 0);
        private Font c_DefaultFont = new Font("Courier New", fontSize, FontStyle.Bold);
        private Font c_HighlightFont = new Font("Courier New", fontSize, FontStyle.Bold);

        private const float fontSize = 14;
        private const int c_CellSize = (int)(14 * 1.5);

        private int c_HeaderRows = 2;

        private Point c_DefaultOffset = new Point((int)(c_CellSize * 0.5), (int)(c_CellSize * 0.5));


        private const int m_VariantCount = 12;

        //Total length = rowlength + 1 + 8 + 1 + 7 = 16 + 17 = 33
        private const int c_RowLength = 16;
        private const int c_TotalLength = 33;
        private const string c_Symbols = "!@#$%^*.<>/?-";
        private const string c_Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Random rng = new Random();

        private string m_Password;
        private List<string> m_Passwords;
        private int m_TryLeft = 2;
        private int m_AddTry = 3;

        private int m_Difficulty;

        private List<Label> ToTypeLetters = new List<Label>();

        public HackingDlg(int difficulty)
        {
            InitializeComponent();
            m_Difficulty = difficulty;
            this.BackColor = c_DefaultBackgroundColor;
            
        }

        private void HackingDlg_Load(object sender, EventArgs e)
        {
            this.Width = c_CellSize * (c_TotalLength+1);
            this.Height = c_CellSize * (c_HeaderRows + m_VariantCount + 2);
            this.Left = (int)((SystemInformation.PrimaryMonitorSize.Width - this.Width) * 0.5);
            this.Top = (int)((SystemInformation.PrimaryMonitorSize.Height - this.Height) * 0.5);

            
        }

        private string RngSymbol
        {
            get
            {
                var ind = rng.Next(0, c_Symbols.Length - 1);
                return c_Symbols.Substring(ind, 1);
            }
        }

        private string RngLetter
        {
            get
            {
                var ind = rng.Next(0, c_Letters.Length - 1);
                return c_Letters.Substring(ind, 1);
            }
        }

        private string GeneratePassword(int length)
        {
            var password = string.Empty;
            while (password.Length < length)
            {
                var letter = RngLetter;
                if (!password.Contains(letter))
                {
                    password += letter;
                }
            }
            return password;
        }

        private string FakePassword(string password)
        {
            var min = m_Difficulty + 1;
            var max = min * 2;

            var div = password.Length - rng.Next(min, max);

            var fakepass = password;
            int index;
            while (div > 0)
            {
                index = rng.Next(0, fakepass.Length-1);
                fakepass = fakepass.Remove(index, 1);
                div--;
            }

            while (fakepass.Length < password.Length)
            {
                index = rng.Next(0, fakepass.Length);

                var l = RngLetter;
                if (!fakepass.Contains(l))
                {
                    fakepass = fakepass.Insert(index, l);
                }
            }

            return fakepass;
        }

        private void typeMessage(string message, int rowIndex, int colStart, object tag)
        {
            var loc = new Point(c_DefaultOffset.X + c_CellSize*colStart, c_DefaultOffset.Y + c_CellSize*rowIndex);

            for (int index = 0; index<message.Length; index++)
            {
                var label = new Label();

                label.AutoSize = false;
                label.Height = c_CellSize;
                label.Width = c_CellSize;

                label.Text = message.Substring(index, 1);
                label.Tag = tag;

                label.Font = c_DefaultFont;
                label.ForeColor = c_DefaultForeColor;
                label.BackColor = c_DefaultBackColor;
                label.TextAlign = ContentAlignment.TopCenter;
                label.Location = loc;

                label.Click += letter_Click;
                label.MouseHover += letter_MouseHover;
                label.MouseLeave += letter_MouseLeave;

                ToTypeLetters.Add(label);

                loc.X += c_CellSize;
            }
        }

        

        private void letter_Click(object sender, EventArgs e)
        {
            var lb = sender as Label;
            if (lb != null)
            {
                int index, pos, cont;
                if (int.TryParse(lb.Tag.ToString(), out index) && index >= 0)
                {
                    if (!AnalizePass(index, out pos, out cont))
                    {
                        var space = string.Empty;
                        for (int i = 0; i <= 8 - m_Password.Length; i++)
                        {
                            space += " ";
                        }
                        typeMessage(string.Format(Resources.sTryString, m_Passwords[index], space, pos.ToString(), cont.ToString()), index+c_HeaderRows, c_RowLength+1, -1);
                    }
                    else
                    {
                        HackSuccess();
                        return;
                    }
                }
            }
            --m_TryLeft;
            if (m_TryLeft == 0)
            {
                HackFailed();
            }
        }

        private void letter_MouseHover(object sender, EventArgs e)
        {
            var lb = sender as Label;
            if (lb != null)
            {
                int index;
                if (int.TryParse(lb.Tag.ToString(), out index) && index >= 0)
                {
                    int cindex;
                    foreach (var control in this.Controls)
                    {
                        var clb = control as Label;
                        if (clb != null)
                        {
                            if (int.TryParse(clb.Tag.ToString(), out cindex) && cindex == index)
                            {
                                clb.Font = c_HighlightFont;
                                clb.ForeColor = c_HighlightForeColor;
                                clb.BackColor = c_HighlightBackColor;
                            }
                        }
                    }
                }
            }
        }

        private void letter_MouseLeave(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                var clb = control as Label;
                if (clb != null)
                {
                    clb.Font = c_DefaultFont;
                    clb.ForeColor = c_DefaultForeColor;
                    clb.BackColor = c_DefaultBackColor;
                }
            }
        }

        private bool AnalizePass(int index, out int positions, out int letters)
        {
            var candidate = m_Passwords[index];
            positions = 0;
            letters = 0;
            if (candidate.Equals(m_Password))
            {
                return true;
            }
            else
            {
                for (int i = 0; i < Math.Min(m_Password.Length, candidate.Length); i++)
                {
                    var c = candidate.Substring(i, 1);
                    var p = m_Password.Substring(i, 1);

                    if (c.Equals(p))
                    {
                        ++positions;
                    }
                    else
                    {
                        if (m_Password.Contains(c))
                        {
                            ++letters;
                        }
                    }
                }

                return false;
            }
        }

        private void HackStart()
        {
            this.Controls.Clear();
            //           0123456789ABCDEF=FEDCBA9876543210
            typeMessage("DECRYPT PASSWORD           ReiCo.", 0, 0, -1);

            m_TryLeft += rng.Next(1, m_AddTry);

            m_Password = GeneratePassword(2 + m_Difficulty * 2);
            m_Passwords = new List<string>(m_VariantCount);

            while (m_Passwords.Count < m_VariantCount - 1)
            {
                var fake = FakePassword(m_Password);
                if (!m_Passwords.Contains(fake))
                {
                    m_Passwords.Add(fake);
                }
            }

            int index = rng.Next(0, m_Passwords.Count);
            m_Passwords.Insert(index, m_Password);

            for (int i = 0; i < m_VariantCount; i++)
            {
                index = rng.Next(0, c_RowLength - m_Password.Length - 1);
                for (int j = 0; j < c_RowLength; j++)
                {
                    string text;
                    int tag;
                    if (j >= index && j < index + m_Password.Length)
                    {
                        text = m_Passwords[i].Substring(j - index, 1);
                        tag = i;
                    }
                    else
                    {
                        text = RngSymbol;
                        tag = -1;
                    }

                    typeMessage(text, c_HeaderRows + i, j, tag);
                }
            }
        }

        private void HackSuccess()
        {
            ToTypeLetters.Clear();
            this.Controls.Clear();
            //           0123456789ABCDEF=FEDCBA9876543210
            typeMessage("ACCESS GRANTED", 4, 9, -1);
        }

        private void HackFailed()
        {
            ToTypeLetters.Clear();
            this.Controls.Clear();
            //           0123456789ABCDEF=FEDCBA9876543210
                     typeMessage("TERMINAL LOCKED", 2, 9, -1);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ToTypeLetters.Count > 0)
            {
                this.Controls.Add(ToTypeLetters[0]);
                ToTypeLetters.RemoveAt(0);
                this.Refresh();
            }
        }

        private void HackingDlg_Shown(object sender, EventArgs e)
        {
            HackStart();
        }

        private void HackingDlg_MouseDown(object sender, MouseEventArgs e)
        {
            timer.Interval = 10;
        }

        private void HackingDlg_MouseUp(object sender, MouseEventArgs e)
        {
            timer.Interval = 50;
        }
    }
}
