using DungeonSlayer.Units.Players.Inventory;
using DungeonSlayer.Units.Players.Perks;
using System;
using System.Collections.Generic;

namespace DungeonSlayer.Units.NPC
{

    enum ETraderState
    {
        BUY,
        SELL
    }

    class Trader : Unit
    {
        public List<Item> items;
        public EItemType itemType;
        public Trader(EItemType _type)
        {
            form = 'T';
            color = ConsoleColor.Yellow;
            items = new List<Item>();
            itemType = _type;
            for (int i = 0; i < ItemsList.items.Count; ++i)
            {
                if ((ItemsList.items[i].itemType == itemType) && (ItemsList.items[i].level > 0))
                {
                    items.Add(ItemsList.items[i]);
                }
            }
        }

        public void ShowShop()
        {
            Console.Clear();
            Game.consoleBuffer = new char[Game.consoleHeight, Game.consoleWidth];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" You have gold: " + Game.player.currentGold);
            Console.WriteLine(" [B] - Buy [S] - Sell [else] - close shop");
            char command = Console.ReadKey(true).KeyChar;
            ETraderState state;
            switch (command)
            {
                case 'b':
                case 'B':
                    Console.WriteLine(" Buy items");
                    state = ETraderState.BUY;
                    break;
                case 's':
                case 'S':
                    Console.WriteLine(" Sell items");
                    state = ETraderState.SELL;
                    break;
                default:
                    return;
            }
            if (state == ETraderState.BUY)
            {
                Console.WriteLine(" Items of trader: ");
                Console.WriteLine();
                for (int i = 0; i < items.Count; ++i)
                {
                    Console.WriteLine(" [" + (i + 1) + "] " + items[i].name + " " + items[i].GetInfo());
                }
            }
            else
            {
                Console.WriteLine(" Items of player: ");
                Console.WriteLine();
                for (int i = 0; i < Game.player.inventory.items.Count; ++i)
                {
                    Console.WriteLine(" [" + (i + 1) + "] " + Game.player.inventory.items[i].name + " " + Game.player.inventory.items[i].GetInfo());
                }
            }
            Console.WriteLine(" [C] - Close shop");
            Console.Write(" ");
            string choseCommand = Console.ReadLine();
            if ((choseCommand == "c") || (choseCommand == "C"))
            {
                return;
            }
            else
            {
                if (Int32.TryParse(choseCommand, out int itemIndex))
                {
                    if (state == ETraderState.BUY)
                    {
                        if (((itemIndex - 1) < items.Count) && ((itemIndex - 1) >= 0))
                        {
                            if (Game.player.currentGold >= items[itemIndex - 1].cost)
                            {
                                Game.player.currentGold -= items[itemIndex - 1].cost;
                                Game.player.inventory.items.Add(items[itemIndex - 1]);
                                Console.WriteLine(" " + Game.player.name + " bought : " + items[itemIndex - 1].name + " for " + items[itemIndex - 1].cost);
                            }
                            else
                            {
                                Console.WriteLine(" You don't have enough gold");
                            }
                        }
                    }
                    else
                    {
                        if (((itemIndex - 1) < Game.player.inventory.items.Count) && ((itemIndex - 1) > 0))
                        {
                            int gold = Game.player.inventory.items[itemIndex - 1].cost / 2 + (Game.player.perksSystem.CheckPerk(PerksList.traderPerk) ? (Game.player.inventory.items[itemIndex - 1].cost / 10) : 0);
                            Game.player.currentGold += gold;
                            Console.WriteLine(" " + Game.player.name + " sold : " +
                                              Game.player.inventory.items[itemIndex - 1].name +
                                              " for " + gold);
                            Game.player.inventory.items.RemoveAt(itemIndex - 1);

                        }
                    }
                    Console.ReadKey(true);
                }
                ShowShop();
            }
        }
    }
}
