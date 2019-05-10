using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToJail : GameTile
{

    public BoardLayout layout;
    
    void Start()
    {
        pos = GetComponent<Transform>().position;
    }
    
    public override void onLand(Player player)
    {
        player.index = BoardLayout.JAIL_INDEX;
        player.currentPos = BoardLayout.JAIL_INDEX;
        player.inJail = true;
        player.repeat = false;
        player.setPos(layout.jail);
        player.readyForAction();
    }
}
