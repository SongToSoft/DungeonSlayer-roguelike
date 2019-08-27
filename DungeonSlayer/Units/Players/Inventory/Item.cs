namespace DungeonSlayer.Units.Players.Inventory
{
    class Item
    {
        public string name;
        public int cost = 20;
        public int level = 1;

        public virtual void Use()
        {
        }

        public virtual string GetInfo()
        {
            return "Item";
        }
    }
}
