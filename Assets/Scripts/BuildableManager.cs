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
    [SerializeField] public GameObject house;
    [SerializeField] public GameObject hotel;
    // make list better; add ways to keep track of houses/hotels
    public float lerpValue;
    public BoardLayout layout;
    

    // Start is called before the first frame update
    void Start()
    {
        SetDefaultLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Object InstantiateBuilding(Boolean type, Vector3 pos)
    {
        return Instantiate((type ? (Object) hotel : house), pos, new Quaternion(0,0,0,0));
    }
    
  /*  public Object InstantiateBuildingOffset(bool type, float centerOffset, float horizontalOffset, int spacing)
    {
        return InstantiateBuilding((spacing == 5), ((pos + 2f * returnOffset(manager)) - switchVectorXZ(returnOffset(manager))) + (switchVectorXZ(returnOffset(manager)) * .5f * (numOfHouses == 5 ? 0 : numOfHouses)));

    }
    */
    
      
    
    // for later
  /*  public void UpdateZAxis()
    {
        
    }

    public void LerpZ(float a, float b, float t)
    {
        
    }
    */
    
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
