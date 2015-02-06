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
using FalloutPNP_PipBoy.Dialogs.Properties;

namespace FalloutPNP_PipBoy.Dialogs
{

    public partial class CharacterDlg : Form
    {
        private Character m_Character;
        private List<Attributes> m_Items;
        private List<Attributes> m_Races;
        private List<Attributes> m_Traits;

        private bool ChangedByUser = true;

        private const string cSpecial = " S.P.E.C.I.A.L. ";
        private const string cSpecialCanDistrib = " Доступно {0} оч. ";
        private const string cSpecialOverDistrib = " ПРЕВЫШЕНО {0} оч. ";

        private const string cSkills = " Умения ";
        private const string cTagsCanDistrib = " Умения (Доступно особых умений: {0}) ";
        private const string cTagsOverDistrib = " Умения (ЛИШНИХ особых умений: {0}) ";

        private const string cControlName_LbSpecialMinName = "lb{0}Min";
        private const string cControlName_LbSpecialMaxName = "lb{0}Max";
        private const string cControlName_NudSpecialName = "nud{0}";

        private const string cControlName_CbSkillName = "cbSkill{0}Name";
        private const string cControlName_LbSkillName = "lbSkill{0}Name";
        private const string cControlName_LbSkillResult = "lbSkill{0}Value";
        private const string cControlName_LbSkillDestr_1_100 = "lbSkillD1{0}D1";
        private const string cControlName_LbSkillDestr_101_125 = "lbSkill{0}D2";
        private const string cControlName_LbSkillDestr_126_150 = "lbSkill{0}D3";
        private const string cControlName_LbSkillDestr_151_175 = "lbSkill{0}D4";
        private const string cControlName_LbSkillDestr_176_200 = "lbSkill{0}D5";

        private const string cControlName_LbParameterName = "lbParameter{0}Name";
        private const string cControlName_LbParameterResult = "lbParameter{0}Value";
        

        public CharacterDlg(Character character, List<Attributes> items, List<Attributes> races, List<Attributes> traits)
        {
            InitializeComponent();
            m_Character = character;
            m_Items = items;
            m_Races = races;
            m_Traits = traits;

            CreateControls();

            RefreshChar();
        }

        private void CharacterDlg_Load(object sender, EventArgs e)
        {
            ChangedByUser = false;

            cmbRace.Items.Clear();
            foreach (var race in m_Races)
            {
                cmbRace.Items.Add(race[AttributeNames.cName]);
            }

            ChangedByUser = true;
        }

        #region Отображение Character`а

        private void RefreshChar()
        {
            m_Character.Refresh();

            ChangedByUser = false;

            RefreshControls();
            SetSpecials();
            SetSkills();
            SetParameters();

            ChangedByUser = true;
        }

        private void RefreshControls()
        {
            var charRace = m_Character.Race[AttributeNames.cName];
            cmbRace.Text = charRace;
            
            var traitFirst = m_Character.TraitFirst[AttributeNames.cName];
            var traitSecond = m_Character.TraitSecond[AttributeNames.cName];
            
            cmbTraitFirst.Items.Clear();
            cmbTraitSecond.Items.Clear();
            foreach (var trait in m_Traits)
            {
                var traitName = trait[AttributeNames.cName];
                var races = trait.Element.Elements(AttributeNames.cRace);
                foreach (var race in races)
                {
                    if (race.Value == charRace)
                    {
                        if (traitSecond != traitName)
                        {
                            cmbTraitFirst.Items.Add(traitName);
                        }
                        if (traitFirst != traitName)
                        {
                            cmbTraitSecond.Items.Add(traitName);
                        }
                        break;
                    }
                }
            }
            cmbTraitFirst.Items.Insert(0, "");
            cmbTraitSecond.Items.Insert(0, "");

            cmbTraitFirst.SelectedIndex = cmbTraitFirst.Items.IndexOf(traitFirst);
            cmbTraitSecond.SelectedIndex = cmbTraitSecond.Items.IndexOf(traitSecond);
        }

