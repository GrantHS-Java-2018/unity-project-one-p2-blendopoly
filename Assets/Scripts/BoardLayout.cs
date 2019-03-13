using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLayout : MonoBehaviour
{
    public static GameTile[] boardTrack;

    void Start()
    {
        var pos = new Vector3(0,0,0);
        var rents = new int[4];
        var housePrice = 1;
        var morgagePrice = 1;
        var price = 1;
        boardTrack = new GameTile[40];
        var mediterraneanAve = new Property(pos,rents,housePrice,morgagePrice, price);
        boardTrack[0] = mediterraneanAve;
    }

    private void setVector3(Vector3 vec, float x, float y, float z)
    {
        
    }
    
}
