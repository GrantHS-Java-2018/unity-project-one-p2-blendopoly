using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunityChest : GameTile
{
    
    private int[] cardsDrawn = new int[16];
    
    public int[] getCardsDrawn()
    {
        return cardsDrawn;
    }
    
    private int[] cardsNotDrawn = new int[16];

    public int[] getCardsNotDrawn()
    {
        return cardsDrawn;
    }

    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        //throw new System.NotImplementedException();
    }
}
