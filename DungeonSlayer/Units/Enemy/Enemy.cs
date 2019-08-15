using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Enemy
{
    class Enemy : Persona
    {
        public int expectedExp = 0;

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
