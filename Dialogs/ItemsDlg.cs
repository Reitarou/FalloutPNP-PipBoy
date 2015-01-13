using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FalloutPNP_PipBoy.Dialogs
{
    public partial class ItemsDlg : Form
    {
        private Items m_Items;
        private Item m_SelectedItem = null;

        public ItemsDlg(Items items)
        {
            m_Items = items;
            InitializeComponent();
        }

        private void RefreshItems()
        {
        }

        private void UpdateControls()
        {
            if (m_SelectedItem != null)
            {
                switch (m_SelectedItem.Type)
                {
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Назначить SelectedItem
            UpdateControls();
        }
    }
}
