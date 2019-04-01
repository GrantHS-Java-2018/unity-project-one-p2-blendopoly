using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToJail : GameTile
{

    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        //notImplementedYet
    }
}
