using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CommunityChest : GameTile
{
    private CardHandler card;
    
    public Image CommunityCCard;

    private Player player;

    void Start()
    {
        card = CommunityCCard.GetComponent<CardHandler>();
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        card.renderOn();
        this.player = player;
        player.readyForAction();
    }

}
