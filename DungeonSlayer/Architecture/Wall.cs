namespace DungeonSlayer.Architecture
{
    class Wall : ArchitectureObject
    {
        private ELocation location;

        public Wall(int x, int y, ELocation _location)
        {
            position.X = x;
            position.Y = y;
            location = _location;
            if (location == ELocation.HORIZONTAL)
            {
                height = 1;
                width = 4;
            }
            else
            {
                width = 1;
                height = 4;
            }
            places = new char[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    places[i, j] = '#';
                }
            }
        }
    }
}
