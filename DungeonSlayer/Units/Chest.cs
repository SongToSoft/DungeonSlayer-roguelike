using DungeonSlayer.Units.Players.Inventory;
using System;

namespace DungeonSlayer.Units
{
    class Chest : Unit
    {
        public bool active = true;

        public Chest()
        {
            form = 'C';
            color = ConsoleColor.Yellow;
        }

        public Item GetBounty()
        {
            active = false;
            var item = ItemsList.GetItemByLvl(Game.maxDungeonLevel);
            StatusLine.AddLine(" " + " You got in the chest: " + item.name + "\n");
            return ItemsList.GetItemByLvl(Game.maxDungeonLevel);
        }
    }
}
