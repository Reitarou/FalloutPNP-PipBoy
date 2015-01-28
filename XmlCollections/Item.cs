using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FalloutPNP_PipBoy.Properties;

namespace FalloutPNP_PipBoy.XmlCollections
{
    public class Item : XmlEntry
    {
        public Item()
            : base()
        {
        }

        public override void FillList()
        {
            AttributesList = new AttributesList();
            foreach (var att in Attributes.ArmourAtt.All)
            {
                AttributesList.Add(att);
            }
        }

        public override string Name
        {
            get
            {
                return AttributesList[Attributes.ItemsCommonAtt.Name];
            }
        }

        //public string Name
        //{
        //    get
        //    {
        //        
        //    }
        //}
    }
}

