using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CCCard : MonoBehaviour
{
    
    public Sprite[] spriteList = new Sprite[16];

    //public SpriteRenderer sr;
    
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        //sr.sprite = null;
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
    }

    public void renderOn()
    {
        //Transform this1 = GetComponent<Transform>();
        //transform.SetPositionAndRotation(position, transform.rotation);
        //sr.sprite = spriteList[4];
        //this1.transform.localPosition = position;
        gameObject.GetComponent<Image>().sprite = spriteList[4];
        gameObject.SetActive(true);
    }

    public void renderOff()
    {
        //sr.sprite = null;
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
    }
}
