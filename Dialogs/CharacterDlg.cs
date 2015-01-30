using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using FalloutPNP_PipBoy.XmlCollections;
using FalloutPNP_PipBoy.Properties;

namespace FalloutPNP_PipBoy
{

    public partial class CharacterDlg : Form
    {
        private Character m_Character;
        private Races m_Races;
        private Items m_Items;

        private bool ChangedByUser = true;

        private const string cSpecial = " S.P.E.C.I.A.L. ";
        private const string cSpecialCanDistrib =  " Доступно {0} оч.";
        private const string cSpecialOverDistrib = " ПРЕВЫШЕНО {0} оч.";

        private const string cControlName_LbSpecialMinName = "lb{0}Min";
        private const string cControlName_LbSpecialMaxName = "lb{0}Max";
        private const string cControlName_NudSpecialName = "nud{0}";

        private const string cControlName_LbSkillName = "lbSkill{0}";
        private const string cControlName_LbSkillResult = "lbSkill{0}";
        private const string cControlName_LbSkillDestr_1_100 = "lbSkill{0}";
        private const string cControlName_LbSkillDestr_101_125 = "lbSkill{0}";
        private const string cControlName_LbSkillDestr_126_150 = "lbSkill{0}";
        private const string cControlName_LbSkillDestr_151_175 = "lbSkill{0}";
        private const string cControlName_LbSkillDestr_176_200 = "lbSkill{0}";

        public CharacterDlg(Races races, Items items, Character character)
        {
            InitializeComponent();
            m_Races = races;
            m_Items = items;
            m_Character = character;

            CreateControls();

            RefreshChar();
        }

        private void CharacterDlg_Load(object sender, EventArgs e)
        {
            ChangedByUser = false;

            cmbRace.Items.Clear();
            foreach (var race in m_Races)
            {
                cmbRace.Items.Add(race.Name);
            }

            ChangedByUser = true;
        }

        private void RefreshChar()
        {
            m_Character.Refresh();

            int totalDistrSumm = 5;
            for (int i = 0; i < 7; i++)
            {
                var stat = m_Character.CharStats[i];
                totalDistrSumm -= stat.Distibution;
            }

            #region PostToControls

            ChangedByUser = false;

            cmbRace.Text = m_Character.CharRace.Name;

            if (totalDistrSumm > 0)
            {
                gbSpecial.Text = string.Format(cSpecialCanDistrib, totalDistrSumm.ToString());
            }
            else if (totalDistrSumm == 0)
            {
                gbSpecial.Text = string.Format(cSpecial, totalDistrSumm.ToString());
            }
            else //if (TotalDistrSumm < 0)
            {
                gbSpecial.Text = string.Format(cSpecialOverDistrib, (totalDistrSumm*-1).ToString());
            }

            SetSpecialParams(m_Character);

            ChangedByUser = true;

            #endregion
        }

        private void SetSpecialParams(Character character)
        {
            for (int i = 0; i < 7; i++)
            {
                var statName = ((Attributes.SPECIAL)i).ToString();
                var stat = character.CharStats[i];

                var control = gbSpecial.Controls[string.Format(cControlName_NudSpecialName, statName)];
                if (control != null)
                {
                    var nud = control as NumericUpDown;
                    if (nud != null)
                    {
                        nud.Minimum = Math.Min(stat.MinValue, stat.CurValue);
                        nud.Maximum = Math.Max(stat.MaxValue, stat.CurValue);
                        nud.Value = stat.CurValue;
                    }
                }

                control = gbSpecial.Controls[string.Format(cControlName_LbSpecialMinName, statName)];
                if (control != null)
                {
                    var lb = control as Label;
                    if (lb != null)
                    {
                        lb.Text = stat.MinValue.ToString();
                    }
                }

                control = gbSpecial.Controls[string.Format(cControlName_LbSpecialMaxName, statName)];
                if (control != null)
                {
                    var lb = control as Label;
                    if (lb != null)
                    {
                        lb.Text = stat.MaxValue.ToString();
                    }
                }
            }
        }

        private void cmbRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                m_Character.AttributesList[Attributes.CharacterAtt.Race] = cmbRace.Text;

                for (int i = 0; i < 7; i++)
                {
                    m_Character.AttributesList[Attributes.CharacterAtt.Distribution(i)] = "0";
                }
                RefreshChar();
            }
        }

        #region SPECIAL Numerics

        private void nudSpecial_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                var nud = sender as NumericUpDown;
                if (nud != null)
                {
                    var statName = nud.Tag.ToString();

                    var prevValue = int.Parse(nud.Text);
                    var currValue = nud.Value;
                    
                    var curDistr = m_Character.AttributesList.GetInt(string.Format(Attributes.CharacterAtt.cDistribution, statName));
                    var newDistr = curDistr + (currValue - prevValue);
                    
                    m_Character.AttributesList[string.Format(Attributes.CharacterAtt.cDistribution, statName)] = newDistr.ToString();
                    RefreshChar();
                }
            }
        }

        #endregion

        #region CreateControls

        private void CreateControls()
        {
            #region Skills

            int y = 20;
            for (int i = 0; i < 19; i++)
            {
                var label = new Label();
                label.Name = string.Format(cControlName_LbSkillName, ((Attributes.SkillNames)i).ToString());
                label.Size = new Size(100, 13);
                label.Text = ((Attributes.SkillNames)i).Description();
                label.Location = new Point(10, y);
                gbSkills.Controls.Add(label);

                label = new Label();
                label.Name = string.Format(cControlName_LbSkillResult, ((Attributes.SkillNames)i).ToString());
                label.Size = new Size(25, 13);
                label.Text = "200";
                label.Location = new Point(110, y);
                gbSkills.Controls.Add(label);

                y += 20;
                if (i == 2 || i == 5 || i == 7 || i == 11 || i == 14 || i == 16)
                {
                    y += 10;
                }
            }

            #endregion
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
