using DungeonSlayer.Units.Players.Inventory;
using DungeonSlayer.Units.Players.Perks;
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
            var item = ItemsList.GetItemByLvl(Game.maxDungeonLevel + (Game.player.perksSystem.CheckPerk(PerksList.luckPerk) ? 2 : 0));
            StatusLine.AddLine(" " + " You got in the chest: " + item.name);
            return item;
        }
    }
}
