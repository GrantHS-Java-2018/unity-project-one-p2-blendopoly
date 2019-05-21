using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript9 : Card
{
    public BoardLayout layout;
    public CardHandler card;
    public override void action(Player player)
    {
        //reading railroad = 5
        if (player.index > 5)
        {
            player.passedGo = true;
        }
        player.index = 5;
        player.chanceAction = true;
        card.landedOnSpace = true;
    }
}