        private void SetSpecials()
        {
            for (int i = 0; i < 7; i++)
            {
                var statName = ((AttributeNames.ESpecials)i).ToString();
                var stat = m_Character.Stats[i];

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

            int totalDistrSumm = 5;
            for (int i = 0; i < 7; i++)
            {
                var stat = m_Character.Stats[i];
                totalDistrSumm -= stat.Distibution;
            }
            if (totalDistrSumm > 0)
            {
                gbSpecial.Text = string.Format(cSpecialCanDistrib, totalDistrSumm.ToString());
            }
            else if (totalDistrSumm == 0)
            {
                gbSpecial.Text = cSpecial;
            }
            else //if (TotalDistrSumm < 0)
            {
                gbSpecial.Text = string.Format(cSpecialOverDistrib, (totalDistrSumm * -1).ToString());
            }
        }

        private void SetSkills()
        {
            for (int i = 0; i < 19; i++)
            {
                var skillName = ((AttributeNames.ESkills)i).ToString();
                var skill = m_Character.Skills[i];

                var lbName = gbSkills.Controls[string.Format(cControlName_LbSkillName, skillName)] as Label;
                var lbValue = gbSkills.Controls[string.Format(cControlName_LbSkillResult, skillName)] as Label;
                lbValue.Text = skill.Value.ToString();
                if (skill.Tag == true)
                {
                    lbName.Font = new Font(lbName.Font, FontStyle.Bold);
                }
                else
                {
                    lbName.Font = new Font(lbName.Font, FontStyle.Regular);
                }
            }

            int availableTags = 3;
            var tags = m_Character.Attribs.Element.Elements(AttributeNames.cTag);
            availableTags -= tags.Count();
            if (availableTags > 0)
            {
                gbSkills.Text = string.Format(cTagsCanDistrib, availableTags.ToString());
            }
            else if (availableTags == 0)
            {
                gbSkills.Text = string.Format(cSkills);
            }
            else //if (TotalDistrSumm < 0)
            {
                gbSkills.Text = string.Format(cTagsOverDistrib, (availableTags * -1).ToString());
            }
        }

        private void SetParameters()
        {
            for (int i = 0; i < (int)(AttributeNames.EParameters.Count); i++)
            {
                var parameterName = ((AttributeNames.EParameters)i).ToString();
                var parameter = m_Character.Parameters[i];

                var lbName = gbParameters.Controls[string.Format(cControlName_LbParameterName, parameterName)] as Label;
                var lbValue = gbParameters.Controls[string.Format(cControlName_LbParameterResult, parameterName)] as Label;
                lbValue.Text = parameter.Value.ToString();
            }
        }

        #endregion

        #region Изменение Control`ов

        private void cmbRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                foreach (var race in m_Races)
                {
                    if (race[AttributeNames.cName] == cmbRace.Text)
                    {
                        m_Character.Race = race;
                        break;
                    }
                }

                for (int i = 0; i < 7; i++)
                {
                    m_Character.Attribs[AttributeNames.SpecialAttrib.DistribValue(i)] = "0";
                }
                RefreshChar();
            }
        }

        private void cmbTrait_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                rtbTraitFirst.Text = "";
                rtbTraitSecond.Text = "";
                Attributes traitFirst = null;
                Attributes traitSecond = null;
                foreach (var trait in m_Traits)
                {
                    if (trait[AttributeNames.cName] == cmbTraitFirst.Text)
                    {
                        traitFirst = trait;
                    }

                    if (trait[AttributeNames.cName] == cmbTraitSecond.Text)
                    {
                        traitSecond = trait;
                    }
                }

                if (traitFirst != null)
                {
                    var descr = convertXmlDescription(traitFirst[AttributeNames.cDescription]);
                    rtbTraitFirst.Text = descr;
                }

