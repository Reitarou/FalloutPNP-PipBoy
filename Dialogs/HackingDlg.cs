using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FalloutPNP_PipBoy.Dialogs.Properties;

namespace FalloutPNP_PipBoy.Dialogs
{
    public partial class HackingDlg : Form
    {
        private class LetterTag
        {
            public int Row = -1;
            public int Col = -1;
            public int PassIndex = -1;

            public LetterTag()
            {
            }
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private Color c_DefaultBackgroundColor = System.Drawing.Color.FromArgb(255, 0, 30, 15);
        private Color c_HighlightBackColor = System.Drawing.Color.FromArgb(255, 30, 255, 130);
        private Color c_DefaultForeColor = System.Drawing.Color.FromArgb(255, 30, 255, 130);
        private Color c_HighlightForeColor = System.Drawing.Color.FromArgb(255, 15, 130, 65);

        private Font m_Font;
        //private Font c_HighlightFont = new Font("Courier New", fontSize, FontStyle.Bold);

        private const float c_FontSize = 13.25f;
        private const int c_CellWidth = 11;
        private const int c_CellHeight = 20;
        //private const int c_CellSize = (int)(12 * 1.5);

        private const int c_HeaderRows = 5;
        private const int c_DataRows = 17;
        private const int c_AddressCols = 7;
        private const int c_DataCols = 12;

        private Point c_TypeFieldLoc = new Point(95, 80);

        private const int m_VariantCount = 12;

        private const int c_RowLength = 16;
        private Random RNG = new Random();

        private string m_Password;
        private List<string> m_Passwords;
        private int m_TryLeft = 2;
        private int m_AddTry = 3;

        private int m_Difficulty;
        private int m_Address = 61440;
        private int m_CommentRow = c_HeaderRows;

        private List<Label> ToTypeLetters = new List<Label>();
        private List<Label> ToReplaceLetters = new List<Label>();

        public HackingDlg(int difficulty)
        {
            InitializeComponent();
            m_Difficulty = difficulty;
        }

        private void HackingDlg_Load(object sender, EventArgs e)
        {
            m_Address += RNG.Next(50, 900) * 4;
            this.TransparencyKey = System.Drawing.Color.FromArgb(255, 255, 0, 255);
            this.AllowTransparency = true;
            PrepareFont();
        }

        #region RNG & Generations

        private string RngSymbol
        {
            get
            {
                var ind = RNG.Next(0, Resources.sSymbols.Length - 1);
                return Resources.sSymbols.Substring(ind, 1);
            }
        }

        private string RngLetter
        {
            get
            {
                var ind = RNG.Next(0, Resources.sLetters.Length - 1);
                return Resources.sLetters.Substring(ind, 1);
            }
        }

