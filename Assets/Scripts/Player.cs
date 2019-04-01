using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    private Transform pos;
    public int index { get; set; } = 0;
    public GameObject board;
    public Boolean inJail { get; set; } = false;

    void Start()
    {
        pos = GetComponent<Transform>();
        for (int i = 0; i < 1000; i++)
        {
            turn(0);
            Thread.Sleep(1000);
        }
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
        for (var i = 0; i < roll; i++)
        {
            index++;
            if (index == board.GetComponent<BoardLayout>().boardTrack.Length)
            {
                index = 0;
            }
            setPos(board.GetComponent<BoardLayout>().boardTrack[index]);
        }
        board.GetComponent<BoardLayout>().boardTrack[index].onLand(this);
    }

    private void setPos(GameTile space)
    {
        pos.SetPositionAndRotation(space.pos, pos.rotation);
    }

    private int roll()
    {
        return Random.Range(1, 6);
    }

}
