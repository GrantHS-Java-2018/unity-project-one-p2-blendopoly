using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Spaces.Purchasable.Purchasable
{
    public class Property : Purchasable
    {
        public int[] rents;
        public int housePrice;
        public int numOfHouses = 0;
        public Property[] group;
        public Object[] buildableList = new Object[5];
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

        public void removeHouse()
        {
            Destroy(buildableList[numOfHouses], 0.0f);
        }

        public void buildHouse(Player player, BuildableManager manager)
        {
            ++numOfHouses;
            if (numOfHouses == 5)
            {
                ++player.numOfHotelsBuilt;
                player.numOfHousesBuilt -= 4;
                for (int i = 0; i < 3; i++)
                {
                    Destroy(buildableList[i]);
            }
            }
            else
            {
                ++player.numOfHousesBuilt;
            }

            player.changeMoney(-housePrice);
            handler.checkIfValid(this);
            bool type = numOfHouses == 5;
            buildableList[numOfHouses-1] = manager.InstantiateBuilding(type, new Vector3(pos.x, pos.y, pos.z + numOfHouses * 2.5f));

        }

        // return the offset so that the buildings are rotated correctly
        public Vector3 returnOffset(BuildableManager manager)
        {
           
            if (manager.getIndexOf(this) < 11)
            {
                return 
            }
            else if (manager.getIndexOf(this) < 20 & manager.getIndexOf(this) > 10)
            {
                
            }
            else if(manager.getIndexOf(this) < 30 & manager.getIndexOf(this) > 20)
            {
    
            }
            else
            {
               
            }
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
            removeHouse();
        }
    
    }
}
