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

    public int bid = 0;
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
    public bool chanceAction = false;
    public PlayerText playerText;
    public int offsetIndex;

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
                if (!equal && offsetIndex != -1)
                {
                    layout.boardTrack[currentPos - 1].occupied[offsetIndex] = false;
                }
                offsetIndex = 0;
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
                offsetBasedOnPosition();
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
            if (!chanceAction)
            {
                layout.boardTrack[index].onLand(this);
            }
            else
            {
                chanceAction = false;
            }
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
                layout.jail.occupied[offsetIndex] = false;
                offsetIndex = -1;
                ++doubles;
                repeat = true;
                move(die1.faceShowing + die2.faceShowing);
            }
            else if (turnsInJail == 2)
            {
                move(die1.faceShowing + die2.faceShowing);
                inJail = false;
                layout.jail.occupied[offsetIndex] = false;
                offsetIndex = -1;
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
        offsetBasedOnPosition();
        pos.position = space.pos + offset;
    }

    public void setPos()
    {
        offsetBasedOnPosition();
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
        if (currentPos == 10 && inArc && offsetIndex > 1)
        {
            pos.eulerAngles = Vector3.Lerp(new Vector3(0, 180, 0), new Vector3(0, 270, 0), counter / 25f);
        }
        if (currentPos == 11 && inArc && pos.eulerAngles != new Vector3(0,270,0))
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
        else if (currentPos == 10 && offsetIndex > 1)
        {
            pos.eulerAngles = new Vector3(0,270,0);
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

    public void offsetBasedOnPosition()
    {
        int playersOnSpace = checkIfSpaceOccupied();
        if (playersOnSpace == 0)
        {
            offset = new Vector3(0,offset.y,0);
        }
        else if (inJail)
        {
            switch (playersOnSpace)
            {
                case 1:
                    offset = new Vector3(-5,offset.y,0);
                    break;
                case 2:
                    offset = new Vector3(0,offset.y, -5);
                    break;
                case 3:
                    offset = new Vector3(-5,offset.y, -5);
                    break;
                default:
                    Debug.Log("Broken in player class");
                    break;
            }
        }
        else
        {
            if (currentPos < 10)
            {
                offset = new Vector3(0, offset.y, getOffset(playersOnSpace));
            }
            else if (currentPos == 10)
            {
                switch (playersOnSpace)
                {
                    case 1:
                        offset = new Vector3(6,offset.y,0);
                        break;
                    case 2:
                        offset = new Vector3(-7, offset.y, 6);
                        break;
                    case 3:
                        offset = new Vector3(-7, offset.y, 12);
                        break;
                    default:
                        Debug.Log("Broken in player class");
                        break;
                }
            }
            else if (currentPos < 20)
            {
                offset = new Vector3(getOffset(playersOnSpace), offset.y, 0);
            }
            else if (currentPos < 30)
            {
                offset = new Vector3(0, offset.y, -getOffset(playersOnSpace));
            }
            else
            {
                offset = new Vector3(-getOffset(playersOnSpace), offset.y, 0);
            }
        }
    }
    
    /*private int checkIfSpaceOccupied()
    {
        int count = 0;
        foreach(Player player in handler.players)
        {
            if (player != handler.players[handler.index] && player.index == currentPos)
            {
                ++count;
            }
        }
        return count;
    }*/
    
    private int checkIfSpaceOccupied()
    {
        if (inJail)
        {
            for (int i = 0; i < layout.jail.occupied.Length; ++i)
            {
                if (!layout.jail.occupied[i])
                {
                    offsetIndex = i;
                    layout.jail.occupied[i] = true;
                    return i;
                }
            }
        }
        for(int i = 0; i < layout.boardTrack[currentPos].occupied.Length; ++i)
        {
            if (currentPos == 30)
            {
                return 0;
            }
            if (!layout.boardTrack[currentPos].occupied[i])
            {
                offsetIndex = i;
                layout.boardTrack[currentPos].occupied[i] = true;
                return i;
            }
        }
        return -1;
    }

    private int getOffset(int playersOnSpace)
    {
        switch (playersOnSpace)
        {
            case 1:
                return 3;
            case 2:
                return -3;
            case 3:
                return 6;
            default:
                Debug.Log("Broken in player class");
                return 0;
        }
    }

    public void movingOffSpace()
    {
        layout.boardTrack[currentPos].occupied[offsetIndex] = false;
    }
    
}
