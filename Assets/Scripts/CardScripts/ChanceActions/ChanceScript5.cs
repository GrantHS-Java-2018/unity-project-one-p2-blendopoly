using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spaces.Purchasable.Purchasable;

public class ChanceScript5 : Card
{
    public BoardLayout layout;
    public override void action(Player player)
    {
        //electric company = 12
        //water works = 28

        int utilityIndex = 0;
        
        if (player.index > 28)
        {
            utilityIndex = 28;
        }
        else if (utilityIndex < 12)
        {
            utilityIndex = 12;
        }

        else if (player.index > 12 && player.index < 20)
        {
            utilityIndex = 12;
        }
        else if (player.index >= 20 && player.index < 28)
        {
            utilityIndex = 28;
        }

        else
        {
            Debug.Log("Game Broken in ChanceScript5");
            utilityIndex = 0;
        }

        player.setPos(layout.boardTrack[utilityIndex]);
        player.index = utilityIndex;
        player.currentPos = utilityIndex;
        Utilities utility = layout.boardTrack[player.index] as Utilities;
        
        if (utility != null && utility.owner == null)
        {
            utility.onLand(player);
        }
        else if (utility != null)
        {
            int rent = utility.calculateRent(utility.owner) * 2;
            player.money -= rent;
            utility.owner.money += rent;
        }
        else
        {
            Debug.Log("Chancescript5 null utility error");
        }
    }
}
