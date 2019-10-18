using DungeonSlayer.FileSystem;
using DungeonSlayer.Units.Enemies;
using DungeonSlayer.Units.Players.Inventory;
using DungeonSlayer.Units.Players.Magics;
using DungeonSlayer.Units.Players.Perks;
using System;
using System.Numerics;

namespace DungeonSlayer.Units.Players
{
    class Player : Persona
    {
        public PlayerSpecifications specification;
        public PlayerInventory inventory;
        public PerksSystem perksSystem;
        public MagicSystem magicSystem;
        public int currentGold = 5;
        public bool isDead = false, isMove = false;

        public Player()
        {
            name = "Player";
            form = '@';
            color = ConsoleColor.Red;
            specification = new PlayerSpecifications();
            inventory = new PlayerInventory();
            perksSystem = new PerksSystem();
            magicSystem = new MagicSystem();
        }

        public void DrawInfo(int value)
        {
            const int startValue = 3;
            switch (value)
            {
                case startValue:
                    Console.WriteLine(" Name: " + name + "     ");
                    break;
                case startValue + 1:
                    Console.WriteLine(" Level: " + specification.level + "     ");
                    break;
                case startValue + 2:
                    Console.WriteLine(" Experience: " + specification.currentExp + '/' + specification.maxExp + "     ");
                    break;
                case startValue + 3:
                    Console.WriteLine(" Helth: " + helth + '/' + maxHelth + " Mana: " + mana + '/' + maxMana + "     ");
                    break;
                case startValue + 4:
                    Console.WriteLine(" Race: " + specification.race + "     ");
                    break;
                case startValue + 5:
                    Console.WriteLine(" Gender: " + specification.gender + "     ");
                    break;
                case startValue + 6:
                    Console.WriteLine(" Class: " + specification.specialization + "     ");
                    break;
                case startValue + 7:
                    Console.WriteLine(" Strength: " + specification.strength + "     ");
                    break;
                case startValue + 8:
                    Console.WriteLine(" Agility: " + specification.agility + "     ");
                    break;
                case startValue + 9:
                    Console.WriteLine(" Intelligence: " + specification.intelligence + "     ");
                    break;
                case startValue + 10:
                    Console.WriteLine(" Spell Power: " + specification.spellPower + "     ");
                    break;
                case startValue + 11:
                    Console.WriteLine(" Active Magic: " + ((magicSystem.activeMagic != null) ? magicSystem.activeMagic.name : "No active magic"));
                    break;
                case startValue + 12:
                    Console.WriteLine(" Attack: " + attack + "     ");
                    break;
                case startValue + 13:
                    Console.WriteLine(" Defense: " + blocking + "     ");
                    break;
                case startValue + 14:
                    Console.WriteLine(" Evasion: " + evasion + "     ");
                    break;
                case startValue + 15:
                    Console.WriteLine(" Accuracy: " + accuracy + "     ");
                    break;
                case startValue + 16:
                    Console.WriteLine(" Critical Chance: " + criticalChance + "     ");
                    break;
                case startValue + 17:
                    Console.WriteLine(" Helmet: " + inventory.activeHelmet.name + "     ");
                    break;
                case startValue + 18:
                    Console.WriteLine(" Armor: " + inventory.activeArmor.name + "     ");
                    break;
                case startValue + 19:
                    Console.WriteLine(" Weapon: " + inventory.activeWeapon.name + "     ");
                    break;
                case startValue + 20:
                    Console.WriteLine(" Gold: " + currentGold + "     ");
                    break;
            }
        }
        public void Update()
        {
            if (inStun)
            {
                StatusLine.AddLine(" " + name + " in stun");
                inStun = false;
                isMove = true;
            }
            else
            {
                isMove = false;
                Console.SetCursorPosition(1, 1);

                char command = Console.ReadKey(true).KeyChar;
                switch (command)
                {
                    case 'w':
                    case 'W':
                        isMove = true;
                        AllChecks((int)position.X - 1, (int)position.Y);
                        MoveUp();
                        break;
                    case 'd':
                    case 'D':
                        isMove = true;
                        AllChecks((int)position.X, (int)position.Y + 1);
                        MoveRight();
                        break;
                    case 's':
                    case 'S':
                        isMove = true;
                        AllChecks((int)position.X + 1, (int)position.Y);
                        MoveDown();
                        break;
                    case 'a':
                    case 'A':
                        isMove = true;
                        AllChecks((int)position.X, (int)position.Y - 1);
                        MoveLeft();
                        break;
                    case 'i':
                    case 'I':
                        inventory.OpenInventory();
                        break;
                    case 'u':
                    case 'U':
                        specification.LevelUp();
                        break;
                    case 'p':
                    case 'P':
                        perksSystem.ShowPerks();
                        break;
                    case 'q':
                    case 'Q':
                        if (magicSystem.activeMagic != null)
                        {
                            magicSystem.activeMagic.Cast();
                        }
                        break;
                    case 'm':
                    case 'M':
                        magicSystem.ShowMagics();
                        break;
                }
            }
            Console.SetCursorPosition(1, 1);
            Console.Write(" ");
            Draw();
        }

