using System.Collections;
using System.Collections.Generic;
using Spaces.Purchasable.Purchasable;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    public BoardLayout layout;
    private ArrayList properties = new ArrayList();

    public void selectProperty(Player player)
    {
        getPlayersProperties(player);
    }

    private void getPlayersProperties(Player player)
    {
        foreach (Property property in layout.boardTrack)
        {
            if (property.owner == player)
            {
                properties.Add(property);
            }
        }
    }
}
