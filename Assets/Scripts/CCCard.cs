using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CCCard : MonoBehaviour
{
    
    public Card[] cardList = new Card[16];
    
    private List<int> notChosen = new List<int>();

    private bool rendered = false;

    public bool getStatus()
    {
        return rendered;
    }

    void Start()
    {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
        Vector3 scale;
        scale.x = 1;
        scale.y = 1;
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
        int value = notChosen[index];
        notChosen.RemoveAt(index);
        gameObject.GetComponent<Image>().sprite = cardList[value].renderedSprite;
        gameObject.SetActive(true);
        rendered = true;
    }

    private void Update()
    {
        if (rendered)
        {
            Thread.Sleep(10000);
            renderOff();
            rendered = false;
        }
    }

    private void renderOff()
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
