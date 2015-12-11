using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;

namespace FalloutPNP_PipBoy.Params
{
    public class Race
    {
        public Stats MinStats;
        public Stats InitialStats;
        public Stats MaxStats;
        public string Name;

        public Race(StgNode node)
        {
            MinStats = new Stats(node.GetNode("MinStats"));
            InitialStats = new Stats(node.GetNode("IniStats"));
            MaxStats = new Stats(node.GetNode("MaxStats"));
            Name = node.GetString("Name", "");
        }
    }
}
