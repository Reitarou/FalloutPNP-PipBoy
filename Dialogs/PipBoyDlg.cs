using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FalloutPNP_PipBoy.Dialogs;
using FalloutPNP_PipBoy.XmlCollections;

namespace FalloutPNP_PipBoy
{
    public partial class PipBoyDlg : Form
    {
        private Races m_Races;
        private Items m_Items;
        //private Characters m_Characters;

        public PipBoyDlg()
        {
            InitializeComponent();
            ReadXml();
        }

        private void ReadXml()
        {
            m_Items = new Items("items.xml");
            m_Races = new Races("races.xml");
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
            var itemsDlg = new ItemsDlg(m_Items);
            itemsDlg.Show();
        }

        private void btnCreateCharacter_Click(object sender, EventArgs e)
        {

        }
    }
}
