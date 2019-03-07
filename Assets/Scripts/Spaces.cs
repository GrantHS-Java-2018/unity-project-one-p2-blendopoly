using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public abstract class Spaces
{

    private Player owner;
    private int[] rents;

    private void onLand()
    {
        
    }

    public Player GetOwner()
    {
        return owner;
    }

    public int getRent(int houses)
    {
        return rents[houses];
    }

    public void SetOwner(Player player)
    {
        owner = player;
    }

    public void setRents(int[] rents)
    {
        this.rents = rents;
    }

}
