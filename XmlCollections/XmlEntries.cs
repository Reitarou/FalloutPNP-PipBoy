using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FalloutPNP_PipBoy.Properties;
using System.Xml;

namespace FalloutPNP_PipBoy.XmlCollections
{
    public abstract class XmlEntries
    {
        protected string fp;

        public XmlEntries(string path)
        {
            fp = path;
            ReloadEntries();
        }

        protected abstract void ReloadEntries();

        protected List<XmlNode> GetNodes(string key, string noFileErrorMsg)
        {
            var result = new List<XmlNode>();
            if (!File.Exists(fp))
            {
                //XmlTextWriter xtw = new XmlTextWriter(fp, Encoding.UTF8);
                //xtw.WriteStartDocument();
                //xtw.WriteStartElement("items");
                //xtw.WriteEndDocument();
                //xtw.Close();
                MessageBox.Show(noFileErrorMsg);
                return result;
            }
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read);
            xd.Load(fs);
            var nodes = xd.GetElementsByTagName(key);
            for (int i = 0; i < nodes.Count; i++)
            {
                result.Add(nodes[i]);
            }
            fs.Close();
            return result;
        }

        //public void Add(Item item)
        //{
        //    var fp = m_ItemsPath;
        //    XmlDocument xd = new XmlDocument();
        //    FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.ReadWrite);
        //    xd.Load(fs);

        //    XmlNode eItem = xd.CreateElement("item");
        //    var nItems = xd.GetElementsByTagName("item");
        //    for (int i = 0; i < nItems.Count; i++)
        //    {
        //        var nItem = nItems[i];
        //        var dbItem = new Item(nItem);
        //        if (dbItem.Name == item.Name)
        //        {
        //            eItem = (XmlElement)nItem;
        //            break;
        //        }
        //    }
        //    item.SetToElement(ref eItem, xd);
        //    xd.DocumentElement.AppendChild(eItem);
        //    fs.Close();
        //    xd.Save(fp);
        //}

        //public void Edit(Item item, string oldName)
        //{
        //    var fp = m_ItemsPath;
        //    XmlDocument xd = new XmlDocument();
        //    FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.ReadWrite);
        //    xd.Load(fs);

        //    var changed = false;
        //    var nodes = xd.GetElementsByTagName("item");
        //    for (int i = 0; i < nodes.Count; i++)
        //    {
        //        var node = nodes[i];
        //        var dbMob = new Item(node);
        //        if (dbMob.Name == oldName)
        //        {
        //            item.SetToElement(ref node, xd);
        //            changed = true;
        //        }
        //    }
        //    fs.Close();
        //    if (changed)
        //    {
        //        xd.Save(fp);
        //    }
        //}

        //public void Remove(Item item)
        //{
        //    var fp = m_ItemsPath;
        //    XmlDocument xd = new XmlDocument();
        //    FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.ReadWrite);
        //    xd.Load(fs);

        //    var changed = false;
        //    var nodes = xd.GetElementsByTagName("item");
        //    for (int i = 0; i < nodes.Count; i++)
        //    {
        //        var node = nodes[i];
        //        var dbMob = new Item(node);
        //        if (dbMob.Name == item.Name)
        //        {
        //            xd.DocumentElement.RemoveChild(node);
        //            changed = true;
        //        }
        //    }
        //    fs.Close();
        //    if (changed)
        //    {
        //        xd.Save(fp);
        //    }
        //}

    }
}
