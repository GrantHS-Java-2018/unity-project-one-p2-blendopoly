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
        ++index;
        if (index >= players.Length)
        {
            index = 0;
        }
        handler.turnOffEndTurn();
        players[index].readyForTurn();
    }
}
