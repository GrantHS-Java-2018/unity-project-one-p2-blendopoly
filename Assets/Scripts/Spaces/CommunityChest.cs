using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = System.Random;

public class CommunityChest : GameTile
{
    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        player.readyForAction();
    }

}
