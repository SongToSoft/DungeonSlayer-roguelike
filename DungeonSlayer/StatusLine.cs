using System;
using System.Numerics;

namespace DungeonSlayer
{
    static class StatusLine
    {
        static public string status = "";
        static public string bufferStatus = "";
        static public int stringNum = 0;
        static public Vector2 position = new Vector2(0, Game.world.height + 1);

        static public void AddLine(string line)
        {
            status += line;
            ++stringNum;
        }

        static public void ShowInfo()
        {
            status = " Hello traveler. Are you new here?. \n" +
                     " I will explain how everything is arranged here.\n" +
                     " Now you are in save place. Here you can buy new items and go to the new Dungeon level.\n" +
                     " On every Dungeon level you must go to the next portal, that will open the entrance to the next level.\n" +
                     " Repeat it untill you dont go to the last Dungeon Level and kill Diablo.... oooouuu i want say kill the Devil.\n" +
                     " After than your journey will be over. Good Luck\n";
        }

        //TODO: Improve this method
        static public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition((int)position.X, (int)position.Y);
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 120; ++j)
                {
                    Console.SetCursorPosition((int)position.X + j, (int)position.Y + i);
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition((int)position.X, (int)position.Y);
            Console.WriteLine(" Status: ");
            Console.Write(status);
            bufferStatus = status;
            stringNum = 0;
        }

        static public void DrawBuffer()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Status: ");
            Console.WriteLine(bufferStatus);
        }
    }
}