                if (traitSecond != null)
                {
                    var descr = convertXmlDescription(traitSecond[AttributeNames.cDescription]);
                    rtbTraitSecond.Text = descr;
                }

                m_Character.TraitFirst = traitFirst;
                m_Character.TraitSecond = traitSecond;

                RefreshChar();
            }
        }

        private void nudSpecial_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                var nud = sender as NumericUpDown;
                if (nud != null)
                {
                    var i = int.Parse(nud.Tag.ToString());

                    var prevValue = int.Parse(nud.Text);
                    var currValue = nud.Value;

                    var curDistr = m_Character.Attribs.GetInt(AttributeNames.SpecialAttrib.DistribValue(i));
                    var newDistr = curDistr + (currValue - prevValue);

                    m_Character.Attribs[AttributeNames.SpecialAttrib.DistribValue(i)] = newDistr.ToString();
                    RefreshChar();
                }
            }
        }

        private void cbSkillTag_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb != null)
            {
                var tag = cb.Tag.ToString();
                var xes = m_Character.Attribs.Element.Elements(AttributeNames.cTag);
                foreach (var xe in xes)
                {
                    if (xe.Value == tag)
                    {
                        xe.Remove(); 
                    }
                }
                if (cb.Checked)
                {
                    m_Character.Attribs.Element.Add(new XElement(AttributeNames.cTag, tag));
                }
                RefreshChar();
            }
        }

        #endregion

        #region Создание Control`ов

        private void CreateControls()
        {
            #region Skills

            int y = 20;
            for (int i = 0; i < 19; i++)
            {
                var skillName = ((AttributeNames.ESkills)i).ToString();

                var cb = new CheckBox();
                cb.Name = string.Format(cControlName_CbSkillName, skillName);
                cb.Size = new Size(13, 13);
                cb.Location = new Point(8, y);
                cb.CheckedChanged += cbSkillTag_CheckedChanged;
                cb.Tag = i.ToString();
                gbSkills.Controls.Add(cb);

                var label = new Label();
                label.Name = string.Format(cControlName_LbSkillName, skillName);
                label.Size = new Size(100, 13);
                label.Text = ((AttributeNames.ESkills)i).Description();
                label.Location = new Point(25, y);
                gbSkills.Controls.Add(label);

                label = new Label();
                label.Name = string.Format(cControlName_LbSkillResult, skillName);
                label.Size = new Size(25, 13);
                label.Text = "200";
                label.Location = new Point(130, y);
                gbSkills.Controls.Add(label);

                y += 20;
                if (i == 2 || i == 5 || i == 7 || i == 11 || i == 14 || i == 16)
                {
                    y += 10;
                }
            }

            #endregion

            #region Parameters

            y = 20;
            for (int i = 0; i < (int)(AttributeNames.EParameters.Count); i++)
            {
                var parameterName = ((AttributeNames.EParameters)i).ToString();

                var label = new Label();
                label.Name = string.Format(cControlName_LbParameterName, parameterName);
                label.Size = new Size(100, 13);
                label.Text = ((AttributeNames.EParameters)i).Description();
                label.Location = new Point(8, y);
                gbParameters.Controls.Add(label);

                label = new Label();
                label.Name = string.Format(cControlName_LbParameterResult, parameterName);
                label.Size = new Size(25, 13);
                label.Text = "200";
                label.Location = new Point(130, y);
                gbParameters.Controls.Add(label);

                y += 20;
            }

            #endregion
        }

        #endregion

        #region Доп. методы

        private string convertXmlDescription(string s)
        {
            var changed = true;
            while (changed)
            {
                changed = false;
                var t = s.Replace(".  ", ". ");
                if (!t.Equals(s))
                {
                    s = t;
                    changed = true;
                }
            }
            s = s.Replace(". ", ".\n");
            return s;
        }

        #endregion
    }
}
