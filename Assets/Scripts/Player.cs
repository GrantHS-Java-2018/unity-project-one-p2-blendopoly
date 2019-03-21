using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    private Transform pos;
    private int index = 0;
    [SerializeField] private GameObject board;

    void Start()
    {
        pos = GetComponent<Transform>();
        for (int i = 0; i < 1000; i++)
        {
            turn();
            Thread.Sleep(1000);
        }
    }

    public void turn()
    {
        move(roll());
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
