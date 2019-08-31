using DungeonSlayer.Units.Players.Perks;

namespace DungeonSlayer.Units.Players.Inventory.Bottles
{
    class ManaBottle : Item
    {
        public ManaBottle()
        {
            name = "Mana Bottle";
            itemType = EItemType.ITEM;
        }

        public override void Use()
        {
            Game.player.mana += (20 + (Game.player.perksSystem.CheckPerk(PerksList.healPerk) ? 5 : 0));
            if (Game.player.mana > Game.player.maxMana)
            {
                Game.player.mana = Game.player.maxMana;
            }
        }

        public override string GetInfo()
        {
            return "Restores " + (20 + (Game.player.perksSystem.CheckPerk(PerksList.healPerk) ? 5 : 0)) + " mana" + ", Cost: " + cost;
        }
    }
}
