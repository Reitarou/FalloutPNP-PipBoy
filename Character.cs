using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FalloutPNP_PipBoy.Dialogs
{
    public class Character
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
                    StatName = ((AttributeNames.ESpecial)enumSpecial).ToString();
                }
            }

            private Character m_Character;
            private Stat[] m_Stats = new Stat[7];

            public Stats(Character character)
            {
                m_Character = character;
                for (int i = 0; i < 7; i++)
                {
                    var stat = new Stat(i);
                    stat.MinValue = m_Character.RaceAttribs.GetInt(AttributeNames.SpecialAttrib.MinValue(i));
                    var RaceIni = m_Character.RaceAttribs.GetInt(AttributeNames.SpecialAttrib.IniValue(i));
                    stat.MaxValue = m_Character.RaceAttribs.GetInt(AttributeNames.SpecialAttrib.MaxValue(i));
                    stat.Distibution = m_Character.CharAttribs.GetInt(AttributeNames.CharacterAttrib.Distribution(i));
                    stat.CurValue = RaceIni + stat.Distibution;
                    m_Stats[i] = stat;
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
                private AttributeNames.ESkills m_EnumSkillName;
                public int IniValue = 0;
                public bool Tag = false;

                public Skill(int enumSkillName)
                {
                    m_EnumSkillName = (AttributeNames.ESkills)enumSkillName;
                    SkillName = m_EnumSkillName.ToString();
                }

                public void SetInitials(Stats stats)
                {
                    var Str = stats[(int)AttributeNames.ESpecial.Str].CurValue;
                    var Per = stats[(int)AttributeNames.ESpecial.Per].CurValue;
                    var End = stats[(int)AttributeNames.ESpecial.End].CurValue;
                    var Cha = stats[(int)AttributeNames.ESpecial.Cha].CurValue;
                    var Int = stats[(int)AttributeNames.ESpecial.Int].CurValue;
                    var Agi = stats[(int)AttributeNames.ESpecial.Agi].CurValue;
                    var Lck = stats[(int)AttributeNames.ESpecial.Lck].CurValue;

                    switch (m_EnumSkillName)
                    {
                        case AttributeNames.ESkills.SmallGuns:
                            IniValue = 5 + 4 * Agi;
                            break;

                        case AttributeNames.ESkills.BigGuns:
                            IniValue = 0 + 2 * Agi;
                            break;

                        case AttributeNames.ESkills.EnergyWeapons:
                            IniValue = 0 + 2 * Agi;
                            break;

                        case AttributeNames.ESkills.Unarmed:
                            IniValue = 30 + 2 * (Str + Agi);
                            break;

                        case AttributeNames.ESkills.MeleeWeapons:
                            IniValue = 20 + 2 * (Str + Agi);
                            break;

                        case AttributeNames.ESkills.Throwing:
                            IniValue = 0 + 4 * Agi;
                            break;

                        case AttributeNames.ESkills.FirstAid:
                            IniValue = 0 + 2 * (Per + Int) ;
                            break;

                        case AttributeNames.ESkills.Doctor:
                            IniValue = 5 + 1 * (Per + Int);
                            break;

                        case AttributeNames.ESkills.Sneak:
                            IniValue = 5 + 3 * Agi;
                            break;

                        case AttributeNames.ESkills.Lockpick:
                            IniValue = 10 + 1 * (Per + Agi);
                            break;

                        case AttributeNames.ESkills.Steal:
                            IniValue = 0 + 3 * Agi;
                            break;

                        case AttributeNames.ESkills.Trap:
                            IniValue = 10 + 1 * (Per + Agi);
                            break;

                        case AttributeNames.ESkills.Science:
                            IniValue = 0 + 4 * Int;
                            break;

                        case AttributeNames.ESkills.Repair:
                            IniValue = 0 + 3 * Int;
                            break;

                        case AttributeNames.ESkills.Pilot:
                            IniValue = 0 + 2 * (Per + Agi) ;
                            break;

                        case AttributeNames.ESkills.Speech:
                            IniValue = 0 + 5 * Cha;
                            break;

                        case AttributeNames.ESkills.Barter:
                            IniValue = 0 + 4 * Cha;
                            break;

                        case AttributeNames.ESkills.Gambling:
                            IniValue = 0 + 5 * Lck;
                            break;

                        case AttributeNames.ESkills.Outdoorsman:
                            IniValue = 0 + 2 * (Per + Int);
                            break;
                    }
                }
            }

            private Character m_Character;
            private Skill[] m_Skills = new Skill[19];

            public Skills(Character character)
            {
                m_Character = character;
                for (int i = 0; i < 19; i++)
                {
                    m_Skills[i] = new Skill(i);
                }

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

        private XElement m_Element;
        private List<Attributes> m_Items;
        private List<Attributes> m_Races;
        private List<Attributes> m_Traits;


        public Stats CharStats = null;
        public Skills CharSkills = null;
        public Attributes RaceAttribs;
        public Attributes CharAttribs;

        public Character(XElement element, List<Attributes> items, List<Attributes> races, List<Attributes> traits)
            :base()
        {
            m_Element = element;
            m_Items = items;
            m_Races = races;
            m_Traits = traits;
            CharAttribs = new Attributes(element);
            RaceAttribs = new Attributes(new XElement("race"));
        }

        public void Refresh()
        {
            var charRaceName = CharAttribs[AttributeNames.CharacterAttrib.CharacterRace];

            foreach (var race in m_Races)
            {
                if (race[AttributeNames.RaceAttrib.RaceName] == charRaceName)
                {
                    RaceAttribs = race;
                    break;
                }
            }

                CharStats = new Stats(this);
                CharSkills = new Skills(this);
        }
    }
}
