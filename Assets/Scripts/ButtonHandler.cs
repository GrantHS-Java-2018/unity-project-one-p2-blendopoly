using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject roll;
    public GameObject changeCamera;
    public GameObject endTurn;
    public GameObject getOutOfJail;
    public GameObject houses;
    public GameObject morgage;
    public GameObject unMorgage;
    public GameObject cancel;
    public ArrayList buttons = new ArrayList();

    private void Start()
    {
        turnOffEndTurn();
        turnOffJail();
        turnOffCancel();
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
        houses.SetActive(true);
        morgage.SetActive(true);
        unMorgage.SetActive(true);
        endTurn.SetActive(true);
    }
    
    public void turnOffEndTurn()
    {
        houses.SetActive(false);
        morgage.SetActive(false);
        unMorgage.SetActive(false);
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
    

    public void turnOnActions()
    {
        houses.SetActive(true);
        morgage.SetActive(true);
        unMorgage.SetActive(true);
    }

    public void turnOffActions()
    {
        houses.SetActive(false);
        morgage.SetActive(false);
        unMorgage.SetActive(false);
    }

    public void turnOnCancel()
    {
        cancel.SetActive(true);
    }

    public void turnOffCancel()
    {
        cancel.SetActive(false);
    }
    
    public void addButton(GameObject property)
    {
        buttons.Add(property);
    }

    public void clearProperties()
    {
        foreach (GameObject property in buttons)
        {
            Destroy(property);
        }
    }
}
