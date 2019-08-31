using System;
using System.Numerics;

namespace DungeonSlayer.Architecture
{
    enum ELocation
    {
        HORIZONTAL,
        VERTICAL
    }

    class ArchitectureObject
    {
        protected Vector2 position;
        protected int width;
        protected int height;
        protected char[,] places;
        protected ConsoleColor[,] colors;

        public Vector2 GetPosition()
        {
            return position;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public void SetColors()
        {
            colors = new ConsoleColor[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    colors[i, j] = ConsoleColor.DarkGray;
                }
            }
        }

        public void Draw()
        {
            if (colors == null)
            {
                SetColors();
            }
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (((position.X + i) < Game.world.height) && ((position.Y + j) < Game.world.width))
                    {
                        Game.world.colors[(int)(position.X + i), (int)(position.Y + j)] = colors[i, j];
                        Game.world.map[(int)(position.X + i), (int)(position.Y + j)] = places[i, j];
                    }
                }
            }
        }
    }
}
