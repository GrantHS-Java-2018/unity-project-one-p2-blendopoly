using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public Player[] allPlayersPossible;
    [NonSerialized]public Player[] players = new Player[ValueHolder.numOfPlayers];
    public ButtonHandler handler;
    public Text text;
    public int index = 0;
    public BoardLayout layout;

    private void Awake()
    {
        for (int j = 0; j < allPlayersPossible.Length; ++j)
        {
            if (j < players.Length)
            {
                players[j] = allPlayersPossible[j];
            }
            else
            {
                allPlayersPossible[j].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < players.Length; ++i)
        {
            if (ValueHolder.playerNames[i] != null && ValueHolder.playerNames[i] != "")
            {
                players[i].name = ValueHolder.playerNames[i];
            }
        }
    }

    private void Update()
    {
        text.text = players[index].name + ": $" + players[index].money;
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
        layout.jail.occupied[players[index].offsetIndex] = false;
        players[index].offsetIndex = -1;
        handler.turnOffJail();
    }

    private void checkForWinner()
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

    private void winnerOfGame(Player player)
    {
        InfoHolder.player = player;
        SceneManager.LoadSceneAsync(1);
    }
}
