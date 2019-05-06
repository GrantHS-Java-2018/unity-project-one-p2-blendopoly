using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Spaces;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    private Transform pos;
    public Vector3 offset;
    public String name;
    public int index = 0;
    public GameObject board;
    private BoardLayout layout;
    public bool inJail { get; set; } = false;
    public int money = 500;
    public ButtonHandler buttonHandler;
    public int utilities = 0;
    public int railroads = 0;
    private int doubles = 0;
    private int turnsInJail;
    public int hasGetOutOfJailFree = 0;
    public bool repeat = false;
    public bool moving = false;
    public bool inArc = false;
    public int currentPos = 0;
    public int counter = 0;
    private Vector3 difference;
    private bool equal = false;
    public int unMorgagedProperties = 0;
    public int numOfHousesBuilt = 0;
    public int numOfHotelsBuilt = 0;
    public Die die1;
    public Die die2;
    public bool jailWaiting = false;
    public bool bankrupt = false;
    public bool goingBankrupt = false;

    void Start()
    {
        pos = GetComponent<Transform>();
        layout = board.GetComponent<BoardLayout>();
        setPos();
    }

    void Update()
    {
        setRotationOfPlayer();
        if (money <= 0)
        {
            if (unMorgagedProperties == 0 && numOfHotelsBuilt == 0 && numOfHousesBuilt == 0)
            {
                bankrupt = true;
            }
            else if(!goingBankrupt)
            {
                goingBankrupt = true;
                emergencyMoney();
            }
        }
        else if (bankrupt)
        {
            goingBankrupt = false;
            bankrupt = false;
            endEmergencyMode();
        }
        else if (goingBankrupt)
        {
            buttonHandler.keepPanicking();
        }
        else if ((currentPos != index || equal) && (!die1.rolling && !die2.rolling))
        {
            if (!moving)
            {
                counter = 0;
            }
            moving = true;
            if (!inArc)
            {
                ++currentPos;
                if (currentPos >= 40)
                {
                    currentPos = 0;
                }
                if (currentPos == index)
                {
                    equal = true;
                }
                else if (equal)
                {
                    currentPos = index;
                    equal = false;
                }
                difference = layout.boardTrack[currentPos].pos + offset - pos.position;
                inArc = true;
            }
            else
            {
                moveToSpace(counter);
                if (counter == 25)
                {
                    counter = 0;
                    inArc = false;
                    //pos.position = layout.boardTrack[currentPos].pos + offset;
                }
            }
            ++counter;
        }
        else if (moving)
        {
            moving = false;
            inArc = false;
            layout.boardTrack[index].onLand(this);
        } 
        else if (jailWaiting && (!die1.rolling && !die2.rolling))
        {
            readyForAction();
            jailWaiting = false;
        }
    }

    public void readyForAction()
    {
        buttonHandler.turnOnEndTurn();
    }

    public void readyForTurn()
    {
        buttonHandler.turnOnButtons();
        if (inJail)
        {
            buttonHandler.turnOnJail();
        }
    }

    public void turn()
    {
        buttonHandler.turnOffButtons();
        if (!inJail)
        {
            turnsInJail = 0;
            die1.roll(roll());
            die2.roll(roll());
            if (die1.faceShowing == die2.faceShowing && doubles != 2)
            {
                ++doubles;
                repeat = true;
            }
            else if (die1.faceShowing == die2.faceShowing)
            {
                index = BoardLayout.JAIL_INDEX;
                currentPos = BoardLayout.JAIL_INDEX;
                doubles = 0;
                inJail = true;
                repeat = false;
                setPos(layout.jail);
            }
            else
            {
                doubles = 0;
                repeat = false;
            }
            move(die1.faceShowing + die2.faceShowing);
        }
        else
        {
            die1.roll(roll());
            die2.roll(roll());
            if (die1 == die2)
            {
                move(die1.faceShowing + die2.faceShowing);
                inJail = false;
            }
            else if (turnsInJail == 2)
            {
                move(die1.faceShowing + die2.faceShowing);
                inJail = false;
                money -= 50;

            }
            else
            {
                ++turnsInJail;
                jailWaiting = true;
            }
        }
    }

    private void move(int roll)
    {
        index += roll;
        if (index >= 40)
        {
            index -= 40;
            money += 200;
        }
    }

    public void setPos(GameTile space)
    {
        pos.position = space.pos + offset;
    }

    public void setPos()
    {
        pos.position = layout.boardTrack[index].pos + offset;
    }

    public int roll()
    {
        return Random.Range(1, 6);
    }

    private void moveToSpace(int number)
    {
        pos.position = new Vector3(pos.position.x + difference.x/25,5 * (float)Math.Abs(Math.Sin(number * Math.PI/25)),pos.position.z + difference.z/25);
        pos.position += offset;
    }

    public void emergencyMoney()
    {
        buttonHandler.turnOnPanicButtons();
    }

    public void endEmergencyMode()
    {
        buttonHandler.turnOffPanicButtons();
        buttonHandler.turnOnActions();
    }
    
    public void setRotationOfPlayer()
    {
        if (currentPos <= 10)
        {
            pos.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (currentPos <= 20)
        {
            pos.rotation = Quaternion.Euler(0,-90,0);
        }
        else if (currentPos <= 30)
        {
            pos.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            pos.rotation = Quaternion.Euler(0,90,0);
        }
    }
    
}
