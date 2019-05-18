using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript10 : Card
{
    public override void action(Player player)
    {
        player.changeMoney(-((25 * player.numOfHousesBuilt) + (100 * player.numOfHotelsBuilt)));
    }
}
