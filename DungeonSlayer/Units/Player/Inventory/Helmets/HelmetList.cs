using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Player.Inventory.Helmets
{
    static class HelmetList
    {
        static public Helmet emptyHelmet = new Armor("Шлем отсутствует", 0, new Vector3(0, 0, 0));
        static public Helmet ironHelmet = new Armor("Железный шлем", 2, new Vector3(0, 0, 0));
        static public Helmet stealHelmet = new Armor("Стальной шлем", 3, new Vector3(0, 0, 0));
        static public Helmet leatherHelmet = new Armor("Кожаный шлем", 1, new Vector3(0, 0, 0));
        static public Helmet elvenHelmet = new Armor("Эльфийский шлем", 3, new Vector3(0, 0, 1));
        static public Helmet dwarfsHelmet = new Armor("Гномий шлем", 4, new Vector3(1, 0, -1));
        static public Helmet obsidianHelmet = new Armor("Обсидиановый шлем", 4, new Vector3(1, 0, 0));
    }
}
