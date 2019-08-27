using System;
using System.IO;

namespace DungeonSlayer.Units.Players
{
    static class PlayerGenerator
    {
        static public void SetupSpecifications(ref Player player)
        {
            Console.Clear();
            while (!SetName(ref player)) {}
            SetSex(ref player);
            SetRace(ref player);
            SetClass(ref player);
            Console.WriteLine(" Enter any key");
            char command = Console.ReadKey(true).KeyChar;
            Console.Clear();
            Game.player.helth = Game.player.maxHelth;
            Game.player.mana = Game.player.maxMana;
        }

        static public bool SetName(ref Player player)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Enter hero name");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string command = Console.ReadLine();
            if ((command.Length == 0) || (command.Length > 15))
            {
                Console.WriteLine(" Length of hero name must be more than 0 and less than 15");
                return false;
            }
            else
            {
                if (File.Exists(command + ".json"))
                {
                    Console.WriteLine(" The hero with same name was created yet");
                    return false;
                }
                else
                {
                    Console.WriteLine(" You enter name: " + command);
                    player.name = command;
                    return true;
                }
            }
        }

        static private void SetSex(ref Player player)
        {
            bool isSet = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Chose gender:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" [M] - male: +1 strength");
            Console.WriteLine(" [F] - female: +1 agility");

            while (isSet)
            {
                char command = Console.ReadKey(true).KeyChar;
                isSet = false;
                switch (command)
                {
                    case 'm':
                    case 'M':
                        player.specification.SetGender(EGender.MALE);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose male");
                        break;
                    case 'f':
                    case 'F':
                        player.specification.SetGender(EGender.FEMALE);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose female");
                        break;
                    default:
                        isSet = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Incorrect chose");
                        break;

                }
            }
        }

        static private void SetClass(ref Player player)
        {
            bool isSet = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Chose your class:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" [K] - Knight: +1 strength, +1 agility, Iron set");
            Console.WriteLine(" [B] - Barbarian: +2 strength, Leather armor, Iron Mace");
            Console.WriteLine(" [P] - Pathfinder: +2 agility, Leather set, iron dagger");
            Console.WriteLine(" [N] - Nameless");
            while (isSet)
            {
                char command = Console.ReadKey(true).KeyChar;
                isSet = false;
                switch (command)
                {
                    case 'k':
                    case 'K':
                        player.specification.SetSpecialization(EClass.KNIGHT);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose Knight");
                        break;
                    case 'b':
                    case 'B':
                        player.specification.SetSpecialization(EClass.BARBARIAN);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose Barbarian");
                        break;
                    case 'p':
                    case 'P':
                        player.specification.SetSpecialization(EClass.PATHFINDER);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose Pathfinder");
                        break;
                    case 'n':
                    case 'N':
                        player.specification.SetSpecialization(EClass.NOBODY);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You refused to choose a class");
                        break;
                    default:
                        isSet = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Incorrect chose");
                        break;
                }
            }
        }

        static private void SetRace(ref Player player)
        {
            bool isSet = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Chose your race:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" [H] - Human: +20 max HP and MANA");
            Console.WriteLine(" [E] - ELF: +1 agility and Intelligence, +1 attack with dagger");
            Console.WriteLine(" [D] - Dvarf: +2 strength, +1 attack with Mace and Axe");
            Console.WriteLine(" [O] - Ork: +5 strength, +1 attack with Mace, +5 blocking damage, You always will have 0 evasion");
            Console.WriteLine(" [G] - Goblin: +3 agility, 20 max HP, +3 evasion, Heal Spell");
            while (isSet)
            {
                char command = Console.ReadKey(true).KeyChar;
                isSet = false;
                switch (command)
                {
                    case 'h':
                    case 'H':
                        player.specification.SetRace(ERaсe.HUMAN);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose Human");
                        break;
                    case 'e':
                    case 'E':
                        player.specification.SetRace(ERaсe.ELF);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose Elf");
                        break;
                    case 'd':
                    case 'D':
                        player.specification.SetRace(ERaсe.DWARF);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose Dvarf");
                        break;
                    case 'o':
                    case 'O':
                        player.specification.SetRace(ERaсe.ORC);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose Orc");
                        break;
                    case 'g':
                    case 'G':
                        player.specification.SetRace(ERaсe.GOBLIN);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" You chose Goblin");
                        break;
                    default:
                        isSet = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Incorrect chose");
                        break;
                }
            }
        }
    }
}
