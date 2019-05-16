using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneHandler : MonoBehaviour
{

    void Start()
    {
        Button textHandler = gameObject.GetComponent<Button>();
        textHandler.onClick.AddListener(delegate {changeScene();});
    }

    public void changeScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}