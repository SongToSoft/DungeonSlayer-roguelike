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
            status = " Привет путник. Давно в наших краях не было новых людей.\n" +
                     " Всё началось с того момента, как тут открылся портал, ведущий прямиком в подземелья, находящиеся под городом.\n" +
                     " Из него периодически на город нападают различные твари, от которых кое-как отбиваются стражники.\n" +
                     " Если кто-то не спустится в низ и не закроет портал, то город так и будет уничтожен постоянными наплывами тьмы.\n" +
                     " Все кто спускался вниз, говорят о том, что на каждом из этажей подземелий находятся два портала.\n" +
                     " Первый ведёт обратно на эту улицу, второй телепортирует тебя на уровень ниже.\n" +
                     " Если ты собираешься испытать свои силы в этом испытании, то можешь попробовать купить снаряжение у местного торговца.\n" +
                     " Удачи путник в твоём пути.\n";                   
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
