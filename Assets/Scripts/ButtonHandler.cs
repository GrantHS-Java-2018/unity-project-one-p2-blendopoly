using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject roll;
    public GameObject changeCamera;
    
    public void turnOffButtons()
    {
        roll.SetActive(false);
        changeCamera.SetActive(false);
    }

    public void turnOnButtons()
    {
        roll.SetActive(true);
        changeCamera.SetActive(true);
    }
}
