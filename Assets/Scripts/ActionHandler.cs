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

    public void displayProperties(Player player)
    {
        foreach (Purchasable property in properties)
        {
            GameObject button = new GameObject();
            button.name = "Button";
            GameObject text = new GameObject();
            text.name = "Text";
            button.AddComponent<RectTransform>();
            button.transform.SetParent(canvas.transform);
            button.transform.position = new Vector3(0,0,0);
            text.transform.SetParent(button.transform);
            button.AddComponent<Image>();
            button.GetComponent<Image>().sprite = Resources.Load("UISprite") as Sprite;
            button.AddComponent<Button>().onClick.AddListener(delegate { getPlayersProperties(player); });
            button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();
            text.AddComponent<Text>().text = property.name;
            text.GetComponent<Text>().color = Color.black;
            text.GetComponent<Text>().font = Resources.Load("Arial") as Font;
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

    public void morgageProperties()
    {
        getPlayersProperties(handler.players[handler.index]);
        displayProperties(handler.players[handler.index]);
    }
}
