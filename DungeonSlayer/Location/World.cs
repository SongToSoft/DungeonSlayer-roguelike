using DungeonSlayer.Architecture;
using DungeonSlayer.Location;
using DungeonSlayer.MapObjects;
using DungeonSlayer.Units.Enemy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer
{

    class World
    {
        public int height, width;
        public Dungeon dungeon;
        public char[,] map;
        public ConsoleColor[,] colors;

        public World(int _height, int _width)
        {
            height = _height;
            width = _width;
            map = new char[height, width];
            colors = new ConsoleColor[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    map[i, j] = ' ';
                    colors[i, j] = ConsoleColor.White;
                }
            }
            dungeon = new Dungeon();
        }

        public void AddBorder()
        {
            for (int i = 0; i < width; ++i)
            {
                map[0, i] = '-';
                map[height - 1, i] = '-';
            }
            for (int i = 0; i < height; ++i)
            {
                map[i, 0] = '|';
                map[i, width - 1] = '|';
            }
        }

        public void GoToNewDungeon()
        {
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    map[i, j] = ' ';
                    colors[i, j] = ConsoleColor.White;
                }
            }
            dungeon.Generate();
            AddBorder();
            Draw();
            Game.player.SetInRoom(0);
        }

        public void GoToHub()
        {
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    map[i, j] = ' ';
                    colors[i, j] = ConsoleColor.White;
                }
            }
            dungeon.GenerateHub();
            AddBorder();
            Draw();
            Game.player.SetInRoom(0);
        }

        public void GoToCurrentDungeon()
        {
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    map[i, j] = ' ';
                    colors[i, j] = ConsoleColor.White;
                }
            }
            dungeon.LoadCurrentDungeon();
            AddBorder();
            Draw();
            Game.player.SetInRoom(0);
        }

        public void Update()
        {
            dungeon.Update();
        }

        public void Draw()
        {
            dungeon.Draw();
        }
    }
}
