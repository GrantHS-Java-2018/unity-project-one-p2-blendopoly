using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript7 : Card
{
    
    public BoardLayout layout;

    public chanceCard card;
    public override void action(Player player)
    {
        player.index -= 3;
        player.setPos();
        card.landedOnSpace = true;
        layout.boardTrack[player.index].onLand(player);
    }
}
