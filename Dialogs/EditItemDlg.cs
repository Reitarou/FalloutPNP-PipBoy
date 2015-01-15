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
            cbPropertyName.Items.Clear();
            foreach (var property in m_Item.Properties)
            {
                if (property.Category == Category.Common)
                {
                    if (property.Name != Resources.sName && property.Name != Resources.sCategory)
                    {
                        if (m_Item.Properties[property.Name].Value == string.Empty)
                        {
                            cbPropertyName.Items.Add(property.Name);
                        }
                    }
                }
            }

            foreach (var property in m_Item.Properties)
            {
                if (property.Category == m_Item.Category)
                {
                    if (m_Item.Properties[property.Name].Value == string.Empty)
                    {
                        cbPropertyName.Items.Add(property.Name);
                    }
                }
            }
            if (cbPropertyName.Items.Count > 0)
            {
                cbPropertyName.SelectedIndex = 0;
            }

            lbProperties.Items.Clear();
            foreach (var property in m_Item.Properties)
            {
                if (property.Name != Resources.sName && property.Name != Resources.sCategory && property.Value != string.Empty)
                {
                    lbProperties.Items.Add(string.Format(Resources.sPropertyView, property.Name, Resources.sDivider, property.Value));
                }
            }
            
        }

        private void DoInit()
        {
            cbCategory.Items.Clear();
            for (int i = 0; i < (int)Category.Count-1; i++) //i<Count-1 добавляет все кроме последних ДВУХ (Собственно каунт и коммон, которая для свойств)
            {
                var cat = (Category)i;
                cbCategory.Items.Add(cat.GetDescription());
            }
            tbName.Text = m_Item.Name;
            cbCategory.SelectedIndex = (int)m_Item.Category;
        }

        private void DoCommit()
        {
            m_Item.Name = tbName.Text;
            m_Item.Category = (Category)(cbCategory.SelectedIndex);
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
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cat = (Category)cbCategory.SelectedIndex;
            m_Item.Category = cat;
            UpdateControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbPropertyName.Text == string.Empty)
            {
                MessageBox.Show(Resources.eIncorrectPropertyName);
                return;
            }

            if (tbPropertyValue.Text == string.Empty)
            {
                MessageBox.Show(Resources.eIncorrectPropertyValue);
                return;
            }

            m_Item.Properties[cbPropertyName.Text].Value = tbPropertyValue.Text;
            UpdateControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = lbProperties.SelectedIndex;
            if (index >= 0)
            {
                var s = lbProperties.Items[index].ToString();
                var separators = new string[1];
                separators[0] = Resources.sDivider;
                var ss = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                m_Item.Properties[ss[0]].Value = string.Empty;
                UpdateControls();
            }
        }
    }
}
