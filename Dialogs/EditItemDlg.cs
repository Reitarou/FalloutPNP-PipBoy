using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using FalloutPNP_PipBoy.Properties;

namespace FalloutPNP_PipBoy.Dialogs
{
    public partial class EditItemDlg : Form
    {
        private static Item m_Item;

        public EditItemDlg()
        {
            InitializeComponent();
        }

        private void UpdateControls()
        {

        }

        private void DoInit()
        {
            cbCategory.Items.Clear();
            for (int i = 0; i < (int)Categories.Category.Count; i++)
            {
                var cat = (Categories.Category)i;
                cbCategory.Items.Add(cat.GetDescription());
            }
            tbName.Text = m_Item.Name;
            cbCategory.SelectedIndex = (int)m_Item.Category;
        }

        private void DoCommit()
        {
            m_Item.Name = tbName.Text;
            m_Item.Category = (Categories.Category)cbCategory.SelectedIndex;
        }

        public static bool Execute(ref Item item)
        {
            using (var dlg = new EditItemDlg())
            {
                m_Item = new Item();
                m_Item.Assign(item);
                dlg.DoInit();
                while (true)
                {
                    switch (dlg.ShowDialog())
                    {
                        case DialogResult.Cancel:
                            return false;

                        case DialogResult.OK:
                            dlg.DoCommit();
                            item.Assign(m_Item);
                            return true;

                        case DialogResult.Retry:
                            break;

                        default:
                            Debug.Assert(false);
                            break;
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbName.Text == string.Empty)
            {
                MessageBox.Show("Введите название");
                this.DialogResult = DialogResult.Retry;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditItemDlg_Load(object sender, EventArgs e)
        {
            
        }
    }
}
