using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PropertyHandler : MonoBehaviour
{

    public Button buy;
    public Button notBuy;

    private Property currentProperty;
    private Player currentPlayer;

    public void buyProperty(Property property, Player player)
    {
        if (player.money >= property.price)
        {
            buy.SetEnabled(true);
        }
        notBuy.SetEnabled(true);
        currentProperty = property;
        currentPlayer = player;
    }

    public void buyProperty()
    {
        currentProperty.owner = currentPlayer;
        currentPlayer.money -= currentProperty.price;
        continueGame();
        
    }

    public void continueGame()
    {
        buy.SetEnabled(false);
        notBuy.SetEnabled(false);
    }
    
}
