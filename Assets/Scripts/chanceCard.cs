using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class chanceCard : MonoBehaviour
{
    
    public Card[] cardList = new Card[16];
    
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
    }

    public void renderOn()
    {
        gameObject.GetComponent<Image>().sprite = cardList[1].renderedSprite;
        gameObject.SetActive(true);
    }
    
    public void renderOff()
    {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
    }
}
