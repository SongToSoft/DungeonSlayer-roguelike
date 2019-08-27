namespace DungeonSlayer.Units.Players.Inventory.Bottles
{
    class ManaBottle : Item
    {
        public ManaBottle()
        {
            name = "Mana Bottle";
        }

        public override void Use()
        {
            Game.player.mana += 20;
            if (Game.player.mana > Game.player.maxMana)
            {
                Game.player.mana = Game.player.maxMana;
            }
        }

        public override string GetInfo()
        {
            return "Restores 20 mana" + ", Cost: " + cost;
        }
    }
}