        private string RngDataString
        {
            get
            {
                var hexaddr = m_Address.ToString("X");
                var symbols = string.Empty;
                for (int i = 0; i < c_DataCols; i++)
                {
                    symbols += RngSymbol;
                }
                m_Address += 6;
                return string.Format(Resources.sCodeString, hexaddr, symbols);
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

            var div = password.Length - RNG.Next(min, max);

            var fakepass = password;
            int index;
            while (div > 0)
            {
                index = RNG.Next(0, fakepass.Length - 1);
                fakepass = fakepass.Remove(index, 1);
                div--;
            }

            while (fakepass.Length < password.Length)
            {
                index = RNG.Next(0, fakepass.Length);

                var l = RngLetter;
                if (!fakepass.Contains(l))
                {
                    fakepass = fakepass.Insert(index, l);
                }
            }

            return fakepass;
        }

        private void NextRowCol(ref int row, ref int col)
        {
            if (col == c_AddressCols + c_DataCols - 1)
            {
                col = c_AddressCols;
                if (row != c_HeaderRows + c_DataRows - 1)
                {
                    ++row;
                }
                else
                {
                    row = c_HeaderRows;
                    col = c_AddressCols + c_DataCols + 1 + c_AddressCols;
                }
            }
            else if (col == (c_AddressCols + c_DataCols) * 2)
            {
                col = c_AddressCols + c_DataCols + 1 + c_AddressCols;
                if (row != c_HeaderRows + c_DataRows - 1)
                {
                    ++row;
                }
                else
                {
                    Debug.Assert(false);
                }
            }
            else
            {
                ++col;
            }
        }

        #endregion

        private void TypeStringMessage(string message, int row, int col)
        {
            TypeStringMessage(message, row, col, true);
        }

        private void TypeStringMessage(string message, int row, int col, bool delay)
        {
            for (int index = 0; index < message.Length; index++)
            {
                var label = new Label();

                label.AutoSize = false;
                label.Height = c_CellHeight;
                label.Width = c_CellWidth;

                label.Text = message.Substring(index, 1);
                label.Tag = new LetterTag() { Col = col, Row = row };

                label.Font = m_Font;
                label.ForeColor = c_DefaultForeColor;
                label.BackColor = c_DefaultBackgroundColor;
                label.TextAlign = ContentAlignment.TopCenter;
                label.Location = new Point(c_TypeFieldLoc.X + c_CellWidth * col, c_TypeFieldLoc.Y + c_CellHeight * row);

                label.Click += letter_Click;
                label.MouseHover += letter_MouseHover;
                label.UseCompatibleTextRendering = true;

                if (delay)
                {
                    ToTypeLetters.Add(label);
                }
                else
                {
                    this.Controls.Add(label);
                    this.Controls[this.Controls.Count - 1].BringToFront();
                }
                ++col;
            }
        }
        private void ReplaceLetter(int row, int col, string newLetter, int newPassIndex)
        {
            var lb = new Label();
            lb.Text = newLetter;
            lb.Tag = new LetterTag() { Col = col, Row = row, PassIndex = newPassIndex };

            ToReplaceLetters.Add(lb);
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
            TypeStringMessage(Resources.sHeader1, 0, 0);
            TypeStringMessage(Resources.sHeader2, 1, 0);
            TypeStringMessage(Resources.sAttempts, 3, 0);
            m_TryLeft += RNG.Next(1, m_AddTry);
            for (int i = 0; i < m_TryLeft; i++)
            {
                TypeStringMessage("O", 3, Resources.sAttempts.Length + i);
            }

            for (int i = 0; i < c_DataRows; i++)
            {
                TypeStringMessage(RngDataString, c_HeaderRows + i, 0, true);
            }

            for (int i = 0; i < c_DataRows; i++)
            {
                TypeStringMessage(RngDataString, c_HeaderRows + i, c_AddressCols + c_DataCols + 1, true);
            }

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

            int index = RNG.Next(0, m_Passwords.Count);
            m_Passwords.Insert(index, m_Password);

            var range = (int)(c_DataCols * c_DataRows * 2 / m_Passwords.Count);
            for (int i = 0; i < m_Passwords.Count; i++)
            {
                var password = m_Passwords[i];

                var pos = range * i + RNG.Next(0, range - m_Password.Length - 1);
                var row = c_HeaderRows;
                var col = c_AddressCols;
                while (pos > 0)
                {
                    NextRowCol(ref row, ref col);
                    --pos;
                }
                for (int j = 0; j < password.Length; j++)
                {
                    ReplaceLetter(row, col, password.Substring(j, 1), i);
                    NextRowCol(ref row, ref col);
                }
            }



            //for (int i = 0; i < m_VariantCount; i++)
            //{
            //    index = RNG.Next(0, c_RowLength - m_Password.Length - 1);
            //    for (int j = 0; j < c_RowLength; j++)
            //    {
            //        string text;
            //        int tag;
            //        if (j >= index && j < index + m_Password.Length)
            //        {
            //            text = m_Passwords[i].Substring(j - index, 1);
            //            tag = i;
            //        }
            //        else
            //        {
            //            text = RngSymbol;
            //            tag = -1;
            //        }

            //        TypeStringMessage(text, c_HeaderRows + i, j, tag);
            //    }
            //}
        }

        private void HackingDlg_Shown(object sender, EventArgs e)
        {
            HackStart();
        }

        private void PrepareFont()
        {
            //Stream fontStream = this.GetType().Assembly.GetManifestResourceStream("Fallout_PNP_PipBoy.fixedsys.ttf");


            //var pfc = new PrivateFontCollection();

            //byte[] fontdata = new byte[fontStream.Length];

            //fontStream.Read(fontdata, 0, (int)fontStream.Length);

            //fontStream.Close();

            //unsafe
            //{

            //    fixed (byte* pFontData = fontdata)
            //    {

            //        pfc.AddMemoryFont((System.IntPtr)pFontData, fontdata.Length);

            //    }

            //}



            //unsafe
            //{
            //    string resource = "Fallout_PNP_PipBoy.fixedsys.ttf";
            //    Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);

            //    // create an unsafe memory block for the font data
            //    System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);

            //    // create a buffer to read in to
            //    byte[] fontdata = new byte[fontStream.Length];

            //    // read the font data from the resource
            //    fontStream.Read(fontdata, 0, (int)fontStream.Length);

            //    // copy the bytes to the unsafe memory block
            //    Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);

            //    // pass the font to the font collection
            //    pfc.AddMemoryFont(data, (int)fontStream.Length);

            //    // close the resource stream
            //    fontStream.Close();

            //    // free up the unsafe memory
            //    Marshal.FreeCoTaskMem(data);
            //}

            //var ff = pfc.Families[0];
            //m_Font = new Font(ff, c_FontSize);


            //try
            //{
            // Create the byte array and get its length
            //byte[] fontArray = Resources.SDF;
            //int dataLength = Resources.SDF.Length;

            //// ASSIGN MEMORY AND COPY  BYTE[] ON THAT MEMORY ADDRESS
            //IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            //Marshal.Copy(fontArray, 0, ptrData, dataLength);

            //uint cFonts = 0;
            //AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            //PrivateFontCollection pfc = new PrivateFontCollection();
            ////PASS THE FONT TO THE  PRIVATEFONTCOLLECTION OBJECT
            //pfc.AddMemoryFont(ptrData, dataLength);

            ////FREE THE  "UNSAFE" MEMORY
            //Marshal.FreeCoTaskMem(ptrData);

            //var ff = pfc.Families[0];
            //m_Font = new Font(ff, c_FontSize, FontStyle.Regular);
            //}
            //catch
            //{
            m_Font = new Font("Courier New", c_FontSize, FontStyle.Bold);
            //}
        }

        #region Actions

        //Letters
        private void letter_Click(object sender, EventArgs e)
        {
            var lb = sender as Label;
            if (lb != null)
            {
                var tag = lb.Tag as LetterTag;
                if (tag != null)
                {
                    var index = tag.PassIndex;
                    if (index >= 0)
                    {
                        int pos, cont;
                        if (!AnalizePass(index, out pos, out cont))
                        {
                            TypeStringMessage(">" + m_Passwords[index], m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            TypeStringMessage(">" + "hit:" + pos.ToString() + " con:" + cont.ToString(), m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                        }
                        else
                        {
                            TypeStringMessage(">" + m_Passwords[index], m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            TypeStringMessage(">Exact match!", m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            TypeStringMessage(">Please wait", m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            TypeStringMessage(">while system", m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            TypeStringMessage(">is accessed.", m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            return;
                        }
                        ReplaceLetter(3, Resources.sAttempts.Length + m_TryLeft - 1, "X", -1);
                        --m_TryLeft;
                        if (m_TryLeft == 0)
                        {
                            TypeStringMessage(">", m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            TypeStringMessage(">WARNING!", m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            TypeStringMessage(">System blocked!", m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            TypeStringMessage(">Right pass", m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                            TypeStringMessage(">" + m_Password, m_CommentRow, (c_AddressCols + c_DataCols + 1) * 2);
                            ++m_CommentRow;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Highlights letters with same Tag >= 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void letter_MouseHover(object sender, EventArgs e)
        {
            var lb = sender as Label;
            if (lb != null)
            {
                var tag = lb.Tag as LetterTag;
                if (tag != null)
                {
                    var index = tag.PassIndex;
                    if (index >= 0)
                    {
                        foreach (var control in this.Controls)
                        {
                            var olb = control as Label;
                            if (olb != null)
                            {
                                var otag = olb.Tag as LetterTag;
                                if (otag != null)
                                {
                                    var cindex = otag.PassIndex;

                                    if (cindex == index)
                                    {
                                        olb.ForeColor = c_HighlightForeColor;
                                        olb.BackColor = c_HighlightBackColor;
                                    }
                                    else
                                    {
                                        olb.ForeColor = c_DefaultForeColor;
                                        olb.BackColor = c_DefaultBackgroundColor;
                                    }
                                }
                            }
                        }
                    }
                    else //if index < 0
                    {
                        foreach (var control in this.Controls)
                        {
                            var olb = control as Label;
                            if (olb != null)
                            {
                                olb.ForeColor = c_DefaultForeColor;
                                olb.BackColor = c_DefaultBackgroundColor;
                            }
                        }
                    }
                }
            }
        }

        //Typer timer
        private void tmTyper_Tick(object sender, EventArgs e)
        {
            if (ToTypeLetters.Count > 0)
            {
                this.Controls.Add(ToTypeLetters[0]);
                this.Controls[this.Controls.Count - 1].BringToFront();
                ToTypeLetters.RemoveAt(0);
                return;
            }

            if (ToReplaceLetters.Count > 0)
            {
                var newlb = ToReplaceLetters[0];
                var newtag = newlb.Tag as LetterTag;
                if (newtag != null)
                {
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        var lb = this.Controls[i] as Label;
                        if (lb != null)
                        {
                            var tag = lb.Tag as LetterTag;
                            if (tag != null)
                            {
                                if (tag.Row == newtag.Row && tag.Col == newtag.Col)
                                {
                                    lb.Text = newlb.Text;
                                    lb.Tag = newtag;
                                    ToReplaceLetters.RemoveAt(0);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        //Dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void HackingDlg_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void HackingDlg_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void HackingDlg_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion

        private void TempStorage()
        {
            // Store integer 182
            int decValue = 182;
            // Convert integer 182 as a hex in a string variable
            string hexValue = decValue.ToString("X");
            // Convert the hex string back to the number
            int decAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
        }

        private void pbPowerButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
