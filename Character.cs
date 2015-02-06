using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FalloutPNP_PipBoy.Dialogs
{
    public class Character
    {
        public class cStats
        {
            public class Stat
            {
                public int MinValue = 0;
                public int CurValue = 0;
                public int MaxValue = 0;
                public int Distibution = 0;
            }

            private Stat[] m_Stats = new Stat[7];

            public cStats(Character character)
            {
                for (int i = 0; i < 7; i++)
                {
                    var stat = new Stat();
                    var raceMin = character.Race.GetInt(AttributeNames.SpecialAttrib.MinValue(i));
                    var raceIni = character.Race.GetInt(AttributeNames.SpecialAttrib.IniValue(i));
                    var raceMax = character.Race.GetInt(AttributeNames.SpecialAttrib.MaxValue(i));
                    var distrib = character.Attribs.GetInt(AttributeNames.SpecialAttrib.DistribValue(i));
                    var bonus = character.ModAttr(AttributeNames.SpecialAttrib.ModValue(i));

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
        public class cSkills
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

                public static Skill Initialize(int eSkill, cStats stats)
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

            public cSkills(Character character)
            {
                var tags = character.Attribs.Element.Elements(AttributeNames.cTag);

                for (int i = 0; i < 19; i++)
                {
                    var skill = Skill.Initialize(i, character.Stats);
                    foreach (var tag in tags)
                    {
                        if (tag.Value == i.ToString())
                        {
                            skill.Tag = true;
                            skill.Value += 20;
                        }
                    }

                    var bonus = character.ModAttr(AttributeNames.SkillAttrib.ModValue(i));
                    skill.Value += bonus;
                    m_Skills[i] = skill;
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
        public class cParameters
        {
            public class Parameter
            {
                public int Value = 0;

                public static Parameter Initialize(int eParameter, cStats stats)
                {
                    var parameter = new Parameter();
                    var eParameterName = (AttributeNames.EParameters)eParameter;

                    var Str = stats[(int)AttributeNames.ESpecials.Str].CurValue;
                    var Per = stats[(int)AttributeNames.ESpecials.Per].CurValue;
                    var End = stats[(int)AttributeNames.ESpecials.End].CurValue;
                    var Cha = stats[(int)AttributeNames.ESpecials.Cha].CurValue;
                    var Int = stats[(int)AttributeNames.ESpecials.Int].CurValue;
                    var Agi = stats[(int)AttributeNames.ESpecials.Agi].CurValue;
                    var Lck = stats[(int)AttributeNames.ESpecials.Lck].CurValue;

                    switch (eParameterName)
                    {
                        case AttributeNames.EParameters.MaxHP:
                            parameter.Value = 15 + Str + 2 * End;
                            break;
                        case AttributeNames.EParameters.HPperLVL:
                            parameter.Value = 3 + (int)(Math.Truncate(End / 2.0));
                            break;
                        case AttributeNames.EParameters.ArmorClass:
                            parameter.Value = Agi;
                            break;
                        case AttributeNames.EParameters.ActionPoints:
                            parameter.Value = 5 + (int)(Math.Truncate(Agi / 2.0));
                            break;
                        case AttributeNames.EParameters.CarryWeight:
                            parameter.Value = 25 + 25 * Str;
                            break;
                        case AttributeNames.EParameters.MeleeDamage:
                            parameter.Value = Math.Max(1, Str - 5);
                            break;
                        case AttributeNames.EParameters.PoisonResistance:
                            parameter.Value = 5 * End;
                            break;
                        case AttributeNames.EParameters.RadiationResistance:
                            parameter.Value = 2 * End;
                            break;
                        case AttributeNames.EParameters.GasResistance:
                            parameter.Value = 0;
                            break;
                        case AttributeNames.EParameters.Sequence:
                            parameter.Value = 2 * Per;
                            break;
                        case AttributeNames.EParameters.HealingRate:
                            parameter.Value = (int)(Math.Truncate(End / 3.0));
                            break;
                        case AttributeNames.EParameters.CriticalChance:
                            parameter.Value = Lck;
                            break;
                        case AttributeNames.EParameters.SkillPointsPerLevel:
                            parameter.Value = 5 + 2 * Int;
                            break;
                        case AttributeNames.EParameters.PerkPerLevel:
                            parameter.Value = 0;
                            break;
                    }

                    return parameter;
                }
            }

            private Parameter[] m_Parameters = new Parameter[(int)(AttributeNames.EParameters.Count)];

            public cParameters(Character character)
            {
                for (int i = 0; i < (int)(AttributeNames.EParameters.Count); i++)
                {
                    var fixedValue = character.FixAttr(AttributeNames.CharacterAttrib.FixValue(i));
                    if (fixedValue != -1)
                    {
                        var parameter = new Parameter() { Value = fixedValue };
                        m_Parameters[i] = parameter;
                    }
                    else
                    {
                        var parameter = Parameter.Initialize(i, character.Stats);
                        var raceMod = character.Race.GetInt(AttributeNames.CharacterAttrib.ModValue(i));
                        var charMod = character.ModAttr(AttributeNames.CharacterAttrib.ModValue(i));
                        parameter.Value += raceMod + charMod;
                        m_Parameters[i] = parameter;
                    }
                }
            }

            public Parameter this[int i]
            {
                get
                {
                    return m_Parameters[i];
                }
            }
        }

        public cStats Stats = null;
        public cSkills Skills = null;
        public cParameters Parameters = null;
        public Attributes Attribs;

        public Character(XElement element)
            :base()
        {
            //m_Element = element;
            Attribs = new Attributes(element);
        }

        public Attributes Race
        {
            get
            {
                var xe = Attribs.Element.Element("race");
                if (xe != null)
                {
                    return new Attributes(xe);
                }
                return new Attributes(new XElement("race"));
            }
            set
            {
                foreach (var xe in Attribs.Element.Elements("race"))
                {
                    xe.Remove();
                }
                Attribs.Element.Add(value.Element);
            }
        }

        public Attributes TraitFirst
        {
            get
            {
                var xe = Attribs.Element.Element("trait1");
                if (xe != null)
                {
                    return new Attributes(xe);
                }
                return new Attributes(new XElement("trait1"));
            }
            set
            {
                foreach (var xe in Attribs.Element.Elements("trait1"))
                {
                    xe.Remove();
                }
                if (value!= null)
                {
                    var trait = new XElement(value.Element);
                    trait.Name = "trait1";
                    Attribs.Element.Add(trait);
                }
            }
        }

        public Attributes TraitSecond
        {
            get
            {
                var xe = Attribs.Element.Element("trait2");
                if (xe != null)
                {
                    return new Attributes(xe);
                }
                return new Attributes(new XElement("trait2"));
            }
            set
            {
                foreach (var xe in Attribs.Element.Elements("trait2"))
                {
                    xe.Remove();
                }
                if (value!= null)
                {
                    var trait = new XElement(value.Element);
                    trait.Name = "trait2";
                    Attribs.Element.Add(trait);
                }
            }
        }


        public void Refresh()
        {
            Stats = new cStats(this);
            Skills = new cSkills(this);
            Parameters = new cParameters(this);
        }

        public int ModAttr(string attrName)
        {
            var bonus = 0;

            var trait1 = Attribs.Element.Element("trait1");
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

            var trait2 = Attribs.Element.Element("trait2");
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

            foreach (var perk in Attribs.Element.Elements("perk"))
            {
                var attr = perk.Attribute(attrName);
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

        public int FixAttr(string attrName)
        {
            var trait1 = Attribs.Element.Element("trait1");
            if (trait1 != null)
            {
                var attr = trait1.Attribute(attrName);
                if (attr != null)
                {
                    int value;
                    if (int.TryParse(attr.Value, out value))
                    {
                        return value;
                    }
                }
            }

            var trait2 = Attribs.Element.Element("trait2");
            if (trait2 != null)
            {
                var attr = trait2.Attribute(attrName);
                if (attr != null)
                {
                    int value;
                    if (int.TryParse(attr.Value, out value))
                    {
                        return value;
                    }
                }
            }

            foreach (var perk in Attribs.Element.Elements("perk"))
            {
                var attr = perk.Attribute(attrName);
                if (attr != null)
                {
                    int value;
                    if (int.TryParse(attr.Value, out value))
                    {
                        return value;
                    }
                }
            }

            return -1;
        }
    }
}
