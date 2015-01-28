
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using FalloutPNP_PipBoy.Properties;

namespace FalloutPNP_PipBoy.XmlCollections
{
    public class Races : XmlEntries, IEnumerable<Race>
    {
        private List<Race> m_Races;

        public Races(string path)
            : base(path)
        {
        }

        protected override void ReloadEntries()
        {
            m_Races = new List<Race>();

            var nodes = GetNodes("race", Resources.eRacesFileNotFound);
            foreach (var node in nodes)
            {
                var item = new Race();
                item.Load(node);
                m_Races.Add(item);
            }
        }

        public Race this[string name]
        {
            get
            {
                foreach (var race in m_Races)
                {
                    if (race.Name == name)
                    {
                        return race;
                    }
                }
                return null;
            }
        }

        #region IEnumerable<Race> Members

        public IEnumerator<Race> GetEnumerator()
        {
            return m_Races.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_Races.GetEnumerator();
        }

        #endregion
    }
}
