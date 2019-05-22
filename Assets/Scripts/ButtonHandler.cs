using System;
using System.Collections;
using System.Collections.Generic;
using Spaces.Purchasable.Purchasable;
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
    public GameObject[] propertyDisplayers;
    public ArrayList buttons = new ArrayList();

    private void Start()
    {
        turnOffEndTurn();
        turnOffJail();
        turnOffCancel();
        foreach (var gameObject in propertyDisplayers)
        {
            gameObject.SetActive(false);
        }
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
        turnOnPropertyDisplayers();
        turnOffDice();
    }
    
    public void turnOffEndTurn()
    {
        buy.SetActive(false);
        sell.SetActive(false);
        morgage.SetActive(false);
        unMorgage.SetActive(false);
        endTurn.SetActive(false);
        turnOffPropertyDisplayers();
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
        turnOnPropertyDisplayers();
        turnOffDice();
    }

    public void turnOffActions()
    {
        buy.SetActive(false);
        sell.SetActive(false);
        morgage.SetActive(false);
        unMorgage.SetActive(false);
        turnOffPropertyDisplayers();
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
                if (button.GetComponentInChildren<Text>().name == name)
                {
                    Destroy(button);
                }
            }
        }
    }

    public void updateButton(Property property)
    {
        foreach (GameObject button in buttons)
        {
            if (button != null)
            {
                Text text = button.GetComponentInChildren<Text>();
                if (text.name == property.name)
                {
                    text.text = text.name + ": " + property.numOfHouses;
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

    public void turnOnPropertyDisplayers()
    {
        for (int i = 0; i <= ValueHolder.numOfPlayers; i++)
        {
            propertyDisplayers[i].SetActive(true);
        }
    }

    public void turnOffPropertyDisplayers()
    {
        for (int i = 0; i <= ValueHolder.numOfPlayers; i++)
        {
            propertyDisplayers[i].SetActive(false);
        }
    }

    public void turnOffAll()
    {
        turnOffDice();
        turnOffJail();
        turnOffActions();
        turnOffButtons();
        turnOffEndTurn();
        turnOffCancel();
    }
}
