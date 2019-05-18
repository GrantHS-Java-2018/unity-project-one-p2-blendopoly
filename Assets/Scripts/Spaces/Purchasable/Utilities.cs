using UnityEngine;

namespace Spaces.Purchasable.Purchasable
{
    public class Utilities : Purchasable
    {
        public Die die1;
        public Die die2;

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
                int rent = calculateRent(owner);
                player.changeMoney(-rent);
                owner.changeMoney(rent);
                player.readyForAction();
            }
        }

        public int calculateRent(Player player)
        {
            int dieRoll = die1.faceShowing + die2.faceShowing;
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