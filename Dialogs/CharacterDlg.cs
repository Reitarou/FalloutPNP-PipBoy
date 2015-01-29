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

namespace FalloutPNP_PipBoy
{
    
    public partial class CharacterDlg : Form
    {
        private Character m_Character;
        private Races m_Races;
        private Items m_Items;

        private int RaceStrMin, RaceStrIni, RaceStrMax,
                RacePerMin, RacePerIni, RacePerMax,
                RaceEndMin, RaceEndIni, RaceEndMax,
                RaceChaMin, RaceChaIni, RaceChaMax,
                RaceIntMin, RaceIntIni, RaceIntMax,
                RaceAgiMin, RaceAgiIni, RaceAgiMax,
                RaceLckMin, RaceLckIni, RaceLckMax;

        private int DistrStr, DistrPer, DistrEnd, DistrCha, DistrInt, DistrAgi, DistrLck;

        private decimal StrCur, PerCur, EndCur, ChaCur, IntCur, AgiCur, Lck;

        public CharacterDlg(Races races, Items items, Character character)
        {
            InitializeComponent();
            m_Races = races;
            m_Items = items;
            m_Character = character;
        }

        private void CharacterDlg_Load(object sender, EventArgs e)
        {
            cmbRace.Items.Clear();
            foreach (var race in m_Races)
            {
                cmbRace.Items.Add(race.Name);
            }
        }

        private void RefreshChar()
        {
            int StrMin, StrMax, PerMin, PerMax, EndMin, EndMax, ChaMin, ChaMax, IntMin, IntMax, AgiMin, AgiMax, LckMin, LckMax;

            RaceStrMin = RaceStrIni = RaceStrMax =
            RacePerMin = RacePerIni = RacePerMax =
            RaceEndMin = RaceEndIni = RaceEndMax =
            RaceChaMin = RaceChaIni = RaceChaMax =
            RaceIntMin = RaceIntIni = RaceIntMax =
            RaceAgiMin = RaceAgiIni = RaceAgiMax =
            RaceLckMin = RaceLckIni = RaceLckMax =
            0;

            var sRace = m_Character.AttributesList[Attributes.CharacterAtt.Race];
            foreach (var race in m_Races)
            {
                if (race.Name == sRace)
                {
                    RaceStrMin = race.AttributesList.GetInt(Attributes.SpecialAtt.StrMin);
                    RaceStrIni = race.AttributesList.GetInt(Attributes.SpecialAtt.StrIni);
                    RaceStrMax = race.AttributesList.GetInt(Attributes.SpecialAtt.StrMax);

                    RacePerMin = race.AttributesList.GetInt(Attributes.SpecialAtt.PerMin);
                    RacePerIni = race.AttributesList.GetInt(Attributes.SpecialAtt.PerIni);
                    RacePerMax = race.AttributesList.GetInt(Attributes.SpecialAtt.PerMax);

                    RaceEndMin = race.AttributesList.GetInt(Attributes.SpecialAtt.EndMin);
                    RaceEndIni = race.AttributesList.GetInt(Attributes.SpecialAtt.EndIni);
                    RaceEndMax = race.AttributesList.GetInt(Attributes.SpecialAtt.EndMax);

                    RaceChaMin = race.AttributesList.GetInt(Attributes.SpecialAtt.ChaMin);
                    RaceChaIni = race.AttributesList.GetInt(Attributes.SpecialAtt.ChaIni);
                    RaceChaMax = race.AttributesList.GetInt(Attributes.SpecialAtt.ChaMax);

                    RaceIntMin = race.AttributesList.GetInt(Attributes.SpecialAtt.IntMin);
                    RaceIntIni = race.AttributesList.GetInt(Attributes.SpecialAtt.IntIni);
                    RaceIntMax = race.AttributesList.GetInt(Attributes.SpecialAtt.IntMax);

                    RaceAgiMin = race.AttributesList.GetInt(Attributes.SpecialAtt.AgiMin);
                    RaceAgiIni = race.AttributesList.GetInt(Attributes.SpecialAtt.AgiIni);
                    RaceAgiMax = race.AttributesList.GetInt(Attributes.SpecialAtt.AgiMax);

                    RaceLckMin = race.AttributesList.GetInt(Attributes.SpecialAtt.LckMin);
                    RaceLckIni = race.AttributesList.GetInt(Attributes.SpecialAtt.LckIni);
                    RaceLckMax = race.AttributesList.GetInt(Attributes.SpecialAtt.LckMax);
                }
            }


            StrMin = RaceStrMin;
            StrCur = RaceStrIni;
            StrMax = RaceStrMax;

            lbStrMin.Text = StrMin.ToString();
            nudStr.Minimum = StrMin;
            nudStr.Value = StrCur;
            nudStr.Maximum = StrMax;
            lbStrMax.Text = StrMax.ToString();

            lbPerMin.Text = RacePerMin.ToString();
            nudPer.Value = RacePerIni;
            lbPerMax.Text = RacePerMax.ToString();

            lbEndMin.Text = RaceEndMin.ToString();
            nudEnd.Value = RaceEndIni;
            lbEndMax.Text = RaceEndMax.ToString();

            lbChaMin.Text = RaceChaMin.ToString();
            nudCha.Value = RaceChaIni;
            lbChaMax.Text = RaceChaMax.ToString();

            lbIntMin.Text = RaceIntMin.ToString();
            nudInt.Value = RaceIntIni;
            lbIntMax.Text = RaceIntMax.ToString();

            lbAgiMin.Text = RaceAgiMin.ToString();
            nudAgi.Value = RaceAgiIni;
            lbAgiMax.Text = RaceAgiMax.ToString();

            lbLckMin.Text = RaceLckMin.ToString();
            nudLck.Value = RaceLckIni;
            lbLckMax.Text = RaceLckMax.ToString();
        }

        private void cmbRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Character.AttributesList[Attributes.CharacterAtt.Race] = cmbRace.Text;
            RefreshChar();
            //switch (cbRace.Text)
            //{
            //    case "Человек":
            //        race = "RaceHuman";
            //        break;
            //    case "Гуль":
            //        race = "RaceGhoul";
            //        break;
            //    case "Супер Мутант Альфа":
            //        race = "RaceSuperMutantAlfa";
            //        break;
            //    case "Супер Мутант Бета":
            //        race = "RaceSuperMutantBeta";
            //        break;
            //    case "Полумутант":
            //        race = "RaceSuperMutantHalf";
            //        break;
            //    case "Коготь Смерти":
            //        race = "RaceDeathclaws";
            //        break;
            //    case "Собака":
            //        race = "RaceDog";
            //        break;
            //    case "Робот Гуманоид":
            //        race = "RaceHumanoidRobot";
            //        break;
            //}

            //RaceParamLoad(race);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void nudStr_ValueChanged(object sender, EventArgs e)
        {
            var t = 0;
        }

    }
}
