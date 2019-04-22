using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CCCard : MonoBehaviour
{
    
    public Sprite[] spriteList = new Sprite[16];

    public SpriteRenderer sr;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spriteList[0];
    }

    public void renderOn(Vector3 position)
    {
        
        //transform.SetPositionAndRotation(position, transform.rotation);
        sr.sprite = spriteList[4];
        // set the position
        transform.localPosition = position;
    }

    private void renderOff()
    {
        sr.sprite = null;
    }
}
