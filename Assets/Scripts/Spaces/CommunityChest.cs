using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunityChest : GameTile
{
    public SpriteRenderer sr;
    
    private ArrayList cardsDrawn { get; set; }

    private ArrayList cardsNotDrawn { get; set; }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cardsDrawn = new ArrayList();
        cardsNotDrawn = new ArrayList(16);
        cardinitialization();
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        
        if (cardsDrawn.Count >= 9)
        {
            cardinitialization();
        }
        
        

        player.readyForAction();
    }

    private void cardinitialization()
    {
        for (int x1 = 0; x1 < 10; ++x1)
        {
            cardsDrawn.Clear();
            cardsNotDrawn[x1] = x1;
        }
    }

}
