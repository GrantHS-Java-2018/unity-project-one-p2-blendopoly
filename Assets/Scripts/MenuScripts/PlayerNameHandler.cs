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

    private string name;
    public Text textBox;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
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
        name = textBox.text;
        Debug.Log(name);
    }
    
}
