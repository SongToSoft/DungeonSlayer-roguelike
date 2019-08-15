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

        //TODO: Improve this method
        static public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition((int)position.X, (int)position.Y);
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 30; ++j)
                {
                    Console.SetCursorPosition((int)position.X + j, (int)position.Y + i);
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition((int)position.X, (int)position.Y);
            Console.WriteLine(" Статус: ");
            Console.Write(status);
            bufferStatus = status;
            stringNum = 0;
        }

        static public void DrawBuffer()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Статус: ");
            Console.WriteLine(bufferStatus);
        }
    }
}
