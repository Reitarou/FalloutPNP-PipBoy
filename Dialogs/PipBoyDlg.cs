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
using FalloutPNP_PipBoy.Dialogs.Properties;
using System.Xml.Linq;

namespace FalloutPNP_PipBoy.Dialogs
{
    public partial class PipBoyDlg : Form
    {
        private List<Attributes> m_Items;
        private List<Attributes> m_Races;
        private List<Attributes> m_Traits;
        //private Characters m_Characters;

        public PipBoyDlg()
        {
            InitializeComponent();
            m_Items = LoadFromXml("Xmls\\items.xml", "item");
            m_Races = LoadFromXml("Xmls\\races.xml", "race");
            m_Traits = LoadFromXml("Xmls\\traits.xml", "trait");
        }

        private List<Attributes> LoadFromXml(string path, string key)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show(string.Format(Resources.eNoFile, path));
                return null;
            }
            var list = new List<Attributes>();
            var doc = XDocument.Load(path);
            foreach (var xe in doc.Root.Elements())
            {
                if (xe.Name == key)
                {
                    list.Add(new Attributes(xe));
                }
            }

            return list;
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
            var element = new XElement("char");
            var character = new Character(element, m_Items, m_Races, m_Traits);
            var characterDlg = new CharacterDlg(character, m_Items, m_Races, m_Traits);
            characterDlg.Show();
        }
    }
}
