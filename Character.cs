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

            private Stat[] m_Stats = new Stat[7];

            public Stats(Character character)
            {
                for (int i = 0; i < 7; i++)
                {
                    var stat = new Stat(i);
                    stat.MinValue = character.Race.GetInt(AttributeNames.SpecialAttrib.MinValue(i));
                    var raceIni = character.Race.GetInt(AttributeNames.SpecialAttrib.IniValue(i));
                    stat.Distibution = character.CharAttribs.GetInt(AttributeNames.SpecialAttrib.DistribValue(i));
                    var bonus = character.BonusAttr(AttributeNames.SpecialAttrib.BonusValue(i));
                    stat.CurValue = raceIni + stat.Distibution;
                    stat.MaxValue = character.Race.GetInt(AttributeNames.SpecialAttrib.MaxValue(i));
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
                public int Value = 0;
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
                            Value = 5 + 4 * Agi;
                            break;

                        case AttributeNames.ESkills.BigGuns:
                            Value = 0 + 2 * Agi;
                            break;

                        case AttributeNames.ESkills.EnergyWeapons:
                            Value = 0 + 2 * Agi;
                            break;

                        case AttributeNames.ESkills.Unarmed:
                            Value = 30 + 2 * (Str + Agi);
                            break;

                        case AttributeNames.ESkills.MeleeWeapons:
                            Value = 20 + 2 * (Str + Agi);
                            break;

                        case AttributeNames.ESkills.Throwing:
                            Value = 0 + 4 * Agi;
                            break;

                        case AttributeNames.ESkills.FirstAid:
                            Value = 0 + 2 * (Per + Int) ;
                            break;

                        case AttributeNames.ESkills.Doctor:
                            Value = 5 + 1 * (Per + Int);
                            break;

                        case AttributeNames.ESkills.Sneak:
                            Value = 5 + 3 * Agi;
                            break;

                        case AttributeNames.ESkills.Lockpick:
                            Value = 10 + 1 * (Per + Agi);
                            break;

                        case AttributeNames.ESkills.Steal:
                            Value = 0 + 3 * Agi;
                            break;

                        case AttributeNames.ESkills.Trap:
                            Value = 10 + 1 * (Per + Agi);
                            break;

                        case AttributeNames.ESkills.Science:
                            Value = 0 + 4 * Int;
                            break;

                        case AttributeNames.ESkills.Repair:
                            Value = 0 + 3 * Int;
                            break;

                        case AttributeNames.ESkills.Pilot:
                            Value = 0 + 2 * (Per + Agi) ;
                            break;

                        case AttributeNames.ESkills.Speech:
                            Value = 0 + 5 * Cha;
                            break;

                        case AttributeNames.ESkills.Barter:
                            Value = 0 + 4 * Cha;
                            break;

                        case AttributeNames.ESkills.Gambling:
                            Value = 0 + 5 * Lck;
                            break;

                        case AttributeNames.ESkills.Outdoorsman:
                            Value = 0 + 2 * (Per + Int);
                            break;
                    }
                }
            }

            private Skill[] m_Skills = new Skill[19];

            public Skills(Character character)
            {
                var tags = character.CharAttribs.Element.Elements(AttributeNames.cTag);
                for (int i = 0; i < 19; i++)
                {
                    m_Skills[i] = new Skill(i);
                }

                for (int i = 0; i < 19; i++)
                {
                    var skill = m_Skills[i];
                    skill.SetInitials(character.CharStats);
                    foreach (var tag in tags)
                    {
                        if (tag.Value == i.ToString())
                        {
                            skill.Tag = true;
                            skill.Value += 20;
                        }
                    }
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

        //private XElement m_Element;

        public Stats CharStats = null;
        public Skills CharSkills = null;
        public Attributes CharAttribs;

        public Character(XElement element)
            :base()
        {
            //m_Element = element;
            CharAttribs = new Attributes(element);
        }

        public Attributes Race
        {
            get
            {
                var xe = CharAttribs.Element.Element("race");
                if (xe != null)
                {
                    return new Attributes(xe);
                }
                return new Attributes(new XElement("race"));
            }
            set
            {
                foreach (var xe in CharAttribs.Element.Elements("race"))
                {
                    xe.Remove();
                }
                CharAttribs.Element.Add(value.Element);
            }
        }

        public Attributes TraitFirst
        {
            get
            {
                var xe = CharAttribs.Element.Element("trait1");
                if (xe != null)
                {
                    return new Attributes(xe);
                }
                return new Attributes(new XElement("trait1"));
            }
            set
            {
                foreach (var xe in CharAttribs.Element.Elements("trait1"))
                {
                    xe.Remove();
                }
                CharAttribs.Element.Add(value.Element);
            }
        }

        public Attributes TraitSecond
        {
            get
            {
                var xe = CharAttribs.Element.Element("trait2");
                if (xe != null)
                {
                    return new Attributes(xe);
                }
                return new Attributes(new XElement("trait2"));
            }
            set
            {
                foreach (var xe in CharAttribs.Element.Elements("trait2"))
                {
                    xe.Remove();
                }
                CharAttribs.Element.Add(value.Element);
            }
        }


        public void Refresh()
        {
            CharStats = new Stats(this);
            CharSkills = new Skills(this);
        }

        public int BonusAttr(string attrName)
        {
            var bonus = 0;

            foreach (var trait in CharAttribs.Element.Elements("trait"))
            {
                var attr = trait.Attribute(attrName);
                if (attr != null)
                {
                    int value;
                    if (int.TryParse(attr.Value, out value))
                    {
                        bonus += value;
                    }
                }
            }

            return bonus;
        }
    }
}
