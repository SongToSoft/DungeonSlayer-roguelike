using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.NPC
{
    class Guardian : Human
    {
        public Guardian()
        {
            form = 'g';
            color = ConsoleColor.DarkRed;
        }
    }
}
