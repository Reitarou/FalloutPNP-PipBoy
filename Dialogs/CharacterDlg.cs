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
            int RaceStrMin, RaceStrInit, RaceStrMax,
                RacePerMin, RacePerInit, RacePerMax,
                RaceEndurMin, RaceEndurInit, RaceEndurMax,
                RaceCharMin, RaceCharInit, RaceCharMax,
                RaceIntelMin, RaceIntelInit, RaceIntelMax,
                RaceAgilMin, RaceAgilInit, RaceAgilMax,
                RaceLuckMin, RaceLuckInit, RaceLuckMax;

            RaceStrMin = RaceStrInit = RaceStrMax =
            RacePerMin = RacePerInit = RacePerMax =
            RaceEndurMin = RaceEndurInit = RaceEndurMax =
            RaceCharMin = RaceCharInit = RaceCharMax =
            RaceIntelMin = RaceIntelInit = RaceIntelMax =
            RaceAgilMin = RaceAgilInit = RaceAgilMax =
            RaceLuckMin = RaceLuckInit = RaceLuckMax =
            0;

            var sRace = m_Character.AttributesList[Attributes.CharacterAtt.Race];
            foreach (var race in m_Races)
            {
                if (race.Name == sRace)
                {
                    RaceStrMin = race.AttributesList.GetInt(Attributes.SpecialAtt.StrMin);
                    RaceStrInit = race.AttributesList.GetInt(Attributes.SpecialAtt.StrInit);
                    RaceStrMax = race.AttributesList.GetInt(Attributes.SpecialAtt.StrMax);

                    RacePerMin = race.AttributesList.GetInt(Attributes.SpecialAtt.PerMin);
                    RacePerInit = race.AttributesList.GetInt(Attributes.SpecialAtt.PerInit);
                    RacePerMax = race.AttributesList.GetInt(Attributes.SpecialAtt.PerMax);

                    RaceEndurMin = race.AttributesList.GetInt(Attributes.SpecialAtt.EndurMin);
                    RaceEndurInit = race.AttributesList.GetInt(Attributes.SpecialAtt.EndurStart);
                    RaceEndurMax = race.AttributesList.GetInt(Attributes.SpecialAtt.EndurMax);

                    RaceCharMin = race.AttributesList.GetInt(Attributes.SpecialAtt.CharMin);
                    RaceCharInit = race.AttributesList.GetInt(Attributes.SpecialAtt.CharStart);
                    RaceCharMax = race.AttributesList.GetInt(Attributes.SpecialAtt.CharMax);

                    RaceIntelMin = race.AttributesList.GetInt(Attributes.SpecialAtt.IntMin);
                    RaceIntelInit = race.AttributesList.GetInt(Attributes.SpecialAtt.IntStart);
                    RaceIntelMax = race.AttributesList.GetInt(Attributes.SpecialAtt.IntMax);

                    RaceAgilMin = race.AttributesList.GetInt(Attributes.SpecialAtt.AgiMin);
                    RaceAgilInit = race.AttributesList.GetInt(Attributes.SpecialAtt.AgiStart);
                    RaceAgilMax = race.AttributesList.GetInt(Attributes.SpecialAtt.AgiMax);

                    RaceLuckMin = race.AttributesList.GetInt(Attributes.SpecialAtt.LuckMin);
                    RaceLuckInit = race.AttributesList.GetInt(Attributes.SpecialAtt.LuckStart);
                    RaceLuckMax = race.AttributesList.GetInt(Attributes.SpecialAtt.LuckMax);
                }
            }

            lbStrMin.Text = RaceStrMin.ToString();
            nudStr.Minimum = RaceStrMin;
            nudStr.Value = RaceStrInit;
            nudStr.Maximum = RaceStrMax;
            lbStrMax.Text = RaceStrMax.ToString();

            lbPerMin.Text = RacePerMin.ToString();
            nudPer.Minimum = RacePerMin;
            nudPer.Value = RacePerInit;
            nudPer.Maximum = RacePerMax;
            lbPerMax.Text = RacePerMax.ToString();

            lbEndurMin.Text = RaceEndurMin.ToString();
            nudEndur.Minimum = RaceEndurMin;
            nudEndur.Value = RaceEndurInit;
            nudEndur.Maximum = RaceEndurMax;
            lbEndurMax.Text = RaceEndurMax.ToString();

            lbCharMin.Text = RaceCharMin.ToString();
            nudChar.Minimum = RaceCharMin;
            nudChar.Value = RaceCharInit;
            nudChar.Maximum = RaceCharMax;
            lbCharMax.Text = RaceCharMax.ToString();

            lbIntelMin.Text = RaceIntelMin.ToString();
            nudIntel.Minimum = RaceIntelMin;
            nudIntel.Value = RaceIntelInit;
            nudIntel.Maximum = RaceIntelMax;
            lbIntelMax.Text = RaceIntelMax.ToString();

            lbAgilMin.Text = RaceAgilMin.ToString();
            nudAgil.Minimum = RaceAgilMin;
            nudAgil.Value = RaceAgilInit;
            nudAgil.Maximum = RaceAgilMax;
            lbAgilMax.Text = RaceAgilMax.ToString();

            lbLuckMin.Text = RaceLuckMin.ToString();
            nudLuck.Minimum = RaceIntelMin;
            nudLuck.Value = RaceLuckInit;
            nudLuck.Maximum = RaceLuckMax;
            lbLuckMax.Text = RaceLuckMax.ToString();


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

    }
}
