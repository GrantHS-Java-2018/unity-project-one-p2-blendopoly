using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript0 : Card
{
    public BoardLayout layout;

    public override void  action(Player player)
    {
        //illinois ave = 24
        player.index = 24;
        player.setPos();
        gameObject.GetComponent<chanceCard>().landedOnSpace = true;
        layout.boardTrack[player.index].onLand(player);
    }
}
