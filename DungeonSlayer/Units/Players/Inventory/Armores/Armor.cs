using DungeonSlayer.Units.Players.Inventory.Helmets;
using System.Numerics;

namespace DungeonSlayer.Units.Players.Inventory.Armores
{
    class Armor : Helmet
    {
        public Armor(string _name, int _blockingValue, Vector3 _increasingStats, int _cost, int _level) :
                    base(_name, _blockingValue, _increasingStats, _cost, _level)
        {
            itemType = EItemType.ARMOR;
        }

        public override void Use()
        {
            if (Game.player.specification.race != ERaсe.MINOTAUR)
            {
                Game.player.inventory.AddItem(Game.player.inventory.activeArmor);
                Game.player.inventory.SetActiveArmor(this);
            }
        }

        public override string GetInfo()
        {
            return " Defense: " + blockingValue + ", Cost: " + cost +
                   ", Increasing Helth - " + increasingStats.X +
                   ", Increasing Evasion - " + increasingStats.Y +
                   ", Increasing Spell Power - " + increasingStats.Z;
        }
    }
}
