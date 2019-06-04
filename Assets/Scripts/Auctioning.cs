using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Transactions;
using Spaces.Purchasable.Purchasable;
using UnityEngine;
using UnityEngine.UI;

public class Auctioning : MonoBehaviour
{
    public BidButtonHandler buttonHandlerButton;
    public BidButtonHandler stopButtonHandlerButton;
    public BidButtonHandler buttonHandlerSlider;
    public Slider bidSlider;
    private int playerIndex = 0;
    
    private List<Player> bids;
    
    public PropertyHandler handler;
    public PlayerHandler playerHandler;
    public BoardLayout layout;
    
    public Text maxValue;
    public Text minValue;
    public Text name;
    public Text bidValue;
    
    public BidButtonHandler minValueScript;
    public BidButtonHandler maxValueScript;
    public BidButtonHandler nameScript;
    public BidButtonHandler bidValueScript;
    
    public BidButtonHandler minValuePanel;
    public BidButtonHandler maxValuePanel;
    public BidButtonHandler namePanel;
    public BidButtonHandler bidValuePanel;

    private void setText()
    {
        maxValue.text = "max: $" + (bids[playerIndex].money-1).ToString();
        minValue.text = "current bid: $" + maxBid();
        name.text = bids[playerIndex].name;
        bidValue.text = "$" + ((int) bidSlider.value).ToString();
    }

    void Update()
    {
        if (ButtonHandler.resolutionChanged)
        {
            minValuePanel.GetComponent<Scaler>().updateForScreen();
            maxValuePanel.GetComponent<Scaler>().updateForScreen();
            namePanel.GetComponent<Scaler>().updateForScreen();
            bidValuePanel.GetComponent<Scaler>().updateForScreen();
            buttonHandlerButton.GetComponent<Scaler>().updateForScreen();
            stopButtonHandlerButton.GetComponent<Scaler>().updateForScreen();
            buttonHandlerSlider.GetComponent<Scaler>().updateForScreen();
        }
        bidValue.text = ((int) bidSlider.value).ToString();
    }

    private void Start()
    {
        bids = new List<Player>(playerHandler.players.Length);
        bidSlider.maxValue = playerHandler.players[playerIndex].money - 1;
        bidSlider.minValue = 1;

        textAlign();
        
        bidEnd();
    }

    private void textAlign()
    {
        maxValue.alignment = TextAnchor.MiddleCenter;
        minValue.alignment = TextAnchor.MiddleCenter;
        name.alignment = TextAnchor.MiddleCenter;
        bidValue.alignment = TextAnchor.MiddleCenter;
    }

    private void bidsInitialize()
    {
        foreach (Player player in playerHandler.players){
            bids.Add(player);
        }
    }

    public void bidStart()
    {
        buttonHandlerButton.turnOn();
        buttonHandlerSlider.turnOn();
        stopButtonHandlerButton.turnOn();
        
        maxValueScript.turnOn();
        nameScript.turnOn();
        bidValueScript.turnOn();
        minValueScript.turnOn();

        minValuePanel.turnOn();
        maxValuePanel.turnOn();
        namePanel.turnOn();
        bidValuePanel.turnOn();
        
        playerIndex = 0;
        bidsInitialize();
        setText();
    }
    
    void bidEnd()
    {
        buttonHandlerButton.turnOff();
        buttonHandlerSlider.turnOff();
        stopButtonHandlerButton.turnOff();
        
        maxValueScript.turnOff();
        nameScript.turnOff();
        bidValueScript.turnOff();
        minValueScript.turnOff();

        minValuePanel.turnOff();
        maxValuePanel.turnOff();
        namePanel.turnOff();
        bidValuePanel.turnOff();
        
        playerIndex = 0;
        bids.Clear();
    }

    private int maxBid()
    {
        int bid = 0;
        foreach (Player player in bids)
        {
            if (bid < player.bid)
            {
                bid = player.bid;
            }
        }
        return bid;
    }

    public void raiseBid()
    {
        bidSlider.minValue = maxBid() + 1;
        if (bids.Count == 1)
        {
            playerIndex = 0;
            setText();
            winner();
        }
        else if (playerIndex >= bids.Count)
        {
            playerIndex = 0;
            setText();
        }
        else if((bids[playerIndex].money - 2) <= (maxBid()))
        {
            removeBid();
        }
        else
        {
            bidSlider.maxValue = bids[playerIndex].money - 1;
            bids[playerIndex].bid = (int) bidSlider.value;
            setText();
            ++playerIndex;
            if (playerIndex >= bids.Count)
            {
                playerIndex = 0;
            }
            setText();
        }
        bidSlider.minValue = maxBid() + 1;
    }
    
    private void removeBid()
    {
        if (bids.Count > 1)
        {
            if (playerIndex >= bids.Count)
            {
                playerIndex = 0;
            }
            bids[playerIndex].bid = 0;
            bids.Remove(bids[playerIndex]);
            if (playerIndex >= bids.Count)
            {
                playerIndex = 0;
            }
            setText();
        }
        if(bids.Count == 1)
        {
            playerIndex = 0;
            setText();
            winner();
        }
    }

    private void returnBack()
    {
        handler.continueGame();
    }

    private void winner()
    {
        Debug.Log("List Length: " + bids.Count.ToString() + " Winner: " + bids[0]);
        bids[0].changeMoney(-bids[0].bid);
        Purchasable property = layout.boardTrack[playerHandler.players[playerHandler.index].index] as Purchasable;
        property.owner = bids[0];
        bids[0].bid = 0;
        resetBids();
        bidEnd();
        returnBack();
    }

    private void resetBids()
    {
        foreach (Player player in playerHandler.players)
        {
            player.bid = 0;
        }
    }
}