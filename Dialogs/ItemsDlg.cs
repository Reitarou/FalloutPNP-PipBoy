using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FalloutPNP_PipBoy.Properties;
using FalloutPNP_PipBoy.XmlCollections;

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
                lbItemName.Text = m_SelectedItem.Name;

                lbItemWeight.Text = string.Format(Resources.sWeight, m_SelectedItem.AttributesList[Attributes.ItemsCommonAtt.Weight]);
                lbItemPrice.Text = string.Format(Resources.sPrice, m_SelectedItem.AttributesList[Attributes.ItemsCommonAtt.Price]);

                //foreach (var obj in this.Controls)
                //{
                //    var control = obj as Control;
                //    if (control != null)
                //    {
                //        if (control.Tag.ToString() != string.Empty)
                //        {
                //            if (control.Tag.ToString() == m_SelectedItem.Category.GetDescription())
                //            {
                //                control.Visible = true;
                //            }
                //            else
                //            {
                //                control.Visible = false;
                //            }
                //        }
                //    }
                //}
            }
            else
            {
                lbItemName.Text = string.Empty;

                lbItemWeight.Text = string.Empty;
                lbItemPrice.Text = string.Empty;

                foreach (var obj in this.Controls)
                {
                    var control = obj as Control;
                    if (control != null)
                    {
                        if (control.Tag.ToString() != string.Empty)
                        {
                            control.Visible = false;
                        }
                    }
                }
            }
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = lbItems.SelectedIndex;
            if (index >= 0)
            {
                var name = lbItems.Items[index].ToString();
                var item = m_Items[name];
                if (item != null)
                {
                    m_SelectedItem = item;
                }
            }
            UpdateControls();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //var item = new Item();
            //if (EditItemDlg.Execute(ref item))
            //{
            //    m_Items.Add(item);
            //    m_Items.ReloadItems();
            //    UpdateControls();
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //var index = lbItems.SelectedIndex;
            //if (index >= 0)
            //{
            //    var name = lbItems.Items[index].ToString();
            //    var item = m_Items[name];
            //    if (item != null)
            //    {
            //        var oldName = item.Name;
            //        if (EditItemDlg.Execute(ref item))
            //        {
            //            m_Items.Edit(item, oldName);
            //            m_Items.ReloadItems();
            //            UpdateControls();
            //        }
            //    }
            //}
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //var index = lbItems.SelectedIndex;
            //if (index >= 0)
            //{
            //    var name = lbItems.Items[index].ToString();
            //    var item = m_Items[name];
            //    if (item != null)
            //    {
            //        m_Items.Remove(item);
            //        m_Items.ReloadItems();
            //        UpdateControls();
            //    }
            //}
        }
    }
}
