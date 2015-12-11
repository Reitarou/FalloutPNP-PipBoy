using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;

namespace FalloutPNP_PipBoy.Params
{
    class ResistNames
    {
        public const string Poison = "Poison";
        public const string Radiation = "Radiation";
        public const string Gas = "Gas";
        public const string Electric = "Electric";
        public const string Normal = "Normal";
        public const string Laser = "Laser";
        public const string Flame = "Flame";
        public const string Plasma = "Plasma";
        public const string Explosive = "Explosive";

        public const string Resistance = "Resistance";
        public const string Threshold = "Threshold";
    }

    class Resist
    {
        string Name;
        int Resistance = 0;
        int Threshold = 0;

        public Resist(string name)
        {
            Name = name;
        }

        public void SaveToStg(StgNode node)
        {
            node.AddInt(Name + ResistNames.Resistance, Resistance);
            node.AddInt(Name + ResistNames.Threshold, Threshold);
        }

        public void LoadFromStg(StgNode node)
        {
            Resistance = node.GetInt(Name + ResistNames.Resistance, 0);
            Threshold = node.GetInt(Name + ResistNames.Threshold, 0);
        }

        public static Resist operator +(Resist a, Resist b)
        {
            return new Resist(a.Name) { Resistance = a.Resistance + b.Resistance, Threshold = a.Threshold + b.Threshold };
        }
    }

    class Resistances
    {
        public Resist Poison = new Resist(ResistNames.Poison);
        public Resist Radiation = new Resist(ResistNames.Radiation);
        public Resist Gas = new Resist(ResistNames.Gas);
        public Resist Electric = new Resist(ResistNames.Electric);
        public Resist Normal = new Resist(ResistNames.Normal);
        public Resist Laser = new Resist(ResistNames.Laser);
        public Resist Flame = new Resist(ResistNames.Flame);
        public Resist Plasma = new Resist(ResistNames.Plasma);
        public Resist Explosive = new Resist(ResistNames.Explosive);

        public Resistances()
        {
        }

        public Resistances(StgNode node)
        {
            Poison.LoadFromStg(node);
            Radiation.LoadFromStg(node);
            Gas.LoadFromStg(node);
            Electric.LoadFromStg(node);
            Normal.LoadFromStg(node);
            Laser.LoadFromStg(node);
            Flame.LoadFromStg(node);
            Plasma.LoadFromStg(node);
            Explosive.LoadFromStg(node);
        }
    }
}
