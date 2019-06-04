using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidButtonHandler : MonoBehaviour
{
    public void turnOn()
    {
        gameObject.SetActive(true);
    }

    public void turnOff()
    {
        gameObject.SetActive(false);
    }
}
