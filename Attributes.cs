using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using FalloutPNP_PipBoy.Properties;
using System.Xml;

namespace FalloutPNP_PipBoy
{
    public static class Attributes
    {
        /* Сюда вбивать атрибуты.
         * Названия атрибутов должны быть уникальными.
         * В названии свойства не должно быть пробелов.*/

        public static class SpecialAtt
        {
            public const string StrMin = "SPECIAL_Str_Min";
            public const string StrInit = "SPECIAL_Str_Init";
            public const string StrMax = "SPECIAL_Str_Max";

            public const string PerMin = "SPECIAL_Per_Min";
            public const string PerInit = "SPECIAL_Per_Init";
            public const string PerMax = "SPECIAL_Per_Max";

            public const string EndurMin = "SPECIAL_Endur_Min";
            public const string EndurStart = "SPECIAL_Endur_Init";
            public const string EndurMax = "SPECIAL_Endur_Max";

            public const string CharMin = "SPECIAL_Char_Min";
            public const string CharStart = "SPECIAL_Char_Init";
            public const string CharMax = "SPECIAL_Char_Max";

            public const string IntMin = "SPECIAL_Int_Min";
            public const string IntStart = "SPECIAL_Int_Init";
            public const string IntMax = "SPECIAL_Int_Max";

            public const string AgiMin = "SPECIAL_Agi_Min";
            public const string AgiStart = "SPECIAL_Agi_Init";
            public const string AgiMax = "SPECIAL_Agi_Max";

            public const string LuckMin = "SPECIAL_Luck_Min";
            public const string LuckStart = "SPECIAL_Luck_Init";
            public const string LuckMax = "SPECIAL_Luck_Max";

            public static List<Attribute> All
            {
                get
                {
                    var list = new List<Attribute>();
                    list.Add(new Attribute(StrMin));
                    list.Add(new Attribute(StrInit));
                    list.Add(new Attribute(StrMax));

                    list.Add(new Attribute(PerMin));
                    list.Add(new Attribute(PerInit));
                    list.Add(new Attribute(PerMax));

                    list.Add(new Attribute(EndurMin));
                    list.Add(new Attribute(EndurStart));
                    list.Add(new Attribute(EndurMax));

                    list.Add(new Attribute(CharMin));
                    list.Add(new Attribute(CharStart));
                    list.Add(new Attribute(CharMax));

                    list.Add(new Attribute(IntMin));
                    list.Add(new Attribute(IntStart));
                    list.Add(new Attribute(IntMax));

                    list.Add(new Attribute(AgiMin));
                    list.Add(new Attribute(AgiStart));
                    list.Add(new Attribute(AgiMax));

                    list.Add(new Attribute(LuckMin));
                    list.Add(new Attribute(LuckStart));
                    list.Add(new Attribute(LuckMax));
                    return list;
                }
            }
        }

        public static class ItemsCommonAtt
        {
            //public const string cArmor = "Броня";
            //public const string cHelm = "Шлем";
            //public const string cFullArmor = "Броня со шлемом";
            //public const string cWeapon = "Оружие";
            //public const string cAmmo = "Аммуниция";
            //public const string cDemolition = "Взрывчатое в-во";
            //public const string cMod = "Модификация";
            //public const string cMedicine = "Медицина";
            //public const string cSundry = "Предмет";

            //public enum CategoryList
            //{
            //    [Description("Неизвестно")]
            //    Unknown, /*Этот пункт всегда должен быть первым!!! 
            //      * Присваивается если категория не совпадает с одной из перечисленных ниже*/

            //    [Description(Attributes.cArmor)]
            //    Armor,
            //    [Description(Attributes.cHelm)]
            //    Helm,
            //    [Description(Attributes.cFullArmor)]
            //    FullArmor,
            //    [Description(Attributes.cWeapon)]
            //    Weapon,
            //    [Description(Attributes.cAmmo)]
            //    Ammo,
            //    [Description(Attributes.cDemolition)]
            //    Demolition,
            //    [Description(Attributes.cMod)]
            //    Mod,
            //    [Description(Attributes.cMedicine)]
            //    Medicine,
            //    [Description(Attributes.cSundry)]
            //    Sundry,

