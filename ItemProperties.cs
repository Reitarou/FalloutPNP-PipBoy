using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using FalloutPNP_PipBoy.Properties;

namespace FalloutPNP_PipBoy
{
    public static class PropertyName
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


    public enum Category
    {
        [Description("Неизвестно")]
        Unknown, /*Этот пункт всегда должен быть первым!!! 
                  * Присваивается если категория не совпадает с одной из перечисленных ниже*/

        [Description(PropertyName.cArmor)]
        Armor,
        [Description(PropertyName.cHelm)]
        Helm,
        [Description(PropertyName.cFullArmor)]
        FullArmor,
        [Description(PropertyName.cWeapon)]
        Weapon,
        [Description(PropertyName.cAmmo)]
        Ammo,
        [Description(PropertyName.cDemolition)]
        Demolition,
        [Description(PropertyName.cMod)]
        Mod,
        [Description(PropertyName.cMedicine)]
        Medicine,
        [Description(PropertyName.cSundry)]
        Sundry,

        Common, /*Этот пункт всегда должен быть предпоследним!!! 
                 * Эта категория только для свойств. Не должна фигурировать в предметах*/
        Count /*Этот пункт всегда должен быть последним!!!*/
    }

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

    public class ItemProperty
    {
        public string Name;
        public Category Category;
        public string Value = string.Empty;

        public ItemProperty(ItemProperty property, string value)
        {
            Name = property.Name;
            Category = property.Category;
            Value = value;
        }

        public ItemProperty(string name, Category category)
        {
            Name = name;
            Category = category;
        }


    }

    public class ItemProperties : IEnumerable<ItemProperty>
    {
        private List<ItemProperty> m_Properties;

        public ItemProperties()
        {
            m_Properties = GetAllPropertiesList();
        }

        public ItemProperty this[string name]
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

        public static Category GetCategory(string sCategory)
        {
            for (int i = 0; i < (int)Category.Count - 1; i++) // Категория Common у Item`а идёт как Unknown, а Count вообще не должна быть назначена
            {
                var cat = (Category)i;
                if (cat.GetDescription() == sCategory)
                {
                    return cat;
                }
            }
            return Category.Unknown;
        }

        private static List<ItemProperty> GetAllPropertiesList()
        {
            var props = new List<ItemProperty>();

            /* Сюда доюавлять свойства. Имя свойства вбивается выше. Категории уже вбиты. 
             * Категорию "Броня со шлемом" заполнять не надо - там просто выводятся свойства брони и свойства шлема.*/

            //Common
            props.Add(new ItemProperty(PropertyName.pName, Category.Common));
            props.Add(new ItemProperty(PropertyName.pCategory, Category.Common));
            props.Add(new ItemProperty(PropertyName.pWeight, Category.Common));
            props.Add(new ItemProperty(PropertyName.pDescription, Category.Common));
            props.Add(new ItemProperty(PropertyName.pPrice, Category.Common));

            //Armor
            props.Add(new ItemProperty(PropertyName.pArmorClass, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorNormalDamageResistance, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorNormalDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorLaserDamageResistance, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorLaserDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorFireDamageResistance, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorFireDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorPlasmaDamageResistance, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorPlasmaDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorBlastDamageResistance, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorBlastDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorElectricDamageResistance, Category.Armor));
            props.Add(new ItemProperty(PropertyName.pArmorElectricDamageThreshold, Category.Armor));

            //Helm
            props.Add(new ItemProperty(PropertyName.pHelmClass, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmNormalDamageResistance, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmNormalDamageThreshold, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmLaserDamageResistance, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmLaserDamageThreshold, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmFireDamageResistance, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmFireDamageThreshold, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmPlasmaDamageResistance, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmPlasmaDamageThreshold, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmBlastDamageResistance, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmBlastDamageThreshold, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmElectricDamageResistance, Category.Helm));
            props.Add(new ItemProperty(PropertyName.pHelmElectricDamageThreshold, Category.Helm));

            //Weapon
            // === Оружие ===
            props.Add(new ItemProperty(PropertyName.pWeaponHandling, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponRange, Category.Weapon));

            //Урон каждым типом
            props.Add(new ItemProperty(PropertyName.pWeaponNormalDamage, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponLaserDamage, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponPlasmaDamage, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponFireDamage, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponBlastDamage, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponElectroDamage, Category.Weapon));

            props.Add(new ItemProperty(PropertyName.pWeaponAmmoType, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponCage, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponBurstAmmo, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponTimeSingle, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponTimeAimed, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponTimeBurst, Category.Weapon));
            props.Add(new ItemProperty(PropertyName.pWeaponComplexity, Category.Weapon));

            //=== Ammo ===
            //Урон каждым типом
            props.Add(new ItemProperty(PropertyName.pAmmoNormalDamage, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoLaserDamage, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoPlasmaDamage, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoFireDamage, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoBlastDamage, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoElectroDamage, Category.Ammo));

            props.Add(new ItemProperty(PropertyName.pAmmoArmorClassMod, Category.Ammo));

            //Изменение резистов каждого типа									
            props.Add(new ItemProperty(PropertyName.pAmmoNormalDamageResistanceMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoNormalDamageThresholdMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoLaserDamageResistanceMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoLaserDamageThresholdMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoFireDamageResistanceMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoFireDamageThresholdMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoPlasmaDamageResistanceMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoPlasmaDamageThresholdMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoBlastDamageResistanceMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoBlastDamageThresholdMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoElectroDamageResistanceMod, Category.Ammo));
            props.Add(new ItemProperty(PropertyName.pAmmoElectroDamageThresholdMod, Category.Ammo));

            props.Add(new ItemProperty(PropertyName.pAmmoBoxCount, Category.Ammo));

            //=== Medicine ===
            props.Add(new ItemProperty(PropertyName.pAdaption, Category.Medicine));

            //=== Mods ===
            //Всё описывается в Description?

            //=== Demolition ===
            props.Add(new ItemProperty(PropertyName.pDemolitionNormalDamage, Category.Demolition));
            props.Add(new ItemProperty(PropertyName.pDemolitionLaserDamage, Category.Demolition));
            props.Add(new ItemProperty(PropertyName.pDemolitionPlasmaDamage, Category.Demolition));
            props.Add(new ItemProperty(PropertyName.pDemolitionFireDamage, Category.Demolition));
            props.Add(new ItemProperty(PropertyName.pDemolitionBlastDamage, Category.Demolition));
            props.Add(new ItemProperty(PropertyName.pDemolitionElectroDamage, Category.Demolition));

            return props;
        }

        #region IEnumerable<ItemProperty> Members

        public IEnumerator<ItemProperty> GetEnumerator()
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
