using System;
using System.Threading;

namespace DungeonSlayer
{
    static class Game
    {
        static public int dungeonLevel = 0;
        static public int consoleHeight = 35, consoleWidth = 110;
        static public Player player;
        static public World world;
        static public char[,] consoleBuffer;

        static public void Start()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            world = new World(consoleHeight, consoleWidth);
            consoleBuffer = new char[consoleHeight, consoleWidth];
            player = new Player();
            world.GenerateMap();
            player.SetInRoom(0);
            PlayerGenerator.SetupSpecifications(ref player);
            Update();
        }

        static public void Update()
        {
            Draw();
            player.Update();
            player.Draw();
            world.Update();
            Update();
        }

        static public void EndGame()
        {
            if (player.isDead)
            {
                //TODO: Del player save
                StatusLine.AddLine("!!!!!!!!!!!!!");
            }
            else
            {
                //TODO: Save character
            }
        }

        static public void Draw()
        {
            //Console.Clear();
            world.Draw();
            player.Draw();
            //for (int i = 0; i < map.height; ++i)
            //{
            //    Console.Write("  ");
            //    for (int j = 0; j < map.width; ++j)
            //    {
            //        Console.ForegroundColor = map.colors[i, j];
            //        Console.Write(map.places[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < world.height; ++i)
            {
                for (int j = 0; j < world.width; ++j)
                {
                    if (consoleBuffer[i, j] != world.map[i, j])
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ForegroundColor = world.colors[i, j];
                        consoleBuffer[i, j] = world.map[i, j];
                        Console.Write(world.map[i, j]);
                    }
                }
                Console.SetCursorPosition(world.width, i);
                if (i == 1)
                {
                    Console.Write(" Текущий уровень подземелья: " + dungeonLevel);
                }
                else
                {
                    player.DrawInfo(i);
                }
            }
            Console.SetCursorPosition(0, world.height);
            Console.WriteLine(" [W] - Up [D] - Right [S] - Down [A] - Left [I] - Inventory" +
                             ((player.specification.currentExp == player.specification.maxExp) ? "[U] - Level Up" : ""));

            //for (int i = (int)(player.GetPosition().X - player.vision.X); i < (player.GetPosition().X + player.vision.X / 2); ++i)
            //{
            //    for (int j = (int)(player.GetPosition().Y - player.vision.Y); j < (player.GetPosition().Y + player.vision.Y); ++j)
            //    {
            //        if ((i < map.height) && (j < map.width) && (i >= 0) && (j >= 0))
            //        {
            //            Console.ForegroundColor = map.colors[i, j];
            //            Console.Write(map.places[i, j]);
            //        }
            //    }
            //    Console.WriteLine();
            //}
            //StatusLine.status += " Команда игрока: ";
            if (StatusLine.status != "")
            {
                StatusLine.Draw();
            }
            else
            {
                StatusLine.DrawBuffer();
            }
            //player.DrawInfo();
        }
    }
}
