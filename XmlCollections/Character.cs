using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FalloutPNP_PipBoy.XmlCollections
{
    public class Character : XmlEntry
    {
        public class Stats
        {
            public class Stat
            {
                public string SpecialName;
                public int MinValue = 0;
                public int CurValue = 0;
                public int MaxValue = 0;
                public int Distibution = 0;

                public Stat(string name)
                {
                    SpecialName = name;
                }
            }

            private Character m_Character;
            private Stat[] m_Stats = new Stat[7];

            public Stats(Character character)
            {
                m_Character = character;
                for (int i = 0; i < 7; i++)
                {
                    m_Stats[i] = new Stat(((Attributes.SPECIAL)i).ToString());
                }
            }

            public void Refresh()
            {
                for (int i = 0; i < 7; i++)
                {
                    var stat = m_Stats[i];
                    stat.MinValue = m_Character.CharRace.AttributesList.GetInt(Attributes.SpecialAtt.MinValue(i));
                    var RaceIni = m_Character.CharRace.AttributesList.GetInt(Attributes.SpecialAtt.IniValue(i));
                    stat.MaxValue = m_Character.CharRace.AttributesList.GetInt(Attributes.SpecialAtt.MaxValue(i));
                    stat.Distibution = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.Distribution(i));
                    stat.CurValue = RaceIni + stat.Distibution;
                }
            }

            public Stat this[int i]
            {
                get
                {
                    return m_Stats[i];
                }
            }
        }

        public Stats CharStats;
        public Race CharRace;
        private Races m_Races;
        private Items m_Items;

        public Character(Races races, Items items)
            :base()
        {
            m_Races = races;
            m_Items = items;

            CharRace = new Race();
            CharStats = new Stats(this);
        }

        public override void FillList()
        {
            AttributesList = new AttributesList();
            foreach (var att in Attributes.CharacterAtt.All)
            {
                AttributesList.Add(att);
            }
        }
        public void Refresh()
        {
            var charRaceName = AttributesList[Attributes.CharacterAtt.Race];
            CharRace = new Race();

            foreach (var race in m_Races)
            {
                if (race.Name == charRaceName)
                {
                    CharRace.Assign(race);
                    break;
                }
            }

            CharStats.Refresh();
        }
    }
}
