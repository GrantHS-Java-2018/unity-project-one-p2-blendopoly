﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
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

    void Start()
    {
        pos = GetComponent<Transform>();
        layout = board.GetComponent<BoardLayout>();
        setPos();
    }

    void Update()
    {
        if (index < 10)
        {
            pos.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (index < 20)
        {
            pos.rotation = Quaternion.Euler(0,-90,0);
        }
        else if (index < 30)
        {
            pos.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            pos.rotation = Quaternion.Euler(0,90,0);
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
            int die1 = roll();
            int die2 = roll();
            move(die1 + die2);
            if (die1 == die2 && doubles != 2)
            {
                ++doubles;
                repeat = true;
            }
            else if (die1 == die2)
            {
                index = BoardLayout.JAIL_INDEX;
                doubles = 0;
                inJail = true;
                repeat = false;
                setPos();
            }
            else
            {
                doubles = 0;
                repeat = false;
            }
        }
        else
        {
            int die1 = roll();
            int die2 = roll();
            if (die1 == die2)
            {
                move(die1 + die2);
                inJail = false;
            }
            else if (turnsInJail == 2)
            {
                move(die1 + die2);
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
        for (var i = 0; i < roll; ++i)
        {
            ++index;
            if (index == layout.boardTrack.Length)
            {
                index = 0;
                money += 200; //passing go
            }
            setPos(layout.boardTrack[index]);
        }
        layout.boardTrack[index].onLand(this);
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

}
