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
        monoMan.position.Set(monoMan.position.x,monoMan.sizeDelta.y * (monoMan.position.y/464.3f),monoMan.position.z);
        text.position.Set(text.position.x,Screen.height * (text.position.y/621f),text.position.z);
        fountain1.transform.position.Set(Screen.width * (fountain1.transform.position.y/1179f),Screen.height * (fountain1.transform.position.y/621f),fountain1.transform.position.z);
        fountain2.transform.position.Set(Screen.width * (fountain2.transform.position.y/1179f),Screen.height * (fountain2.transform.position.y/621f),fountain2.transform.position.z);
    }
}
