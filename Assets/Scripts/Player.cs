using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Transform pos;

    void Start()
    {
        pos = GetComponent<Transform>();
    }

    public void turn()
    {
        move(roll());
    }

    private void move(int roll)
    {
        for (int i = 0; i < roll; i++)
        {
            setPos(BoardLayout.boardTrack[i]);
        }
    }

    private void setPos(GameTile space)
    {
        pos.SetPositionAndRotation(space.getPos(), pos.rotation);
    }

    private int roll()
    {
        return Random.Range(1, 6);
    }

}
