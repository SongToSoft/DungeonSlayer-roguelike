using DungeonSlayer.FileSystem;
using DungeonSlayer.Location;
using DungeonSlayer.Units.Players;
using System;
using System.Threading;

namespace DungeonSlayer
{
    static class Game
    {
        static public int currentDungeonLevel = 0, maxDungeonLevel = 0;
        static public int consoleHeight = 35, consoleWidth = 110;
        static public Player player;
        static public World world;
        static public char[,] consoleBuffer;

        static public void Start()
        {
            ConsoleSupport.Setup();
            world = new World(consoleHeight, consoleWidth);
            consoleBuffer = new char[consoleHeight, consoleWidth];
            player = new Player();
            world.GoToHub();
            Menu.StartScreen();
            Update();
        }

        static public void Update()
        {
            Draw();
            player.Update();
            player.Draw();
            if (player.isMove)
            {
                world.Update();
            };
            Update();
        }

        static public void EndGame(bool diabloIsDead = false)
        {
            if (player.isDead)
            {
                StatusLine.AddLine(" Player is dead, your character is deleted");
                SaveSystem.DelCharacter();
                Console.ReadKey();
            }
            if (diabloIsDead)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine(" Thank you for game!");
                Console.ReadKey();
            }
            Console.ReadKey();
            Environment.Exit(0);
        }

        static public void Draw()
        {
            world.Draw();
            player.Draw();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < world.height; ++i)
            {
                for (int j = 0; j < world.width; ++j)
                {
                    if (consoleBuffer[i, j] != Game.world.map[i, j])
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ForegroundColor = Game.world.colors[i, j];
                        consoleBuffer[i, j] = Game.world.map[i, j];
                        Console.Write(Game.world.map[i, j]);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(world.width, i);
                if (i == 1)
                {
                    Console.Write((currentDungeonLevel != 0) ? (" Dungeon Level: " + currentDungeonLevel + "     ") :
                                  (" You are in save place  "));
                }
                else
                {
                    player.DrawInfo(i);
                }
            }
            Console.SetCursorPosition(0, world.height);
            Console.WriteLine(" [W] - Up [D] - Right [S] - Down [A] - Left [I] - Inventory [P] - Perks [M] - Magic List [Q] - Use Magic" +
                             ((player.specification.levelPoint != 0) ? " [U] - Level Up" : "              "));

            if (StatusLine.statuses.Count != 0)
            {
                StatusLine.Draw();
            }
            else
            {
                StatusLine.DrawBuffer();
            }
        }
    }
}