            //    Common, /*Этот пункт всегда должен быть предпоследним!!! 
            //     * Эта категория только для свойств. Не должна фигурировать в предметах*/
            //    Count /*Этот пункт всегда должен быть последним!!!*/
            //}

            public const string Name = "Item_Name";
            public const string Category = "Item_Category";
            public const string Weight = "Item_Weight";
            public const string Price = "Item_Price";
            public const string Description = "Item_Description";

            public static List<Attribute> All
            {
                get
                {
                    var list = new List<Attribute>();
                    list.Add(new Attribute(Name));
                    list.Add(new Attribute(Category));
                    list.Add(new Attribute(Weight));
                    list.Add(new Attribute(Price));
                    list.Add(new Attribute(Description));
                    return list;
                }
            }
        }

        public static class ArmourAtt
        {
            public const string ArmorClass = "Armour_Armor_Class";

            public const string NormalDamageThreshold = "Armour_Normal_Damage_Threshold";
            public const string NormalDamageReduction = "Armour_Normal_Damage_Reduction";

            public const string FireDamageThreshold = "Armour_Fire_Damage_Threshold";
            public const string FireDamageReduction = "Armour_Fire_Damage_Reduction";

            public const string BlastDamageThreshold = "Armour_Blast_Damage_Threshold";
            public const string BlastDamageReduction = "Armour_Blast_Damage_Reduction";

            public const string LaserDamageThreshold = "Armour_Laser_Damage_Threshold";
            public const string LaserDamageReduction = "Armour_Laser_Damage_Reduction";

            public const string PlasmaDamageThreshold = "Armour_Plasma_Damage_Threshold";
            public const string PlasmaDamageReduction = "Armour_Plasma_Damage_Reduction";

            public const string ElectricDamageThreshold = "Armour_Electric_Damage_Threshold";
            public const string ElectricDamageReduction = "Armour_Electric_Damage_Reduction";
            
            public const string PoisonDamageResistance = "Armour_Poison_Damage_Resistance";
            public const string RadiationDamageResistance = "Armour_Radiation_Damage_Resistance";
            public const string GasDamageResistance = "Armour_Gas_Damage_Resistance";

            public static List<Attribute> All
            {
                get
                {
                    var list = new List<Attribute>();
                    list.Add(new Attribute(ArmorClass));
                    list.Add(new Attribute(NormalDamageThreshold));
                    list.Add(new Attribute(NormalDamageReduction));
                    list.Add(new Attribute(FireDamageThreshold));
                    list.Add(new Attribute(FireDamageReduction));
                    list.Add(new Attribute(BlastDamageThreshold));
                    list.Add(new Attribute(BlastDamageReduction));
                    list.Add(new Attribute(LaserDamageThreshold));
                    list.Add(new Attribute(LaserDamageReduction));
                    list.Add(new Attribute(PlasmaDamageThreshold));
                    list.Add(new Attribute(PlasmaDamageReduction));
                    list.Add(new Attribute(PoisonDamageResistance));
                    list.Add(new Attribute(RadiationDamageResistance));
                    list.Add(new Attribute(GasDamageResistance));
                    return list;
                }
            }

        }

        public static class CharacterAtt
        {
            public const string Name = "Character_Name";
            public const string Race = "Race_Name";
            public const string CreationComplete = "Character_Creation_Complete";

            public const string DistributionStr = "Character_DistributionStr";
            public const string DistributionPer = "Character_DistributionPer";
            public const string DistributionEnd = "Character_DistributionEnd";
            public const string DistributionCha = "Character_DistributionCha";
            public const string DistributionInt = "Character_DistributionInt";
            public const string DistributionAgi = "Character_DistributionAgi";
            public const string DistributionLuc = "Character_DistributionLuc";

