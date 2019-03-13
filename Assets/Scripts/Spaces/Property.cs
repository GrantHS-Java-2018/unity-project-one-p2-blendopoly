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
    private int price;

    public Property(Vector3 pos, int[] rents, int housePrice, int morgagePrice, int price)
    {
        this.pos = pos;
        this.rents = rents;
        this.housePrice = housePrice;
        this.morgagePrice = morgagePrice;
        this.price = price;
    }
    
    public override void onLand(Player player)
    {
        //notImplemented yet
    }
    
}
