using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Player.Inventory.Armores
{
    static class ArmorList
    {
        static public Armor emptyArmor = new Armor("Доспех отсутствует", 0, new Vector3(0, 0, 0));
        static public Armor ironArmor = new Armor("Железный доспех", 4, new Vector3(0, 0, 0));
        static public Armor stealArmor = new Armor("Стальной доспех", 6, new Vector3(0, 0, 0));
        static public Armor leatherArmor = new Armor("Кожаный доспех", 2, new Vector3(0, 1, 0));
        static public Armor elvenArmor = new Armor("Эльфийский доспех", 7, new Vector3(0, 3, 1));
        static public Armor dwarfsArmor = new Armor("Гномий доспех", 10, new Vector3(3, 0, -2));
        static public Armor obsidianArmor = new Armor("Обсидиановый доспех", 11, new Vector3(2, 0, 0));
    }
}
