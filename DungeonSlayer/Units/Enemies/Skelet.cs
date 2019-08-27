using System;

namespace DungeonSlayer.Units.Enemies
{
    class Skelet : Enemy
    {
        public Skelet()
        {
            name = "skeleton";
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
