using UnityEngine;

namespace Spaces.Purchasable.Purchasable
{
    public class Property : Purchasable
    {
        public int[] rents;
        public int housePrice;
        public int numOfHouses = 0;

        void Start()
        {
            pos = GetComponent<Transform>().position;
        }
    
        public override void onLand(Player player)
        {
            if (owner == null)
            {
                handler.buyProperty(this, player);
            }
            else if (owner == player || morgaged)
            {
                player.readyForAction();
            }
            else
            {
                player.money -= rents[numOfHouses];
                owner.money += rents[numOfHouses];
                player.readyForAction();
            }
        }
    
    }
}
