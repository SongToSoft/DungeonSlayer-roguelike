using DungeonSlayer.Architecture;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace DungeonSlayer
{
    static class DungeonGenerator
    {
        static public Random random = new Random();
        static public int roomCount = 4;
        static public void AddRooms(List<Room> rooms)
        {
            //int roomCount = random.Next(4, 5);
            ERoomLocation roomLocation;
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < roomCount; ++j)
                {
                    int roomHeight = random.Next(10, 15);
                    int roomWidth = random.Next(20, 23);
                    if (i == 0)
                    {
                        roomLocation = ERoomLocation.TOP;
                    }
                    else
                    {
                        roomLocation = ERoomLocation.DOWN;
                    }
                    if ((i == 0) && (j == 0))
                    {
                        Room room = new Room(new Vector2(3, 3), roomHeight, roomWidth, 0, roomLocation);
                        rooms.Add(room);
                    }
                    else
                    {
                        if ((i == 1) && (j == 0))
                        {
                            Room room = new Room(new Vector2(19, 3), roomHeight, roomWidth, (i * roomCount) + j, roomLocation);
                            rooms.Add(room);
                        }
                        else
                        {
                            Room room = new Room(new Vector2(rooms[(i * roomCount) + (j - 1)].GetPosition().X,
                                                             rooms[(i * roomCount) + (j - 1)].GetPosition().Y + rooms[(i * roomCount) + (j - 1)].GetWidth() + random.Next(3, 5)),
                                                             roomHeight, roomWidth, (i * roomCount) + j, roomLocation);
                            rooms.Add(room);
                        }
                    }           
                }
            }
        }

        static public void AddBridges(List<Room> rooms, List<Bridge> bridges, bool isDungeon = true)
        {
            for (int i = 0; i < rooms.Count; ++i)
            {
                for (int j = 0; j < rooms.Count; ++j)
                {
                    if (rooms[i].GetPosition().Y < rooms[j].GetPosition().Y)
                    {
                        if ((rooms[j].GetPosition().Y - (rooms[i].GetPosition().Y + rooms[i].GetWidth() - 1) + 1) > 0)
                        {
                            Bridge bridge = new Bridge(rooms[i], rooms[j]);
                            bridges.Add(bridge);
                            break;
                        }
                    }
                }
            }
            if (isDungeon)
            {
                int verticalCount = random.Next(1, 4);
                for (int i = 0; i < verticalCount; ++i)
                {
                    int currentBridge = random.Next(0, 4);
                    Bridge bridge = new Bridge(rooms[currentBridge], rooms[currentBridge + 4], ELocation.VERTICAL);
                    bridges.Add(bridge);
                }
            }
        }

        static public void AddPillars(List<ArchitectureObject> objects, Vector2 roomPosition, int roomHeight, int roomWidth)
        {
            int pillarsCount = random.Next(2, 3);
            for (int i = 0; i < pillarsCount; ++i)
            {
                Pillar pillar = new Pillar(random.Next((int)roomPosition.X + 3, (int)roomPosition.X + roomHeight - 5),
                                           random.Next((int)roomPosition.Y + 2, (int)roomPosition.Y + roomWidth - 5));
                objects.Add(pillar);
            }
        }

        static public void AddWalls(List<ArchitectureObject> objects, Vector2 roomPosition, int roomHeight, int roomWidth)
        {
            int wallsCount = random.Next(2, 3);
            for (int i = 0; i < wallsCount; ++i)
            {
                Wall WallHorizontal = new Wall(random.Next((int)roomPosition.X + 3, (int)roomPosition.X + roomHeight - 5),
                                           random.Next((int)roomPosition.Y + 2, (int)roomPosition.Y + roomWidth - 5), ELocation.HORIZONTAL);
                Wall WallVertical = new Wall(random.Next((int)roomPosition.X + 3, (int)roomPosition.X + roomHeight - 5),
                           random.Next((int)roomPosition.Y + 2, (int)roomPosition.Y + roomWidth - 5), ELocation.VERTICAL);
                objects.Add(WallHorizontal);
                objects.Add(WallVertical);
            }
        }

        static public bool CheckRoom(List<Room> rooms, Room room)
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

        static public void MakeHub(List<Room> rooms)
        {
            for (int i = 0; i < 2; ++i)
            {
                int roomHeight = 20;
                int roomWidth = 20;
                Room room = new Room(new Vector2(4, 2 + (i * (roomWidth + 10))), roomHeight, roomWidth, i);
                room.objects = new List<ArchitectureObject>();
                rooms.Add(room);
            }
        }
    }
}
 