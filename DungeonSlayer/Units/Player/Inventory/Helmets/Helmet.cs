using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Player.Inventory
{
    class Helmet : Item
    {
        public int blockingValue;
        public Vector3 increasingStats;

        public Helmet(string _name, int _blockingValue, Vector3 _increasingStats)
        {
            name = _name;
            blockingValue = _blockingValue;
            increasingStats = _increasingStats;
        }

        public string GetInfo()
        {
            return " Защита: " + blockingValue +
                   ", Увеличение характеристик: S - " + increasingStats.X +
                   ", A - " + increasingStats.Y +
                   ", I - " + increasingStats.Z + '\n';
        }
    }
}
