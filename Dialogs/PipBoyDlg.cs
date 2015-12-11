using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FalloutPNP_PipBoy.Dialogs.Dialogs;
using System.IO;
using FalloutPNP_PipBoy.Properties;
using System.Xml.Linq;
using FalloutPNP_PipBoy.Params;
using Stg;

namespace FalloutPNP_PipBoy.Dialogs
{
    public partial class PipBoyDlg : Form
    {
        private const string c_RacesPath = "Xmls\\races.xml";
        private const string c_TraitsPath = "Xmls\\traits.xml";
        private const string c_ItemsPath = "Xmls\\items.xml";
        private List<Race> m_Races;

        public PipBoyDlg()
        {
            InitializeComponent();
            m_Races = new List<Race>();
            var doc = new StgDocument(c_RacesPath);
            var nodes = doc.Body.GetNodes("race");
            foreach (var node in nodes)
            {
                var race = new Race(node);
                m_Races.Add(race);
            }
        }

        private void btnTerminalEasy_Click(object sender, EventArgs e)
        {
            var hackDlg = new HackingDlg(1);
            hackDlg.Show();
        }

        private void btnTerminalNormal_Click(object sender, EventArgs e)
        {
            var hackDlg = new HackingDlg(2);
            hackDlg.Show();
        }

        private void btnTerminalHard_Click(object sender, EventArgs e)
        {
            var hackDlg = new HackingDlg(3);
            hackDlg.Show();
        }

        private void btnItemsList_Click(object sender, EventArgs e)
        {
            //var itemsDlg = new ItemsDlg(m_Items);
            //itemsDlg.Show();
        }

        private void btnCreateCharacter_Click(object sender, EventArgs e)
        {
            var character = new Char();
            var characterDlg = new CharacterCreationDlg(character, m_Races);
            characterDlg.Show();
        }
    }
}
