using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class chanceCard : MonoBehaviour
{
    
    public Card[] cardList = new Card[16];
    
    private List<int> notChosen = new List<int>();

    private bool rendered = false;

    private int value;

    public PlayerHandler handler;
    
    public bool landedOnSpace = false;
    
    public bool getStatus()
    {
        return rendered;
    }
    
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
        /*Vector3 scale;
        scale.x = 2;
        scale.y = 2;
        scale.z = 1;
        gameObject.GetComponent<RectTransform>().localScale = scale;
        */
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 0.9f, Screen.height * 0.9f);
    }

    public void renderOn()
    {
        if (notChosen.Count <= 0)
        {
            reset();
        }
        int index = Random.Range(0, notChosen.Count);
        value = notChosen[index];
        notChosen.RemoveAt(index);
        gameObject.GetComponent<Image>().sprite = cardList[value].renderedSprite;
        gameObject.SetActive(true);
        rendered = true;
        Debug.Log("Chance Size: " + notChosen.Count);
    }

    private void Update()
    {
        if (rendered)
        {
            Thread.Sleep(5000);
            renderOff();
            rendered = false;
            cardList[value].action(handler.players[handler.index]);
        }
    }

    private void renderOff()
    {
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
    }
    
    private void reset()
    {
        Debug.Log("Chance reset");
        for (int x1 = 0; x1 < 16; ++x1)
        {
            notChosen.Add(x1);
        }
    }
}
