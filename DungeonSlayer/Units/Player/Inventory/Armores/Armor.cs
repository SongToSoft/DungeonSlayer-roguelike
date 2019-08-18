using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Player.Inventory
{
    class Armor : Helmet
    {
        public Armor(string _name, int _blockingValue, Vector3 _increasingStats) :
                    base(_name, _blockingValue, _increasingStats)
        {
        }

        public override void Use()
        {
            Game.player.inventory.AddItem(Game.player.inventory.activeArmor);
            Game.player.inventory.SetActiveArmor(this);
        }

        public override string GetInfo()
        {
            return " Защита: " + blockingValue +
                   ", Увеличение характеристик: S - " + increasingStats.X +
                   ", A - " + increasingStats.Y +
                   ", I - " + increasingStats.Z;
        }
    }
}
