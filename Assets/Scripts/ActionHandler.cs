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
        int y = 5;
        foreach (Purchasable property in properties)
        {
            GameObject button = new GameObject();
            button.name = "Button";
            GameObject text = new GameObject();
            text.name = property.name;
            RectTransform buttonTransform = button.AddComponent<RectTransform>();
            buttonTransform.SetParent(canvas.transform);
            text.transform.SetParent(buttonTransform);
            buttonTransform.anchorMin = new Vector2(0, 0);
            buttonTransform.anchorMax = new Vector2(0, 0);
            buttonTransform.position = new Vector3((Screen.width - 184) / 4 * x + 92, (Screen.height - 52) / 5 * y + 26, 0);
            buttonTransform.sizeDelta = new Vector2(160, 40);
            button.AddComponent<Image>().type = Image.Type.Sliced;
            button.GetComponent<Image>().sprite = _buttonSprite;
            Text textComponent = text.AddComponent<Text>();
            switch (purpose)
            {
                case 0:
                    button.AddComponent<Button>().onClick.AddListener(delegate { morgageSelection(property.name); });
                    textComponent.text = property.name + ": $" + property.morgagePrice;
                    break;
                case 1:
                    button.AddComponent<Button>().onClick.AddListener(delegate { unMorgageSelection(property.name); });
                    textComponent.text = property.name + ": $" + property.morgagePrice;
                    break;
                case 2:
                    Property p = property as Property;
                    button.AddComponent<Button>().onClick.AddListener(delegate { p.buildHouse(player); });
                    textComponent.text = property.name + ": " + p.numOfHouses;
                    break;
                case 3:
                    Property propertyVersion = property as Property;
                    button.AddComponent<Button>().onClick.AddListener(delegate { propertyVersion.sellHouse(player); });
                    textComponent.text = property.name + ": " + propertyVersion.numOfHouses;
                    break;
                default:
                    //build a house
                    //also sell a house
                    break;
            }
            button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.color = Color.black;
            textComponent.font = arial;
            buttonHandler.addButton(button);
            if (y == 0 || (x == 2 && y == 2))
            {
                y = 5;
                ++x;
            }
            else
            {
                --y;
            }
        }
    }

    private void getPlayersProperties(bool sell, Player player)
    {
        properties.Clear();
        int min;
        int max;
        if (sell)
        {
            min = 1;
            max = 5;
        }
        else
        {
            min = 0;
            max = 4;
        }
        foreach (var property in layout.boardTrack)
        {
            var p = property as Property;
            if (p != null)
            {
                if (p.owner == player && p.numOfHouses <= max && p.numOfHouses >= min && p.groupOwned() && !p.morgaged)
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
                    var houses = p as Property;
                    if (houses == null || houses.numOfHouses == 0)
                    {
                        properties.Add(property);
                    }
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
        getPlayersProperties(false, handler.players[handler.index]);
        displayProperties(handler.players[handler.index], 2);
    }

    public void sellHouse()
    {
        buttonHandler.turnOffEndTurn();
        buttonHandler.turnOnCancel();
        getPlayersProperties(true, handler.players[handler.index]);
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
                handler.players[handler.index].changeMoney(property.morgagePrice);
                --handler.players[handler.index].unMorgagedProperties;
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
                handler.players[handler.index].changeMoney(-property.morgagePrice);
                ++handler.players[handler.index].unMorgagedProperties;
            }
        }
        cancel();
    }
}
