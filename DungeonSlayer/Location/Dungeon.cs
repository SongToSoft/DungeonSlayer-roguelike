using DungeonSlayer.MapObjects;
using DungeonSlayer.Units;
using DungeonSlayer.Units.Enemy;
using DungeonSlayer.Units.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Location
{
    class Dungeon
    {
        public List<Room> rooms = new List<Room>();
        public List<Bridge> bridges = new List<Bridge>();
        public List<Unit> units = new List<Unit>();
        public List<Enemy> enemyes = new List<Enemy>();

        public List<Room> tmp_rooms = new List<Room>();
        public List<Bridge> tmp_bridges = new List<Bridge>();
        public List<Unit> tmp_units = new List<Unit>();
        public List<Enemy> tmp_enemyes = new List<Enemy>();

        public List<Room> hub_rooms = new List<Room>();
        public List<Bridge> hub_bridges = new List<Bridge>();
        public List<Unit> hub_units = new List<Unit>();

        public int enemyCount = 4;

        public Dungeon()
        {
            Load();
        }

        public void Load()
        {
            enemyes = new List<Enemy>();
            units = new List<Unit>();
            rooms = new List<Room>();
            bridges = new List<Bridge>();
        }

        public void SaveDungeon()
        {
            tmp_bridges = bridges;
            tmp_enemyes = enemyes;
            tmp_rooms = rooms;
            tmp_units = units;
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

        public void Generate()
        {
            Load();
            DungeonGenerator.AddRooms(ref rooms);
            Game.world.Draw();
            AddPortal(0, EPortalStatus.HUB);
            AddPortal(rooms.Count - 1, EPortalStatus.NEXT_DUNGEON);
            DungeonGenerator.AddBridges(ref rooms, ref bridges);
            //Add enemyes
            for (int i = 0; i < enemyCount; ++i)
            {
                AddSkelet(i);
                enemyes[i].Draw();
            }
            tmp_bridges = bridges;
            tmp_rooms = rooms;
            tmp_units = units;
            tmp_enemyes = enemyes;
            ++Game.maxLevel;
            Game.currentLevel = Game.maxLevel;
        }

        public void LoadHub()
        {
            Load();
            bridges = hub_bridges;
            rooms = hub_rooms;
            units = hub_units;
            Game.currentLevel = 0;
        }

        public void LoadCurrentDungeon()
        {
            if (tmp_bridges.Count != 0)
            {
                Load();
                bridges = tmp_bridges;
                rooms = tmp_rooms;
                units = tmp_units;
                enemyes = tmp_enemyes;
            }
            else
            {
                Generate();
            }
        }

        public void GenerateHub()
        {
            Load();
            if (hub_rooms.Count == 0)
            {
                DungeonGenerator.MakeHub(ref rooms);
                //DungeonGenerator.AddRooms(ref rooms);
                Game.world.Draw();
                AddPortal(0, EPortalStatus.HUB);
                AddPortal(rooms.Count - 1, EPortalStatus.CURRENT_DUNGEON);
                DungeonGenerator.AddBridges(ref rooms, ref bridges);
                Informant informant = new Informant();
                for (int i = 0; i < 20; ++i)
                {
                    Human human = new Human();
                    human.SetInRoom(DungeonGenerator.random.Next(0, 2));
                    human.Draw();
                    units.Add(human);
                }
                for (int i = 0; i < 10; ++i)
                {
                    Guardian guardian = new Guardian();
                    guardian.SetInRoom(2);
                    guardian.Draw();
                    units.Add(guardian);
                }
                informant.SetInRoom(0);
                units.Add(informant);
                hub_bridges = bridges;
                hub_rooms = rooms;
                hub_units = units;
            }
            else
            {
                LoadHub();
                Game.world.Draw();
            }
        }

        public void Update()
        {
            for (int i = 0; i < units.Count; ++i)
            {
                if ((units[i] is Human) || (units[i] is Guardian))
                {
                    (units[i] as Human).Update();
                }
            }
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
