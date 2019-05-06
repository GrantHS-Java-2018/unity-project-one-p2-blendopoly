using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject roll;
    public GameObject changeCamera;
    public GameObject endTurn;
    public GameObject getOutOfJail;
    public GameObject buy;
    public GameObject sell;
    public GameObject morgage;
    public GameObject unMorgage;
    public GameObject cancel;
    public GameObject die1;
    public GameObject die2;
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
        die1.SetActive(true);
        die2.SetActive(true);
        //changeCamera.SetActive(true);
    }

    public void turnOnEndTurn()
    {
        buy.SetActive(true);
        sell.SetActive(true);
        morgage.SetActive(true);
        unMorgage.SetActive(true);
        endTurn.SetActive(true);
        turnOffDice();
    }
    
    public void turnOffEndTurn()
    {
        buy.SetActive(false);
        sell.SetActive(false);
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
        buy.SetActive(true);
        sell.SetActive(true);
        morgage.SetActive(true);
        unMorgage.SetActive(true);
        turnOffDice();
    }

    public void turnOffActions()
    {
        buy.SetActive(false);
        sell.SetActive(false);
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

    public void disableButtonWithName(String name)
    {
        foreach (GameObject button in buttons)
        {
            if (button != null)
            {
                if (button.GetComponentInChildren<Text>().text == name)
                {
                    Destroy(button);
                }
            }
        }
    }
    
    public void turnOffDice()
    {
        die1.SetActive(false);
        die2.SetActive(false);
    }

    public void turnOnPanicButtons()
    {
        turnOffDice();
        turnOffActions();
        turnOffCancel();
        turnOffEndTurn();
        sell.SetActive(true);
        morgage.SetActive(true);
    }

    public void turnOffPanicButtons()
    {
        sell.SetActive(false);
        morgage.SetActive(false);
    }

    public void keepPanicking()
    {
        if (endTurn.activeSelf)
        {
            turnOnPanicButtons();
        }
    }
}