        public void AllChecks(int i, int j)
        {
            CheckChest(i, j);
            CheckTrader(i, j);
            CheckInformant(i, j);
            CheckPortal(i, j);
            CheckAtack(i, j);
        }

        public void CheckAtack(int i, int j)
        {
            if ((i < Game.world.height) && (j < Game.world.width))
            {
                Enemy enemy = Game.world.dungeon.GetEnemyOverPosition(i, j);
                if (Game.world.dungeon.GetEnemyOverPosition(i, j) != null)
                {
                    Attack(enemy);
                }
            }
        }

        public void CheckPortal(int i, int j)
        {
            if ((i < Game.world.height) && (j < Game.world.width))
            {
                if (Game.world.map[i, j] == 'P')
                {
                    Portal portal = Game.world.dungeon.GetPortalOverPosition(i, j);
                    if (portal != null)
                    {
                        if (portal.status == EPortalStatus.NEXT_DUNGEON)
                        {
                            Game.world.GoToNewDungeon();
                        }
                        if (portal.status == EPortalStatus.HUB)
                        {
                            if (Game.player.magicSystem.isBuffAttack)
                            {
                                Game.player.attack -= 3;
                                Game.player.magicSystem.isBuffAttack = false;
                            }
                            if (Game.player.magicSystem.isBuffEvasion)
                            {
                                Game.player.evasion -= 5;
                                Game.player.magicSystem.isBuffEvasion = false;
                            }
                            if (Game.player.magicSystem.isBuffBlocking)
                            {
                                Game.player.magicSystem.isBuffBlocking = false;
                                Game.player.blocking -= Game.player.specification.spellPower;
                            }
                            if (Game.player.perksSystem.CheckPerk(PerksList.allRecoverHPPerk))
                            {
                                Game.player.helth = Game.player.maxHelth;
                            }
                            if (Game.player.perksSystem.CheckPerk(PerksList.allRecoverManaPerk))
                            {
                                Game.player.maxMana = Game.player.mana;
                            }
                            Console.Clear();
                            Game.consoleBuffer = new char[Game.consoleHeight, Game.consoleWidth];
                            SaveSystem.DelCharacter();
                            SaveSystem.SaveCharacter();
                            Game.world.GoToHub();
                        }
                        if (portal.status == EPortalStatus.CURRENT_DUNGEON)
                        {
                            Game.world.GoToCurrentDungeon();
                        }
                    }
                }
            }
        }

        public void CheckInformant(int i, int j)
        {
            if ((i < Game.world.height) && (j < Game.world.width))
            {
                if (Game.world.map[i, j] == 'I')
                {
                    StatusLine.ShowInfo();
                }
            }
        }

        public void CheckTrader(int i, int j)
        {
            if ((i < Game.world.height) && (j < Game.world.width))
            {
                if (Game.world.map[i, j] == 'T')
                {
                    Game.world.dungeon.ShowShop(i, j);
                }
            }
        }

        public void CheckChest(int i, int j)
        {
            if ((i < Game.world.height) && (j < Game.world.width))
            {
                if (Game.world.map[i, j] == 'C')
                {
                    Chest chest = Game.world.dungeon.GetChestOverPosition(i, j);
                    if (chest != null)
                    {
                        if (chest.active)
                        {
                            inventory.items.Add(chest.GetBounty());
                        }
                    }
                }
            }
        }

        public new void SetInRoom(int roomId)
        {
            position = new Vector2((int)Game.world.dungeon.rooms[roomId].GetPosition().X + 2, (int)Game.world.dungeon.rooms[roomId].GetPosition().Y + 2);
        }
    }
}
