using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private float resolutionX;
    private float resolutionY;
    private RectTransform transform;
    private Vector2 sizeDelta;
    private Vector3 position;
    void Start()
    {
        transform = GetComponent<RectTransform>();
        sizeDelta = transform.sizeDelta;
        position = transform.position;
        resolutionX = Screen.width;
        resolutionY = Screen.height;
        transform.sizeDelta = new Vector2(Screen.width * sizeDelta.x / 918f, Screen.height * sizeDelta.y / 374f);
        transform.position = new Vector3(Screen.width * position.x / 918f, Screen.height * position.y / 374f, position.z);
    }

    private void Update()
    {
        if (resolutionX != Screen.width || resolutionY != Screen.height)
        {
            transform.sizeDelta = new Vector2(Screen.width * sizeDelta.x / 918f, Screen.height * sizeDelta.y / 374f);
            transform.position = new Vector3(Screen.width * position.x / 918f, Screen.height * position.y / 374f,position.z);
            resolutionX = Screen.width;
            resolutionY = Screen.height;
        }
    }
}
