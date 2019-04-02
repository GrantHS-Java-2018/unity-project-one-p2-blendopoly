using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : GameTile
{
    public int[] rents;
    public int housePrice;
    public int morgagePrice;
    public bool morgaged = false;
    public int price;
    public int numOfHouses = 0;

    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        player.money -= price;
    }
    
}
