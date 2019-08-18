using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Enemy
{
    class Skelet : Enemy
    {
        public Skelet()
        {
            name = "скелет";
            color = ConsoleColor.DarkGray;
            form = 's';
            helth = 15;
            attack = 6;
            expectedExp = DungeonGenerator.random.Next(3, 5);
            expectedGold = DungeonGenerator.random.Next(1, 5);
            accuracy = 90;
            criticalChance = 5;
        }
    }
}
