using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Architecture
{
    class Pillar
    {
        public System.Numerics.Vector2 position;
        public int width;
        public int height;
        public char[,] places;

        public Pillar(int x, int y)
        {
            position.X = x;
            position.Y = y;
            width = DungeonGenerator.random.Next(3, 5);
            height = DungeonGenerator.random.Next(3, 5);
            places = new char[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    places[i, j] = '#'; 
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
