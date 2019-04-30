using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    
    public Player[] players;
    public ButtonHandler handler;
    public Text text;
    public int index = 0;

    private void Update()
    {
        text.text = "Money: $" + players[index].money;
    }

    public void startTurn()
    {
        players[index].turn();
    }

    public void endTurn()
    {
        if (!players[index].repeat)
        {
            ++index;
            if (index >= players.Length)
            {
                index = 0;
            }
        }
        handler.turnOffEndTurn();
        handler.turnOffActions();
        players[index].readyForTurn();
    }

    public void getOutOfJail()
    {
        int price;
        if (players[index].hasGetOutOfJailFree > 0)
        {
            price = 0;
            players[index].hasGetOutOfJailFree -= 1;
        }
        else
        {
            price = 50;
        }
        players[index].money -= price;
        players[index].inJail = false;
        handler.turnOffJail();
    }
}
