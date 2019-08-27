using DungeonSlayer.Units.Players.Inventory.Armores;
using DungeonSlayer.Units.Players.Inventory.Bottles;
using DungeonSlayer.Units.Players.Inventory.Helmets;
using DungeonSlayer.Units.Players.Inventory.Weapons;
using System.Collections.Generic;
using System.Numerics;

namespace DungeonSlayer.Units.Players.Inventory
{
    static class ItemsList
    {
        static public HelthBottle helthBottle = new HelthBottle();
        static public ManaBottle manaBottle = new ManaBottle();

        static public Armor castoffs = new Armor("Сastoffs", 0, new Vector3(0, 0, 0), 1, 0);
        static public Armor ironArmor = new Armor("Iron Armor", 4, new Vector3(0, 0, 0), 20, 2);
        static public Armor stealArmor = new Armor("Steal Armor", 6, new Vector3(0, 0, 0), 35, 4);
        static public Armor leatherArmor = new Armor("Leather Armor", 2, new Vector3(0, 1, 0), 15, 4);
        static public Armor elvenArmor = new Armor("Elven Armor", 7, new Vector3(0, 3, 1), 50, 6);
        static public Armor dwarfsArmor = new Armor("Dwarfs Armor", 10, new Vector3(3, 0, -2), 55, 8);
        static public Armor obsidianArmor = new Armor("Obsidian Armor", 11, new Vector3(2, 0, 0), 70, 10);

        static public Helmet wellWornHood = new Helmet("Well-worn Hood", 0, new Vector3(0, 0, 0), 1, 0);
        static public Helmet ironHelmet = new Helmet("Iron Helmet", 2, new Vector3(0, 0, 0), 13, 2);
        static public Helmet stealHelmet = new Helmet("Steal Helmet", 3, new Vector3(0, 0, 0), 20, 4);
        static public Helmet leatherHelmet = new Helmet("Leather Helmet", 1, new Vector3(0, 0, 0), 10, 4);
        static public Helmet elvenHelmet = new Helmet("Elven Helmet", 3, new Vector3(0, 0, 1), 25, 6);
        static public Helmet dwarfsHelmet = new Helmet("Dwarfs Helmet", 4, new Vector3(1, 0, -1), 28, 8);
        static public Helmet obsidianHelmet = new Helmet("Obsidian Helmet", 4, new Vector3(1, 0, 0), 30, 10);

        static public Weapon workGloves = new Weapon("Work Gloves", 1, 95, 1, EWeaponType.HAND, new Vector3(0, 0, 0), 1, 0);
        static public Weapon ironSword = new Weapon("Iron Sword", 4, 90, 5, EWeaponType.SWORD, new Vector3(0, 0, 0), 10, 2);
        static public Weapon ironDagger = new Weapon("Iron Dagger", 3, 92, 8, EWeaponType.DAGGER, new Vector3(0, 0, 0), 14, 3);
        static public Weapon ironSpear = new Weapon("Iron Spear", 3, 70, 15, EWeaponType.SPEAR, new Vector3(0, 0, 0), 13, 2);
        static public Weapon ironMace = new Weapon("Iron Mace", 4, 80, 9, EWeaponType.MACE, new Vector3(0, 0, 0), 14, 2);
        static public Weapon ironAxe = new Weapon("Iron Axe", 5, 85, 4, EWeaponType.AXE, new Vector3(0, 0, 0), 15, 4);
        static public Weapon woodStaff = new Weapon("Wood Staff", 2, 90, 2, EWeaponType.STAFF, new Vector3(0, 0, 0), 11, 4);

        static public List<Item> items = new List<Item>
        {
            helthBottle,
            manaBottle,
            castoffs,
            ironArmor,
            stealArmor,
            leatherArmor,
            elvenArmor,
            dwarfsArmor,
            obsidianArmor,
            wellWornHood,
            stealHelmet,
            leatherHelmet,
            elvenHelmet,
            dwarfsHelmet,
            obsidianHelmet,
            workGloves,
            ironSword,
            ironDagger,
            ironSpear,
            ironMace,
            ironAxe,
            woodStaff
        };

        static public Item GetItemByName(string name)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                if (items[i].name == name)
                {
                    return items[i];
                }
            }
            return items[0];
        }

        static public Item GetItemByLvl(int lvl)
        {
            int itemIndex = DungeonGenerator.random.Next(0, items.Count - 1);
            do
            {
                itemIndex = DungeonGenerator.random.Next(0, items.Count - 1);
                if ((items[itemIndex].level <= lvl) && (items[itemIndex].level > 0))
                {
                    return items[itemIndex];
                }
            }
            while (items[itemIndex].level != lvl);
            return items[0];
        }

    }
}
