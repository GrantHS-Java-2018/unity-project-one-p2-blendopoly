﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript13 : Card
{
    public override void action(Player player)
    {
        player.changeMoney(-15);
    }
}
