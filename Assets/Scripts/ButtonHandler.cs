using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject roll;
    public GameObject changeCamera;
    public GameObject endTurn;
    public GameObject houses;
    public GameObject morgage;

    private void Start()
    {
        turnOffEndTurn();
    }

    public void turnOffButtons()
    {
        roll.SetActive(false);
        //changeCamera.SetActive(false);
    }

    public void turnOnButtons()
    {
        roll.SetActive(true);
        //changeCamera.SetActive(true);
    }

    public void turnOnEndTurn()
    {
        houses.SetActive(true);
        morgage.SetActive(true);
        endTurn.SetActive(true);
    }
    
    public void turnOffEndTurn()
    {
        houses.SetActive(false);
        morgage.SetActive(false);
        endTurn.SetActive(false);
    }

    public void turnOnActions()
    {
        houses.SetActive(true);
        morgage.SetActive(true);
    }

    public void turnOffActions()
    {
        houses.SetActive(false);
        morgage.SetActive(false);
    }
}
