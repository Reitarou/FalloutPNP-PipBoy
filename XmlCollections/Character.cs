using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FalloutPNP_PipBoy.XmlCollections
{
    public class Character : XmlEntry
    {
        public override void FillList()
        {
            AttributesList = new AttributesList();
            foreach (var att in Attributes.CharacterAtt.All)
            {
                AttributesList.Add(att);
            }
        }

        public override string Name
        {
            get { throw new NotImplementedException(); }
        }
    }
}
