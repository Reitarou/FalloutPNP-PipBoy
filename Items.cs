using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using FalloutPNP_PipBoy.Properties;
using System.Reflection;
using System.ComponentModel;

namespace FalloutPNP_PipBoy
{
    public static class Categories
    {
        public enum Category
        {
            [Description("Неизвестно")]
            Unknown,
            [Description("Броня")]
            Armor,
            [Description("Шлем")]
            Helm,
            [Description("Комплект броня и шлем")]
            ArmorWithHelm,
            [Description("Оружие (одноручное)")]
            Weapon1H,
            [Description("Оружие (двуручное)")]
            Weapon2H,
            [Description("Предмет")]
            Common,
            Count //Этот пункт всегда должен быть последним!!!
        }

        public static string GetDescription<T>(this T enumerationValue)
             where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();

        }

        public static Category GetCategory(string sCategory)
        {


            return Category.Unknown;
        }
    }

    public class Items : IEnumerable<Item>
    {
         

        private string m_ItemsPath;
        public Dictionary<string, string> PropertiesList;
        private List<Item> m_Items;

        public Items(string path)
        {
            m_ItemsPath = path;
            FillProperties();
            ReloadItems();
        }

        private void FillProperties()
        {
            //m_Properties.Add(Resources., Resources.);
            PropertiesList = new Dictionary<string, string>();

            //Common
            PropertiesList.Add(Resources.sName, Categories.Category.Common.GetDescription());
            PropertiesList.Add(Resources.sCategory, Categories.Category.Common.GetDescription());

            //Armor
            PropertiesList.Add(Resources.sArmorClass, Categories.Category.Armor.GetDescription());
            PropertiesList.Add(Resources.sNormalDamageResistance, Categories.Category.Armor.GetDescription());
            PropertiesList.Add(Resources.sNormalDamageThreshold, Categories.Category.Armor.GetDescription());
            //m_Properties.Add(Resources., Resources.cArmor);
            //m_Properties.Add(Resources., Resources.cArmor);
        }

        public void ReloadItems()
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
                m_Items.Add(new Item(eItem, this));
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
                var dbItem = new Item(nItem, this);
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
                var dbMob = new Item(node, this);
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