            public static List<Attribute> All
            {
                get
                {
                    var list = new List<Attribute>();
                    list.Add(new Attribute(Name));
                    list.Add(new Attribute(Race));
                    return list;
                }
            }
        }

        //// === Оружие ===
        //public const string pWeaponHandling = "WeaponHandling"; // одноручное, двуручное
        //public const string pWeaponRange = "WeaponRange"; // дальность

        ////Урон каждым типом
        //public const string pWeaponNormalDamage = "WeaponNormalDamage"; //
        //public const string pWeaponLaserDamage = "WeaponLaserDamage"; //
        //public const string pWeaponPlasmaDamage = "WeaponPlasmaDamage"; //
        //public const string pWeaponFireDamage = "WeaponFireDamage"; //
        //public const string pWeaponBlastDamage = "WeaponBlastDamage"; //
        //public const string pWeaponElectroDamage = "WeaponElectroDamage"; //

        //public const string pWeaponAmmoType = "WeaponAmmoType"; // тип боеприпасов
        //public const string pWeaponCage = "WeaponCage"; // патронов в обоймe
        //public const string pWeaponBurstAmmo = "WeaponBurstAmmo"; // патронов в очереди
        //public const string pWeaponTimeSingle = "WeaponTimeSingle"; // ОД на одиночный
        //public const string pWeaponTimeAimed = "WeaponTimeAimed"; // ОД на прицельный
        //public const string pWeaponTimeBurst = "WeaponTimeBurst"; // ОД на очередь
        //public const string pWeaponComplexity = "WeaponComplexity"; // сложность

        ////=== Ammo ===
        ////Урон каждым типом
        //public const string pAmmoNormalDamage = "AmmoNormalDamage"; //
        //public const string pAmmoLaserDamage = "AmmoLaserDamage"; //
        //public const string pAmmoPlasmaDamage = "AmmoPlasmaDamage"; //
        //public const string pAmmoFireDamage = "AmmoFireDamage"; //
        //public const string pAmmoBlastDamage = "AmmoBlastDamage"; //
        //public const string pAmmoElectroDamage = "AmmoElectroDamage"; //

        //public const string pAmmoArmorClassMod = "AmmoArmorClassMod"; // Изменение КБ

        ////Изменение резистов каждого типа										!!! Это нужно? Или патроны дают изменение всех резистов сразу? Так можно делать специальные патроны
        //public const string pAmmoNormalDamageResistanceMod = "AmmoNormalDamageResistanceMod"; //
        //public const string pAmmoNormalDamageThresholdMod = "AmmoNormalDamageThresholdMod"; //
        //public const string pAmmoLaserDamageResistanceMod = "AmmoLaserDamageResistanceMod"; //
        //public const string pAmmoLaserDamageThresholdMod = "AmmoLaserDamageThresholdMod"; //
        //public const string pAmmoFireDamageResistanceMod = "AmmoFireDamageResistanceMod"; //
        //public const string pAmmoFireDamageThresholdMod = "AmmoFireDamageThresholdMod"; //
        //public const string pAmmoPlasmaDamageResistanceMod = "AmmoPlasmaDamageResistanceMod"; //
        //public const string pAmmoPlasmaDamageThresholdMod = "AmmoPlasmaDamageThresholdMod"; //
        //public const string pAmmoBlastDamageResistanceMod = "AmmoBlastDamageResistanceMod"; //
        //public const string pAmmoBlastDamageThresholdMod = "AmmoBlastDamageThresholdMod"; //
        //public const string pAmmoElectroDamageResistanceMod = "AmmoElectroDamageResistanceMod"; //
        //public const string pAmmoElectroDamageThresholdMod = "AmmoElectroDamageThresholdMod"; //

        //public const string pAmmoBoxCount = "AmmoBoxCount"; //количество в одной упаковке                         !!! А что это даёт?

        ////=== Medicine ===
        //public const string pAdaption = "Adaption"; // привыкание

        ////=== Mods ===
        ////Всё описывается в Description?

