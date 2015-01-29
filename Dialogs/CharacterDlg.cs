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
            int RaceStrMin, RaceStrIni, RaceStrMax,
                RacePerMin, RacePerIni, RacePerMax,
                RaceEndMin, RaceEndIni, RaceEndMax,
                RaceChaMin, RaceChaIni, RaceChaMax,
                RaceIntMin, RaceIntIni, RaceIntMax,
                RaceAgiMin, RaceAgiIni, RaceAgiMax,
                RaceLckMin, RaceLckIni, RaceLckMax;

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

            lbStrMin.Text = RaceStrMin.ToString();
            nudStr.Minimum = RaceStrMin;
            nudStr.Maximum = RaceStrMax;
            nudStr.Value = RaceStrIni;
            lbStrMax.Text = RaceStrMax.ToString();

            lbPerMin.Text = RacePerMin.ToString();
            nudPer.Minimum = RacePerMin;
            nudPer.Maximum = RacePerMax;
            nudPer.Value = RacePerIni;           
            lbPerMax.Text = RacePerMax.ToString();

            lbEndurMin.Text = RaceEndMin.ToString();
            nudEndur.Minimum = RaceEndMin;
            nudEndur.Maximum = RaceEndMax;
            nudEndur.Value = RaceEndIni;
            lbEndurMax.Text = RaceEndMax.ToString();

            lbCharMin.Text = RaceChaMin.ToString();
            nudChar.Minimum = RaceChaMin;
            nudChar.Maximum = RaceChaMax;
            nudChar.Value = RaceChaIni;
            lbCharMax.Text = RaceChaMax.ToString();

            lbIntelMin.Text = RaceIntMin.ToString();
            nudIntel.Minimum = RaceIntMin;
            nudIntel.Maximum = RaceIntMax;
            nudIntel.Value = RaceIntIni;
            lbIntelMax.Text = RaceIntMax.ToString();

            lbAgilMin.Text = RaceAgiMin.ToString();
            nudAgil.Minimum = RaceAgiMin;
            nudAgil.Maximum = RaceAgiMax;
            nudAgil.Value = RaceAgiIni; 
            lbAgilMax.Text = RaceAgiMax.ToString();

            lbLuckMin.Text = RaceLckMin.ToString();
            nudLuck.Minimum = RaceLckMin;
            nudLuck.Maximum = RaceLckMax;
            nudLuck.Value = RaceLckIni;           
            lbLuckMax.Text = RaceLckMax.ToString();
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
           
        }

    }
}
