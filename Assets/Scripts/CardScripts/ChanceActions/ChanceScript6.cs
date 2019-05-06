using System.Collections;
using System.Collections.Generic;
using Spaces.Purchasable.Purchasable;
using UnityEngine;

public class ChanceScript6 : Card
{
    public BoardLayout layout;
    public override void action(Player player)
    {
        //reading railroad = 5
        //pennsylvania railroad = 15
        //B and O railroad = 25
        //short line railroad = 35
        
        int railIndex = 0;
        
        if (player.index < 5)
        {
            railIndex = 5;
        }
        else if (player.index > 35)
        {
            railIndex = 35;
        }
        
        else if (player.index > 5 && player.index < 10)
        {
            railIndex = 5;
        }
        else if (player.index >= 10 && player.index < 15)
        {
            railIndex = 15;
        }
        
        else if (player.index > 15 && player.index < 20)
        {
            railIndex = 15;
        }
        else if (player.index >= 20 && player.index < 25)
        {
            railIndex = 25;
        }

        else if (player.index > 25 && player.index < 30)
        {
            railIndex = 25;
        }
        else if (player.index >= 30 && player.index < 35)
        {
            railIndex = 35;
        }
        
        else
        {
            Debug.Log("Game Broken in ChanceScript6");
            railIndex = 0;
        }

        player.setPos(layout.boardTrack[railIndex]);
        player.index = railIndex;
        player.currentPos = railIndex;
        Railroads railroad = layout.boardTrack[player.index] as Railroads;
        
        if (railroad != null && railroad.owner == null)
        {
            railroad.onLand(player);
        }
        else if(railroad != null)
        {
            int rent = railroad.calculateRent(railroad.owner) * 2;
            player.money -= rent;
            railroad.owner.money += rent;
        }
        else
        {
            Debug.Log("Railroad doesn't exist...");
        }
    }
}
