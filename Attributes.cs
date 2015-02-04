using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using FalloutPNP_PipBoy.Dialogs.Properties;
using System.Xml;
using System.Xml.Linq;

namespace FalloutPNP_PipBoy.Dialogs
{
    public class Attributes
    {
        private XElement m_Element;
        public Attributes(XElement element)
        {
            m_Element = element;
        }

        public string this[string name]
        {
            get
            {
                var attr = m_Element.Attribute(name);
                if (attr == null)
                {
                    return string.Empty;
                }
                return attr.Value;
            }
            set
            {
                var attr = m_Element.Attribute(name);
                if (attr == null)
                {
                    m_Element.Add(new XAttribute(name, value));
                    return;
                }
                attr.Value = value;
            }
        }

        public int GetInt(string name)
        {
            var attr = m_Element.Attribute(name);
            if (attr == null)
            {
                return 0;
            }
            int result;
            if (!int.TryParse(attr.Value, out result))
            {
                return 0;
            }
            return result;
        }
    }
}
