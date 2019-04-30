using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript12 : Card
{
    public override void action(Player player)
    {
        player.money += 150;
    }
}
