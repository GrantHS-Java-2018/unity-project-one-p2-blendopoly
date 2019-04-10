using System;
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
    public int index { get; set; } = 0;
    public GameObject board;
    private BoardLayout layout;
    public Boolean inJail { get; set; } = false;
    public int money = 0;
    public Text text;

    void Start()
    {
        pos = GetComponent<Transform>();
        layout = board.GetComponent<BoardLayout>();
        setPos();
    }

    private void Update()
    {
        text.text = "Money: $" + money;
    }

    public void turn(int doubles)
    {
        if (!inJail)
        {
            int die1 = roll();
            int die2 = roll();
            move(die1 + die2);
            if (die1 == die2 && doubles != 2)
            {
                turn(++doubles);
            }
            else if (die1 == die2)
            {
                index = 10;
                inJail = true;
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
        }
    }

    private void move(int roll)
    {
        for (var i = 0; i < roll; ++i)
        {
            index++;
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
        pos.position = space.pos;
    }

    public void setPos()
    {
        pos.position = board.GetComponent<BoardLayout>().boardTrack[index].pos;
    }

    private int roll()
    {
        return Random.Range(1, 6);
    }

}