        ////=== Demolition ===
        //public const string pDemolitionNormalDamage = "DemolitionNormalDamage"; //
        //public const string pDemolitionLaserDamage = "DemolitionLaserDamage"; //
        //public const string pDemolitionPlasmaDamage = "DemolitionPlasmaDamage"; //
        //public const string pDemolitionFireDamage = "DemolitionFireDamage"; //
        //public const string pDemolitionBlastDamage = "DemolitionBlastDamage"; //
        //public const string pDemolitionElectroDamage = "DemolitionElectroDamage"; //
    }

    public class Attribute
    {
        public string Name;
        public string Value = string.Empty;

        //public Attribute(Attribute property, string value)
        //{
        //    Name = property.Name;
        //    Value = value;
        //}

        public Attribute(string name)
        {
            Name = name;
        }
    }

    public class AttributesList : IList<Attribute>
    {
        private List<Attribute> m_Attributes;

        public AttributesList()
        {
            m_Attributes = new List<Attribute>();
        }

        public string this[string name]
        {
            get
            {
                foreach (var attribute in m_Attributes)
                {
                    if (attribute.Name == name)
                    {
                        return attribute.Value;
                    }
                }

                return string.Empty;
            }
            set
            {
                var attribute = new Attribute(name) { Value = value };

                for (int i = 0; i < m_Attributes.Count; i++)
                {
                    if (m_Attributes[i].Name == name)
                    {
                        m_Attributes[i] = attribute;
                        return;
                    }
                }

                m_Attributes.Add(attribute);
            }
        }

        public int GetInt(string name)
        {
            foreach (var attribute in m_Attributes)
            {
                if (attribute.Name == name)
                {
                    int result;
                    if (!int.TryParse(attribute.Value, out result))
                    {
                        return 0;
                    }
                    return result;
                }
            }

            return 0;
        }

        #region IList<Attribute> Members

        public int IndexOf(Attribute item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Attribute item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Attribute this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection<Attribute> Members

        public void Add(Attribute item)
        {
            for (int i = 0; i < m_Attributes.Count; i++)
            {
                if (m_Attributes[i].Name == item.Name)
                {
                    m_Attributes[i] = item;
                    return;
                }
            }

            m_Attributes.Add(item);
        }

        public void Clear()
        {
            m_Attributes.Clear();
        }

        public bool Contains(Attribute item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Attribute[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                return m_Attributes.Count;
            }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Attribute item)
        {
            return m_Attributes.Remove(item);
        }

        #endregion

        #region IEnumerable<Attribute> Members

        public IEnumerator<Attribute> GetEnumerator()
        {
            return m_Attributes.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_Attributes.GetEnumerator();
        }

        #endregion
    }

    #region EnumExtensions

    public static class EnumExtensions
    {
        public static string Description<T>(this T enumerationValue)
             where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();

        }
    }

    #endregion




    #region TrashBin

    //public static ItemCategory GetCategory(string sCategory)
    //{
    //    for (int i = 0; i < (int)ItemCategory.Count - 1; i++) // Категория Common у Item`а идёт как Unknown, а Count вообще не должна быть назначена
    //    {
    //        var cat = (ItemCategory)i;
    //        if (cat.GetDescription() == sCategory)
    //        {
    //            return cat;
    //        }
    //    }
    //    return ItemCategory.Unknown;
    //}

    //private static List<Attribute> GetItemAttributesList()
    //{
    //    var props = new List<Attribute>();

    /* Сюда доюавлять свойства. Имя свойства вбивается выше. Категории уже вбиты. 
     * Категорию "Броня со шлемом" заполнять не надо - там просто выводятся свойства брони и свойства шлема.*/

    //Common
    //props.Add(new Attribute(AttributeName.pName, ItemCategory.Common));
    //props.Add(new Attribute(AttributeName.pCategory, ItemCategory.Common));
    //props.Add(new Attribute(AttributeName.pWeight, ItemCategory.Common));
    //props.Add(new Attribute(AttributeName.pDescription, ItemCategory.Common));
    //props.Add(new Attribute(AttributeName.pPrice, ItemCategory.Common));

