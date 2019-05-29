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
                player.changeMoney(-rents[numOfHouses]);
                owner.changeMoney(rents[numOfHouses]);
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

        public void buildHouse(Player player, BuildableManager manager)
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

            player.changeMoney(-housePrice);
            handler.checkIfValid(this);
            bool type = numOfHouses == 5;
            manager.InstantiateBuilding(type, pos);

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
            player.changeMoney(housePrice);
            handler.checkIfValid(this);
        }
    
    }
}
