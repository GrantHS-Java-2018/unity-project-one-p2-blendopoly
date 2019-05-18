using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript8 : Card
{
    public PlayerHandler handler;
    public override void action(Player player)
    {
        foreach (Player p in handler.players)
        {
            if (p != player)
            {
                p.changeMoney(50);
                player.changeMoney(-50);
            }
        }   
    }
}
