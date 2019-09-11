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

        static public Armor withoutArmor = new Armor("Without Armor", 0, new Vector3(0, 0, 0), 0, 0);
        static public Armor castoffs = new Armor("Сastoffs", 0, new Vector3(0, 0, 0), 1, 0);
        static public Armor ironArmor = new Armor("Iron Armor", 4, new Vector3(0, 0, 0), 50, 2);
        static public Armor robeStudent = new Armor("Robe Student", 0, new Vector3(0, 0, 2), 55, 3);
        static public Armor goblinArmor = new Armor("Goblin clothes", 2, new Vector3(0, 1, 1), 60, 3);
        static public Armor leatherArmor = new Armor("Leather Armor", 2, new Vector3(0, 1, 0), 70, 4);
        static public Armor trollArmor = new Armor("Troll clothes", 2, new Vector3(2, 2, 0), 80, 6);
        static public Armor stealArmor = new Armor("Steal Armor", 6, new Vector3(0, 0, 0), 100, 7);
        static public Armor elvenArmor = new Armor("Elven Armor", 7, new Vector3(0, 3, 1), 110, 7);
        static public Armor dwarfsArmor = new Armor("Dwarfs Armor", 10, new Vector3(3, 0, 0), 120, 8);
        static public Armor orkArmor = new Armor("Ork Armor", 9, new Vector3(4, 0, 0), 170, 9);
        static public Armor hunterArmor = new Armor("Hunter Armor", 7, new Vector3(1, 2, 2), 180, 9);
        static public Armor robeBachelor = new Armor("Robe Bachelor", 2, new Vector3(0, 0, 4), 190, 9);
        static public Armor obsidianArmor = new Armor("Obsidian Armor", 11, new Vector3(2, 0, 0), 220, 10);
        static public Armor elementsArmor = new Armor("Elements Armor", 8, new Vector3(2, 2, 2), 250, 11);
        static public Armor robeMaster = new Armor("Robe Master", 4, new Vector3(1, 1, 6), 270, 14);
        static public Armor dvemerArmor = new Armor("Dvemer Armor", 14, new Vector3(0, 0, 1), 350, 15);
        static public Armor demonicArmor = new Armor("Demonic Armor", 16, new Vector3(4, 2, 2), 500, 20);
        static public Armor angelArmor = new Armor("Angel Armor", 18, new Vector3(3, 3, 1), 500, 20);
        static public Armor diabloArmor = new Armor("Diablo Armor", 20, new Vector3(4, 4, 4), 800, 25);
        static public Armor godArmor = new Armor("God Armor", 23, new Vector3(3, 3, 4), 800, 25);

        static public Helmet withoutHelmet = new Helmet("Without Helmet", 0, new Vector3(0, 0, 0), 0, 0);
        static public Helmet wellWornHood = new Helmet("Well-worn Hood", 0, new Vector3(0, 0, 0), 1, 0);
        static public Helmet ironHelmet = new Helmet("Iron Helmet", 2, new Vector3(0, 0, 0), 35, 2);
        static public Helmet hoodStudent = new Helmet("Hood Student", 0, new Vector3(0, 0, 1), 50, 3);
        static public Helmet goblinHelmet = new Helmet("Goblin Helmet", 1, new Vector3(0, 1, 0), 45, 3);
        static public Helmet leatherHelmet = new Helmet("Leather Helmet", 1, new Vector3(0, 0, 0), 55, 4);
        static public Helmet trollHelmet = new Helmet("Troll Helmet", 1, new Vector3(1, 1, 0), 70, 6);
        static public Helmet stealHelmet = new Helmet("Steal Helmet", 4, new Vector3(0, 0, 0), 85, 7);
        static public Helmet elvenHelmet = new Helmet("Elven Helmet", 5, new Vector3(0, 2, 0), 90, 7);
        static public Helmet dwarfsHelmet = new Helmet("Dwarfs Helmet", 6, new Vector3(2, 0, 0), 100, 8);
        static public Helmet orkHelmet = new Helmet("Ork Helmet", 7, new Vector3(2, 0, 0), 130, 9);
        static public Helmet hunterHelmet = new Helmet("Hunter Helmet", 5, new Vector3(0, 1, 1), 140, 9);
        static public Helmet hoodBachelor = new Helmet("Hood Bachelor", 1, new Vector3(0, 0, 2), 150, 9);
        static public Helmet obsidianHelmet = new Helmet("Obsidian Helmet", 8, new Vector3(1, 0, 0), 160, 10);
        static public Helmet elementsHelmet = new Helmet("Elements Helmet", 6, new Vector3(1, 1, 1), 180, 11);
        static public Helmet hoodMaster = new Helmet("Hood Master", 2, new Vector3(0, 0, 4), 280, 14);
        static public Helmet dvemerHelmet = new Helmet("Dvemer Helmet", 12, new Vector3(0, 0, 0), 300, 15);
        static public Helmet demonicHelmet = new Helmet("Demonic Helmet", 14, new Vector3(2, 1, 1), 4500, 20);
        static public Helmet angelHelmet = new Helmet("Angel Helmet", 15, new Vector3(2, 2, 0), 4500, 20);
        static public Helmet diabloHelmet = new Helmet("Diablo Helmet", 17, new Vector3(2, 2, 2), 700, 25);
        static public Helmet godHelmet = new Helmet("God Helmet", 20, new Vector3(2, 2, 3), 700, 25);

        static public Weapon workGloves = new Weapon("Work Gloves", 1, 95, 1, EWeaponType.HAND, 1, 0);
        static public Weapon ironSword = new Weapon("Iron Sword", 4, 90, 5, EWeaponType.SWORD, 30, 2);
        static public Weapon ironSpear = new Weapon("Iron Spear", 3, 70, 15, EWeaponType.SPEAR, 35, 2);
        static public Weapon ironMace = new Weapon("Iron Mace", 4, 80, 9, EWeaponType.MACE, 40, 2);
        static public Weapon ironDagger = new Weapon("Iron Dagger", 3, 92, 8, EWeaponType.DAGGER, 40, 3);
        static public Weapon ironAxe = new Weapon("Iron Axe", 5, 85, 4, EWeaponType.AXE, 55, 4);
        static public Weapon woodStaff = new Weapon("Wood Staff", 2, 90, 2, EWeaponType.STAFF, 45, 4);

        static public Weapon stealSword = new Weapon("Steal Sword", 5, 90, 5, EWeaponType.SWORD, 80, 4);
        static public Weapon stealSpear = new Weapon("Steal Spear", 4, 70, 15, EWeaponType.SPEAR, 75, 5);
        static public Weapon stealMace = new Weapon("Steal Mace", 5, 80, 9, EWeaponType.MACE, 80, 4);
        static public Weapon stealDagger = new Weapon("Steal Dagger", 4, 92, 8, EWeaponType.DAGGER, 75, 5);
        static public Weapon stealAxe = new Weapon("Steal Axe", 6, 85, 4, EWeaponType.AXE, 80, 6);
        static public Weapon oakStaff = new Weapon("Oak Staff", 3, 90, 2, EWeaponType.STAFF, 75, 6);

        static public Weapon elvenSword = new Weapon("Elven Sword", 6, 90, 5, EWeaponType.SWORD, 80, 7);
        static public Weapon elvenSpear = new Weapon("Elven Spear", 5, 70, 15, EWeaponType.SPEAR, 90, 8);
        static public Weapon elvenMace = new Weapon("Elven Mace", 6, 80, 9, EWeaponType.MACE, 110, 7);
        static public Weapon elvenDagger = new Weapon("Elven Dagger", 5, 92, 8, EWeaponType.DAGGER, 100, 8);
        static public Weapon elvenAxe = new Weapon("Elven Axe", 7, 85, 4, EWeaponType.AXE, 100, 9);
        static public Weapon magicStaff = new Weapon("Magic Staff", 4, 90, 2, EWeaponType.STAFF, 120, 9);

        static public Weapon dwarfsSword = new Weapon("Dwarfs Sword", 7, 90, 5, EWeaponType.SWORD, 120, 7);
        static public Weapon dwarfsSpear = new Weapon("Dwarfs Spear", 6, 70, 15, EWeaponType.SPEAR, 130, 8);
        static public Weapon dwarfsMace = new Weapon("Dwarfs Mace", 7, 80, 9, EWeaponType.MACE, 140, 7);
        static public Weapon dwarfsDagger = new Weapon("Dwarfs Dagger", 6, 92, 8, EWeaponType.DAGGER, 140, 8);
        static public Weapon dwarfsAxe = new Weapon("Dwarfs Axe", 9, 85, 4, EWeaponType.AXE, 120, 9);

        static public Weapon orkMace = new Weapon("Ork Mace", 8, 80, 11, EWeaponType.MACE, 190, 9);
        static public Weapon orkAxe = new Weapon("Ork Axe", 10, 85, 7, EWeaponType.AXE, 180, 10);
        static public Weapon trollSpear = new Weapon("Troll Spear", 7, 70, 18, EWeaponType.SPEAR, 230, 11);
        static public Weapon archmagicStaff = new Weapon("Archmagic Staff", 5, 90, 2, EWeaponType.STAFF, 250, 13);
        static public Weapon elemetsDagger = new Weapon("Elemets Dagger", 6, 92, 8, EWeaponType.DAGGER, 270, 15);
        static public Weapon dvemerMace = new Weapon("Dvemer Mace", 9, 80, 9, EWeaponType.MACE, 300, 16);
        static public Weapon demonSword = new Weapon("Demon Sword", 9, 90, 5, EWeaponType.SWORD, 350, 17);
        static public Weapon angelSword = new Weapon("Angel Sword", 9, 90, 5, EWeaponType.SWORD, 350, 17);
        static public Weapon diabloSword = new Weapon("Dablo Sword", 15, 90, 5, EWeaponType.SWORD, 450, 20);
        static public Weapon godSword = new Weapon("God Sword", 14, 90, 5, EWeaponType.SWORD, 450, 20);
        static public Weapon namelessStaff = new Weapon("Nameless Staff", 7, 90, 2, EWeaponType.STAFF, 700, 22);

        static public List<Item> items = new List<Item>
        {
            helthBottle,
            manaBottle,
            withoutArmor,
            castoffs,
            ironArmor,
            robeStudent,
            goblinArmor,
            leatherArmor,
            trollArmor,
            stealArmor,
            elvenArmor,
            dwarfsArmor,
            orkArmor,
            hunterArmor,
            robeBachelor,
            obsidianArmor,
            elementsArmor,
            robeMaster,
            dvemerArmor,
            demonicArmor,
            angelArmor,
            diabloArmor,
            godArmor,
            withoutHelmet,
            wellWornHood,
            ironHelmet,
            hoodStudent,
            goblinHelmet,
            leatherHelmet,
            trollHelmet,
            stealHelmet,
            elvenHelmet,
            dwarfsHelmet,
            orkHelmet,
            hunterHelmet,
            hoodBachelor,
            obsidianHelmet,
            elementsHelmet,
            hoodMaster,
            dvemerHelmet,
            demonicHelmet,
            angelHelmet,
            diabloHelmet,
            godHelmet,
            workGloves,
            ironSword,
            ironSpear,
            ironMace,
            ironDagger,
            ironAxe,
            woodStaff,
            stealSword,
            stealSpear,
            stealMace,
            stealDagger,
            elvenAxe,
            magicStaff,
            dwarfsSword,
            dwarfsSpear,
            dwarfsMace,
            dwarfsDagger,
            dwarfsAxe,
            orkMace,
            orkAxe,
            trollSpear,
            archmagicStaff,
            elemetsDagger,
            dvemerMace,
            demonSword,
            angelSword,
            diabloSword,
            godSword,
            namelessStaff
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
            int itemIndex = DungeonGenerator.random.Next(1, items.Count - 1);
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
