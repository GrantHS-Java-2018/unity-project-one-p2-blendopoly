using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript14 : Card
{
    
    public BoardLayout layout;

    public chanceCard card;
    public override void action(Player player)
    {
        //saint charles = 11
        if (player.index > 11)
        {
            player.changeMoney(200);
        }

        player.index = 11;
        card.landedOnSpace = true;
        layout.boardTrack[player.index].onLand(player);
    }
}
