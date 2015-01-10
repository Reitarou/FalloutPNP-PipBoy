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

        private void PrepareProperties()
        {
            m_Properties = new Dictionary<string, string>();
            m_Properties.Add(Resources.cName, string.Empty);
        }

        public Item(XmlNode node)
        {
            foreach (var pair in m_Properties)
            {
                var prop = node.SelectSingleNode(pair.Key);
                if (prop != null)
                {
                    m_Properties[pair.Key] = prop.InnerText;
                }
            }
        }

        public string Name
        {
            get
            {
                return m_Properties[Resources.cName];
            }
            set
            {
                m_Properties[Resources.cName] = value;
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

