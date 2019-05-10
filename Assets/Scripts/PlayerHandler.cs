using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        checkForWinner();
    }

    public void startTurn()
    {
        players[index].turn();
    }

    public void endTurn()
    {
        if (!players[index].repeat)
        {
            do
            {
                ++index;
                if (index >= players.Length)
                {
                    index = 0;
                }
            } while (players[index].bankrupt);
        }
        handler.turnOffEndTurn();
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

    public void checkForWinner()
    {
        int numOfPlayersWithMoney = players.Length;
        Player nonBankruptedPlayer = null;
        foreach (Player player in players)
        {
            if (player.bankrupt)
            {
                --numOfPlayersWithMoney;
            }
            else
            {
                nonBankruptedPlayer = player;
            }
        }
        if (numOfPlayersWithMoney == 1)
        {
            winnerOfGame(nonBankruptedPlayer);
        }
    }

    public void winnerOfGame(Player player)
    {
        InfoHolder.player = player;
        SceneManager.LoadScene("WinningScene");
    }
}
