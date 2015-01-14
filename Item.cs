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
        public Dictionary<string, string> Properties = new Dictionary<string, string>();

        public Item()
        {
        }

        public Item(XmlNode node, Items items)
        {
            foreach (var pair in items.PropertiesList)
            {
                var prop = node.SelectSingleNode(pair.Key);
                if (prop != null)
                {
                    Properties.Add(pair.Key, prop.InnerText);
                }
            }
        }

        public void Assign(Item item)
        {
            Properties = item.Properties;
        }

        public string Name
        {
            get
            {
                if (Properties.ContainsKey(Resources.sName))
                {
                    return Properties[Resources.sName];
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (Properties.ContainsKey(Resources.sName))
                {
                    Properties[Resources.sName] = value;
                }
                else
                {
                    Properties.Add(Resources.sName, value);
                }
            }
        }

        public Categories.Category Category
        {
            get
            {
                if (Properties.ContainsKey(Resources.sCategory))
                {
                    return Categories.GetCategory(Properties[Resources.sCategory]);
                }
                else
                {
                    return Categories.Category.Unknown;
                }
            }
            set
            {
                if (Properties.ContainsKey(Resources.sCategory))
                {
                    Properties[Resources.sCategory] = value.ToString();
                }
                else
                {
                    Properties.Add(Resources.sCategory, value.ToString());
                }
            }
        }

        
        public void SetToElement(ref XmlElement xe, XmlDocument xd)
        {
            xe.RemoveAll();
            foreach (var pair in Properties)
            {
                AddNode(xd, xe, pair);
            }
        }

        private void AddNode(XmlDocument xd, XmlElement xe, KeyValuePair<string, string> pair)
        {
            var newElement = xd.CreateElement(pair.Key);
            var newElementText = xd.CreateTextNode(pair.Value);
            newElement.AppendChild(newElementText);
            xe.AppendChild(newElement);
        }
    }
}

