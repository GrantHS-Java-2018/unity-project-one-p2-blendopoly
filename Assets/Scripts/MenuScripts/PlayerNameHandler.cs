using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = System.Object;

public class PlayerNameHandler : MonoBehaviour
{
    public string stringName;
    public Text textBox;

    private void Start()
    {
        InputField textHandler = gameObject.GetComponent<InputField>();
        textHandler.onEndEdit.AddListener(delegate {setName();});
    }

    public void turnOff()
    {
        gameObject.SetActive(false);
    }

    public void turnOn()
    {
        gameObject.SetActive(true);
    }

    public void setName()
    {
        stringName = textBox.text;
    }
    
}
