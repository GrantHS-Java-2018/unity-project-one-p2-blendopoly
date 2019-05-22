using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private RectTransform transform;
    private Vector2 sizeDelta;
    private Vector3 position;
    
    void Start()
    {
        transform = GetComponent<RectTransform>();
        Debug.Log(transform);
        sizeDelta = transform.sizeDelta;
        position = transform.position;
        transform.sizeDelta = new Vector2(Screen.width * sizeDelta.x / 918f, Screen.height * sizeDelta.y / 374f);
        transform.position = new Vector3(Screen.width * position.x / 918f, Screen.height * position.y / 374f, position.z);
    }

    public void updateForScreen()
    {
        //transform.sizeDelta = new Vector2(Screen.width * sizeDelta.x / 918f, Screen.height * sizeDelta.y / 374f);
        //transform.position = new Vector3(Screen.width * position.x / 918f, Screen.height * position.y / 374f,position.z);
    }
}
