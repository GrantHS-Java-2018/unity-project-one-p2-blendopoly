using System.Collections;
using System.Collections.Generic;
using Spaces.Purchasable.Purchasable;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class PropertyHandler : MonoBehaviour
{

    public GameObject buy;
    public GameObject notBuy;
    public ButtonHandler handler;

    private Purchasable currentProperty;
    private Player currentPlayer;

    void Start()
    {
        buy.SetActive(false);
        notBuy.SetActive(false);
    }

    public void buyProperty(Purchasable property, Player player)
    {
        if (player.money >= property.price)
        {
            buy.SetActive(true);
        }
        notBuy.SetActive(true);
        handler.turnOffDice();
        currentProperty = property;
        currentPlayer = player;
    }

    public void buyProperty()
    {
        currentProperty.owner = currentPlayer;
        currentPlayer.money -= currentProperty.price;
        ++currentPlayer.unMorgagedProperties;
        if (currentPlayer.index == 5 || currentPlayer.index == 15 || currentPlayer.index == 25 ||
            currentPlayer.index == 35)
        {
            ++currentPlayer.railroads;
        }
        else if (currentPlayer.index == 12 || currentPlayer.index == 28)
        {
            ++currentPlayer.utilities;
        }
        continueGame();
        
    }

    public void continueGame()
    {
        buy.SetActive(false);
        notBuy.SetActive(false);
        handler.turnOnActions();
        currentPlayer.readyForAction();
    }

    public void checkIfValid(Property property)
    {
        if (property.numOfHouses <= 0 || property.numOfHouses >= 5)
        {
            handler.disableButtonWithName(property.name);
        }
        else
        {
            handler.updateButton(property);
        }
    }
    
}
