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
    class Player : Persona
    {
        public PlayerSpecifications specification;
        public PlayerInventory inventory;
        //public Vector2 vision = new Vector2(20, 70);
        public int currentGold = 100;
        public bool isDead = false;

        public Player()
        {
            name = "Игрок";
            form = '@';
            color = ConsoleColor.Red;
            specification = new PlayerSpecifications();
            inventory = new PlayerInventory();
        }

        public void DrawInfo(int value)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            const int startValue = 3;
            switch (value)
            {
                case startValue:
                    Console.WriteLine(" Имя: " + name);
                    break;
                case startValue + 1:
                    Console.WriteLine(" Уровень: " + specification.level);
                    break;
                case startValue + 2:
                    Console.WriteLine(" Опыт: " + specification.currentExp + '/' + specification.maxExp);
                    break;
                case startValue + 3:
                    Console.WriteLine(" Жизни: " + helth + '/' + maxHelth + " Мана: " + mana + '/' + maxMana);
                    break;
                case startValue + 4:
                    Console.WriteLine(" Раса: " + specification.race);
                    break;
                case startValue + 5:
                    Console.WriteLine(" Пол: " + specification.gender);
                    break;
                case startValue + 6:
                    Console.WriteLine(" Класс: " + specification.specialization);
                    break;
                case startValue + 7:
                    Console.WriteLine(" Сила: " + specification.strength);
                    break;
                case startValue + 8:
                    Console.WriteLine(" Ловкость: " + specification.agility);
                    break;
                case startValue + 9:
                    Console.WriteLine(" Интелект: " + specification.intelligence);
                    break;
                case startValue + 10:
                    Console.WriteLine(" Сила заклинаний: " + specification.spellPower);
                    break;
                case startValue + 11:
                    Console.WriteLine(" Текущая атака: " + attack);
                    break;
                case startValue + 12:
                    Console.WriteLine(" Блокируемый урон: " + blocking);
                    break;
                case startValue + 13:
                    Console.WriteLine(" Шанс уклониться: " + evasion);
                    break;
                case startValue + 14:
                    Console.WriteLine(" Шлем: " + inventory.activeHelmet.name);
                    break;
                case startValue + 15:
                    Console.WriteLine(" Доспех: " + inventory.activeArmor.name);
                    break;
                case startValue + 16:
                    Console.WriteLine(" Оружие: " + inventory.activeWeapon.name);
                    break;
                case startValue + 17:
                    Console.WriteLine(" Текущее количество золота: " + currentGold);
                    break;
            }
        }

        public new void SetInRoom(int roomId)
        {
            for (int i = 0; i < Game.world.units.Count; ++i)
            {
                if (Game.world.units[i] is Portal)
                {
                    if (Game.world.map[(int)Game.world.units[i].GetPosition().X, (int)Game.world.units[i].GetPosition().Y + 1] == '.')
                    {
                        position = new Vector2(Game.world.units[i].GetPosition().X, Game.world.units[i].GetPosition().Y + 1);
                    }
                    else
                    {
                        if (Game.world.map[(int)Game.world.units[i].GetPosition().X + 1, (int)Game.world.units[i].GetPosition().Y] == '.')
                        {
                            position = new Vector2(Game.world.units[i].GetPosition().X + 1, Game.world.units[i].GetPosition().Y);
                        }
                        else
                        {
                            if (Game.world.map[(int)Game.world.units[i].GetPosition().X, (int)Game.world.units[i].GetPosition().Y - 1] == '.')
                            {
                                position = new Vector2(Game.world.units[i].GetPosition().X, Game.world.units[i].GetPosition().Y - 1);
                            }
                            else
                            {
                                if (Game.world.map[(int)Game.world.units[i].GetPosition().X - 1, (int)Game.world.units[i].GetPosition().Y] == '.')
                                {
                                    position = new Vector2(Game.world.units[i].GetPosition().X - 1, Game.world.units[i].GetPosition().Y);
                                }
                            }
                        }
                    }
                    break;
                }
            }
        }

        public void Update()
        {
            Console.SetCursorPosition(1, 1);
            StatusLine.status = "";
            char command = Console.ReadKey().KeyChar;
            switch (command)
            {
                case 'w':
                case 'W':
                    CheckPortal((int)position.X - 1, (int)position.Y);
                    CheckAtack((int)position.X - 1, (int)position.Y);
                    MoveUp();
                    break;
                case 'd':
                case 'D':
                    CheckPortal((int)position.X, (int)position.Y + 1);
                    CheckAtack((int)position.X, (int)position.Y + 1);
                    MoveRight();
                    break;
                case 's':
                case 'S':
                    CheckPortal((int)position.X + 1, (int)position.Y);
                    CheckAtack((int)position.X + 1, (int)position.Y);
                    MoveDown();
                    break;
                case 'a':
                case 'A':
                    CheckPortal((int)position.X, (int)position.Y - 1);
                    CheckAtack((int)position.X, (int)position.Y - 1);
                    MoveLeft();
                    break;
                case 'i':
                case 'I':
                    Game.player.inventory.OpenInventory();
                    break;
            }
            Console.SetCursorPosition(1, 1);
            Console.Write(" ");
            Draw();
        }

        public void CheckAtack(int i, int j)
        {
            if ((i < Game.world.height) && (j < Game.world.width))
            {
                Enemy enemy = Game.world.GetEnemyOverPosition(i, j);
                if (Game.world.GetEnemyOverPosition(i, j) != null)
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
                    Portal portal = Game.world.GetPortalOverPosition(i, j);
                    if (portal != null)
                    {
                        if (portal.status == EPortalStatus.NEXT_DUNGEON)
                        {
                            Game.world.LoadNewDungeon();
                        }
                    }
                }
            }
        }
    }
}
