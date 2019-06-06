using System;
using System.Numerics;
using UnityEngine;
using Object = UnityEngine.Object;
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
                for (int i = 0; i < 4; i++)
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
            buildableList[numOfHouses-1] = InstantiateBuildingOffset(manager, numOfHouses == 5, 2f, 1f, .5f, numOfHouses);
            // pos + (returnOffset(manager) * 2.5f * numOfHouses);
            
        }

        public Object InstantiateBuildingOffset(BuildableManager manager, bool type, float centerOffset, float horizontalOffset, float spacing, int numOfHouses)
        {
            
            return manager.InstantiateBuilding((type), ((pos +(type ? new Vector3(0, 2, 0): new Vector3(0, 0, 0)) + centerOffset * returnOffset(manager)) - (horizontalOffset* (type? -.5f: 1f) * switchVectorXZ(returnOffset(manager))) + (switchVectorXZ(returnOffset(manager)) * spacing * (numOfHouses == 5 ? 0 : numOfHouses))));

        }

        // return the offset so that the buildings are positioned correctly
        public Vector3 returnOffset(BuildableManager manager)
        {

            float offset = 5;
            
            if (manager.getIndexOf(this) < 11)
            {
                return new Vector3(0, 0, offset);
            }
            else if (manager.getIndexOf(this) < 20 & manager.getIndexOf(this) > 10)
            {
                return new Vector3(offset,0,0);
            }
            else if(manager.getIndexOf(this) < 30 & manager.getIndexOf(this) > 20)
            {
                return new Vector3(0,0,-offset);
            }
            else
            {
               return new Vector3(-offset,0,0);
            }
        }

        public void rebuildHouses(BuildableManager manager)
        {
            for (int i = 0; i < 4; i++)
            {
                buildableList[i] =
                    InstantiateBuildingOffset(manager, numOfHouses == 5, 2f, 1f, .5f, i+1);
            }
        }

        public Vector3 switchVectorXZ(Vector3 inVector)
        {
            return new Vector3(inVector.z, inVector.y, inVector.x);
        }

       

        public void sellHouse(Player player, BuildableManager manager)
        {
            --numOfHouses;
            // this offsets the houses for some reason
            if (numOfHouses == 4)
            {
                --player.numOfHotelsBuilt;
                player.numOfHousesBuilt += 4;
                rebuildHouses(manager);
                
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
