using System;
using System.Collections;
using System.Collections.Generic;
using Spaces.Purchasable.Purchasable;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject roll;
    [SerializeField] private GameObject changeCamera;
    [SerializeField] private GameObject money;
    [SerializeField] private GameObject buyProperty;
    [SerializeField] private GameObject dontBuyProperty;
    [SerializeField] private GameObject endTurn;
    [SerializeField] private GameObject getOutOfJail;
    [SerializeField] private GameObject buy;
    [SerializeField] private GameObject sell;
    [SerializeField] private GameObject morgage;
    [SerializeField] private GameObject unMorgage;
    [SerializeField] private GameObject cancel;
    [SerializeField] private GameObject die1;
    [SerializeField] private GameObject die2;
    [SerializeField] private GameObject[] propertyDisplayers;
    private ArrayList buttons = new ArrayList();
    public static bool resolutionChanged = false;
    private float resolutionX = 914;
    private float resolutionY = 374;

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

    private void Update()
    {
        if (resolutionX == Screen.width && resolutionY == Screen.height)
        {
            resolutionChanged = false;
        }
        else
        {
            resolutionChanged = true;
            updateAllSizes();
            resolutionX = Screen.width;
            resolutionY = Screen.height;
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
        updateAllSizes();
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

    private void updateAllSizes()
    {
        roll.GetComponent<Scaler>().updateForScreen();
        changeCamera.GetComponent<Scaler>().updateForScreen();
        money.GetComponent<Scaler>().updateForScreen();
        buyProperty.GetComponent<Scaler>().updateForScreen();
        dontBuyProperty.GetComponent<Scaler>().updateForScreen();
        endTurn.GetComponent<Scaler>().updateForScreen();
        getOutOfJail.GetComponent<Scaler>().updateForScreen();
        buy.GetComponent<Scaler>().updateForScreen();
        sell.GetComponent<Scaler>().updateForScreen();
        morgage.GetComponent<Scaler>().updateForScreen();
        unMorgage.GetComponent<Scaler>().updateForScreen();
        cancel.GetComponent<Scaler>().updateForScreen();
        foreach (var gameObject in propertyDisplayers)
        {
            if (gameObject.activeSelf)
            {
                gameObject.GetComponent<Scaler>().updateForScreen();
            }
        }
        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                if (button != null)
                {
                    button.GetComponent<Scaler>().updateForScreen();
                }
            }
        }
    }
}
