using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject roll;
    public GameObject changeCamera;
    public GameObject endTurn;
    public GameObject getOutOfJail;

    private void Start()
    {
        turnOffEndTurn();
    }

    public void turnOffButtons()
    {
        roll.SetActive(false);
        turnOffJail();
        //changeCamera.SetActive(false);
    }

    public void turnOnButtons()
    {
        roll.SetActive(true);
        //changeCamera.SetActive(true);
    }

    public void turnOnEndTurn()
    {
        endTurn.SetActive(true);
    }
    
    public void turnOffEndTurn()
    {
        endTurn.SetActive(false);
    }

    public void turnOnJail()
    {
        getOutOfJail.SetActive(true);
    }

    public void turnOffJail()
    {
        getOutOfJail.SetActive(false);
    }
    
}
