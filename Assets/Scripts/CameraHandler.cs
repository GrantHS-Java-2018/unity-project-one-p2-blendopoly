using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraHandler : MonoBehaviour
{

    public Transform board;
    private Transform pos;
    private bool xIncreasing = true;
    private bool zIncreasing = true;
    private int counter = 0;
    private bool isOnPlayer = false;
    public PlayerHandler handler;
    public Text buttonText;
    public Light light;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        pos.SetPositionAndRotation(new Vector3(0,40,-100), Quaternion.Euler(40,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        light.transform.SetPositionAndRotation(transform.position, transform.rotation);
        if (isOnPlayer)
        {
            focusOnPlayer(handler.players[handler.index]);
        }
        else
        {
            rotateAroundBoard();
        }
    }

    private void rotateAroundBoard()
    {
        if (counter % 2 == 0)
        {
            if (xIncreasing && !zIncreasing)
            {
                pos.SetPositionAndRotation(new Vector3(pos.position.x + 1, pos.position.y, pos.position.z - 1),
                    Quaternion.Euler(40, -0.9f * pos.position.x, 0));
            }
            else if (!xIncreasing && zIncreasing)
            {
                pos.SetPositionAndRotation(new Vector3(pos.position.x - 1, pos.position.y, pos.position.z + 1),
                    Quaternion.Euler(40, (-90 + (-0.9f * pos.position.z)), 0));
            }
            else if (!xIncreasing && !zIncreasing)
            {
                pos.SetPositionAndRotation(new Vector3(pos.position.x - 1, pos.position.y, pos.position.z - 1),
                    Quaternion.Euler(40, (90 + (0.9f * pos.position.z)), 0));
            }
            else if (xIncreasing && zIncreasing)
            {
                pos.SetPositionAndRotation(new Vector3(pos.position.x + 1, pos.position.y, pos.position.z + 1),
                    Quaternion.Euler(40, -0.9f * pos.position.x, 0));
            }
    
            if (pos.position.x == 100)
            {
                xIncreasing = false;
            }
            else if (pos.position.x == -100)
            {
                xIncreasing = true;
            }
    
            if (pos.position.z == 100)
            {
                zIncreasing = false;
            }
            else if (pos.position.z == -100)
            {
                zIncreasing = true;
            }
        }
        ++counter;   
    }

    private void focusOnPlayer(Player player)
    {
        Vector3 offset;
        if ((player.currentPos == 10 || player.currentPos == 20 || player.currentPos == 30 || player.index == 39) &&
            player.moving)
        {
            offset = circleFunction(player);
        }
        else
        {
            offset = getOffset(player);
        }
        transform.position = player.transform.position + offset;
        Vector3 relativePos = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }

    public void buttonClick()
    {
        isOnPlayer = !isOnPlayer;
        if (isOnPlayer)
        {
            buttonText.text = "Show board";
        }
        else
        {
            buttonText.text = "Show player";
            pos.SetPositionAndRotation(new Vector3(0,40,-100), Quaternion.Euler(40,0,0));
            xIncreasing = true;
            zIncreasing = true;
        }
    }

    public Vector3 getOffset(Player player)
    {
        if (player.currentPos <= 10)
        {
            return new Vector3(0,20,-20);
        }
        if (player.currentPos <= 20)
        {
            return new Vector3(-20,20,0);
        }
        if (player.currentPos <= 30)
        {
            return new Vector3(0, 20, 20);
        }
        return new Vector3(20,20,0);
    }

    public Vector3 getOffset(int location)
    {
        if (location <= 10)
        {
            return new Vector3(0,20,-20);
        }
        if (location <= 20)
        {
            return new Vector3(-20,20,0);
        }
        if (location <= 30)
        {
            return new Vector3(0, 20, 20);
        }
        return new Vector3(20,20,0);
    }

    public Vector3 circleFunction(Player player)
    {
        Vector3 offset = Vector3.Lerp(getOffset(player), getOffset(player.currentPos + 1), player.counter/25f);
        return offset;
    }
    
}
