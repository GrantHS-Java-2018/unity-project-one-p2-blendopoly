﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript2 : Card
{
    public override void action(Player player)
    {
        //go = 0
        player.index = 0;
        player.passedGo = true;
    }
}
