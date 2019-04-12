using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chance : GameTile
{

    private ArrayList cardsDrawn = new ArrayList(16);
    
    public ArrayList getCardsDrawn()
    {
        return cardsDrawn;
    }
    
    private ArrayList cardsNotDrawn = new ArrayList(16);

    public ArrayList getCardsNotDrawn()
    {
        return cardsNotDrawn;
    }

    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        //throw new System.NotImplementedException();
        player.readyForTurn();
    }
}
