using System;
using System.Collections;
using System.Collections.Generic;
using Spaces.Purchasable.Purchasable;
using UnityEngine;
using UnityEngine.UI;

public class ActionHandler : MonoBehaviour
{
    public BoardLayout layout;
    private ArrayList properties = new ArrayList();
    public Canvas canvas;
    public PlayerHandler handler;
    public ButtonHandler buttonHandler;
    public Sprite _buttonSprite;
    public Font arial;

    public void displayProperties(Player player)
    {
        foreach (Purchasable property in properties)
        {
            GameObject button = new GameObject();
            button.name = "Button";
            GameObject text = new GameObject();
            text.name = "Text";
            RectTransform buttonTransform = button.AddComponent<RectTransform>();
            buttonTransform.SetParent(canvas.transform);
            text.transform.SetParent(buttonTransform);
            buttonTransform.localPosition = new Vector3(0, 0, 0);
            buttonTransform.sizeDelta = new Vector2(160,30);
            button.AddComponent<Image>().type = Image.Type.Sliced;
            button.GetComponent<Image>().sprite = _buttonSprite;
            button.AddComponent<Button>().onClick.AddListener(delegate { morgageSelection(property.name); });
            button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();
            Text textComponent = text.AddComponent<Text>();
            textComponent.text = property.name;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.color = Color.black;
            textComponent.font = arial;
            buttonHandler.addButton(button);
        }   
    }

    private void getPlayersProperties(Player player)
    {
        foreach (var property in layout.boardTrack)
        {
            var p = property as Purchasable;
            if (p != null)
            {
                if (p.owner == player)
                {
                    properties.Add(property);
                }
            }
        }
    }

    private void getPlayersProperties(Player player, bool morgaged)
    {
        foreach (var property in layout.boardTrack)
        {
            var p = property as Purchasable;
            if (p != null)
            {
                if (p.owner == player && p.morgaged == morgaged)
                {
                    properties.Add(property);
                }
            }
        }
    }

    public void morgageProperties()
    {
        buttonHandler.turnOffEndTurn();
        buttonHandler.turnOnCancel();
        getPlayersProperties(handler.players[handler.index], false);
        displayProperties(handler.players[handler.index]);
    }

    public void cancel()
    {
        buttonHandler.turnOffCancel();
        buttonHandler.turnOnEndTurn();
        buttonHandler.clearProperties();
    }

    public void morgageSelection(String name)
    {
        foreach(Purchasable property in properties)
        {
            if (property.name == name)
            {
                property.morgaged = true;
                handler.players[handler.index].money += property.morgagePrice;
            }
        }
        cancel();
    }

    public void unMorgageSelection(String name)
    {
        foreach(Purchasable property in properties)
        {
            if (property.name == name)
            {
                property.morgaged = false;
                handler.players[handler.index].money -= property.morgagePrice;
            }
        }
        cancel();
    }
}
