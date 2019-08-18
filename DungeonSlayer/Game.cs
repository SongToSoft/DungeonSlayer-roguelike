using System;

namespace DungeonSlayer
{
    static class Game
    {
        static public int currentLevel = 0, maxLevel = 0;
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
            world.GoToHub();
            //Menu.StartScreen();
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
            }
            Update();
        }

        static public void EndGame()
        {
            if (player.isDead)
            {
                //TODO: Del player save
                StatusLine.AddLine("Player is dead");
                Console.ReadKey();
            }
            //else
            //{
            //    //TODO: Save character
            //}
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
                    Console.Write((currentLevel != 0) ? (" Уровень подземелья: " + currentLevel) :
                                  (" Вы в безопасном месте  "));
                }
                else
                {
                    player.DrawInfo(i);
                }
            }
            Console.SetCursorPosition(0, world.height);
            Console.WriteLine(" [W] - Up [D] - Right [S] - Down [A] - Left [I] - Inventory" +
                             ((player.specification.levelPoint != 0) ? " [U] - Level Up" : "              "));

            if (StatusLine.status != "")
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
