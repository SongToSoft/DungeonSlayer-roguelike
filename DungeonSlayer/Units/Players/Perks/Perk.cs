using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Players.Perks
{
    class Perk
    {
        public EPerkValue value;
        public string info;
        public int level;

        public Perk(EPerkValue _value, string _info, int _level)
        {
            value = _value;
            info = _info;
            level = _level;
        }
    }
}
