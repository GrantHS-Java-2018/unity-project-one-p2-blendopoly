using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    
    [SerializeField] private Card[] cardList = new Card[16];
    
    private List<int> notChosen = new List<int>();

    private int value;

    [SerializeField] private PlayerHandler handler;

    private bool cardShown = false;

    public bool doneShowing = false;
    
    public bool landedOnSpace = false;

    public bool waitingOnDice = false;

    [SerializeField] private BoardLayout layout;

    private RectTransform transform;
    
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate {onClick();});
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.GetComponent<Image>().enabled = false;
        transform = gameObject.GetComponent<RectTransform>();
        transform.sizeDelta = new Vector2(Screen.width * 0.9f, Screen.height * 0.9f);
    }

    void Update()
    {
        if (cardShown && doneShowing && !handler.players[handler.index].moving && !waitingOnDice)
        {
            doneShowing = false;
            cardShown = false;
            finished();
        }
        else if (cardShown)
        {
            transform.sizeDelta = new Vector2(Screen.width * 0.9f, Screen.height * 0.9f);
        }
    }

    public void renderOn()
    {
        cardShown = true;
        transform.sizeDelta = new Vector2(Screen.width * 0.9f, Screen.height * 0.9f);
        if (notChosen.Count <= 0)
        {
            reset();
        }
        int index = Random.Range(0, notChosen.Count);
        value = notChosen[index];
        notChosen.RemoveAt(index);
        gameObject.GetComponent<Image>().sprite = cardList[value].renderedSprite;
        gameObject.GetComponent<Image>().enabled = true;
    }

    private void onClick()
    {
        cardList[value].action(handler.players[handler.index]);
        renderOff();
    }

    private void renderOff()
    {
        doneShowing = true;
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.GetComponent<Image>().enabled = false;
        //gameObject.SetActive(false);
    }
    
    private void reset()
    {
        for (int x1 = 0; x1 < 16; ++x1)
        {
            notChosen.Add(x1);
        }
    }

    private void finished()
    {
        if (landedOnSpace)
        {
            landedOnSpace = false;
            layout.boardTrack[handler.players[handler.index].index].onLand(handler.players[handler.index]);
        }
        else
        {
            handler.players[handler.index].readyForAction();
        }
    }
}
