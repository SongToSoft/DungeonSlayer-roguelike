namespace DungeonSlayer.Units.Players.Inventory
{
    enum EItemType
    {
        ITEM,
        ARMOR,
        HELMET,
        WEAPON
    }

    class Item
    {
        public string name;
        public int cost = 20;
        public int level = 1;
        public EItemType itemType;

        public virtual void Use()
        {
        }

        public virtual string GetInfo()
        {
            return "Item";
        }
    }
}
