using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraHandler : MonoBehaviour
{

    public Transform board;
    private Transform pos;
    private bool xIncreasing = true;
    private bool zIncreasing = true;
    private int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        pos.SetPositionAndRotation(new Vector3(0,40,-100), Quaternion.Euler(40,0,0));
    }

    // Update is called once per frame
    void Update()
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
}
