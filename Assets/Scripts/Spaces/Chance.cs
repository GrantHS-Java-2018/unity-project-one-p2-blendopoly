using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Chance : GameTile
{
    private chanceCard card;
    
    public Image chanceTile;

    private Player player;

    private bool cardShowing = false;
    
    void Update()
    {
        if ((!card.getStatus()) && cardShowing)
        {
            player.readyForAction();
            cardShowing = false;
        }
    }
    
    void Start()
    {
        card = chanceTile.GetComponent<chanceCard>();
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        card.renderOn();
        this.player = player;
        cardShowing = true;
    }

}
