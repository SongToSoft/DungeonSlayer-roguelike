namespace DungeonSlayer.Units.Players.Inventory.Bottles
{
    class HelthBottle : Item
    {
        public HelthBottle()
        {
            name = "Helth Bottle";
        }

        public override void Use()
        {
            Game.player.helth += 20;
            if (Game.player.helth > Game.player.maxHelth)
            {
                Game.player.helth = Game.player.maxHelth;
            }
        }

        public override string GetInfo()
        {
            return "Heal 20 health" + ", Cost: " + cost;
        }
    }
}
