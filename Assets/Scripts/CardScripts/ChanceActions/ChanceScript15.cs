using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript15 : Card
{
    public BoardLayout layout;
    public override void action(Player player)
    {
        player.index = BoardLayout.JAIL_INDEX;
        player.inJail = true;
        player.setPos(layout.jail);
    }
}
