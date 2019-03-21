using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : GameTile
{
    //[SerializeField] private int[] rents;
    //[SerializeField] private int housePrice;
    //[SerializeField] private int morgagePrice;
    //[SerializeField] private bool morgaged = false;
    //[SerializeField] private int price;
    //[SerializeField] private int numOfHouses = 0;

    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        //notImplemented yet
    }
    
}
