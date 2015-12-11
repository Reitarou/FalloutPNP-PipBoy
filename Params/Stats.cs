using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;

namespace FalloutPNP_PipBoy.Params
{
    public class StatsNames
    {
        public const string Strength = "Strength";
        public const string Perception = "Perception";
        public const string Endurance = "Endurance";
        public const string Charisma = "Charisma";
        public const string Intelligence = "Intelligence";
        public const string Agility = "Agility";
        public const string Luck = "Luck";
    }

    public class Stat
    {
        public string Name;
        public int Value;

        public Stat(string name)
        {
            Name = name;
        }

        public void SaveToStg(StgNode node)
        {
            node.AddInt(Name, Value);
        }

        public void LoadFromStg(StgNode node)
        {
            Value = node.GetInt(Name, 0);
        }
    }

    public class Stats
    {
        private Stat[] m_Stats;
        public Stats()
        {
            PrepareStats();
        }

        public Stats(StgNode node)
        {
            PrepareStats();
            if (node != null)
            {
                for (int i = 0; i < m_Stats.Length; i++)
                {
                    m_Stats[i].LoadFromStg(node);
                }
            }
        }

        private void PrepareStats()
        {
            m_Stats = new Stat[7];
            for (int i = 0; i<7; i++)
            {
                var name = "";
                switch(i)
                {
                    case 0:
                        name = StatsNames.Strength;
                        break;
                    case 1:
                        name = StatsNames.Perception;
                        break;
                    case 2:
                        name = StatsNames.Endurance;
                        break;
                    case 3:
                        name = StatsNames.Charisma;
                        break;
                    case 4:
                        name = StatsNames.Intelligence;
                        break;
                    case 5:
                        name = StatsNames.Agility;
                        break;
                    case 6:
                        name = StatsNames.Luck;
                        break;
                }
                m_Stats[i] = new Stat(name);
            }
        }

        public int Strength
        {
            get
            {
                return m_Stats[0].Value;
            }
            set
            {
                m_Stats[0].Value = value;
            }
        }
        public int Perception
        {
            get
            {
                return m_Stats[1].Value;
            }
            set
            {
                m_Stats[1].Value = value;
            }
        }
        public int Endurance
        {
            get
            {
                return m_Stats[2].Value;
            }
            set
            {
                m_Stats[2].Value = value;
            }
        }
        public int Charisma
        {
            get
            {
                return m_Stats[3].Value;
            }
            set
            {
                m_Stats[3].Value = value;
            }
        }
        public int Intelligence
        {
            get
            {
                return m_Stats[4].Value;
            }
            set
            {
                m_Stats[4].Value = value;
            }
        }
        public int Agility
        {
            get
            {
                return m_Stats[5].Value;
            }
            set
            {
                m_Stats[5].Value = value;
            }
        }
        public int Luck
        {
            get
            {
                return m_Stats[6].Value;
            }
            set
            {
                m_Stats[6].Value = value;
            }
        }
    }
}
