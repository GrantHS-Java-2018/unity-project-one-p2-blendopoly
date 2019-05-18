using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCScript13 : Card
{
    public override void action(Player player)
    {
        player.changeMoney(-150);
    }
}