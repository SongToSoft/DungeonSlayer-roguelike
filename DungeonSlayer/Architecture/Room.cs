using DungeonSlayer.Architecture;
using DungeonSlayer.MapObjects;
using DungeonSlayer.Units.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer
{
    class Room
    {
        public int index; 
        public Vector2 position;
        public int height;
        public int width;
        public char[,] places;
        public List<Pillar> pillars;

        public Room(Vector2 _position, int _height, int _width, int _index)
        {
            index = _index;
            pillars = new List<Pillar>();
            position = _position;
            height = _height;
            width = _width;
            places = new char[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (i == 0 || (i == (height - 1)))
                    {
                        places[i, j] = '#';
                    }
                    else
                    {
                        if (j == 0 || (j == (width - 1)))
                        {
                            places[i, j] = '#';
                        }
                        else
                        {
                            places[i, j] = '.';
                        }
                    }
                }
            }
            DungeonGenerator.AddPillars(ref pillars, position, height, width);
        }

        public bool Contain(Room room)
        {            
            if ((position.X < (room.position.X + room.height)) &&
                ((position.X + height) > room.position.X) &&
                (position.Y < (room.position.Y + room.width)) &&
                ((position.Y + width) > room.position.Y))
            {
                return true;
            }
            return false;
        }

        public void Draw()
        {           
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (((position.X + i) < Game.world.height) && ((position.Y + j) < Game.world.width))
                    {
                        Game.world.map[(int)(position.X + i), (int)(position.Y + j)] = places[i, j];
                        Game.world.colors[(int)(position.X + i), (int)(position.Y + j)] = ConsoleColor.White;
                    }
                }
            }
            for (int i = 0; i < pillars.Count; ++i)
            {
                pillars[i].Draw();
            }
        }
    }
}
