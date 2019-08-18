using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Player.Inventory
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

        public Weapon(string _name, int _attack, int _accuracy, int _criticalChance, EWeaponType _type, Vector3 _increasingStats)
        {
            name = _name;
            attack = _attack;
            type = _type;
            increasingStats = _increasingStats;
            accuracy = _accuracy;
            criticalChance = _criticalChance;
        }

        public override void Use()
        {
            Game.player.inventory.AddItem(Game.player.inventory.activeWeapon);
            Game.player.inventory.SetActiveWeapon(this);
        }

        public override string GetInfo()
        {
            return " Тип: " + type +
                   ", Атака: " + attack +
                   ", Увеличение характеристик: S - " + increasingStats.X +
                   ", A - " + increasingStats.Y +
                   ", I - " + increasingStats.Z;
        }
    }
}
