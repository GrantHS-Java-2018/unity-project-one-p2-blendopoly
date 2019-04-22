using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = System.Random;

public class CommunityChest : GameTile
{
    public CCCard card;
    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        Vector3 position;
        position.x = 0;
        position.y = 0;
        position.z = 1;
        card.renderOn(position);

        player.readyForAction();
    }

}
