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

        public ItemsDlg()
        {
            m_Items = new Items("items.xml");
            InitializeComponent();
        }

        private void ItemsDlg_Load(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void RefreshItems()
        {
            m_Items = new Items("items.xml");
        }

        private void UpdateControls()
        {
            lbItems.Items.Clear();
            foreach (var item in m_Items)
            {
                lbItems.Items.Add(item.Name);
            }


            if (m_SelectedItem != null)
            {
                //switch (m_SelectedItem.Type)
                //{
                //}
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Назначить SelectedItem
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var item = new Item();
            if (EditItemDlg.Execute(ref item))
            {
                m_Items.Add(item);
                m_Items.ReloadItems();
                UpdateControls();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var index = lbItems.SelectedIndex;
            if (index >= 0)
            {
                var name = lbItems.Items[index].ToString();
                var item = m_Items[name];
                if (item != null)
                {
                    var oldName = item.Name;
                    if (EditItemDlg.Execute(ref item))
                    {
                        m_Items.Edit(item, oldName);
                        m_Items.ReloadItems();
                        UpdateControls();
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var index = lbItems.SelectedIndex;
            if (index >= 0)
            {
                var name = lbItems.Items[index].ToString();
                var item = m_Items[name];
                if (item != null)
                {
                    m_Items.Remove(item);
                    m_Items.ReloadItems();
                    UpdateControls();
                }
            }
        }
    }
}
