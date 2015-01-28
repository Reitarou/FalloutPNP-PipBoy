
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FalloutPNP_PipBoy.XmlCollections
{
    public class Race : XmlEntry
    {
        public Race()
            :base()
        {
            
        }

        public override void FillList()
        {
            AttributesList = new AttributesList();
            foreach (var att in Attributes.SpecialAtt.All)
            {
                AttributesList.Add(att);
            }
            foreach (var att in Attributes.ArmourAtt.All)
            {
                AttributesList.Add(att);
            }

            AttributesList.Add(new Attribute(Attributes.CharacterAtt.Race));
        }

        public override string Name
        {
            get
            {
                return AttributesList[Attributes.CharacterAtt.Race];
            }
        }
    }
}
