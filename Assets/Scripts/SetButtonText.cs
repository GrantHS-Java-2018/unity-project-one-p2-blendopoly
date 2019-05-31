using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonText : MonoBehaviour
{

    [SerializeField] private int player;
    [SerializeField] private Text text;
    [SerializeField] private PlayerHandler handler;
    
    // Start is called before the first frame update
    void Start()
    {
        if (handler.players.Length > player)
        {
            text.text = handler.players[player].name + "'s Properties";
        }
    }
}
