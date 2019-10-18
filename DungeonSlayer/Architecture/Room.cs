using System;
using System.Collections.Generic;
using System.Numerics;

namespace DungeonSlayer.Architecture
{
    enum ERoomLocation
    {
        TOP,
        DOWN
    }

    class Room : ArchitectureObject
    {
        public int index;
        public ERoomLocation roomLocation;
        public List<ArchitectureObject> objects;
 
        public Room(Vector2 _position, int _height, int _width, int _index, ERoomLocation _roomLocation = ERoomLocation.TOP)
        {
            roomLocation = _roomLocation;
            index = _index;
            objects = new List<ArchitectureObject>();
            position = _position;
            height = _height;
            width = _width;
            places = new char[height, width];
            SetColors();
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (i == 0 || (i == (height - 1)))
                    {
                        places[i, j] = '#';
                        colors[i, j] = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        if (j == 0 || (j == (width - 1)))
                        {
                            places[i, j] = '#';
                            colors[i, j] = ConsoleColor.DarkYellow;
                        }
                        else
                        {
                            places[i, j] = '.';
                            colors[i, j] = ConsoleColor.DarkGray;
                        }
                    }
                }
            }
            DungeonGenerator.AddPillars(objects, position, height, width);
            DungeonGenerator.AddWalls(objects, position, height, width);
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

        public new void Draw()
        {           
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (((position.X + i) < Game.world.height) && ((position.Y + j) < Game.world.width))
                    {
                        Game.world.map[(int)(position.X + i), (int)(position.Y + j)] = places[i, j];
                        Game.world.colors[(int)(position.X + i), (int)(position.Y + j)] = colors[i, j];
                    }
                }
            }
            for (int i = 0; i < objects.Count; ++i)
            {
                objects[i].Draw();
            }
        }
    }
}
