using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FalloutPNP_PipBoy.Properties;

namespace FalloutPNP_PipBoy.XmlCollections
{
    public class Item
    {
        public Attributes Attributes;

        public Item()
        {
            Attributes = new Attributes(AttributesLists.ItemAttributes);
        }

        public Item(XmlNode node)
        {
            Attributes = new Attributes(AttributesLists.ItemAttributes);

            foreach (var attribute in Attributes)
            {
                var name = attribute.Name;
                var valueNode = node.SelectSingleNode(name);
                if (valueNode != null)
                {
                    Attributes[name].Value = valueNode.InnerText;
                }
            }
        }

        public void Assign(Item item)
        {
            foreach (var attribute in Attributes)
            {
                attribute.Value = item.Attributes[attribute.Name].Value;
            }
        }

        public string Name
        {
            get
            {
                return Attributes[AttributeName.pName].Value;
            }
            set
            {
                Attributes[AttributeName.pName].Value = value;
            }
        }

        public ItemCategory Category
        {
            get
            {
                return Attributes.GetCategory(Attributes[AttributeName.pCategory].Value);
            }
            set
            {
                Attributes[AttributeName.pCategory].Value = value.GetDescription();
            }
        }

        
        public void SetToElement(ref XmlNode xn, XmlDocument xd)
        {
            xn.RemoveAll();
            foreach (var attribute in Attributes)
            {
                if (attribute.Value != string.Empty)
                {
                    AddNode(xd, xn, attribute);
                }
            }
        }

        private void AddNode(XmlDocument xd, XmlNode xn, Attribute attribute)
        {
            var newElement = xd.CreateElement(attribute.Name);
            var newElementText = xd.CreateTextNode(attribute.Value);
            newElement.AppendChild(newElementText);
            xn.AppendChild(newElement);
        }
    }
}

