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

    public void displayProperties(Player player, int purpose)
    {
        int x = 0;
        int y = 1;
        foreach (Purchasable property in properties)
        {
            GameObject button = new GameObject();
            button.name = "Button";
            GameObject text = new GameObject();
            text.name = "Text";
            RectTransform buttonTransform = button.AddComponent<RectTransform>();
            buttonTransform.SetParent(canvas.transform);
            text.transform.SetParent(buttonTransform);
            buttonTransform.anchorMin = new Vector2(0, 1);
            buttonTransform.anchorMax = new Vector2(0, 1);
            buttonTransform.position = new Vector3(200 * x + 150, y * -100 + 615, 0);
            buttonTransform.sizeDelta = new Vector2(160, 30);
            button.AddComponent<Image>().type = Image.Type.Sliced;
            button.GetComponent<Image>().sprite = _buttonSprite;
            switch (purpose)
            {
                case 0:
                    button.AddComponent<Button>().onClick.AddListener(delegate { morgageSelection(property.name); });
                    break;
                case 1:
                    button.AddComponent<Button>().onClick.AddListener(delegate { unMorgageSelection(property.name); });
                    break;
                default:
                    //build a house
                    //also sell a house
                    break;
            }
            button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();
            Text textComponent = text.AddComponent<Text>();
            textComponent.text = property.name;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.color = Color.black;
            textComponent.font = arial;
            buttonHandler.addButton(button);
            if (y == 5)
            {
                y = 1;
                ++x;
            }
            else
            {
                ++y;
            }
        }
    }

    private void getPlayersProperties(Player player, int houses)
    {
        bool sell = houses != 0;
        properties.Clear();
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
        properties.Clear();
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
        displayProperties(handler.players[handler.index], 0);
    }

    public void unMorgageProperties()
    {
        buttonHandler.turnOffEndTurn();
        buttonHandler.turnOnCancel();
        getPlayersProperties(handler.players[handler.index], true);
        displayProperties(handler.players[handler.index], 1);
    }

    public void buildHouse()
    {
        buttonHandler.turnOffEndTurn();
        buttonHandler.turnOnCancel();
        getPlayersProperties(handler.players[handler.index]);
        displayProperties(handler.players[handler.index], 2);
    }

    public void sellHouse()
    {
        buttonHandler.turnOffEndTurn();
        buttonHandler.turnOnCancel();
        getPlayersProperties(handler.players[handler.index]);
        displayProperties(handler.players[handler.index], 3);
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
