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
    public BuildableManager manager;
    public Sprite _buttonSprite;
    public Font arial;
    private Purchasable propertyToTrade;

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
            buttonTransform.position = new Vector3((918 - 184) / 4 * x + 92, (374 - 52) / 5 * y + 26, 0);
            buttonTransform.sizeDelta = new Vector2(160, 40);
            button.AddComponent<Scaler>();
            button.AddComponent<Image>().type = Image.Type.Sliced;
            button.GetComponent<Image>().sprite = _buttonSprite;
            Text textComponent = text.AddComponent<Text>();
            Property p = property as Property;
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
                    button.AddComponent<Button>().onClick.AddListener(delegate { p.buildHouse(player); });
                    textComponent.text = property.name + ": " + p.numOfHouses;
                    break;
                case 3:
                    button.AddComponent<Button>().onClick.AddListener(delegate { p.sellHouse(player); });
                    textComponent.text = property.name + ": " + p.numOfHouses;
                    break;
                case 4:
                    if (property.owner == handler.players[handler.index])
                    {
                        button.AddComponent<Button>().onClick.AddListener(delegate { cancel(); });
                    }
                    else
                    {
                        button.AddComponent<Button>().onClick.AddListener(delegate { showAllPropertiesOwnedBy(handler.index + 1, property); });
                    }
                    textComponent.text = property.name;
                    break;
                case 5:
                    button.AddComponent<Button>().onClick.AddListener(delegate { trade(property); });
                    textComponent.text = property.name;
                    break;
                default:
                    Debug.Log("Broken in ActionHandler!");
                    break;
            }
            if (p != null)
            {
                button.GetComponent<Image>().color = p.color;
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

    private void getPlayersProperties(int player)
    {
        properties.Clear();
        foreach (var property in layout.boardTrack)
        {
            var p = property as Purchasable;
            if (p != null)
            {
                switch (player)
                {
                    case 0:
                        if (p.owner == null)
                        {
                            properties.Add(p);
                        }
                        break;
                    default:
                        if (p.owner == handler.players[player - 1])
                        {
                            properties.Add(p);
                        }
                        break;
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

    public void showAllPropertiesOwnedBy(int player)
    {
        buttonHandler.turnOffAll();
        buttonHandler.turnOnCancel();
        getPlayersProperties(player);
        displayProperties(null, 4);
    }

    public void showAllPropertiesOwnedBy(int player, Purchasable property)
    {
        if (checkIfValidTrade(property))
        {
            buttonHandler.clearProperties();
            propertyToTrade = property;
            buttonHandler.turnOffAll();
            buttonHandler.turnOnCancel();
            getPlayersProperties(player);
            displayProperties(null, 5);
        }
        else
        {
            cancel();
        }
    }

    private void trade(Purchasable property)
    {
        if (checkIfValidTrade(property))
        {
            Player p = property.owner;
            property.owner = propertyToTrade.owner;
            propertyToTrade.owner = p;
            checkForChanges(property, p);
            checkForChanges(propertyToTrade, property.owner);
        }
        cancel();
    }

    private bool checkIfValidTrade(Purchasable a)
    {
        Property aProperty = a as Property;
        if (aProperty != null)
        {
            return (!a.morgaged && aProperty.numOfHouses == 0 && a.owner != null);
        }
        return (!a.morgaged && a.owner != null);
    }

    private void checkForChanges(Purchasable p, Player oldOwner)
    {
        Railroads railroad = p as Railroads;
        Utilities utilitiy = p as Utilities;
        if (railroad != null)
        {
            --oldOwner.railroads;
            ++p.owner.railroads;
        }
        else if (utilitiy != null)
        {
            --oldOwner.utilities;
            ++p.owner.utilities;
        }
    }
    
}
