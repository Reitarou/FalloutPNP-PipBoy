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
                public int MinValue = 0;
                public int CurValue = 0;
                public int MaxValue = 0;
                public int Distibution = 0;
            }

            private Stat[] m_Stats = new Stat[7];

            public Stats(Character character)
            {
                for (int i = 0; i < 7; i++)
                {
                    var stat = new Stat();
                    var raceMin = character.Race.GetInt(AttributeNames.SpecialAttrib.MinValue(i));
                    var raceIni = character.Race.GetInt(AttributeNames.SpecialAttrib.IniValue(i));
                    var raceMax = character.Race.GetInt(AttributeNames.SpecialAttrib.MaxValue(i));
                    var distrib = character.CharAttribs.GetInt(AttributeNames.SpecialAttrib.DistribValue(i));
                    var bonus = character.BonusAttr(AttributeNames.SpecialAttrib.BonusValue(i));

                    stat.MinValue = raceMin + bonus;
                    stat.Distibution = distrib;
                    stat.CurValue = raceIni + bonus + stat.Distibution;
                    stat.MaxValue = raceMax;
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
                public int Value = 0;
                public int DistribT0 = 0;
                public int DistribT1 = 0;
                public int DistribT2 = 0;
                public int DistribT3 = 0;
                public int DistribT4 = 0;
                public bool Tag = false;

                public static Skill Initialize(int eSkill, Stats stats)
                {
                    var skill = new Skill();
                    var eSkillName = (AttributeNames.ESkills)eSkill;

                    var Str = stats[(int)AttributeNames.ESpecials.Str].CurValue;
                    var Per = stats[(int)AttributeNames.ESpecials.Per].CurValue;
                    var End = stats[(int)AttributeNames.ESpecials.End].CurValue;
                    var Cha = stats[(int)AttributeNames.ESpecials.Cha].CurValue;
                    var Int = stats[(int)AttributeNames.ESpecials.Int].CurValue;
                    var Agi = stats[(int)AttributeNames.ESpecials.Agi].CurValue;
                    var Lck = stats[(int)AttributeNames.ESpecials.Lck].CurValue;

                    switch (eSkillName)
                    {
                        case AttributeNames.ESkills.SmallGuns:
                            skill.Value = 5 + 4 * Agi;
                            break;

                        case AttributeNames.ESkills.BigGuns:
                            skill.Value = 0 + 2 * Agi;
                            break;

                        case AttributeNames.ESkills.EnergyWeapons:
                            skill.Value = 0 + 2 * Agi;
                            break;

                        case AttributeNames.ESkills.Unarmed:
                            skill.Value = 30 + 2 * (Str + Agi);
                            break;

                        case AttributeNames.ESkills.MeleeWeapons:
                            skill.Value = 20 + 2 * (Str + Agi);
                            break;

                        case AttributeNames.ESkills.Throwing:
                            skill.Value = 0 + 4 * Agi;
                            break;

                        case AttributeNames.ESkills.FirstAid:
                            skill.Value = 0 + 2 * (Per + Int) ;
                            break;

                        case AttributeNames.ESkills.Doctor:
                            skill.Value = 5 + 1 * (Per + Int);
                            break;

                        case AttributeNames.ESkills.Sneak:
                            skill.Value = 5 + 3 * Agi;
                            break;

                        case AttributeNames.ESkills.Lockpick:
                            skill.Value = 10 + 1 * (Per + Agi);
                            break;

                        case AttributeNames.ESkills.Steal:
                            skill.Value = 0 + 3 * Agi;
                            break;

                        case AttributeNames.ESkills.Trap:
                            skill.Value = 10 + 1 * (Per + Agi);
                            break;

                        case AttributeNames.ESkills.Science:
                            skill.Value = 0 + 4 * Int;
                            break;

                        case AttributeNames.ESkills.Repair:
                            skill.Value = 0 + 3 * Int;
                            break;

                        case AttributeNames.ESkills.Pilot:
                            skill.Value = 0 + 2 * (Per + Agi) ;
                            break;

                        case AttributeNames.ESkills.Speech:
                            skill.Value = 0 + 5 * Cha;
                            break;

                        case AttributeNames.ESkills.Barter:
                            skill.Value = 0 + 4 * Cha;
                            break;

                        case AttributeNames.ESkills.Gambling:
                            skill.Value = 0 + 5 * Lck;
                            break;

                        case AttributeNames.ESkills.Outdoorsman:
                            skill.Value = 0 + 2 * (Per + Int);
                            break;
                    }

                    return skill;
                }
            }

            private Skill[] m_Skills = new Skill[19];

            public Skills(Character character)
            {
                var tags = character.CharAttribs.Element.Elements(AttributeNames.cTag);

                for (int i = 0; i < 19; i++)
                {
                    var skill = Skill.Initialize(i, character.CharStats);
                    foreach (var tag in tags)
                    {
                        if (tag.Value == i.ToString())
                        {
                            skill.Tag = true;
                            skill.Value += 20;
                        }
                    }

                    var bonus = character.BonusAttr(AttributeNames.SkillAttrib.BonusValue(i));
                    skill.Value += bonus;

                    m_Skills[i] = skill;
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
                if (value!= null)
                {
                    var trait = new XElement(value.Element);
                    trait.Name = "trait1";
                    CharAttribs.Element.Add(trait);
                }
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
                if (value!= null)
                {
                    var trait = new XElement(value.Element);
                    trait.Name = "trait2";
                    CharAttribs.Element.Add(trait);
                }
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

            var trait1 = CharAttribs.Element.Element("trait1");
            if (trait1 != null)
            {
                var attr = trait1.Attribute(attrName);
                if (attr != null)
                {
                    int value;
                    if (int.TryParse(attr.Value, out value))
                    {
                        bonus += value;
                    }
                }
            }

            var trait2 = CharAttribs.Element.Element("trait2");
            if (trait2 != null)
            {
                var attr = trait2.Attribute(attrName);
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
