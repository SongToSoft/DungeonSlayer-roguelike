using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Player.Inventory
{
    class ManaBottle : Item
    {
        public ManaBottle()
        {
            name = "Склянка с маной";
        }

        public void Use()
        {
            Game.player.mana += 20;
            if (Game.player.mana > Game.player.maxMana)
            {
                Game.player.mana = Game.player.maxMana;
            }
        }
    }
}
