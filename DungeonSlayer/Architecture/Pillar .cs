using System;

namespace DungeonSlayer.Architecture
{
    class Pillar : ArchitectureObject
    {
        public Pillar(int x, int y)
        {
            position.X = x;
            position.Y = y;
            width = DungeonGenerator.random.Next(3, 5);
            height = DungeonGenerator.random.Next(3, 5);
            places = new char[height, width];
            SetColors();
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    places[i, j] = '#';
                    colors[i, j] = ConsoleColor.DarkCyan;
                }
            }
        }
    }
}
