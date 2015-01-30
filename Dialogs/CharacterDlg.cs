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
        

        private int StrCur, PerCur, EndCur, ChaCur, IntCur, AgiCur, LckCur;

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

            #region Declare

            int RaceStrMin, RaceStrIni, RaceStrMax,
                RacePerMin, RacePerIni, RacePerMax,
                RaceEndMin, RaceEndIni, RaceEndMax,
                RaceChaMin, RaceChaIni, RaceChaMax,
                RaceIntMin, RaceIntIni, RaceIntMax,
                RaceAgiMin, RaceAgiIni, RaceAgiMax,
                RaceLckMin, RaceLckIni, RaceLckMax;

            int DistrStr, DistrPer, DistrEnd, DistrCha, DistrInt, DistrAgi, DistrLck;


            int StrMin, StrMax, PerMin, PerMax, EndMin, EndMax, ChaMin, ChaMax, IntMin, IntMax, AgiMin, AgiMax, LckMin, LckMax;

            #endregion

            #region Load

            var charRaceName = m_Character.AttributesList[Attributes.CharacterAtt.Race];
            var CharRace = new Race();

            foreach (var race in m_Races)
            {
                if (race.Name == charRaceName)
                {
                    CharRace.Assign(race);
                    break;
                }
            }

            //S.P.E.C.I.A.L. от Расы
            RaceStrMin = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.StrMin);
            RaceStrIni = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.StrIni);
            RaceStrMax = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.StrMax);

            RacePerMin = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.PerMin);
            RacePerIni = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.PerIni);
            RacePerMax = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.PerMax);

            RaceEndMin = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.EndMin);
            RaceEndIni = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.EndIni);
            RaceEndMax = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.EndMax);

            RaceChaMin = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.ChaMin);
            RaceChaIni = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.ChaIni);
            RaceChaMax = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.ChaMax);

            RaceIntMin = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.IntMin);
            RaceIntIni = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.IntIni);
            RaceIntMax = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.IntMax);

            RaceAgiMin = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.AgiMin);
            RaceAgiIni = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.AgiIni);
            RaceAgiMax = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.AgiMax);

            RaceLckMin = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.LckMin);
            RaceLckIni = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.LckIni);
            RaceLckMax = CharRace.AttributesList.GetInt(Attributes.SpecialAtt.LckMax);

            //Распределение на текущем чаре
            DistrStr = m_Character.AttributesList.GetInt(string.Format(Attributes.CharacterAtt.Distribution, Attributes.SPECIAL.Str.ToString()));
            DistrPer = m_Character.AttributesList.GetInt(string.Format(Attributes.CharacterAtt.Distribution, Attributes.SPECIAL.Per.ToString()));
            DistrEnd = m_Character.AttributesList.GetInt(string.Format(Attributes.CharacterAtt.Distribution, Attributes.SPECIAL.End.ToString()));
            DistrCha = m_Character.AttributesList.GetInt(string.Format(Attributes.CharacterAtt.Distribution, Attributes.SPECIAL.Cha.ToString()));
            DistrInt = m_Character.AttributesList.GetInt(string.Format(Attributes.CharacterAtt.Distribution, Attributes.SPECIAL.Int.ToString()));
            DistrAgi = m_Character.AttributesList.GetInt(string.Format(Attributes.CharacterAtt.Distribution, Attributes.SPECIAL.Agi.ToString()));
            DistrLck = m_Character.AttributesList.GetInt(string.Format(Attributes.CharacterAtt.Distribution, Attributes.SPECIAL.Lck.ToString()));

            #endregion

            #region Calculation

            StrMin = RaceStrMin;
            StrCur = RaceStrIni + DistrStr;
            StrMax = RaceStrMax;

            PerMin = RacePerMin;
            PerCur = RacePerIni + DistrPer;
            PerMax = RacePerMax;

            EndMin = RaceEndMin;
            EndCur = RaceEndIni + DistrEnd;
            EndMax = RaceEndMax;

            ChaMin = RaceChaMin;
            ChaCur = RaceChaIni + DistrCha;
            ChaMax = RaceChaMax;

            IntMin = RaceIntMin;
            IntCur = RaceIntIni + DistrInt;
            IntMax = RaceIntMax;

            AgiMin = RaceAgiMin;
            AgiCur = RaceAgiIni + DistrAgi;
            AgiMax = RaceAgiMax;

            LckMin = RaceLckMin;
            LckCur = RaceLckIni + DistrLck;
            LckMax = RaceLckMax;

            int TotalDistrSumm = 5 - (DistrStr + DistrPer + DistrEnd + DistrCha + DistrInt + DistrAgi + DistrLck);

            #endregion

            #region PostToControls

            ChangedByUser = false;

            cmbRace.Text = CharRace.Name;

            if (TotalDistrSumm > 0)
            {
                gbSpecial.Text = string.Format(cSpecialCanDistrib, TotalDistrSumm.ToString());
            }
            else if (TotalDistrSumm == 0)
            {
                gbSpecial.Text = string.Format(cSpecial, TotalDistrSumm.ToString());
            }
            else //if (TotalDistrSumm < 0)
            {
                gbSpecial.Text = string.Format(cSpecialOverDistrib, (TotalDistrSumm*-1).ToString());
            }

            //Когда параметры будут в пачках, можно будет сделать так.
            //for (int i = 0; i < 7; i++)
            //{
            //    SetSpecialParams(((Attributes.SPECIAL)i).ToString(), minValue, curValue, maxValue);
            //}

            SetSpecialParams(Attributes.SPECIAL.Str.ToString(), StrMin, StrCur, StrMax);
            SetSpecialParams(Attributes.SPECIAL.Per.ToString(), PerMin, PerCur, PerMax);
            SetSpecialParams(Attributes.SPECIAL.End.ToString(), EndMin, EndCur, EndMax);
            SetSpecialParams(Attributes.SPECIAL.Cha.ToString(), ChaMin, ChaCur, ChaMax);
            SetSpecialParams(Attributes.SPECIAL.Int.ToString(), IntMin, IntCur, IntMax);
            SetSpecialParams(Attributes.SPECIAL.Agi.ToString(), AgiMin, AgiCur, AgiMax);
            SetSpecialParams(Attributes.SPECIAL.Lck.ToString(), LckMin, LckCur, LckMax);

            ChangedByUser = true;

            #endregion
        }

        private void SetSpecialParams(string statName, int minValue, int curValue, int maxValue)
        {
            var control = gbSpecial.Controls[string.Format(cControlName_NudSpecialName, statName)];
            if (control != null)
            {
                var nud = control as NumericUpDown;
                if (nud != null)
                {
                    nud.Minimum = minValue;
                    nud.Maximum = maxValue;
                    nud.Value = curValue;
                }
            }

            control = gbSpecial.Controls[string.Format(cControlName_LbSpecialMinName, statName)];
            if (control != null)
            {
                var lb = control as Label;
                if (lb != null)
                {
                    lb.Text = minValue.ToString();
                }
            }

            control = gbSpecial.Controls[string.Format(cControlName_LbSpecialMaxName, statName)];
            if (control != null)
            {
                var lb = control as Label;
                if (lb != null)
                {
                    lb.Text = maxValue.ToString();
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
                    m_Character.AttributesList[string.Format(Attributes.CharacterAtt.Distribution, ((Attributes.SPECIAL)i).ToString())] = "0";
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
                    
                    var curDistr = m_Character.AttributesList.GetInt(string.Format(Attributes.CharacterAtt.Distribution, statName));
                    var newDistr = curDistr + (currValue - prevValue);
                    
                    m_Character.AttributesList[string.Format(Attributes.CharacterAtt.Distribution, statName)] = newDistr.ToString();
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
