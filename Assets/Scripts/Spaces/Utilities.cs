using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : GameTile
{

    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        throw new System.NotImplementedException();
    }
}