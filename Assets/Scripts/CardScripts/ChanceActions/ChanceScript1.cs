using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript1 : Card
{
    public BoardLayout layout;

    public CardHandler card;
    public override void action(Player player)
    {
        //boardwalk = 39
        player.index = 39;
        card.landedOnSpace = true;
        layout.boardTrack[player.index].onLand(player);
    }
}
