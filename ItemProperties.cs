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
            //props.Add(new ItemProperty(Resources., Category.));
            var props = new List<ItemProperty>();

            /* Сюда доюавлять свойства. Имя свойства вбивается выше. Категории уже вбиты. 
             * Категорию "Броня со шлемом" заполнять не надо - там просто выводятся свойства брони и свойства шлема.*/

            //Common
            props.Add(new ItemProperty(PropertyName.pName, Category.Common));
            props.Add(new ItemProperty(PropertyName.pCategory, Category.Common));
            props.Add(new ItemProperty(PropertyName.pWeight, Category.Common));
            props.Add(new ItemProperty(PropertyName.pDescription, Category.Common));
            props.Add(new ItemProperty(PropertyName.pPrice, Category.Common));
            //props.Add(new ItemProperty(Resources., Category.Common));

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
            
            //props.Add(new ItemProperty(Resources., Category.Armor));

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
