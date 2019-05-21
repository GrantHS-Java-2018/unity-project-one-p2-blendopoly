using System.Collections;
using System.Collections.Generic;
using Spaces.Purchasable.Purchasable;
using UnityEngine;

public class ChanceScript6 : Card
{
    public BoardLayout layout;
    public bool debtToPay = false;
    private Player payer;
    private Railroads railroad;
    public CardHandler card;
    
    public override void action(Player player)
    {
        //reading railroad = 5
        //pennsylvania railroad = 15
        //B and O railroad = 25
        //short line railroad = 35
        
        int railIndex = 0;
        
        if (player.index <= 5)
        {
            railIndex = 5;
        }
        else if (player.index <= 15)
        {
            railIndex = 15;
        }
        else if (player.index <= 25)
        {
            railIndex = 25;
        }
        else if (player.index <= 35)
        {
            railIndex = 35;
        }
        else if (player.index <= 39)
        {
            railIndex = 5;
        }
        else
        {
            Debug.Log("Game Broken in ChanceScript6");
            railIndex = 0;
        }
        player.index = railIndex;
        player.chanceAction = true;
        railroad = layout.boardTrack[player.index] as Railroads;
        if (railroad != null && railroad.owner == null)
        {
            card.landedOnSpace = true;
        }
        else if(railroad != null && railroad.owner != player)
        {
            payer = player;
            debtToPay = true;
        }
    }

    void Update()
    {
        if (debtToPay && !payer.moving)
        {
            debtToPay = false;
            int rent = railroad.calculateRent(railroad.owner) * 2;
            payer.changeMoney(-rent);
            railroad.owner.changeMoney(rent);
        }
    }
}
