using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript14 : Card
{

    public BoardLayout layout;
    public override void action(Player player)
    {
        //saint charles = 11
        if (player.index > 11)
        {
            player.money += 200;
        }

        player.index = 11;
        player.setPos();
        gameObject.GetComponentInParent<chanceCard>().landedOnSpace = true;
        layout.boardTrack[player.index].onLand(player);
    }
}
