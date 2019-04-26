using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCScript8 : Card
{
    public PlayerHandler handler;
    public override void action(Player player)
    {
        foreach (Player p in handler.players)
        {
            if (p != player)
            {
                p.money -= 50;
                player.money += 50;
            }
        } 
    }
}