using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSlayer.MapObjects
{
    class Unit
    {
        protected char form;
        protected ConsoleColor color = ConsoleColor.White;
        protected Vector2 position;

        public char GetForm()
        {
            return form;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetInRoom(int roomId)
        {
            bool checkPosition;
            do
            {
                do
                {
                    checkPosition = false;
                    position = new Vector2(DungeonGenerator.random.Next((int)Game.world.dungeon.rooms[roomId].position.X + 1, (int)Game.world.dungeon.rooms[roomId].position.X + Game.world.dungeon.rooms[roomId].height),
                                           DungeonGenerator.random.Next((int)Game.world.dungeon.rooms[roomId].position.Y + 1, (int)Game.world.dungeon.rooms[roomId].position.Y + Game.world.dungeon.rooms[roomId].width - 3));
                    if ((position.X >= Game.world.height) || (position.Y >= Game.world.width))
                    {
                        checkPosition = true;
                        continue;
                    }
                }
                while (checkPosition);
            }
            while ((Game.world.map[(int)(position.X), (int)(position.Y)] != '.'));
        }

        public void Draw()
        {
            Game.world.colors[(int)(position.X), (int)(position.Y)] = color;
            Game.world.map[(int)position.X, (int)position.Y] = GetForm();
        }
    }
}
