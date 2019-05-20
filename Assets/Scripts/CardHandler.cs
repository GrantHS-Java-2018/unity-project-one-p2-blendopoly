using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    
    public Card[] cardList = new Card[16];
    
    private List<int> notChosen = new List<int>();

    private int value;

    public PlayerHandler handler;
    
    public bool landedOnSpace = false;
    
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate {onClick();});
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
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
        Debug.Log("Chance Size: " + notChosen.Count);
    }

    private void onClick()
    {
        cardList[value].action(handler.players[handler.index]);
        renderOff();
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
