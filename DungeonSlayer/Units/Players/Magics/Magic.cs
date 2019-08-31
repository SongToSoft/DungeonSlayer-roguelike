namespace DungeonSlayer.Units.Players.Magics
{
    delegate void CastDelegate();

    class Magic
    {
        public string name;
        public string info;
        public int cost;
        public CastDelegate castDelegate;

        public Magic(string _name, string _info, int _cost, CastDelegate _castDelegate)
        {
            name = _name;
            info = _info;
            cost = _cost;
            castDelegate = _castDelegate;
        }

        public void Cast()
        {
            if (this.name != "Empty magic")
            {
                if (Game.player.mana >= cost)
                {
                    Game.player.mana -= cost;
                    castDelegate();
                    StatusLine.AddLine(" You use magic: " + name + " for " + cost + " mana");
                }
                else
                {
                    StatusLine.AddLine(" You dont have enough mana for: " + name);
                }
            }            
        }
    }
}
