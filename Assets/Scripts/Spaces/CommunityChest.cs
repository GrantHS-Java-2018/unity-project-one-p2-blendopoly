using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunityChest : GameTile
{

    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        //throw new System.NotImplementedException();
        player.readyForAction();
    }
}
