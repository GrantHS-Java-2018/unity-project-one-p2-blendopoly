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
    
    void Start()
    {
        card = chanceTile.GetComponent<chanceCard>();
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
