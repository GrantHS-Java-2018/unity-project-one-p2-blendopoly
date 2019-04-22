using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chanceCard : MonoBehaviour
{

    public Sprite[] spriteList = new Sprite[16];

    public SpriteRenderer sr;
    
    void Start()
    {
        sr = new SpriteRenderer();
        sr.sprite = spriteList[1];
        sr.enabled = false;
    }

    void renderOn()
    {
        sr.enabled = true;
    }

    void renderOff()
    {
        sr.enabled = false;
    }
}
