using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.Units.Enemies
{
    static class EnemyesList
    {
        static public Enemy skelet = new Enemy("skeleton", ConsoleColor.Gray, 's', 10, 5, 2, 2, 90, 5, 1);
        static public Enemy zombi = new Enemy("zombi", ConsoleColor.Green, 'z', 13, 6, 3, 3, 40, 20, 2);
        static public Enemy imp = new Enemy("imp", ConsoleColor.Red, 'i', 15, 7, 4, 4, 90, 6, 3);
        static public Enemy spider = new Enemy("spider", ConsoleColor.Blue, 's', 15, 8, 5, 5, 80, 15, 3);
        static public Enemy goblin = new Enemy("goblin", ConsoleColor.DarkGreen, 'g', 21, 9, 6, 6, 90, 7, 4);
        static public Enemy robber = new Enemy("robber", ConsoleColor.Magenta, 'r', 23, 12, 7, 7, 90, 7, 5);
        static public Enemy darkElf = new Enemy("dark elf", ConsoleColor.DarkCyan, 'e', 25, 14, 8, 8, 90, 10, 6);
        static public Enemy goblinBoss = new Enemy("Boss Goblin", ConsoleColor.DarkGreen, 'G', 28, 12, 9, 9, 90, 13, 7);
        static public Enemy сerberus = new Enemy("сerberus", ConsoleColor.Red, 'C', 30, 13, 10, 10, 90, 5, 8);
        static public Enemy fireElemental = new Enemy("Fire Elemental", ConsoleColor.Red, 'E', 32, 15, 11, 11, 90, 5, 9);
        static public Enemy waterElemental = new Enemy("Water Elemental", ConsoleColor.Blue, 'E', 33, 16, 12, 12, 90, 5, 10);
        static public Enemy windElemental = new Enemy("Wind Elemental", ConsoleColor.White, 'E', 34, 17, 13, 13, 90, 5, 11);
        static public Enemy giantTortoise = new Enemy("Giant Tortoise", ConsoleColor.Green, 'T', 38, 18, 14, 14, 80, 9, 12);
        static public Enemy golem = new Enemy("Golem", ConsoleColor.White, 'G', 42, 19, 15, 15, 90, 5, 13);
        static public Enemy manticore = new Enemy("Manticore", ConsoleColor.DarkRed, 'M', 44, 21, 16, 16, 85, 6, 14);
        static public Enemy naga = new Enemy("Naga", ConsoleColor.Blue, 'N', 20, 23, 17, 17, 95, 7, 15);
        static public Enemy dragon = new Enemy("Dragon", ConsoleColor.Red, 'D', 45, 24, 18, 18, 90, 5, 16);
        static public Enemy blackDragon = new Enemy("Black Dragon", ConsoleColor.Black, 'D', 47, 25, 19, 19, 90, 5, 17);
        static public Enemy titan = new Enemy("Titan", ConsoleColor.White, 'T', 48, 26, 20, 20, 90, 5, 17);
        static public Enemy diablo = new Enemy("Diablo", ConsoleColor.DarkMagenta, 'D', 60, 35, 25, 25, 90, 10, 25);

        static public List<Enemy> enemyes = new List<Enemy>()
        {
            skelet,
            zombi,
            imp,
            spider,
            goblin,
            robber,
            darkElf,
            goblinBoss,
            сerberus,
            fireElemental,
            waterElemental,
            windElemental,
            giantTortoise,
            golem,
            manticore,
            naga,
            dragon,
            blackDragon,
            titan,
            diablo
        };

        static public Enemy GetEnemyByDungeonLevel()
        {
            int lvl = Game.maxDungeonLevel;
            if (Game.maxDungeonLevel > 17)
            {
                lvl = 17;
            }
            bool isLevelCorrect = false;
            while (!isLevelCorrect)
            {
                int index = DungeonGenerator.random.Next(0, enemyes.Count);
                Enemy enemy = enemyes[index];
                if ((enemy.level >= lvl) && (enemy.level <= (lvl +2)))
                {
                    return enemy;
                }
            }
            return enemyes[enemyes.Count - 1];
        }
    }
}
