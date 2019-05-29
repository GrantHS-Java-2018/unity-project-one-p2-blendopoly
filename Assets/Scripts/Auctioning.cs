using System;
using System.Collections;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class Auctioning : MonoBehaviour
{
    public BidButtonHandler buttonhandler;
    public Slider bidSlider;
    private int playerIndex = 0;
    private int[] bids;
    public PropertyHandler handler;
    public PlayerHandler playerHandler;

    private void Start()
    {
        bids = new int[playerHandler.players.Length];
        bidSlider.maxValue = playerHandler.players[playerIndex].money;
    }

    public void bidStart()
    {
        
    }

    public void raiseBid()
    {
        bidSlider.maxValue = playerHandler.players[playerIndex].money;
        if (playerIndex < playerHandler.players.Length)
        {
            bids[playerIndex] = (int) bidSlider.value;
            Debug.Log("playerIndex: " + playerIndex + " biddingValue: " + bids[playerIndex]);
            ++playerIndex;
        }
        else
        {
            winner();
        }
    }

    private void returnBack()
    {
        handler.continueGame();
    }

    private void winner()
    {
        
    }
}