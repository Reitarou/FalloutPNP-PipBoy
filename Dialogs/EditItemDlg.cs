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

namespace FalloutPNP_PipBoy.Dialogs.Dialogs
{
    public partial class EditItemDlg : Form
    {
        //private static Item m_Item;
        //private bool m_NonUserChange = false;

        public EditItemDlg()
        {
            InitializeComponent();
        }

        private void UpdateControls()
        {
            //m_NonUserChange = true;
            //dgvAttributes.Rows.Clear();
            //foreach (var property in m_Item.Attributes)
            //{
            //    if (property.Category == ItemCategory.Common)
            //    {
            //        if (property.Name != Attributes.pName && property.Name != Attributes.pCategory)
            //        {
            //            var index = dgvAttributes.Rows.Add();
            //            var row = dgvAttributes.Rows[index];
            //            row.Cells[dgvcProperty.Name].Value = property.Name;
            //            row.Cells[dgvcValue.Name].Value = m_Item.Attributes[property.Name].Value;
            //        }
            //    }
            //}

            //foreach (var property in m_Item.Attributes)
            //{
            //    if (property.Category == m_Item.Category || (m_Item.Category == ItemCategory.FullArmor && (property.Category == ItemCategory.Armor || property.Category == ItemCategory.Helm)))
            //    {
            //        var index = dgvAttributes.Rows.Add();
            //        var row = dgvAttributes.Rows[index];
            //        row.Cells[dgvcProperty.Name].Value = property.Name;
            //        row.Cells[dgvcValue.Name].Value = m_Item.Attributes[property.Name].Value;
            //    }
            //}
            //m_NonUserChange = false;
        }

        private void DoInit()
        {
            //cbCategory.Items.Clear();
            //cbCategory.Items.Add(ItemCategory.Armor.GetDescription());
            //cbCategory.Items.Add(ItemCategory.Helm.GetDescription());
            //cbCategory.Items.Add(ItemCategory.FullArmor.GetDescription());
            //cbCategory.Items.Add(ItemCategory.Weapon.GetDescription());
            //cbCategory.Items.Add(ItemCategory.Ammo.GetDescription());
            //cbCategory.Items.Add(ItemCategory.Demolition.GetDescription());
            //cbCategory.Items.Add(ItemCategory.Mod.GetDescription());
            //cbCategory.Items.Add(ItemCategory.Medicine.GetDescription());
            //cbCategory.Items.Add(ItemCategory.Sundry.GetDescription());

            //tbName.Text = m_Item.Name;
            //cbCategory.SelectedIndex = (int)m_Item.Category;
        }

        private void DoCommit()
        {
            //m_Item.Name = tbName.Text;
            //Attributes.GetCategory(cbCategory.Text);
        }

        public static bool Execute()//ref Item item)
        {
            //using (var dlg = new EditItemDlg())
            //{
            //    m_Item = new Item();
            //    m_Item.Assign(item);
            //    dlg.DoInit();
            //    while (true)
            //    {
            //        switch (dlg.ShowDialog())
            //        {
            //            case DialogResult.Cancel:
            //                return false;

            //            case DialogResult.OK:
            //                dlg.DoCommit();
            //                item.Assign(m_Item);
            //                return true;

            //            case DialogResult.Retry:
            //                break;

            //            default:
            //                Debug.Assert(false);
            //                break;
            //        }


            //    }
            //}
            return false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (tbName.Text == string.Empty)
            //{
            //    MessageBox.Show("Введите название");
            //    return;
            //}
            //DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var cat = Attributes.GetCategory(cbCategory.Text);
            //m_Item.Category = cat;
            //UpdateControls();
        }

        private void dgvProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (!m_NonUserChange)
            //{
            //    var index = e.RowIndex;
            //    if (index >= 0)
            //    {
            //        var row = dgvAttributes.Rows[index];
            //        var name = row.Cells[dgvcProperty.Name].Value.ToString();
            //        var value = row.Cells[dgvcValue.Name].Value.ToString();
            //        m_Item.Attributes[name].Value = value;
            //    }
            //}
        }
    }
}
