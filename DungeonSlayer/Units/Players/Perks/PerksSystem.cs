using System;
using System.Collections.Generic;

namespace DungeonSlayer.Units.Players.Perks
{
    class PerksSystem
    {
        private List<Perk> perks;
        public int perksPoint = 0;

        public PerksSystem()
        {
            perks = new List<Perk>();
        }

        public void AddPerk(Perk perk)
        {
            perks.Add(perk);
        }

        public bool CheckPerk(Perk perk)
        {
            return perks.Contains(perk);
        }

        public void ShowPerks()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Game.consoleBuffer = new char[Game.consoleHeight, Game.consoleWidth];
            for (int i = 0; i < perks.Count; ++i)
            {
                Console.WriteLine(" " + perks[i].value + ": " + perks[i].info);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            if (perks.Count == 0)
            {
                Console.WriteLine(" You have no one perk");
            }
            Console.WriteLine(" [C] - Close shop " + ((perksPoint > 0) ? "[P] - pick new Perk" : "                   "));
            bool commandChose = true;
            while (commandChose)
            {
                char command = Console.ReadKey(true).KeyChar;
                if ((command == 'c') || (command == 'C'))
                {
                    commandChose = false;
                    return;
                }
                if ((command == 'p') || (command == 'P'))
                {
                    commandChose = false;
                    int count = 1;
                    for (int i = 0; i < PerksList.perks.Count; ++i)
                    {
                        if (!Game.player.perksSystem.CheckPerk(PerksList.perks[i]) && (PerksList.perks[i].level <= Game.player.specification.level))
                        {
                            Console.WriteLine(" [" + count + "]: " + PerksList.perks[i].value + " " + PerksList.perks[i].info);
                            ++count;
                        }                       
                    }
                    bool perkChose = true;
                    while (perkChose)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" ");
                        string choseCommand = Console.ReadLine();
                        if (Int32.TryParse(choseCommand, out int perkIndex))
                        {
                            count = 1;
                            for (int i = 0; i < PerksList.perks.Count; ++i)
                            {
                                if (!Game.player.perksSystem.CheckPerk(PerksList.perks[i]) && (PerksList.perks[i].level <= Game.player.specification.level))
                                {
                                    if (perkIndex == count)
                                    {
                                        --perksPoint;
                                        AddPerk(PerksList.perks[i]);
                                        Console.WriteLine(" Now you have perk: " + PerksList.perks[i].value + " " + PerksList.perks[i].info);
                                        perkChose = false;
                                        Game.player.inventory.SetActiveWeapon(Game.player.inventory.activeWeapon, PerksList.perks[i].value);
                                        if (PerksList.perks[i].value == EPerkValue.EVASION_PERK)
                                        {
                                            Game.player.evasion += 5;
                                        }
                                        if (PerksList.perks[i].value == EPerkValue.CRITICAL_PERK)
                                        {
                                            Game.player.criticalChance += 4;
                                        }
                                        if (PerksList.perks[i].value == EPerkValue.WEAPON_PERK)
                                        {
                                            Game.player.attack += 2;
                                        }
                                        break;
                                    }
                                    ++count;
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Incorrect choise");
                        }
                    }
                }
            }
            return;
        }
    }
}
