using System;

namespace DungeonSlayer.Units
{
    enum EPortalStatus
    {
        NEXT_DUNGEON,
        HUB,
        CURRENT_DUNGEON
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
