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
        public enum SPECIAL
        {
            Str,
            Per,
            End,
            Cha,
            Int,
            Agi,
            Lck
        }

        private Character m_Character;
        private Races m_Races;
        private Items m_Items;

        private bool ChangedByUser = true;

        private const string cSpecial = " S.P.E.C.I.A.L. ";
        private const string cSpecialCanDistrib =  " Доступно {0} оч.";
        private const string cSpecialOverDistrib = " ПРЕВЫШЕНО {0} оч.";

        private const string cLbSkillName = "lb{0}";
        

        private decimal StrCur, PerCur, EndCur, ChaCur, IntCur, AgiCur, LckCur;

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
            DistrStr = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionStr);
            DistrPer = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionPer);
            DistrEnd = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionEnd);
            DistrCha = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionCha);
            DistrInt = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionInt);
            DistrAgi = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionAgi);
            DistrLck = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionLck);



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

            lbStrMin.Text = StrMin.ToString();
            nudStr.Minimum = StrMin;
            nudStr.Maximum = StrMax;
            nudStr.Value = StrCur;
            lbStrMax.Text = StrMax.ToString();

            lbPerMin.Text = PerMin.ToString();
            nudPer.Minimum = PerMin;
            nudPer.Maximum = PerMax;
            nudPer.Value = PerCur;
            lbPerMax.Text = PerMax.ToString();

            lbEndMin.Text = EndMin.ToString();
            nudEnd.Minimum = EndMin;
            nudEnd.Maximum = EndMax;
            nudEnd.Value = EndCur;
            lbEndMax.Text = EndMax.ToString();

            lbChaMin.Text = ChaMin.ToString();
            nudCha.Minimum = ChaMin;
            nudCha.Maximum = ChaMax;
            nudCha.Value = ChaCur;
            lbChaMax.Text = ChaMax.ToString();

            lbIntMin.Text = IntMin.ToString();
            nudInt.Minimum = IntMin;
            nudInt.Maximum = IntMax;
            nudInt.Value = IntCur;
            lbIntMax.Text = IntMax.ToString();

            lbAgiMin.Text = AgiMin.ToString();
            nudAgi.Minimum = AgiMin;
            nudAgi.Maximum = AgiMax;
            nudAgi.Value = AgiCur;
            lbAgiMax.Text = AgiMax.ToString();

            lbLckMin.Text = LckMin.ToString();
            nudLck.Minimum = LckMin;
            nudLck.Maximum = LckMax;
            nudLck.Value = LckCur;
            lbLckMax.Text = LckMax.ToString();

            ChangedByUser = true;

            #endregion
        }

        private void cmbRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                m_Character.AttributesList[Attributes.CharacterAtt.Race] = cmbRace.Text;

                m_Character.AttributesList[Attributes.CharacterAtt.DistributionStr] = "0";
                m_Character.AttributesList[Attributes.CharacterAtt.DistributionPer] = "0";
                m_Character.AttributesList[Attributes.CharacterAtt.DistributionEnd] = "0";
                m_Character.AttributesList[Attributes.CharacterAtt.DistributionCha] = "0";
                m_Character.AttributesList[Attributes.CharacterAtt.DistributionInt] = "0";
                m_Character.AttributesList[Attributes.CharacterAtt.DistributionAgi] = "0";
                m_Character.AttributesList[Attributes.CharacterAtt.DistributionLck] = "0";

                RefreshChar();
            }
        }

        #region SPECIAL Numerics

        private void nudSPECIAL_ValueChanged(SPECIAL stat, NumericUpDown control)
        {
            var prevValue = int.Parse(control.Text);
            var currValue = control.Value;
            int curDistr = 0;

            switch (stat)
            {
                case SPECIAL.Str:
                    curDistr = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionStr);
                    break;
                case SPECIAL.Per:
                    curDistr = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionPer);
                    break;
                case SPECIAL.End:
                    curDistr = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionEnd);
                    break;
                case SPECIAL.Cha:
                    curDistr = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionCha);
                    break;
                case SPECIAL.Int:
                    curDistr = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionInt);
                    break;
                case SPECIAL.Agi:
                    curDistr = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionAgi);
                    break;
                case SPECIAL.Lck:
                    curDistr = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.DistributionLck);
                    break;
            }

            var newDistr = curDistr + (currValue - prevValue);

            switch (stat)
            {
                case SPECIAL.Str:
                    m_Character.AttributesList[Attributes.CharacterAtt.DistributionStr] = newDistr.ToString();
                    break;
                case SPECIAL.Per:
                    m_Character.AttributesList[Attributes.CharacterAtt.DistributionPer] = newDistr.ToString();
                    break;
                case SPECIAL.End:
                    m_Character.AttributesList[Attributes.CharacterAtt.DistributionEnd] = newDistr.ToString();
                    break;
                case SPECIAL.Cha:
                    m_Character.AttributesList[Attributes.CharacterAtt.DistributionCha] = newDistr.ToString();
                    break;
                case SPECIAL.Int:
                    m_Character.AttributesList[Attributes.CharacterAtt.DistributionInt] = newDistr.ToString();
                    break;
                case SPECIAL.Agi:
                    m_Character.AttributesList[Attributes.CharacterAtt.DistributionAgi] = newDistr.ToString();
                    break;
                case SPECIAL.Lck:
                    m_Character.AttributesList[Attributes.CharacterAtt.DistributionLck] = newDistr.ToString();
                    break;

            }

            RefreshChar();
        }

        private void nudStr_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                nudSPECIAL_ValueChanged(SPECIAL.Str, nudStr);
            }
        }


        private void nudPer_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                nudSPECIAL_ValueChanged(SPECIAL.Per, nudPer);
            }
        }

        private void nudEnd_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                nudSPECIAL_ValueChanged(SPECIAL.End, nudEnd);
            }
        }

        private void nudCha_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                nudSPECIAL_ValueChanged(SPECIAL.Cha, nudCha);
            }
        }

        private void nudInt_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                nudSPECIAL_ValueChanged(SPECIAL.Int, nudInt);
            }
        }

        private void nudAgi_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                nudSPECIAL_ValueChanged(SPECIAL.Agi, nudAgi);
            }
        }

        private void nudLck_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedByUser)
            {
                nudSPECIAL_ValueChanged(SPECIAL.Lck, nudLck);
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
                label.Name = string.Format("lb{0}", ((Attributes.SkillNames)i).ToString());
                label.Size = new Size(100, 13);
                label.Text = ((Attributes.SkillNames)i).Description();
                label.Location = new Point(10, y);
                gbSkills.Controls.Add(label);

                label = new Label();
                label.Name = string.Format("lb{0}CurValue", ((Attributes.SkillNames)i).ToString());
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
