using UnityEngine;

namespace Spaces.Purchasable.Purchasable
{
    public class Property : Purchasable
    {
        public int[] rents;
        public int housePrice;
        public int numOfHouses = 0;
        public Property[] group;

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

        public bool groupOwned()
        {
            foreach (Property property in group)
            {
                if (owner != property.owner)
                {
                    return false;
                }
            }
            return true;
        }

        public void buildHouse(Player player)
        {
            ++numOfHouses;
            if (numOfHouses == 5)
            {
                ++player.numOfHotelsBuilt;
                player.numOfHousesBuilt -= 4;
            }
            else
            {
                ++player.numOfHousesBuilt;
            }
            player.money -= housePrice;
            handler.checkIfValid(this);
        }

        public void sellHouse(Player player)
        {
            --numOfHouses;
            if (numOfHouses == 4)
            {
                --player.numOfHotelsBuilt;
                player.numOfHousesBuilt += 4;
            }
            else
            {
                --player.numOfHousesBuilt;
            }
            player.money += housePrice;
            handler.checkIfValid(this);
        }
    
    }
}
