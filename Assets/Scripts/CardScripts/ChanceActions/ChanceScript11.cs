﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceScript11 : Card
{
    public override void action(Player player)
    {
        player.changeMoney(50);
    }
}
