using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CCCard : MonoBehaviour
{
    
    public Card[] cardList = new Card[16];
    
    private List<int> notChosen = new List<int>();
    
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
        Vector3 scale;
        scale.x = 2;
        scale.y = 2;
        scale.z = 1;
        gameObject.GetComponent<RectTransform>().localScale = scale;
    }

    public void renderOn()
    {
        if (notChosen.Count <= 0)
        {
            reset();
        }

        int index = Random.Range(0, notChosen.Count);
        gameObject.GetComponent<Image>().sprite = cardList[index].renderedSprite;
        gameObject.SetActive(true);
        //Thread.Sleep(1000);
        //renderOff();
    }
    
    public void renderOff()
    {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
    }
    
    private void reset()
    {
        for (int x1 = 0; x1 < 16; ++x1)
        {
            notChosen.Add(x1);
        }
    }
}
