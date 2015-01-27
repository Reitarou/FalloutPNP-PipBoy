
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
    class Races : IEnumerable<Race>
    {
        private string m_RacesPath;
        private List<Race> m_Races;

        public Races(string path)
        {
            m_RacesPath = path;
            ReloadRaces();
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

        public void ReloadRaces()
        {
            m_Races = new List<Race>();

            var fp = m_RacesPath;
            if (!File.Exists(fp))
            {
                //XmlTextWriter xtw = new XmlTextWriter(fp, Encoding.UTF8);
                //xtw.WriteStartDocument();
                //xtw.WriteStartElement("races");
                //xtw.WriteEndDocument();
                //xtw.Close();
                MessageBox.Show(Resources.eRacesFileNotFound);
            }

            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read);
            xd.Load(fs);
            var nRaces = xd.GetElementsByTagName("race");
            for (int i = 0; i < nRaces.Count; i++)
            {
                var nRace = nRaces[i];
                m_Races.Add(new Race(nRace));
            }
            fs.Close();
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
