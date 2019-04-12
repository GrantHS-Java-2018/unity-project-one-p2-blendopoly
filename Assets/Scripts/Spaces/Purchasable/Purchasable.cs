namespace Spaces.Purchasable.Purchasable
{
    public abstract class Purchasable : GameTile
    {
        public int morgagePrice;
        public bool morgaged = false;
        public int price;
        public Player owner;
        public PropertyHandler handler;
    
    
    }
}
