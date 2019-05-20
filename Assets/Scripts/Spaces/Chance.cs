using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Chance : GameTile
{
    private CardHandler card;
    
    public Image chanceTile;

    private Player player;
    
    void Start()
    {
        card = chanceTile.GetComponent<CardHandler>();
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        card.renderOn();
        this.player = player;
    }

}
