using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript1 : Card
{
    public BoardLayout layout;
    public override void action(Player player)
    {
        //boardwalk = 39
        player.index = 39;
        player.setPos();
        gameObject.GetComponentInParent<chanceCard>().landedOnSpace = true;
        layout.boardTrack[player.index].onLand(player);
    }
}
