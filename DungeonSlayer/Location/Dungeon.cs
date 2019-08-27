using DungeonSlayer.Architecture;
using DungeonSlayer.Units;
using DungeonSlayer.Units.Enemies;
using DungeonSlayer.Units.NPC;
using System.Collections.Generic;

namespace DungeonSlayer.Location
{
    class Dungeon
    {
        public List<Room> rooms = new List<Room>();
        public List<Bridge> bridges = new List<Bridge>();
        public List<Unit> units = new List<Unit>();
        public List<Enemy> enemyes = new List<Enemy>();

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

        public Chest GetChestOverPosition(int indexI, int indexJ)
        {
            for (int i = 0; i < units.Count; ++i)
            {
                if (units[i] is Chest)
                {
                    if ((units[i].GetPosition().X == indexI) && (units[i].GetPosition().Y == indexJ))
                    {
                        return units[i] as Chest;
                    }
                }
            }
            return null;
        }

        public void ShowShop(int indexI, int indexJ)
        {
            for (int i = 0; i < units.Count; ++i)
            {
                if ((units[i].GetPosition().X == indexI) && (units[i].GetPosition().Y == indexJ))
                {
                    (units[i] as Trader).ShowShop();
                }
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

        public void Generate()
        {
            Load();
            DungeonGenerator.AddRooms(ref rooms);
            Game.world.Draw();
            AddPortal(rooms.Count - 1, EPortalStatus.HUB);
            DungeonGenerator.AddBridges(ref rooms, ref bridges);
            for (int i = 0; i < enemyCount; ++i)
            {
                AddSkelet(i);
                enemyes[i].Draw();
            }
            int chestCount = DungeonGenerator.random.Next(1, 5);
            for (int i = 0; i < chestCount; ++i)
            {
                Chest chest = new Chest();
                chest.SetInRoom(DungeonGenerator.random.Next(0, rooms.Count - 1));
                chest.Draw();
                units.Add(chest);
            }
            ++Game.maxDungeonLevel;
            Game.currentDungeonLevel = Game.maxDungeonLevel;
        }

        public void LoadHub()
        {
            Load();
            bridges = hub_bridges;
            rooms = hub_rooms;
            units = hub_units;
            Game.currentDungeonLevel = 0;
        }

        public void LoadCurrentDungeon()
        {
            Generate();
        }

        public void GenerateHub()
        {
            Load();
            if (hub_rooms.Count == 0)
            {
                DungeonGenerator.MakeHub(ref rooms);
                Game.world.Draw();
                AddPortal(rooms.Count - 1, EPortalStatus.NEXT_DUNGEON);
                Game.world.Draw();
                DungeonGenerator.AddBridges(ref rooms, ref bridges, false);
                for (int i = 0; i < 10; ++i)
                {
                    Human human = new Human();
                    human.SetInRoom(DungeonGenerator.random.Next(0, 2));
                    human.Draw();
                    units.Add(human);
                }
                for (int i = 0; i < 5; ++i)
                {
                    Guardian guardian = new Guardian();
                    guardian.SetInRoom(rooms.Count - 1);
                    guardian.Draw();
                    units.Add(guardian);
                }
                Informant informant = new Informant();
                informant.SetInRoom(0);
                units.Add(informant);

                ETraderType[] types = { ETraderType.ARMOR, ETraderType.BOTTLE, ETraderType.HELMET, ETraderType.WEAPON };
                for (int i = 0; i < types.Length; ++i)
                {
                    Trader trader = new Trader(types[i]);
                    trader.SetInRoom(DungeonGenerator.random.Next(0, 2));
                    trader.Draw();
                    units.Add(trader);
                }
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
