using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Player.Inventory
{
    class Item
    {
        public string name;

        public virtual void Use()
        {
        }

        public virtual string GetInfo()
        {
            return "Предмет";
        }
    }
}
