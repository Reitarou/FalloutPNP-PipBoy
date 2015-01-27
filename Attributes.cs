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
    public static class AttributeName
    {
        /* Сюда вбивать свойства. 
         * В названии свойства не должно быть пробелов.
         * Начинаем названия свойств с буквы p*/

        public const string cArmor = "Броня";
        public const string cHelm = "Шлем";
        public const string cFullArmor = "Броня со шлемом";
        public const string cWeapon = "Оружие";
        public const string cAmmo = "Аммуниция";
        public const string cDemolition = "Взрывчатое в-во";
        public const string cMod = "Модификация";
        public const string cMedicine = "Медицина";
        public const string cSundry = "Предмет";

        public const string pName = "Name";
        public const string pCategory = "Category";
        public const string pWeight = "Weight";
        public const string pDescription = "Description";
        public const string pPrice = "Price";

        // === Броня ===
        public const string pArmorClass = "ArmorClass";
        public const string pArmorNormalDamageThreshold = "ArmorNormalDamageThreshold";
        public const string pArmorLaserDamageThreshold = "ArmorLaserDamageThreshold";
        public const string pArmorFireDamageThreshold = "ArmorFireDamageThreshold";
        public const string pArmorPlasmaDamageThreshold = "ArmorPlasmaDamageThreshold";
        public const string pArmorBlastDamageThreshold = "ArmorBlastDamageThreshold";
        public const string pArmorElectricDamageThreshold = "ArmorElectricDamageThreshold";
        public const string pArmorNormalDamageResistance = "ArmorNormalDamageResistance";
        public const string pArmorLaserDamageResistance = "ArmorLaserDamageResistance";
        public const string pArmorFireDamageResistance = "ArmorFireDamageResistance";
        public const string pArmorPlasmaDamageResistance = "ArmorPlasmaDamageResistance";
        public const string pArmorBlastDamageResistance = "ArmorBlastDamageResistance";
        public const string pArmorElectricDamageResistance = "ArmorElectricDamageResistance";

        // === Шлем ===
        public const string pHelmClass = "HelmClass";
        public const string pHelmNormalDamageThreshold = "HelmNormalDamageThreshold";
        public const string pHelmLaserDamageThreshold = "HelmLaserDamageThreshold";
        public const string pHelmFireDamageThreshold = "HelmFireDamageThreshold";
        public const string pHelmPlasmaDamageThreshold = "HelmPlasmaDamageThreshold";
        public const string pHelmBlastDamageThreshold = "HelmBlastDamageThreshold";
        public const string pHelmElectricDamageThreshold = "HelmElectricDamageThreshold";
        public const string pHelmNormalDamageResistance = "HelmNormalDamageResistance";
        public const string pHelmLaserDamageResistance = "HelmLaserDamageResistance";
        public const string pHelmFireDamageResistance = "HelmFireDamageResistance";
        public const string pHelmPlasmaDamageResistance = "HelmPlasmaDamageResistance";
        public const string pHelmBlastDamageResistance = "HelmBlastDamageResistance";
        public const string pHelmElectricDamageResistance = "HelmElectricDamageResistance";

        // === Оружие ===
        public const string pWeaponHandling = "WeaponHandling"; // одноручное, двуручное
        public const string pWeaponRange = "WeaponRange"; // дальность

        //Урон каждым типом
        public const string pWeaponNormalDamage = "WeaponNormalDamage"; //
        public const string pWeaponLaserDamage = "WeaponLaserDamage"; //
        public const string pWeaponPlasmaDamage = "WeaponPlasmaDamage"; //
        public const string pWeaponFireDamage = "WeaponFireDamage"; //
        public const string pWeaponBlastDamage = "WeaponBlastDamage"; //
        public const string pWeaponElectroDamage = "WeaponElectroDamage"; //

        public const string pWeaponAmmoType = "WeaponAmmoType"; // тип боеприпасов
        public const string pWeaponCage = "WeaponCage"; // патронов в обоймe
        public const string pWeaponBurstAmmo = "WeaponBurstAmmo"; // патронов в очереди
        public const string pWeaponTimeSingle = "WeaponTimeSingle"; // ОД на одиночный
        public const string pWeaponTimeAimed = "WeaponTimeAimed"; // ОД на прицельный
        public const string pWeaponTimeBurst = "WeaponTimeBurst"; // ОД на очередь
        public const string pWeaponComplexity = "WeaponComplexity"; // сложность

        //=== Ammo ===
        //Урон каждым типом
        public const string pAmmoNormalDamage = "AmmoNormalDamage"; //
        public const string pAmmoLaserDamage = "AmmoLaserDamage"; //
        public const string pAmmoPlasmaDamage = "AmmoPlasmaDamage"; //
        public const string pAmmoFireDamage = "AmmoFireDamage"; //
        public const string pAmmoBlastDamage = "AmmoBlastDamage"; //
        public const string pAmmoElectroDamage = "AmmoElectroDamage"; //

        public const string pAmmoArmorClassMod = "AmmoArmorClassMod"; // Изменение КБ

        //Изменение резистов каждого типа										!!! Это нужно? Или патроны дают изменение всех резистов сразу? Так можно делать специальные патроны
        public const string pAmmoNormalDamageResistanceMod = "AmmoNormalDamageResistanceMod"; //
        public const string pAmmoNormalDamageThresholdMod = "AmmoNormalDamageThresholdMod"; //
        public const string pAmmoLaserDamageResistanceMod = "AmmoLaserDamageResistanceMod"; //
        public const string pAmmoLaserDamageThresholdMod = "AmmoLaserDamageThresholdMod"; //
        public const string pAmmoFireDamageResistanceMod = "AmmoFireDamageResistanceMod"; //
        public const string pAmmoFireDamageThresholdMod = "AmmoFireDamageThresholdMod"; //
        public const string pAmmoPlasmaDamageResistanceMod = "AmmoPlasmaDamageResistanceMod"; //
        public const string pAmmoPlasmaDamageThresholdMod = "AmmoPlasmaDamageThresholdMod"; //
        public const string pAmmoBlastDamageResistanceMod = "AmmoBlastDamageResistanceMod"; //
        public const string pAmmoBlastDamageThresholdMod = "AmmoBlastDamageThresholdMod"; //
        public const string pAmmoElectroDamageResistanceMod = "AmmoElectroDamageResistanceMod"; //
        public const string pAmmoElectroDamageThresholdMod = "AmmoElectroDamageThresholdMod"; //

        public const string pAmmoBoxCount = "AmmoBoxCount"; //количество в одной упаковке                         !!! А что это даёт?

        //=== Medicine ===
        public const string pAdaption = "Adaption"; // привыкание

        //=== Mods ===
        //Всё описывается в Description?

        //=== Demolition ===
        public const string pDemolitionNormalDamage = "DemolitionNormalDamage"; //
        public const string pDemolitionLaserDamage = "DemolitionLaserDamage"; //
        public const string pDemolitionPlasmaDamage = "DemolitionPlasmaDamage"; //
        public const string pDemolitionFireDamage = "DemolitionFireDamage"; //
        public const string pDemolitionBlastDamage = "DemolitionBlastDamage"; //
        public const string pDemolitionElectroDamage = "DemolitionElectroDamage"; //
    }


    public enum ItemCategory
    {
        [Description("Неизвестно")]
        Unknown, /*Этот пункт всегда должен быть первым!!! 
                  * Присваивается если категория не совпадает с одной из перечисленных ниже*/

        [Description(AttributeName.cArmor)]
        Armor,
        [Description(AttributeName.cHelm)]
        Helm,
        [Description(AttributeName.cFullArmor)]
        FullArmor,
        [Description(AttributeName.cWeapon)]
        Weapon,
        [Description(AttributeName.cAmmo)]
        Ammo,
        [Description(AttributeName.cDemolition)]
        Demolition,
        [Description(AttributeName.cMod)]
        Mod,
        [Description(AttributeName.cMedicine)]
        Medicine,
        [Description(AttributeName.cSundry)]
        Sundry,

        Common, /*Этот пункт всегда должен быть предпоследним!!! 
                 * Эта категория только для свойств. Не должна фигурировать в предметах*/
        Count /*Этот пункт всегда должен быть последним!!!*/
    }

    #region CategoryExtensions

    public static class CategoryExtensions
    {
        public static string GetDescription<T>(this T enumerationValue)
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

    public class Attribute
    {
        public string Name;
        public ItemCategory Category;
        public string Value = string.Empty;

        public Attribute(Attribute property, string value)
        {


            Name = property.Name;
            Category = property.Category;
            Value = value;
        }

        public Attribute(string name, ItemCategory category)
        {
            Name = name;
            Category = category;
        }


    }

    public enum AttributesLists
    {
        ItemAttributes,
        CharacterAttributes,
        RaceAttributes
    }

    public class Attributes : IEnumerable<Attribute>
    {
        private List<Attribute> m_Properties;

        public Attributes(AttributesLists list)
        {
            switch (list)
            {
                case AttributesLists.ItemAttributes:
                    m_Properties = GetItemPropertiesList();
                    break;
            }

        }

        public Attribute this[string name]
        {
            get
            {
                foreach (var property in m_Properties)
                {
                    if (property.Name == name)
                    {
                        return property;
                    }
                }

                throw new NotImplementedException();
            }
            set
            {
                foreach (var property in m_Properties)
                {
                    if (property.Name == name)
                    {
                        property.Value = value.Value;
                        return;
                    }
                }

                throw new NotImplementedException();
            }
        }

        public static ItemCategory GetCategory(string sCategory)
        {
            for (int i = 0; i < (int)ItemCategory.Count - 1; i++) // Категория Common у Item`а идёт как Unknown, а Count вообще не должна быть назначена
            {
                var cat = (ItemCategory)i;
                if (cat.GetDescription() == sCategory)
                {
                    return cat;
                }
            }
            return ItemCategory.Unknown;
        }

        private static List<Attribute> GetItemPropertiesList()
        {
            var props = new List<Attribute>();

            /* Сюда доюавлять свойства. Имя свойства вбивается выше. Категории уже вбиты. 
             * Категорию "Броня со шлемом" заполнять не надо - там просто выводятся свойства брони и свойства шлема.*/

            //Common
            props.Add(new Attribute(AttributeName.pName, ItemCategory.Common));
            props.Add(new Attribute(AttributeName.pCategory, ItemCategory.Common));
            props.Add(new Attribute(AttributeName.pWeight, ItemCategory.Common));
            props.Add(new Attribute(AttributeName.pDescription, ItemCategory.Common));
            props.Add(new Attribute(AttributeName.pPrice, ItemCategory.Common));

            //Armor
            props.Add(new Attribute(AttributeName.pArmorClass, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorNormalDamageResistance, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorNormalDamageThreshold, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorLaserDamageResistance, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorLaserDamageThreshold, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorFireDamageResistance, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorFireDamageThreshold, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorPlasmaDamageResistance, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorPlasmaDamageThreshold, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorBlastDamageResistance, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorBlastDamageThreshold, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorElectricDamageResistance, ItemCategory.Armor));
            props.Add(new Attribute(AttributeName.pArmorElectricDamageThreshold, ItemCategory.Armor));

            //Helm
            props.Add(new Attribute(AttributeName.pHelmClass, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmNormalDamageResistance, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmNormalDamageThreshold, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmLaserDamageResistance, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmLaserDamageThreshold, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmFireDamageResistance, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmFireDamageThreshold, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmPlasmaDamageResistance, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmPlasmaDamageThreshold, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmBlastDamageResistance, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmBlastDamageThreshold, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmElectricDamageResistance, ItemCategory.Helm));
            props.Add(new Attribute(AttributeName.pHelmElectricDamageThreshold, ItemCategory.Helm));

            //Weapon
            // === Оружие ===
            props.Add(new Attribute(AttributeName.pWeaponHandling, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponRange, ItemCategory.Weapon));

            //Урон каждым типом
            props.Add(new Attribute(AttributeName.pWeaponNormalDamage, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponLaserDamage, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponPlasmaDamage, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponFireDamage, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponBlastDamage, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponElectroDamage, ItemCategory.Weapon));

            props.Add(new Attribute(AttributeName.pWeaponAmmoType, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponCage, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponBurstAmmo, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponTimeSingle, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponTimeAimed, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponTimeBurst, ItemCategory.Weapon));
            props.Add(new Attribute(AttributeName.pWeaponComplexity, ItemCategory.Weapon));

            //=== Ammo ===
            //Урон каждым типом
            props.Add(new Attribute(AttributeName.pAmmoNormalDamage, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoLaserDamage, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoPlasmaDamage, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoFireDamage, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoBlastDamage, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoElectroDamage, ItemCategory.Ammo));

            props.Add(new Attribute(AttributeName.pAmmoArmorClassMod, ItemCategory.Ammo));

            //Изменение резистов каждого типа									
            props.Add(new Attribute(AttributeName.pAmmoNormalDamageResistanceMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoNormalDamageThresholdMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoLaserDamageResistanceMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoLaserDamageThresholdMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoFireDamageResistanceMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoFireDamageThresholdMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoPlasmaDamageResistanceMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoPlasmaDamageThresholdMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoBlastDamageResistanceMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoBlastDamageThresholdMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoElectroDamageResistanceMod, ItemCategory.Ammo));
            props.Add(new Attribute(AttributeName.pAmmoElectroDamageThresholdMod, ItemCategory.Ammo));

            props.Add(new Attribute(AttributeName.pAmmoBoxCount, ItemCategory.Ammo));

            //=== Medicine ===
            props.Add(new Attribute(AttributeName.pAdaption, ItemCategory.Medicine));

            //=== Mods ===
            //Всё описывается в Description?

            //=== Demolition ===
            props.Add(new Attribute(AttributeName.pDemolitionNormalDamage, ItemCategory.Demolition));
            props.Add(new Attribute(AttributeName.pDemolitionLaserDamage, ItemCategory.Demolition));
            props.Add(new Attribute(AttributeName.pDemolitionPlasmaDamage, ItemCategory.Demolition));
            props.Add(new Attribute(AttributeName.pDemolitionFireDamage, ItemCategory.Demolition));
            props.Add(new Attribute(AttributeName.pDemolitionBlastDamage, ItemCategory.Demolition));
            props.Add(new Attribute(AttributeName.pDemolitionElectroDamage, ItemCategory.Demolition));

            return props;
        }

        #region IEnumerable<ItemProperty> Members

        public IEnumerator<Attribute> GetEnumerator()
        {
            return m_Properties.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_Properties.GetEnumerator();
        }

        #endregion
    }
}
