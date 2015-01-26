﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FalloutPNP_PipBoy.Properties;

namespace FalloutPNP_PipBoy
{
    public class Item
    {
        public ItemProperties Properties;

        public Item()
        {
            Properties = new ItemProperties();
        }

        public Item(XmlNode node)
        {
            Properties = new ItemProperties();

            foreach (var property in Properties)
            {
                var name = property.Name;
                var valueNode = node.SelectSingleNode(name);
                if (valueNode != null)
                {
                    Properties[name].Value = valueNode.InnerText;
                }
            }
        }

        public void Assign(Item item)
        {
            foreach (var property in Properties)
            {
                property.Value = item.Properties[property.Name].Value;
            }
        }

        public string Name
        {
            get
            {
                return Properties[PropertyName.pName].Value;
            }
            set
            {
                Properties[PropertyName.pName].Value = value;
            }
        }

        public Category Category
        {
            get
            {
                return ItemProperties.GetCategory(Properties[PropertyName.pCategory].Value);
            }
            set
            {
                Properties[PropertyName.pCategory].Value = value.GetDescription();
            }
        }

        
        public void SetToElement(ref XmlNode xn, XmlDocument xd)
        {
            xn.RemoveAll();
            foreach (var property in Properties)
            {
                if (property.Value != string.Empty)
                {
                    AddNode(xd, xn, property);
                }
            }
        }

        private void AddNode(XmlDocument xd, XmlNode xn, ItemProperty property)
        {
            var newElement = xd.CreateElement(property.Name);
            var newElementText = xd.CreateTextNode(property.Value);
            newElement.AppendChild(newElementText);
            xn.AppendChild(newElement);
        }
    }
}

