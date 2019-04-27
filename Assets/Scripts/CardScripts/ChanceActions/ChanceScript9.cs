﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript9 : Card
{
    public BoardLayout layout;
    public override void action(Player player)
    {
        //reading railroad = 5
        if (player.index > 5)
        {
            player.money += 200;
        }

        player.index = 5;
        player.setPos();
        gameObject.GetComponentInParent<chanceCard>().landedOnSpace = true;
        layout.boardTrack[player.index].onLand(player);
    }
}