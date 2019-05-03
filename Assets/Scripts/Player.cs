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
    private int counter = 0;
    private Vector3 difference;
    private bool equal = false;
    public int numOfHousesBuilt = 0;
    public int numOfHotelsBuilt = 0;
    public Die die1;
    public Die die2;

    void Start()
    {
        pos = GetComponent<Transform>();
        layout = board.GetComponent<BoardLayout>();
        setPos();
    }

    void Update()
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
        if (currentPos != index || equal)
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
                readyForAction();
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

    private int roll()
    {
        return Random.Range(1, 6);
    }

    private void moveToSpace(int number)
    {
        pos.position = new Vector3(pos.position.x + difference.x/25,5 * (float)Math.Abs(Math.Sin(number * Math.PI/25)),pos.position.z + difference.z/25);
        pos.position += offset;
    }
}
