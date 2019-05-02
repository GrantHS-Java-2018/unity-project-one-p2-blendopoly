using UnityEngine;

namespace Spaces.Purchasable.Purchasable
{
    public class Utilities : Purchasable
    {

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
                int rent = calculateRent(player);
                player.money -= rent;
                owner.money += rent;
                player.readyForAction();
            }
        }

        public int calculateRent(Player player)
        {
            int dieRoll = 6;
            switch (player.utilities)
            {
                case 1: return 4 * dieRoll;
                case 2: return 10 * dieRoll;
                default:
                    Debug.Log("Broken in Utilities");
                    //should never happen but congrats you don't pay rent
                    return 0;
            }
        }
    }
}