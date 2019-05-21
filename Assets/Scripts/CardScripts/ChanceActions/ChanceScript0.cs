using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript0 : Card
{
    public BoardLayout layout;

    public CardHandler card;

    public override void  action(Player player)
    {
        //illinois ave = 24
        if (player.index > 24)
        {
            player.passedGo = true;
        }
        player.index = 24;
        player.chanceAction = true;
        card.landedOnSpace = true;
    }
}
