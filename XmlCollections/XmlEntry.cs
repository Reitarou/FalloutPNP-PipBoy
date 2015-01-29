using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FalloutPNP_PipBoy.XmlCollections
{
    /// <summary>
    /// Абстрактный класс, который загружает параметры из XML
    /// </summary>
    public abstract class XmlEntry
    {
        public AttributesList AttributesList;

        public XmlEntry()
        {
            FillList();
        }

        /// <summary>
        /// Заполнение списка атрибутов
        /// </summary>
        public abstract void FillList();

        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Очищает атрибуты и копирует их из otherEntry
        /// </summary>
        /// <param name="other"></param>
        public void Assign(XmlEntry otherEntry)
        {
            AttributesList.Clear();
            foreach (var attribute in otherEntry.AttributesList)
            {
                AttributesList[attribute.Name] = attribute.Value;
            }
        }

        public void Load(XmlNode node)
        {
            var list = new List<string>();
            foreach (var attribute in AttributesList)
            {
                list.Add(attribute.Name);
            }

            foreach (var name in list)
            {
                var valueNode = node.SelectSingleNode(name);
                if (valueNode != null)
                {
                    AttributesList[name] = valueNode.InnerText;
                }
            }
        }

        public void Save(ref XmlNode xn, XmlDocument xd)
        {
            xn.RemoveAll();
            foreach (var attribute in AttributesList)
            {
                if (attribute.Value != string.Empty)
                {
                    var newElement = xd.CreateElement(attribute.Name);
                    var newElementText = xd.CreateTextNode(attribute.Value);
                    newElement.AppendChild(newElementText);
                    xn.AppendChild(newElement);
                }
            }
        }
    }
}
