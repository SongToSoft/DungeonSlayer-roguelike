using System;
using System.Collections.Generic;
using System.Numerics;

namespace DungeonSlayer
{
    static class StatusLine
    {
        static public int stringNum = 0;
        static public Vector2 position = new Vector2(0, Game.world.height + 1);
        static public List<string> statuses = new List<string>();
        static public List<string> buffer = new List<string>();

        static public void AddLine(string line)
        {
            ++stringNum;
            statuses.Add(line);
        }

        static public void Clear()
        {
            statuses.Clear();
        }

        static public void ShowInfo()
        {
            statuses.Add(" Hello traveler. Are you new here?");
            statuses.Add(" I will explain how everything is arranged here.");
            statuses.Add(" Now you are in save place.");
            statuses.Add(" Here you can buy new items and go to the new Dungeon level.");
            statuses.Add(" On every Dungeon level you must go to the next portal,");
            statuses.Add(" that will open the entrance to the next level.");
            statuses.Add(" Repeat it untill you dont go to the last Dungeon Level and kill Diablo");
            statuses.Add(" .... oooouuu i want say kill the Devil.");
            statuses.Add(" After than your journey will be over. Good Luck!");
        }

        static public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition((int)position.X, (int)position.Y);
            for (int i = 0; i < 20; ++i)
            {
                Console.WriteLine("                                                                                  ");
            }
            Console.SetCursorPosition((int)position.X, (int)position.Y);
            Console.WriteLine(" Status: ");
            for (int i = 0; i < statuses.Count; ++i)
            {
                Console.WriteLine(statuses[i]);
            }
            buffer = statuses;
            stringNum = 0;
            Clear();
        }

        static public void DrawBuffer()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Status: ");
            for (int i = 0; i < buffer.Count; ++i)
            {
                Console.WriteLine(buffer[i]);
            }
        }
    }
}
