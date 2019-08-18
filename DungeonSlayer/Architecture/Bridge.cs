using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer
{
    class Bridge
    {
        public Vector2 position;
        public int width;
        public int height;
        public char[,] places;

        public Bridge(Room roomFirst, Room roomSecond, ref char[,] map)
        {
            position.X = roomFirst.position.X + roomFirst.height / 2;
            position.Y = roomFirst.position.Y + roomFirst.width - 1;
            height = 3;
            width = (int)(roomSecond.position.Y - position.Y + 1);
            places = new char[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    places[i, j] = map[(int)(position.X + i), (int)(position.Y + j)];
                }
            }
            for (int i = 0; i < width; ++i)
            {
                places[1, i] = '.';
            }
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (places[i, j] != '.')
                    {
                        places[i, j] = '#';
                    }                    
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (((position.X + i) < Game.world.height) && ((position.Y + j) < Game.world.width))
                    {
                        Game.world.colors[(int)(position.X + i), (int)(position.Y + j)] = ConsoleColor.White;
                        Game.world.map[(int)(position.X + i), (int)(position.Y + j)] = places[i, j];
                    }
                }
            }
        }
    }
}
