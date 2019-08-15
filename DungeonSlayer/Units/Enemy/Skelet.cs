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
            expectedExp = 5;
        }
    }
}
