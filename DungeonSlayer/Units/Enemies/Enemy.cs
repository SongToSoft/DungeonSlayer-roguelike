using System;

namespace DungeonSlayer.Units.Enemies
{
    class Enemy : Persona
    {
        public int expectedExp = 0;
        public int expectedGold = 0;
        public int level = 1;

        public Enemy(string _name, ConsoleColor _color,
                    char _form, int _helth, int _attack,
                    int _expectedExp, int _expectedGold,
                    int _accuracy, int _criticalChance, int _level)
        {
            name = _name;
            color = _color;
            form = _form;
            helth = _helth;
            attack = _attack;
            expectedExp = _expectedExp;
            expectedGold = _expectedGold;
            accuracy = _accuracy;
            criticalChance = _criticalChance;
            level = _level;
        }

        public Enemy(Enemy _enemy)
        {
            name = _enemy.name;
            color = _enemy.color;
            form = _enemy.form;
            helth = _enemy.helth;
            attack = _enemy.attack;
            expectedExp = _enemy.expectedExp;
            expectedGold = _enemy.expectedGold;
            accuracy = _enemy.accuracy;
            criticalChance = _enemy.criticalChance;
            level = _enemy.level;
        }
        public bool CheckPlayer()
        {
            if ((Game.world.map[(int)position.X, (int)position.Y + 1] == '@') ||
                (Game.world.map[(int)position.X + 1, (int)position.Y] == '@') ||
                (Game.world.map[(int)position.X, (int)position.Y - 1] == '@') ||
                (Game.world.map[(int)position.X - 1, (int)position.Y] == '@'))
            {
                return true;
            }
            return false;
        }

        public void Update()
        {
            if (inStun)
            {
                StatusLine.AddLine(" " + name + " in stun");
                inStun = false;
            }
            else
            {
                if (CheckPlayer())
                {
                    Attack(Game.player);
                }
                else
                {
                    int value = DungeonGenerator.random.Next(0, 4);
                    switch (value)
                    {
                        case 0:
                            MoveUp();
                            break;
                        case 1:
                            MoveRight();
                            break;
                        case 2:
                            MoveDown();
                            break;
                        case 3:
                            MoveLeft();
                            break;
                    }
                }
            }           
        }
    }
}
