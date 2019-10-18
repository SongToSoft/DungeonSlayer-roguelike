using System;
using System.Numerics;

namespace DungeonSlayer.Units
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

        public void SetPosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }
    
        public void SetInRoom(int roomId)
        {
            bool checkPosition;
            do
            {
                do
                {
                    checkPosition = false;
                    position = new Vector2(DungeonGenerator.random.Next((int)Game.world.dungeon.rooms[roomId].GetPosition().X + 3, (int)Game.world.dungeon.rooms[roomId].GetPosition().X + Game.world.dungeon.rooms[roomId].GetHeight()),
                                           DungeonGenerator.random.Next((int)Game.world.dungeon.rooms[roomId].GetPosition().Y + 3, (int)Game.world.dungeon.rooms[roomId].GetPosition().Y + Game.world.dungeon.rooms[roomId].GetWidth() - 3));
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
