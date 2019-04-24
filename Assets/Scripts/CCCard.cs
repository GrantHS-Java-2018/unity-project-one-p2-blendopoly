using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CCCard : MonoBehaviour
{
    
    public GameObject[] cardList = new GameObject[16];
    
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
    }

    public void renderOn()
    {
        //gameObject.GetComponent<Image>().sprite = spriteList[4];
        gameObject.SetActive(true);
    }

    public void renderOff()
    {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
    }
}
