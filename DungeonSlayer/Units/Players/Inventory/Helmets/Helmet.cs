using System.Numerics;

namespace DungeonSlayer.Units.Players.Inventory.Helmets
{
    class Helmet : Item
    {
        public int blockingValue;
        public Vector3 increasingStats;

        public Helmet(string _name, int _blockingValue, Vector3 _increasingStats, int _cost, int _level)
        {
            name = _name;
            blockingValue = _blockingValue;
            increasingStats = _increasingStats;
            cost = _cost;
            level = _level;
            itemType = EItemType.HELMET;
        }

        public override void Use()
        {
            if (Game.player.specification.race != ERaсe.MINOTAUR)
            {
                Game.player.inventory.AddItem(Game.player.inventory.activeHelmet);
                Game.player.inventory.SetActiveHelmet(this);
            }
        }

        public override string GetInfo()
        {
            return " Defense: " + blockingValue + ", Cost: " + cost +
                   ", Increasing Stats: S - " + increasingStats.X +
                   ", A - " + increasingStats.Y +
                   ", I - " + increasingStats.Z;
        }
    }
}
