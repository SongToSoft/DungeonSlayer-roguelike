using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            char command = Console.ReadKey().KeyChar;
            Console.WriteLine("");
            Console.WriteLine("[1] - Начать новую игру");
            //Console.WriteLine("[2] - Загрузить персонажа");
            Console.WriteLine("[2] - Выйти из игры");
            bool choseMenuStart = true;
            while (choseMenuStart)
            {
                int commandIndex = Console.ReadKey().KeyChar - '0'; ;
                switch (commandIndex)
                {
                    case 1:
                        Console.Clear();
                        choseMenuStart = false;
                        PlayerGenerator.SetupSpecifications(ref Game.player);
                        break;
                    //case 2:
                    //    //TODO: Make load character
                    //    Console.Clear();
                    //    choseMenuStart = false;
                    //    break;
                    case 2:
                        Game.EndGame();
                        break;
                    default:
                        Console.WriteLine("Невероное значение");
                        break;
                }
            }

        }
    }
}
