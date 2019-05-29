using System;
using System.Collections;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class Auctioning : MonoBehaviour
{
    public BidButtonHandler buttonHandlerButton;
    public BidButtonHandler buttonHandlerSlider;
    public Slider bidSlider;
    private int playerIndex = 0;
    private int[] bids;
    public PropertyHandler handler;
    public PlayerHandler playerHandler;

    private void Start()
    {
        bids = new int[playerHandler.players.Length];
        bidSlider.maxValue = playerHandler.players[playerIndex].money;
        buttonHandlerButton.turnOff();
        buttonHandlerSlider.turnOff();
    }

    public void bidStart()
    {
        buttonHandlerButton.turnOn();
        buttonHandlerSlider.turnOn();
    }
    
    public void bidEnd()
    {
        buttonHandlerButton.turnOff();
        buttonHandlerSlider.turnOff();
    }

    public void raiseBid()
    {
        if (playerIndex < playerHandler.players.Length)
        {
            bidSlider.maxValue = playerHandler.players[playerIndex].money;
            bids[playerIndex] = (int) bidSlider.value;
            Debug.Log("playerIndex: " + playerIndex + " biddingValue: " + bids[playerIndex]);
            ++playerIndex;
        }
        else
        {
            Debug.Log("Choose The Player Now");
            winner();
        }
    }

    private void returnBack()
    {
        handler.continueGame();
    }

    private void winner()
    {
        playerIndex = 0;
        //code
        
        bidEnd();
        returnBack();
    }
}