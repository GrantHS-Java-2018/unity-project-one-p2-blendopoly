using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCScript6 : Card
{
    public override void action(Player player)
    {
        player.money -= ((40 * player.numOfHousesBuilt) + (115 * player.numOfHotelsBuilt));
    }

}