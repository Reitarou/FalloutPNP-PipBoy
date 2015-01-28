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
                RacePerMin, RacePerInit, RacePerMax;

            RaceStrMin = RaceStrInit = RaceStrMax =
            RacePerMin = RacePerInit = RacePerMax =
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
                }
            }

            lbStrMin.Text = RaceStrMin.ToString();
            nudStr.Value = RaceStrInit;
            lbStrMax.Text = RaceStrMax.ToString();
            lbPerMin.Text = RacePerMin.ToString();
            nudPer.Value = RacePerInit;
            lbPerMax.Text = RacePerMax.ToString();


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
