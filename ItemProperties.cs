using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using FalloutPNP_PipBoy.Properties;

namespace FalloutPNP_PipBoy
{
    public enum Category
    {
        [Description("Неизвестно")]
        Unknown, /*Этот пункт всегда должен быть первым!!! 
                  * Присваивается если категория не совпадает с одной из перечисленных ниже*/

        [Description("Броня")]
        Armor,
        [Description("Шлем")]
        Helm,
        [Description("Броня со шлемом")]
        FullArmor,
        [Description("Оружие")]
        Weapon,
        [Description("Аммуниция")]
        Ammo,
        [Description("Медицина")]
        Medicine,
        [Description("Модификация")]
        Mod,
        [Description("Взрывчатое в-во")]
        Demolition,
        [Description("Предмет")]
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

            //Common
            props.Add(new ItemProperty(Resources.sName, Category.Common));
            props.Add(new ItemProperty(Resources.sCategory, Category.Common));
            props.Add(new ItemProperty(Resources.sWeight, Category.Common));
            props.Add(new ItemProperty(Resources.sDescription, Category.Common));
            props.Add(new ItemProperty(Resources.sPrice, Category.Common));
            //props.Add(new ItemProperty(Resources., Category.Common));

            //Armor
            props.Add(new ItemProperty(Resources.sArmorClass, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorNormalDamageResistance, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorNormalDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorLaserDamageResistance, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorLaserDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorFireDamageResistance, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorFireDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorPlasmaDamageResistance, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorPlasmaDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorBlastDamageResistance, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorBlastDamageThreshold, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorElectricDamageResistance, Category.Armor));
            props.Add(new ItemProperty(Resources.sArmorElectricDamageThreshold, Category.Armor));
            
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
