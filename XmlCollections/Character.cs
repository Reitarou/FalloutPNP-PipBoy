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
    class Skills
    {
        public decimal[] SmallGuns = new decimal[4];
        public decimal[] BigGuns = new decimal[4];
        public decimal[] EnergyWeapons = new decimal[4];
        public decimal[] Unarmed = new decimal[4];
        public decimal[] MeeleWeapon = new decimal[4];
        public decimal[] Throwing = new decimal[4];
        public decimal[] FirstAid = new decimal[4];
        public decimal[] Doctor = new decimal[4];
        public decimal[] Sneak = new decimal[4];
        public decimal[] Lockpick = new decimal[4];
        public decimal[] Steal = new decimal[4];
        public decimal[] Traps = new decimal[4];
        public decimal[] Science = new decimal[4];
        public decimal[] Repair = new decimal[4];
        public decimal[] Pilot = new decimal[4];
        public decimal[] Speech = new decimal[4];
        public decimal[] Barter = new decimal[4];
        public decimal[] Gambling = new decimal[4];
        public decimal[] Outdoorsman = new decimal[4];
        public Skills()
        {
        }
        public Skills(decimal[] Special)
        {
            SmallGuns[0] = Special[5] * 4 + 5;
            BigGuns[0] = Special[5] * 2;
            EnergyWeapons[0] = Special[5] * 2;
            Unarmed[0] = 30 + 2 * (Special[0] + Special[5]);
            MeeleWeapon[0] = 20 + 2 * (Special[0] + Special[5]);
            Throwing[0] = Special[5] * 4;
            FirstAid[0] = (Special[1] + Special[4]) * 2;
            Doctor[0] = 5 + (Special[1] + Special[4]);
            Sneak[0] = 5 + 3 * Special[5];
            Lockpick[0] = 10 + (Special[1] + Special[5]);
            Steal[0] = 3 * Special[5];
            Traps[0] = 10 + (Special[5] + Special[1]);
            Science[0] = 4 * Special[4];
            Repair[0] = 3 * Special[4];
            Pilot[0] = 2 + (Special[5] + Special[1]);
            Speech[0] = 5 * Special[3];
            Barter[0] = 4 * Special[3];
            Gambling[0] = 5 * Special[6];
            Outdoorsman[0] = 2 * (Special[1] + Special[4]);
        }
    }
}
