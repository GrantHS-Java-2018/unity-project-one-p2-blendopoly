using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCScript3 : Card
{
    public override void action(Player player)
    {
        player.money += 10;
    }
}