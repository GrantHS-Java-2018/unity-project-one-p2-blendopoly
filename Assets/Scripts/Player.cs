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
    public string name;
    public int index = 0;
    public GameObject board;
    private BoardLayout layout;
    public bool inJail { get; set; } = false;
    public int money;
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
    public ActionHandler actionHandler;
    public bool passedGo = false;
    public PlayerText playerText;

    void Start()
    {
        pos = GetComponent<Transform>();
        layout = board.GetComponent<BoardLayout>();
        setPos();
    }

    void Update()
    {
        setRotationOfPlayer();
        if (money <= 0 && !goingBankrupt)
        {
            if (unMorgagedProperties == 0 && numOfHotelsBuilt == 0 && numOfHousesBuilt == 0)
            {
                bankrupt = true;
                endEmergencyMode();
                gameObject.SetActive(false);
            }
            else
            {
                goingBankrupt = true;
                emergencyMoney();
            }
        }
        else if (money > 0 && goingBankrupt)
        {
            goingBankrupt = false;
            bankrupt = false;
            endEmergencyMode();
        }
        else if (goingBankrupt)
        {
            buttonHandler.keepPanicking();
            if (unMorgagedProperties == 0 && numOfHotelsBuilt == 0 && numOfHousesBuilt == 0)
            {
                bankrupt = true;
                endEmergencyMode();
                gameObject.SetActive(false);
            }
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
                counter = 0;
                ++currentPos;
                if (currentPos >= 40)
                {
                    currentPos = 0;
                    if (passedGo)
                    {
                        changeMoney(200);
                        passedGo = false;
                    }
                }
                if (currentPos == index)
                {
                    equal = true;
                }
                else if (equal)
                {
                    currentPos = index;
                    equal = false;
                    return;
                }
                difference = layout.boardTrack[currentPos].gameObject.transform.position + offset - pos.position;
                inArc = true;
            }
            else
            {
                moveToSpace(counter);
                if (counter == 25)
                {
                    inArc = false;
                }
                else
                {
                    ++counter;
                }
            }
        }
        else if (moving)
        {
            moving = false;
            inArc = false;
            layout.boardTrack[index].onLand(this);
        } 
        else if (jailWaiting && (!die1.rolling && !die2.rolling))
        {
            Thread.Sleep(1000);
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
                move(die1.faceShowing + die2.faceShowing);
            }
            else if (die1.faceShowing == die2.faceShowing)
            {
                index = BoardLayout.JAIL_INDEX;
                currentPos = BoardLayout.JAIL_INDEX;
                doubles = 0;
                inJail = true;
                repeat = false;
                setPos(layout.jail);
                readyForAction();
            }
            else
            {
                doubles = 0;
                repeat = false;
                move(die1.faceShowing + die2.faceShowing);
            }
        }
        else
        {
            die1.roll(roll());
            die2.roll(roll());
            if (die1.faceShowing == die2.faceShowing)
            {
                inJail = false;
                ++doubles;
                repeat = true;
                move(die1.faceShowing + die2.faceShowing);
            }
            else if (turnsInJail == 2)
            {
                move(die1.faceShowing + die2.faceShowing);
                inJail = false;
                changeMoney(-50);

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
            passedGo = true;
        }
    }

    public void setPos(GameTile space)
    {
        pos.position = space.pos + offset;
    }

    public void setPos()
    {
        pos.position = new Vector3(64.2f, 0, -67.3f) + offset;
    }

    public int roll()
    {
        return Random.Range(1, 7);
    }

    private void moveToSpace(int number)
    {
        pos.position = new Vector3(pos.position.x + difference.x/25,5 * (float)Math.Abs(Math.Sin(number * Math.PI/25)) + offset.y,pos.position.z + difference.z/25);
    }

    public void emergencyMoney()
    {
        buttonHandler.turnOnPanicButtons();
    }

    public void endEmergencyMode()
    {
        actionHandler.cancel();
        buttonHandler.turnOffPanicButtons();
        buttonHandler.turnOnEndTurn();
    }
    
    public void setRotationOfPlayer()
    {
        if (currentPos == 11 && inArc)
        {
            pos.eulerAngles = Vector3.Lerp(new Vector3(0,180,0), new Vector3(0, 270, 0), counter/25f);
        }
        else if (currentPos == 20 && inArc)
        {
            pos.eulerAngles = Vector3.Lerp(new Vector3(0,-90,0), new Vector3(0, -45, 0), counter/25f);
        }
        else if (currentPos == 21 && inArc)
        {
            pos.eulerAngles = Vector3.Lerp(new Vector3(0,-45,0), new Vector3(0, 0, 0), counter/25f);
        }
        else if (currentPos == 30 && inArc)
        {
            pos.eulerAngles = Vector3.Lerp(new Vector3(0,0,0), new Vector3(0, 45, 0), counter/25f);
        }
        else if (currentPos == 31 && inArc)
        {
            pos.eulerAngles = Vector3.Lerp(new Vector3(0,45,0), new Vector3(0, 90, 0), counter/25f);
        }
        else if (currentPos == 0 && inArc)
        {
            pos.eulerAngles = Vector3.Lerp(new Vector3(0,90,0), new Vector3(0, 180, 0), counter/25f);
        }
        else if (currentPos <= 10)
        {
            pos.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (currentPos < 20)
        {
            pos.rotation = Quaternion.Euler(0,-90,0);
        }
        else if (currentPos == 20)
        {
            pos.rotation = Quaternion.Euler(0,-45,0);
        }
        else if (currentPos < 30)
        {
            pos.rotation = Quaternion.Euler(0,0,0);
        }
        else if (currentPos == 30)
        {
            pos.rotation = Quaternion.Euler(0,45,0);
        }
        else
        {
            pos.rotation = Quaternion.Euler(0,90,0);
        }
    }

    public void changeMoney(int change)
    {
        money += change;
        playerText.displayChange(change);
    }
    
}
