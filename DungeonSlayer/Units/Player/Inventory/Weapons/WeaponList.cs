using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Player.Inventory.Weapons
{
    static class WeaponList
    {
        static public Weapon bareHands = new Weapon("Голые руки", 1, 95, 1, EWeaponType.HAND, new Vector3(0, 0, 0));
        static public Weapon ironSword = new Weapon("Железный меч", 4, 90, 5, EWeaponType.SWORD, new Vector3(0, 0, 0));
        static public Weapon ironDagger = new Weapon("Железный кинжал", 3, 92, 8, EWeaponType.DAGGER, new Vector3(0, 0, 0));
        static public Weapon ironSpear = new Weapon("Железное копьё", 3, 70, 15, EWeaponType.SPEAR, new Vector3(0, 0, 0));
        static public Weapon ironMace = new Weapon("Железная булава", 4, 80, 9, EWeaponType.MACE, new Vector3(0, 0, 0));
        static public Weapon ironAxe = new Weapon("Железный топор", 5, 85, 4, EWeaponType.AXE, new Vector3(0, 0, 0));
        static public Weapon woodStaff = new Weapon("Деревянный посох", 2, 90, 2, EWeaponType.STAFF, new Vector3(0, 0, 0));
    }
}
