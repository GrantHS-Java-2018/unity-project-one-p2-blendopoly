using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript7 : Card
{
    public BoardLayout layout;
    public override void action(Player player)
    {
        player.index -= 3;
        player.setPos();
        gameObject.GetComponent<chanceCard>().landedOnSpace = true;
        layout.boardTrack[player.index].onLand(player);
    }
}
