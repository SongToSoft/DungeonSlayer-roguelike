using DungeonSlayer.MapObjects;
using DungeonSlayer.Units.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.NPC
{
    class Human : Persona
    {
        public Human()
        {
            form = 'h';
            color = ConsoleColor.Gray;
        }

        public void Update()
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
