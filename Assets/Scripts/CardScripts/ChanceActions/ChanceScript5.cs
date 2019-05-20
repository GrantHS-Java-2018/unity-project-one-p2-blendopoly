using System.Collections;
using System.Collections.Generic;
using Spaces;
using UnityEngine;
using Spaces.Purchasable.Purchasable;

public class ChanceScript5 : Card
{
    public BoardLayout layout;
    public Die die1;
    public Die die2;
    public bool debtToPay = false;
    private Player debtor;
    private Player payer;
    public CardHandler card;
    
    public override void action(Player player)
    {
        //electric company = 12
        //water works = 28

        int utilityIndex = 0;
        
        if (player.index <= 12)
        {
            utilityIndex = 12;
        }
        else if (utilityIndex <= 28)
        {
            utilityIndex = 12;
        }
        else if (player.index <= 39)
        {
            utilityIndex = 12;
        }
        else
        {
            Debug.Log("Game Broken in ChanceScript5");
            utilityIndex = 0;
        }
        player.index = utilityIndex;
        Utilities utility = layout.boardTrack[player.index] as Utilities;
        
        if (utility != null && utility.owner == null)
        {
            card.landedOnSpace = true;
            utility.onLand(player);
        }
        else if (utility != null)
        {
            card.waitingOnDice = true;
            die1.roll(player.roll());
            die2.roll(player.roll());
            payer = player;
            debtor = utility.owner;
            debtToPay = true;
        }
        else
        {
            Debug.Log("Chancescript5 null utility error");
        }
    }

    void Update()
    {
        if (debtToPay && !(die1.rolling || die2.rolling))
        {
            debtToPay = false;
            int rent = (die1.faceShowing + die2.faceShowing) * 10;
            payer.changeMoney(-rent);
            debtor.changeMoney(rent);
        }
    }
}
