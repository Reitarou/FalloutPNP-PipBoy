using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using FalloutPNP_PipBoy.Properties;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;

namespace FalloutPNP_PipBoy.XmlCollections
{
    public class Items : XmlEntries,  IEnumerable<Item>
    {
        private List<Item> m_Items;

        public Items(string path)
            : base(path)
        {
        }

        protected override void ReloadEntries()
        {
            m_Items=new List<Item>();

            var nodes = GetNodes("item", Resources.eItemsFileNotFound);
            foreach (var node in nodes)
            {
                var item = new Item();
                item.Load(node);
                m_Items.Add(item);
            }
        }

        public Item this[string name]
        {
            get
            {
                foreach (var item in m_Items)
                {
                    if (item.Name == name)
                    {
                        return item;
                    }
                }
                return null;
            }
        }

        #region IEnumerable<Item> Members

        public IEnumerator<Item> GetEnumerator()
        {
            return m_Items.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_Items.GetEnumerator();
        }

        #endregion
    }
}
