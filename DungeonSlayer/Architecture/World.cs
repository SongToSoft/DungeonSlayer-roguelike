using DungeonSlayer.Architecture;
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
        public char[,] map;
        public ConsoleColor[,] colors;
        public int height, width;
        public List<Room> rooms = new List<Room>();
        public List<Bridge> bridges = new List<Bridge>();
        public List<Unit> units;
        public List<Enemy> enemyes;

        public void LoadNewDungeon()
        {
            enemyes = new List<Enemy>();
            units = new List<Unit>();
            map = new char[height, width];
            colors = new ConsoleColor[height, width];

            rooms = new List<Room>();
            bridges = new List<Bridge>();
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    map[i, j] = ' ';
                    colors[i, j] = ConsoleColor.White;
                }
            }
            GenerateMap();
            Game.player.SetInRoom(0);
        }

        public World(int _height, int _width)
        {
            enemyes = new List<Enemy>();
            units = new List<Unit>();
            height = _height;
            width = _width;
            map = new char[height, width];
            colors = new ConsoleColor[height, width];

            rooms = new List<Room>();
            bridges = new List<Bridge>();
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    map[i, j] = ' ';
                    colors[i, j] = ConsoleColor.White;
                }
            }
        }
        
        public Enemy GetEnemyOverPosition(int indexI, int indexJ)
        {
            for (int i = 0; i < enemyes.Count; ++i)
            {
                if ((enemyes[i].GetPosition().X == indexI) && (enemyes[i].GetPosition().Y == indexJ))
                {
                    return enemyes[i];
                }
            }
            return null;
        }

        public Portal GetPortalOverPosition(int indexI, int indexJ)
        {
            for (int i = 0; i < units.Count; ++i)
            {
                if (units[i] is Portal)
                {
                    if ((units[i].GetPosition().X == indexI) && (units[i].GetPosition().Y == indexJ))
                    {
                        return units[i] as Portal;
                    }
                }
            }
            return null;
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

        public void AddPortal(int index, EPortalStatus status)
        {
            Portal portal = new Portal(status);
            portal.SetInRoom(index);
            units.Add(portal);
        }

        public void AddSkelet(int index)
        {
            Skelet skelet = new Skelet();
            skelet.SetInRoom(index);
            enemyes.Add(skelet);
        }

        public void GenerateMap()
        {
            ++Game.dungeonLevel;
            //for (int i = 0; i < roomsCount; ++i)
            //{
            //    DungeonGenerator.AddRoom(ref rooms);
            //}
            DungeonGenerator.AddRooms(ref rooms);            
            Draw();
            AddPortal(0, EPortalStatus.HUB);
            AddPortal(rooms.Count - 1, EPortalStatus.NEXT_DUNGEON);
            AddSkelet(0);
            AddSkelet(1);
            AddSkelet(2);
            AddSkelet(3);
            DungeonGenerator.AddBridges(ref rooms, ref bridges);
            AddBorder();
            Draw();
        }

        public void Update()
        {
            //for (int i = 0; i < rooms.Count; ++i)
            //{
            //    rooms[i].Update();
            //}
            for (int i = 0; i < enemyes.Count; ++i)
            {
                enemyes[i].Update();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < rooms.Count; ++i)
            {
                rooms[i].Draw();
            }
            for (int i = 0; i < bridges.Count; ++i)
            {
                bridges[i].Draw();
            }
            for (int i = 0; i < units.Count; ++i)
            {
                units[i].Draw();
            }
            for (int i = 0; i < enemyes.Count; ++i)
            {
                enemyes[i].Draw();
            }
        }
    }
}
