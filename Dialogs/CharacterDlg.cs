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

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        public string race;
        public decimal param;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            racesBox.SelectedIndex = 0;
            numericStrenght.Minimum = 1;
            numericStrenght.Maximum = 10;
            
        }

        private void RaceParamLoad(string Race)
        {
            XDocument RaceParametr = XDocument.Load("Races.xml");
            var parametrs = from stats in RaceParametr.Descendants(Race)
                            select new
                            {
                                MinStrenght = stats.Element("MinStrenght").Value,
                                MinPerception = stats.Element("MinPerception").Value,
                                MinEndurance = stats.Element("MinEndurance").Value,
                                MinCharisma = stats.Element("MinCharisma").Value,
                                MinIntelligence = stats.Element("MinIntelligence").Value,
                                MinAgility = stats.Element("MinAgility").Value,
                                MinLuck = stats.Element("MinLuck").Value,
                                Strenght = stats.Element("Strenght").Value,
                                Perception = stats.Element("Perception").Value,
                                Endurance = stats.Element("Endurance").Value,
                                Charisma = stats.Element("Charisma").Value,
                                Intelligence = stats.Element("Intelligence").Value,
                                Agility = stats.Element("Agility").Value,
                                Luck = stats.Element("Luck").Value,
                                MaxStrenght = stats.Element("MaxStrenght").Value,
                                MaxPerception = stats.Element("MaxPerception").Value,
                                MaxEndurance = stats.Element("MaxEndurance").Value,
                                MaxCharisma = stats.Element("MaxCharisma").Value,
                                MaxIntelligence = stats.Element("MaxIntelligence").Value,
                                MaxAgility = stats.Element("MaxAgility").Value,
                                MaxLuck = stats.Element("MaxLuck").Value,
                                ResistancePoison = stats.Element("ResistancePoison").Value,
                                ResistanceRadiation = stats.Element("ResistanceRadiation").Value,
                                ResistanceElectric = stats.Element("ResistanceElectric").Value,
                                ResistanceGas = stats.Element("ResistanceGas").Value,

                            };
            foreach (var Par in parametrs)
            {
                decimal.TryParse(Par.MinStrenght, out param);
                numericStrenght.Minimum = param;
                decimal.TryParse(Par.MinPerception, out param);
                numericPerception.Minimum = param;
                decimal.TryParse(Par.MinEndurance, out param);
                numericEndurance.Minimum = param;
                decimal.TryParse(Par.MinCharisma, out param);
                numericCharisma.Minimum = param;
                decimal.TryParse(Par.MinIntelligence, out param);
                numericIntelligence.Minimum = param;
                decimal.TryParse(Par.MinAgility, out param);
                numericAgility.Minimum = param;
                decimal.TryParse(Par.MinLuck, out param);
                numericLuck.Minimum = param;

                decimal.TryParse(Par.MaxStrenght, out param);
                numericStrenght.Maximum = param;
                decimal.TryParse(Par.MaxPerception, out param);
                numericPerception.Maximum = param;
                decimal.TryParse(Par.MaxEndurance, out param);
                numericEndurance.Maximum = param;
                decimal.TryParse(Par.MaxCharisma, out param);
                numericCharisma.Maximum = param;
                decimal.TryParse(Par.MaxIntelligence, out param);
                numericIntelligence.Maximum = param;
                decimal.TryParse(Par.MaxAgility, out param);
                numericAgility.Maximum = param;
                decimal.TryParse(Par.MaxLuck, out param);
                numericLuck.Maximum = param;

                decimal.TryParse(Par.Strenght, out param);
                numericStrenght.Value = param;
                decimal.TryParse(Par.Perception, out param);
                numericPerception.Value = param;
                decimal.TryParse(Par.Endurance, out param);
                numericEndurance.Value = param;
                decimal.TryParse(Par.Charisma, out param);
                numericCharisma.Value = param;
                decimal.TryParse(Par.Intelligence, out param);
                numericIntelligence.Value = param;
                decimal.TryParse(Par.Agility, out param);
                numericAgility.Value = param;
                decimal.TryParse(Par.Luck, out param);
                numericLuck.Value = param;
            }
        }

        private void racesBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (racesBox.Text)
            {
                case "Человек":
                    race = "RaceHuman";
                    break;
                case "Гуль":
                    race = "RaceGhoul";
                    break;
                case "Супер Мутант Альфа":
                    race = "RaceSuperMutantAlfa";
                    break;
                case "Супер Мутант Бета":
                    race = "RaceSuperMutantBeta";
                    break;
                case "Полумутант":
                    race = "RaceSuperMutantHalf";
                    break;
                case "Коготь Смерти":
                    race = "RaceDeathclaws";
                    break;
                case "Собака":
                    race = "RaceDog";
                    break;
                case "Робот Гуманоид":
                    race = "RaceHumanoidRobot";
                    break;
            }

            RaceParamLoad(race);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

    }
}
