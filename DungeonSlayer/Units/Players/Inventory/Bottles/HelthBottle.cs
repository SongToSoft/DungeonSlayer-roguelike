using DungeonSlayer.Units.Players.Perks;

namespace DungeonSlayer.Units.Players.Inventory.Bottles
{
    class HelthBottle : Item
    {
        public HelthBottle()
        {
            name = "Helth Bottle";
            itemType = EItemType.ITEM;
        }

        public override void Use()
        {
            Game.player.helth += (20 + (Game.player.perksSystem.CheckPerk(PerksList.healPerk) ? 5 : 0));
            if (Game.player.helth > Game.player.maxHelth)
            {
                Game.player.helth = Game.player.maxHelth;
            }
        }

        public override string GetInfo()
        {
            return "Heal " + (20 + (Game.player.perksSystem.CheckPerk(PerksList.healPerk) ? 5 : 0)) + " health" + ", Cost: " + cost;
        }
    }
}
