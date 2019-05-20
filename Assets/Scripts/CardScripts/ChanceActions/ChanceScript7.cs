﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript7 : Card
{
    
    public BoardLayout layout;

    public CardHandler card;
    public override void action(Player player)
    {
        player.index -= 3;
        card.landedOnSpace = true;
        layout.boardTrack[player.index].onLand(player);
    }
}
