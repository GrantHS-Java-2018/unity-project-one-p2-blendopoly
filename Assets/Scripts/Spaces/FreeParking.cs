﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeParking : GameTile
{

    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        //do nothing
        player.readyForAction();
    }
}
