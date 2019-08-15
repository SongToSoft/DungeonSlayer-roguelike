using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.MapObjects
{
    enum EPortalStatus
    {
        NEXT_DUNGEON,
        HUB
    }
    class Portal : Unit
    {
        public EPortalStatus status; 
        public Portal(EPortalStatus _status)
        {
            form = 'P';
            color = ConsoleColor.Blue;
            status = _status;
        }
    }
}
