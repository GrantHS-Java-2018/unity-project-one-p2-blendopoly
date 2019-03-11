using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : GameTile
{
    private int[] rents;
    private int housePrice;
    private int morgagePrice;
    private bool morgaged = false;

    public Property(Vector3 pos, int[] rents, int housePrice, int morgagePrice)
    {
        this.pos = pos;
        this.rents = rents;
        this.housePrice = housePrice;
        this.morgagePrice = morgagePrice;
    }
    
    public override void onLand(Player player)
    {
        //notImplemented yet
    }
    
}
