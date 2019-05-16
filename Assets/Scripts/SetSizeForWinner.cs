using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSizeForWinner : MonoBehaviour
{
    public RectTransform background;
    public RectTransform monoMan;
    public RectTransform text;
    public ParticleSystem fountain1;
    public ParticleSystem fountain2;
    
    void Start()
    {
        monoMan.sizeDelta = new Vector2(Screen.width * (monoMan.sizeDelta.x/background.sizeDelta.x), Screen.height * (monoMan.sizeDelta.y/background.sizeDelta.y));
        background.sizeDelta = new Vector2(Screen.width, Screen.height);
        monoMan.position.Set(monoMan.position.x,Screen.height * (monoMan.position.y/Screen.height),monoMan.position.z);
        text.position.Set(text.position.x,Screen.height * (text.position.y/Screen.height),text.position.z);
        fountain1.transform.position.Set(Screen.width * (fountain1.transform.position.y/Screen.width),Screen.height * (fountain1.transform.position.y/Screen.height),fountain1.transform.position.z);
        fountain2.transform.position.Set(Screen.width * (fountain2.transform.position.y/Screen.width),Screen.height * (fountain2.transform.position.y/Screen.height),fountain2.transform.position.z);
    }
}
