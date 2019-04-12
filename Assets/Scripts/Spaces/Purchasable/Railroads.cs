using UnityEngine;

namespace Spaces.Purchasable.Purchasable
{
    public class Railroads : Purchasable
    {

        public BoardLayout layout;

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
            else if (owner == player)
            {
                player.readyForTurn();
            }
            else
            {
                int rent = calculateRent(player);
                player.money -= rent;
                owner.money += rent;
            }
        }

        private int calculateRent(Player player)
        {
            switch (player.railroads)
            {
                case 1: return 25;
                case 2: return 50;
                case 3: return 100;
                case 4: return 200;
                default:
                    //should never happen but congrats you don't pay rent!
                    return 0;
            }
        }
    }
}