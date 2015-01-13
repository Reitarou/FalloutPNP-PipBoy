using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FalloutPNP_PipBoy.Properties;

namespace FalloutPNP_PipBoy
{
    public class Item
    {
        private Dictionary<string, string> m_Properties;

        public enum ItemType
        {
            Unknown,
            OneHandWeapon,
            TwoHandWeapon,
            Armor
        }

        public Item(XmlNode node)
        {
            PrepareProperties();

            foreach (var pair in m_Properties)
            {
                var t = node.SelectSingleNode("ArmorNormal");
                var dt = t.SelectSingleNode("DamageThreshold");

                var prop = node.SelectSingleNode(pair.Key);
                if (prop != null)
                {
                    m_Properties[pair.Key] = prop.InnerText;
                }
            }
        }

        private void PrepareProperties()
        {
            m_Properties = new Dictionary<string, string>();
            m_Properties.Add(Resources.cName, string.Empty);
            m_Properties.Add(Resources.cType, string.Empty);
            m_Properties.Add(Resources.cDmg, string.Empty);
        }

        public string Name
        {
            get
            {
                return m_Properties[Resources.cName];
            }
        }

        public ItemType Type
        {
            get
            {
                var sType = m_Properties[Resources.cType];
                ItemType eType = ItemType.Unknown;
                switch (sType)
                {
                }

                return eType;
            }
        }

        public void SetToElement(ref XmlElement xe, XmlDocument xd)
        {
            xe.RemoveAll();
            foreach (var pair in m_Properties)
            {
                AddNode(xd, xe, pair);
            }
        }

        public void AddNode(XmlDocument xd, XmlElement xe, KeyValuePair<string, string> pair)
        {
            var newElement = xd.CreateElement(pair.Key);
            var newElementText = xd.CreateTextNode(pair.Value);
            newElement.AppendChild(newElementText);
            xe.AppendChild(newElement);
        }
    }
}

