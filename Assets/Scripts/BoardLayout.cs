using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Diagnostics;

public class BoardLayout : MonoBehaviour
{
    public static GameTile[] boardTrack;

    void Start()
    {
        var i = 0;
        var pos = new Vector3(0,0,0);
        var rents = new int[4];
        var housePrice = 1;
        var morgagePrice = 1;
        var price = 1;
        boardTrack = new GameTile[40];
        var mediterraneanAve = new Property(pos,rents,housePrice,morgagePrice, price);
        boardTrack[i++] = mediterraneanAve;
        setVector3(pos,10, 0, 10);
        setRents(rents,1,1,1,1);
        housePrice = 1;
        morgagePrice = 1;
        price = 1;
        boardTrack[i++] = new Property(pos,rents,housePrice,morgagePrice,price);
    }

    private GameTile setPropertyValues(Vector3 vec, int[] rents, float x, float y, float z, float a, float b, float c, float d, int housePrice,
        int morgagePrice, int price)
    {
        setVector3(vec, x, y, z);
        setRents(rents, a,b,c,d);
        return new Property(vec,rents,housePrice,morgagePrice,price);
    }

    private void setVector3(Vector3 vec, float x, float y, float z)
    {
        vec.x = x;
        vec.y = y;
        vec.z = z;
    }

    private void setRents(int[] rents, int a, int b, int c, int d)
    {
        rents[0] = a;
        rents[1] = b;
        rents[2] = c;
        rents[3] = d;
    }
    
}
