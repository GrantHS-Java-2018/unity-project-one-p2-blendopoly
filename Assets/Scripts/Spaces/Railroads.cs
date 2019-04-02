﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railroads : GameTile
{

    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        player.money -= 200;
    }
}