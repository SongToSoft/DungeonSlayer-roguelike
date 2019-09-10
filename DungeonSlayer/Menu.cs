using DungeonSlayer.FileSystem;
using DungeonSlayer.Units.Players;
using System;
using System.IO;

namespace DungeonSlayer
{
    static class Menu
    {
        public static void StartScreen()
        {
            Console.CursorSize = 100;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("| #######  #      # ##      # ######## ######## ######## ##      # |");
            Console.WriteLine("| #      # #      # # #     # #        #        #      # # #     # |");
            Console.WriteLine("| #      # #      # #  #    # #        #        #      # #  #    # |");
            Console.WriteLine("| #      # #      # #   #   # #  ##### ######## #      # #   #   # |");
            Console.WriteLine("| #      # #      # #    #  # #      # #        #      # #    #  # |");
            Console.WriteLine("| #      # #      # #     # # #      # #        #      # #     # # |");
            Console.WriteLine("| #######  ######## #      ## ######## ######## ######## #      ## |");
            Console.WriteLine("|                                                                  |");
            Console.WriteLine("|     ######## #           #      #      # ######## ########       |");
            Console.WriteLine("|     #        #          # #     #      # #        #      #       |");
            Console.WriteLine("|     #        #          # #     #      # #        #      #       |");
            Console.WriteLine("|     ######## #         #####    ######## ######## ########       |");
            Console.WriteLine("|            # #         #   #       ##    #        ###            |");
            Console.WriteLine("|            # #        #     #      ##    #        #  ##          |");
            Console.WriteLine("|     ######## ######## #      #     ##    ######## #    ##        |");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("----------------------Developed by SongToSoft-----------------------");
            Console.WriteLine("---------------------------Press Any Key----------------------------");
            char command = Console.ReadKey(true).KeyChar;
            //Console.Clear();
            //Console.WriteLine(" [1] - Start new game");
            //Console.WriteLine(" [2] - Load Character");
            //Console.WriteLine(" [3] - Exit game");
            bool choseMenuStart = true;
            while (choseMenuStart)
            {
                Console.Clear();
                Console.WriteLine(" [1] - Start new game");
                Console.WriteLine(" [2] - Load Character");
                Console.WriteLine(" [3] - Exit game");
                int commandIndex = Console.ReadKey(true).KeyChar - '0';
                switch (commandIndex)
                {
                    case 1:
                        choseMenuStart = false;
                        PlayerGenerator.SetupSpecifications(ref Game.player);
                        break;
                    case 2:
                        //TODO: Make load character
                        DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                        int count = 1;
                        foreach (var item in dir.GetFiles())
                        {
                            if (item.Name.EndsWith(".json"))
                            {
                                Console.WriteLine(" [" + count + "] " + (Path.GetFileNameWithoutExtension(item.FullName)));
                                ++count;
                            }
                        }
                        if (count == 1)
                        {
                            Console.WriteLine(" No one saved hero");
                            Console.ReadKey(true);
                            break;
                        }
                        bool choseHero = true;
                        while (choseHero)
                        {
                            Console.WriteLine(" Chose hero");
                            Console.WriteLine(" [C] - cancel");
                            command = Console.ReadKey(true).KeyChar;
                            if ((command == 'C') || (command == 'c'))
                            {
                                break;
                            }
                            commandIndex = command - '0';
                            count = 1;
                            foreach (var item in dir.GetFiles())
                            {
                                if (item.Name.EndsWith(".json"))
                                {
                                    if (count == commandIndex)
                                    {
                                        SaveSystem.LoadCharacter(item.Name);
                                        choseHero = false;
                                        break;
                                    }
                                    ++count;
                                }
                            }
                            choseMenuStart = false;
                        }
                        break;
                    case 3:
                        Game.EndGame();
                        break;
                    default:
                        Console.WriteLine("Incorrect value");
                        break;
                }
            }

        }
    }
}
