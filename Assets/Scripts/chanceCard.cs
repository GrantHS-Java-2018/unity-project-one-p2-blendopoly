using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class chanceCard : MonoBehaviour
{
    
    public Sprite[] spriteList = new Sprite[16];

    public SpriteRenderer sr;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = null;
    }

    public void renderOn(Vector3 position)
    {
        Transform this1 = GetComponent<Transform>();
        //transform.SetPositionAndRotation(position, transform.rotation);
        sr.sprite = spriteList[4];
        this1.transform.localPosition = position;
    }
    
    private void renderOff()
    {
        sr.sprite = null;
    }
}
