
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FalloutPNP_PipBoy.XmlCollections
{
    class Race
    {
        public Attributes Attributes;

        public Race(XmlNode node)
        {
            Attributes = new Attributes(AttributesLists.RaceAttributes);

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

        public string Name
        {
            get
            {
                return Attributes[AttributeName.RacesAtt.Name].Value;
            }
            set
            {
                Attributes[AttributeName.RacesAtt.Name].Value = value;
            }
        }
    }
}
