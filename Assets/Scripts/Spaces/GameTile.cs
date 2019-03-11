using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameTile : MonoBehaviour
{
    
    public Vector3 pos;

    public Vector3 getPos()
    {
        return pos;
    }

    public void setPos(Vector3 pos)
    {
        this.pos = pos;
    }

    public abstract void onLand(Player player);

}
