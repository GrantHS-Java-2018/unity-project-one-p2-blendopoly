using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Object = UnityEngine.Object;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class BuildableManager : MonoBehaviour
{
    public GameObject house;
    public GameObject hotel;
    [SerializeField] private BoardLayout layout;
    

    void Start()
    {
        SetDefaultLocation();
    }
    
    public Object InstantiateBuilding(Boolean type, Vector3 pos)
    {
        return Instantiate((type ? (Object) hotel : house), pos, new Quaternion(0,0,0,0));
    }
    
    public void SetDefaultLocation()
    {
        house.transform.position = new Vector3(0,-10, 0);
        hotel.transform.position = new Vector3(0, -10, 0);
    }

    public int getIndexOf(GameTile tile)
    {
        for(int i = 0; i < 40; ++i)
        {
            if (layout.boardTrack[i] == tile)
            {
                return i;
            }    
        }
        Debug.Log("IS BROKEY!");
        return -1;
    }
    
}
