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

    private Player player;
    
    private bool cardShowing = false;

    void Update()
    {
        if ((!card.getStatus()) && cardShowing && !card.landedOnSpace)
        {
            player.readyForAction();
            cardShowing = false;
        }
        else if ((!card.getStatus()) && cardShowing && card.landedOnSpace)
        {
            card.landedOnSpace = false;
            cardShowing = false;
        }
    }

    void Start()
    {
        card = CommunityCCard.GetComponent<CCCard>();
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        card.renderOn();
        this.player = player;
        cardShowing = true;
    }

}
