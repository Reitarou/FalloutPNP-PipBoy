using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FalloutPNP_PipBoy.Dialogs;

namespace FalloutPNP_PipBoy
{
    public partial class PipBoyDlg : Form
    {
        private Items m_Items;

        public PipBoyDlg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var hackDlg = new HackingDlg(1);
            hackDlg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var hackDlg = new HackingDlg(2);
            hackDlg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var hackDlg = new HackingDlg(3);
            hackDlg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var itemsDlg = new ItemsDlg();
            itemsDlg.Show();
        }
    }
}
