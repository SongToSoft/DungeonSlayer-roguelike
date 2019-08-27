namespace DungeonSlayer.Architecture
{
    class Bridge : ArchitectureObject
    {
        public Bridge(Room roomFirst, Room roomSecond, ELocation location = ELocation.HORIZONTAL)
        {
            if (location == ELocation.HORIZONTAL)
            {
                position.X = roomFirst.GetPosition().X + (roomFirst.GetHeight() / 2);
                position.Y = roomFirst.GetPosition().Y + roomFirst.GetWidth() - 1;
                height = 3;
                width = (int)(roomSecond.GetPosition().Y - position.Y + 5);
                places = new char[height, width];
                for (int i = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {
                        places[i, j] = Game.world.map[(int)(position.X + i), (int)(position.Y + j)];
                    }
                }
                for (int i = 0; i < width; ++i)
                {
                    places[1, i] = '.';
                }
                for (int i = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {
                        if (places[i, j] != '.')
                        {
                            places[i, j] = '#';
                        }
                    }
                }
            }
            else
            {
                position.X = roomFirst.GetPosition().X + roomFirst.GetHeight() - 1;
                position.Y = roomFirst.GetPosition().Y + roomFirst.GetWidth() / 2;
                width = 3;
                height = (int)(roomSecond.GetPosition().X - position.X + 5);
                places = new char[height, width];
                for (int i = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {
                        places[i, j] = Game.world.map[(int)(position.X + i), (int)(position.Y + j)];
                    }
                }
                for (int i = 0; i < height; ++i)
                {
                    places[i, 1] = '.';
                }
                for (int i = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {
                        if (places[i, j] != '.')
                        {
                            places[i, j] = '#';
                        }
                    }
                }
            }
        }
    }
}
