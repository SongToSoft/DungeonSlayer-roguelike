using System.Numerics;

namespace DungeonSlayer.Units.Players.Inventory.Weapons
{
    enum EWeaponType
    {
        SWORD,
        DAGGER,
        STAFF,
        KATANA,
        MACE,
        SPEAR,
        HAND,
        AXE
    }

    class Weapon : Item
    {
        public int attack;
        public int accuracy;
        public int criticalChance;
        public EWeaponType type;
        public Vector3 increasingStats;

        public Weapon(string _name, int _attack, int _accuracy, int _criticalChance, EWeaponType _type, Vector3 _increasingStats, int _cost, int _level)
        {
            name = _name;
            attack = _attack;
            type = _type;
            increasingStats = _increasingStats;
            accuracy = _accuracy;
            criticalChance = _criticalChance;
            cost = _cost;
            level = _level;
            itemType = EItemType.WEAPON;
        }

        public override void Use()
        {
            Game.player.inventory.AddItem(Game.player.inventory.activeWeapon);
            Game.player.inventory.SetActiveWeapon(this);
        }

        public override string GetInfo()
        {
            return " Type: " + type +
                   ", Attack: " + attack + ", Cost: " + cost +
                   ", Accuracy: " + accuracy + ", Critical Chance: " + criticalChance +
                   ", Increasing Stats: S - " + increasingStats.X +
                   ", A - " + increasingStats.Y +
                   ", I - " + increasingStats.Z;
        }
    }
}
