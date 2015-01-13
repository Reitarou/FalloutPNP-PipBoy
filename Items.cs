using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace FalloutPNP_PipBoy
{
    public class Items : IEnumerable<Item>
    {
        private string m_ItemsPath;
        private List<Item> m_Items;

        public Items(string path)
        {
            m_ItemsPath = path;
            LoadItems();
        }

        private void LoadItems()
        {
            m_Items = new List<Item>();
            var fp = m_ItemsPath;
            if (!File.Exists(fp))
            {
                XmlTextWriter xtw = new XmlTextWriter(fp, Encoding.UTF8);
                xtw.WriteStartDocument();
                xtw.WriteStartElement("items");
                xtw.WriteEndDocument();
                xtw.Close();
            }
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read);
            xd.Load(fs);
            var nItems = xd.GetElementsByTagName("item");
            for (int i = 0; i < nItems.Count; i++)
            {
                var eItem = nItems[i];
                m_Items.Add(new Item(eItem));
            }
            fs.Close();
        }

        public void Add(Item item)
        {
            var fp = m_ItemsPath;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.ReadWrite);
            xd.Load(fs);

            XmlElement eItem = xd.CreateElement("item");
            var nItems = xd.GetElementsByTagName("item");
            for (int i = 0; i < nItems.Count; i++)
            {
                var nItem = nItems[i];
                var dbItem = new Item(nItem);
                if (dbItem.Name == item.Name)
                {
                    eItem = (XmlElement)nItem;
                    break;
                }
            }
            item.SetToElement(ref eItem, xd);
            xd.DocumentElement.AppendChild(eItem);
            fs.Close();
            xd.Save(fp);
        }

        public void Edit(Item item)
        {
            Remove(item);
            Add(item);
        }

        public void Remove(Item item)
        {
            var fp = m_ItemsPath;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.ReadWrite);
            xd.Load(fs);

            var changed = false;
            var nodes = xd.GetElementsByTagName("item");
            for (int i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                var dbMob = new Item(node);
                if (dbMob.Name == item.Name)
                {
                    xd.DocumentElement.RemoveChild(node);
                    changed = true;
                }
            }
            fs.Close();
            if (changed)
            {
                xd.Save(fp);
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
