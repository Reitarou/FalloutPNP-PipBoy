using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;
using FalloutPNP_PipBoy.Params;

namespace FalloutPNP_PipBoy
{
    public class Char
    {
        private bool m_RefreshCache = true;
        private Race m_Race;
        private Stats m_DistributedStats;

        public Char(Race race)
        {
            m_Race = race;
        }

        public Char(StgNode node)
        {
        }

        public void SaveToStg()
        {
        }
    }
}
