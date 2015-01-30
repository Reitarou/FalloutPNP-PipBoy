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
                public string StatName;
                public int MinValue = 0;
                public int CurValue = 0;
                public int MaxValue = 0;
                public int Distibution = 0;

                public Stat(int enumSpecial)
                {
                    StatName = ((Attributes.SPECIAL)enumSpecial).ToString();
                }
            }

            private Character m_Character;
            private Stat[] m_Stats = new Stat[7];

            public Stats(Character character)
            {
                m_Character = character;
                for (int i = 0; i < 7; i++)
                {
                    m_Stats[i] = new Stat(i);
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

        public class Skills
        {
            public class Skill
            {
                public string SkillName;
                private Attributes.SkillNames m_EnumSkillName;
                public int IniValue = 0;
                public bool Tag = false;

                public Skill(int enumSkillName)
                {
                    m_EnumSkillName = (Attributes.SkillNames)enumSkillName;
                    SkillName = m_EnumSkillName.ToString();
                }

                public void SetInitials(Stats stats)
                {
                    switch (m_EnumSkillName)
                    {
                        case Attributes.SkillNames.SmallGuns:
                            IniValue = 5;
                            IniValue += stats[(int)Attributes.SPECIAL.Agi].CurValue * 4;
                            break;
                    }
                }
            }

            private Character m_Character;
            private Skill[] m_Skills = new Skill[7];

            public Skills(Character character)
            {
                m_Character = character;
                for (int i = 0; i < 19; i++)
                {
                    m_Skills[i] = new Skill(i);
                }
            }

            public void Refresh()
            {
                for (int i = 0; i < 19; i++)
                {
                    var skill = m_Skills[i];
                    skill.SetInitials(m_Character.CharStats);
                    //skill.MinValue = m_Character.CharRace.AttributesList.GetInt(Attributes.SpecialAtt.MinValue(i));
                    //var RaceIni = m_Character.CharRace.AttributesList.GetInt(Attributes.SpecialAtt.IniValue(i));
                    //skill.MaxValue = m_Character.CharRace.AttributesList.GetInt(Attributes.SpecialAtt.MaxValue(i));
                    //skill.Distibution = m_Character.AttributesList.GetInt(Attributes.CharacterAtt.Distribution(i));
                    //skill.CurValue = RaceIni + skill.Distibution;
                }
            }

            public Skill this[int i]
            {
                get
                {
                    return m_Skills[i];
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
