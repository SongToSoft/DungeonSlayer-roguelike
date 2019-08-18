using DungeonSlayer.Units.Player;
using DungeonSlayer.Units.Player.Inventory;
using DungeonSlayer.Units.Player.Inventory.Armores;
using DungeonSlayer.Units.Player.Inventory.Helmets;
using DungeonSlayer.Units.Player.Inventory.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer
{
    class PlayerInventory
    {
        public Helmet activeHelmet = HelmetList.emptyHelmet;
        public Armor activeArmor = ArmorList.emptyArmor;
        public Weapon activeWeapon = WeaponList.bareHands;

        List<Item> items;

        public PlayerInventory()
        {
            items = new List<Item>();
            items.Add(ItemsList.healtBottle);
            items.Add(ItemsList.healtBottle);
            items.Add(ItemsList.manaBottle);
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void SetActiveHelmet(Helmet helmet)
        {
            Game.player.blocking -= activeHelmet.blockingValue;
            activeHelmet = helmet;
            Game.player.blocking += activeHelmet.blockingValue;
        }

        public void SetActiveArmor(Armor armor)
        {
            Game.player.blocking -= activeArmor.blockingValue;
            activeArmor = armor;
            Game.player.blocking += activeArmor.blockingValue;
        }

        public void SetActiveWeapon(Weapon weapon)
        {
            Game.player.accuracy = weapon.accuracy;
            Game.player.criticalChance = weapon.criticalChance;
            if ((Game.player.specification.race == ERaсe.ELF) && (activeWeapon.type == EWeaponType.DAGGER))
            {
                --Game.player.attack;
            }
            if ((Game.player.specification.race == ERaсe.DWARF) &&
                ((activeWeapon.type == EWeaponType.MACE) || (activeWeapon.type == EWeaponType.AXE)))
            {
                --Game.player.attack;
            }
            Game.player.attack -= activeWeapon.attack;
            activeWeapon = weapon;
            Game.player.attack += activeWeapon.attack;
            if ((Game.player.specification.race == ERaсe.ELF) && (activeWeapon.type == EWeaponType.DAGGER))
            {
                ++Game.player.attack;
            }
            if ((Game.player.specification.race == ERaсe.DWARF) &&
                ((activeWeapon.type == EWeaponType.MACE) || (activeWeapon.type == EWeaponType.AXE)))
            {
                ++Game.player.attack;
            }
        }

        public void OpenInventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Game.consoleBuffer = new char[Game.consoleHeight, Game.consoleWidth];
            Console.WriteLine(" Активный Шлем: " + activeHelmet.name + " " + activeHelmet.GetInfo());
            Console.WriteLine(" Активный Доспех: " + activeArmor.name + " " + activeArmor.GetInfo());
            Console.WriteLine(" Активное Оружие: " + activeWeapon.name + " " + activeWeapon.GetInfo());
            Console.WriteLine();
            for (int i = 0; i < items.Count; ++i)
            {
                Console.WriteLine(" [" + (i + 1) + "]" + " " + items[i].name + " " + items[i].GetInfo());
            }
            Console.WriteLine();
            Console.WriteLine(" Введите номер предмета, который хотите использовать");
            Console.WriteLine(" [C] - Закрыть инвентарь");
            char command = Console.ReadKey().KeyChar;
            if ((command == 'c') || (command == 'C'))
            {
                return;
            }
            else
            {
                int itemIndex = command - '0';
                if ((itemIndex <= items.Count) && (itemIndex > 0))
                {
                    items[itemIndex - 1].Use();
                    items.RemoveAt(itemIndex - 1);
                }
                OpenInventory();
            }
        }
    }
}
