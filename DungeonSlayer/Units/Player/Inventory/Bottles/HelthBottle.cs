using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Player.Inventory
{
    class HelthBottle : Item
    {
        public HelthBottle()
        {
            name = "Склянка с жизнью";
        }

        public void Use()
        {
            Game.player.helth += 20;
            if (Game.player.helth > Game.player.maxHelth)
            {
                Game.player.helth = Game.player.maxHelth;
            }
        }
    }
}
