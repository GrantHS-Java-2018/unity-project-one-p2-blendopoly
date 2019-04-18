using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = System.Random;

public class Chance : GameTile
{

    public SpriteRenderer sr;

    public Sprite[] spriteList = new Sprite[16];
    
    private ArrayList alreadyChosen = new ArrayList();
    
    private Random chooser = new Random();

    void Start()
    {
        sr.sprite = null;
    }
    
    public override void onLand(Player player)
    {
        int randomInt;

        if (alreadyChosen.Count >= 16)
        {
            alreadyChosen.Clear();
        }

        do
        {
            randomInt = chooser.Next() * 15;
        } while (inside(randomInt));

        alreadyChosen.Add(randomInt);

        sr.sprite = spriteList[randomInt];
        
        Thread.Sleep(1000);
        
        player.readyForAction();
        sr.sprite = null;
    }

    private bool inside(int searchFor)
    {
        foreach(int x1 in alreadyChosen){
            if (x1 == searchFor)
            {
                return true;
            }
        }

        return false;
    }
}
