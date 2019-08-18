using DungeonSlayer.Architecture;
using DungeonSlayer.Location;
using DungeonSlayer.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer
{
    static class DungeonGenerator
    {
        static public Random random = new Random();

        static public void AddRooms(ref List<Room> rooms)
        {
            int roomCount = random.Next(4, 5);
            for (int i = 0; i < roomCount; ++i)
            {
                int roomHeight = random.Next(15, 20);
                int roomWidth = random.Next(15, 25);
                if (i == 0)
                {
                    Room room = new Room(new Vector2(random.Next(5, 7), random.Next(2, 5)), roomHeight, roomWidth, i);
                    rooms.Add(room);
                }
                else
                {
                    Room room = new Room(new Vector2((rooms[i - 1].position.X) + random.Next(-2, 2),
                                                      rooms[i - 1].position.Y + rooms[i - 1].width + random.Next(2, 6)),
                                                      roomHeight, roomWidth, i);
                    rooms.Add(room);
                }
            }
        }

        static public void AddBridges(ref List<Room> rooms, ref List<Bridge> bridges)
        {
            for (int i = 0; i < rooms.Count; ++i)
            {
                for (int j = 0; j < rooms.Count; ++j)
                {
                    if (rooms[i].position.Y < rooms[j].position.Y)
                    {
                        Bridge bridge = new Bridge(rooms[i], rooms[j], ref Game.world.map);
                        bridges.Add(bridge);
                        break;
                    }
                }
            }
        }

        static public void AddPillars(ref List<Pillar> pillars, Vector2 roomPosition, int roomHeight, int roomWidth)
        {
            int pillarsCount = random.Next(2, 3);
            for (int i = 0; i < pillarsCount; ++i)
            {
                Pillar pillar = new Pillar(random.Next((int)roomPosition.X + 3, (int)roomPosition.X + roomHeight - 5),
                                           random.Next((int)roomPosition.Y + 2, (int)roomPosition.Y + roomWidth - 5));
                pillars.Add(pillar);
            }
        }

        static public bool CheckRoom(ref List<Room> rooms, ref Room room)
        {
            for (int i = 0; i < rooms.Count; ++i)
            {
                if (rooms[i].Contain(room))
                {
                    return true;
                }
            }
            return false;
        }

        static public void MakeHub(ref List<Room> rooms)
        {
            int roomHeight = 25;
            int roomWidth = 30;
            for (int i = 0; i < 3; ++i)
            {
                Room room = new Room(new Vector2(4, 2 + (i * roomWidth + 5)), roomHeight, roomWidth, i);
                room.pillars = new List<Pillar>();
                rooms.Add(room);
            }
        }
    }
}
 