    ////Armor
    //props.Add(new Attribute(AttributeName.pArmorClass, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorNormalDamageResistance, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorNormalDamageThreshold, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorLaserDamageResistance, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorLaserDamageThreshold, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorFireDamageResistance, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorFireDamageThreshold, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorPlasmaDamageResistance, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorPlasmaDamageThreshold, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorBlastDamageResistance, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorBlastDamageThreshold, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorElectricDamageResistance, ItemCategory.Armor));
    //props.Add(new Attribute(AttributeName.pArmorElectricDamageThreshold, ItemCategory.Armor));

    ////Helm
    //props.Add(new Attribute(AttributeName.pHelmClass, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmNormalDamageResistance, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmNormalDamageThreshold, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmLaserDamageResistance, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmLaserDamageThreshold, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmFireDamageResistance, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmFireDamageThreshold, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmPlasmaDamageResistance, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmPlasmaDamageThreshold, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmBlastDamageResistance, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmBlastDamageThreshold, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmElectricDamageResistance, ItemCategory.Helm));
    //props.Add(new Attribute(AttributeName.pHelmElectricDamageThreshold, ItemCategory.Helm));

    ////Weapon
    //// === Оружие ===
    //props.Add(new Attribute(AttributeName.pWeaponHandling, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponRange, ItemCategory.Weapon));

    ////Урон каждым типом
    //props.Add(new Attribute(AttributeName.pWeaponNormalDamage, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponLaserDamage, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponPlasmaDamage, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponFireDamage, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponBlastDamage, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponElectroDamage, ItemCategory.Weapon));

    //props.Add(new Attribute(AttributeName.pWeaponAmmoType, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponCage, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponBurstAmmo, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponTimeSingle, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponTimeAimed, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponTimeBurst, ItemCategory.Weapon));
    //props.Add(new Attribute(AttributeName.pWeaponComplexity, ItemCategory.Weapon));

    ////=== Ammo ===
    ////Урон каждым типом
    //props.Add(new Attribute(AttributeName.pAmmoNormalDamage, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoLaserDamage, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoPlasmaDamage, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoFireDamage, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoBlastDamage, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoElectroDamage, ItemCategory.Ammo));

    //props.Add(new Attribute(AttributeName.pAmmoArmorClassMod, ItemCategory.Ammo));

    ////Изменение резистов каждого типа									
    //props.Add(new Attribute(AttributeName.pAmmoNormalDamageResistanceMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoNormalDamageThresholdMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoLaserDamageResistanceMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoLaserDamageThresholdMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoFireDamageResistanceMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoFireDamageThresholdMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoPlasmaDamageResistanceMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoPlasmaDamageThresholdMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoBlastDamageResistanceMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoBlastDamageThresholdMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoElectroDamageResistanceMod, ItemCategory.Ammo));
    //props.Add(new Attribute(AttributeName.pAmmoElectroDamageThresholdMod, ItemCategory.Ammo));

    //props.Add(new Attribute(AttributeName.pAmmoBoxCount, ItemCategory.Ammo));

    ////=== Medicine ===
    //props.Add(new Attribute(AttributeName.pAdaption, ItemCategory.Medicine));

    ////=== Mods ===
    ////Всё описывается в Description?

    ////=== Demolition ===
    //props.Add(new Attribute(AttributeName.pDemolitionNormalDamage, ItemCategory.Demolition));
    //props.Add(new Attribute(AttributeName.pDemolitionLaserDamage, ItemCategory.Demolition));
    //props.Add(new Attribute(AttributeName.pDemolitionPlasmaDamage, ItemCategory.Demolition));
    //props.Add(new Attribute(AttributeName.pDemolitionFireDamage, ItemCategory.Demolition));
    //props.Add(new Attribute(AttributeName.pDemolitionBlastDamage, ItemCategory.Demolition));
    //props.Add(new Attribute(AttributeName.pDemolitionElectroDamage, ItemCategory.Demolition));

    //    return props;
    //}

    #endregion


}
