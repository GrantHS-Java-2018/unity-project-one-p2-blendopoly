using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript4 : Card
{
    public override void action(Player player)
    {
        player.hasGetOutOfJailFree += 1;
    }
}
