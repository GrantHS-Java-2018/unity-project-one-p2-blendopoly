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
    [NonSerialized] public List<Object> BuildingList = new List<Object>();
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
        
    public void InstantiateBuilding(Boolean type, Vector3 pos)
    {
        BuildingList.Add(Instantiate((type ? (Object) house : hotel), pos, new Quaternion(0,0,0,0)));
    }
    
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
    
}
