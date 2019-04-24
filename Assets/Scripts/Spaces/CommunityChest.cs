using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CommunityChest : GameTile
{
    private CCCard card;
    
    public Image CommunityCCard;

    void Start()
    {
        card = CommunityCCard.GetComponent<CCCard>();
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {

        card.renderOn();
        
        //Thread.Sleep(1000);
        
        //card.renderOff();
        
        player.readyForAction();
    }

}
