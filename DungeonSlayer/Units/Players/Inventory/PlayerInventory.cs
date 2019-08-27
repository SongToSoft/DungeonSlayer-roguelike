using DungeonSlayer.Units.Players.Inventory.Armores;
using DungeonSlayer.Units.Players.Inventory.Helmets;
using DungeonSlayer.Units.Players.Inventory.Weapons;
using DungeonSlayer.Units.Players.Perks;
using System;
using System.Collections.Generic;

namespace DungeonSlayer.Units.Players.Inventory
{
    class PlayerInventory
    {
        public Helmet activeHelmet = ItemsList.wellWornHood;
        public Armor activeArmor = ItemsList.castoffs;
        public Weapon activeWeapon = ItemsList.workGloves;

        public List<Item> items;

        public PlayerInventory()
        {
            items = new List<Item>();
            items.Add(ItemsList.helthBottle);
            items.Add(ItemsList.helthBottle);
            items.Add(ItemsList.manaBottle);
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void SetActiveHelmet(Helmet helmet)
        {
            Game.player.specification.IncreaseStrength((int)-activeHelmet.increasingStats.X, true);
            Game.player.specification.IncreaseAgility((int)-activeHelmet.increasingStats.Y, true);
            Game.player.specification.IncreaseIntelligence((int)-activeHelmet.increasingStats.Z, true);
            Game.player.blocking -= activeHelmet.blockingValue;
            activeHelmet = helmet;
            Game.player.blocking += activeHelmet.blockingValue;
            Game.player.specification.IncreaseStrength((int)activeHelmet.increasingStats.X, true);
            Game.player.specification.IncreaseAgility((int)activeHelmet.increasingStats.Y, true);
            Game.player.specification.IncreaseIntelligence((int)activeHelmet.increasingStats.Z, true);
        }

        public void SetActiveArmor(Armor armor)
        {
            Game.player.specification.IncreaseStrength((int)-activeArmor.increasingStats.X, true);
            Game.player.specification.IncreaseAgility((int)-activeArmor.increasingStats.Y, true);
            Game.player.specification.IncreaseIntelligence((int)-activeArmor.increasingStats.Z, true);
            Game.player.blocking -= activeArmor.blockingValue;
            activeArmor = armor;
            Game.player.blocking += activeArmor.blockingValue;
            Game.player.specification.IncreaseStrength((int)activeArmor.increasingStats.X, true);
            Game.player.specification.IncreaseAgility((int)activeArmor.increasingStats.Y, true);
            Game.player.specification.IncreaseIntelligence((int)activeArmor.increasingStats.Z, true);
        }

        public void SetActiveWeapon(Weapon weapon, EPerkValue perk = EPerkValue.EMPTY_PERK)
        {
            Game.player.specification.IncreaseStrength((int)-activeWeapon.increasingStats.X, true);
            Game.player.specification.IncreaseAgility((int)-activeWeapon.increasingStats.Y, true);
            Game.player.specification.IncreaseIntelligence((int)-activeWeapon.increasingStats.Z, true);
            Game.player.accuracy = weapon.accuracy;
            Game.player.criticalChance = weapon.criticalChance;
            if (perk != EPerkValue.DAGGER_PERK)
            {
                if ((activeWeapon.type == EWeaponType.DAGGER) && Game.player.perksSystem.CheckPerk(PerksList.daggerPerk))
                {
                    --Game.player.attack;
                }
            }
            if (perk != EPerkValue.MACE_PERK)
            {
                if ((activeWeapon.type == EWeaponType.MACE) && Game.player.perksSystem.CheckPerk(PerksList.macePerk))
                {
                    --Game.player.attack;
                }
            }
            if (perk != EPerkValue.AXE_PERK)
            {
                if ((activeWeapon.type == EWeaponType.AXE) && Game.player.perksSystem.CheckPerk(PerksList.axePerk))
                {
                    --Game.player.attack;
                }
            }
            if (perk != EPerkValue.SWORD_PERK)
            {
                if ((activeWeapon.type == EWeaponType.SWORD) && Game.player.perksSystem.CheckPerk(PerksList.swordPerk))
                {
                    --Game.player.attack;
                }
            }
            if (perk != EPerkValue.STAFF_PERK)
            {
                if ((activeWeapon.type == EWeaponType.STAFF) && Game.player.perksSystem.CheckPerk(PerksList.staffPerk))
                {
                    --Game.player.attack;
                }
            }
            if (perk != EPerkValue.SPEAR_PERK)
            {
                if ((activeWeapon.type == EWeaponType.SPEAR) && Game.player.perksSystem.CheckPerk(PerksList.spearPerk))
                {
                    --Game.player.attack;
                }
            }

            Game.player.attack -= activeWeapon.attack;
            activeWeapon = weapon;
            Game.player.attack += activeWeapon.attack;

            if ((activeWeapon.type == EWeaponType.DAGGER) && Game.player.perksSystem.CheckPerk(PerksList.daggerPerk))
            {
                ++Game.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.MACE) && Game.player.perksSystem.CheckPerk(PerksList.macePerk))
            {
                ++Game.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.AXE) && Game.player.perksSystem.CheckPerk(PerksList.axePerk))
            {
                ++Game.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.SWORD) && Game.player.perksSystem.CheckPerk(PerksList.swordPerk))
            {
                ++Game.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.STAFF) && Game.player.perksSystem.CheckPerk(PerksList.staffPerk))
            {
                ++Game.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.SPEAR) && Game.player.perksSystem.CheckPerk(PerksList.spearPerk))
            {
                ++Game.player.attack;
            }
            Game.player.specification.IncreaseStrength((int)activeWeapon.increasingStats.X, true);
            Game.player.specification.IncreaseAgility((int)activeWeapon.increasingStats.Y, true);
            Game.player.specification.IncreaseIntelligence((int)activeWeapon.increasingStats.Z, true);
        }

        public void OpenInventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Game.consoleBuffer = new char[Game.consoleHeight, Game.consoleWidth];
            Console.WriteLine(" Active Helmet: " + activeHelmet.name + " " + activeHelmet.GetInfo());
            Console.WriteLine(" Active Armor: " + activeArmor.name + " " + activeArmor.GetInfo());
            Console.WriteLine(" Active Weapon: " + activeWeapon.name + " " + activeWeapon.GetInfo());
            Console.WriteLine();
            for (int i = 0; i < items.Count; ++i)
            {
                Console.WriteLine(" [" + (i + 1) + "]" + " " + items[i].name + " " + items[i].GetInfo());
            }
            Console.WriteLine();
            Console.WriteLine(" Enter number of item, wich you want use");
            Console.WriteLine(" [C] - Close inventory");
            Console.Write(" ");
            string command = Console.ReadLine();
            if ((command == "c") || (command == "C"))
            {
                Console.Clear();
                return;
            }
            else
            {
                if (Int32.TryParse(command, out int itemIndex))
                {
                    if ((itemIndex <= items.Count) && (itemIndex > 0))
                    {
                        items[itemIndex - 1].Use();
                        items.RemoveAt(itemIndex - 1);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                }
                OpenInventory();
            }
        }
    }
}
