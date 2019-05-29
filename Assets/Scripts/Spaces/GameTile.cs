using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class GameTile : MonoBehaviour
{

    public Vector3 pos { get; set; }
    public bool[] occupied = {false, false, false, false};
    
    public abstract void onLand(Player player);
}
