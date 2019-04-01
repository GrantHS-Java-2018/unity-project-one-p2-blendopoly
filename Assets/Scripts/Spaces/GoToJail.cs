using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToJail : GameTile
{

    private const int JAIL_INDEX = 10;
    
    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        player.index = JAIL_INDEX;
        player.inJail = true;
    }
}
