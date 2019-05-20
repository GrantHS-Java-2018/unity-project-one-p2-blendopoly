using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerText : MonoBehaviour
{

    public Transform player;
    public TextMesh text;
    public Transform camera;

    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = player.position + calculateOffset();
        pointToCamera();
        ++counter;
        if (counter >= 60)
        {
            gameObject.SetActive(false);
        }
    }

    private Vector3 calculateOffset()
    {
        return new Vector3(0,2 + (counter/12f),0);
    }

    public void displayChange(int change)
    {
        text.text = change.ToString();
        if (change > 0)
        {
            text.color = Color.green;
        }
        else
        {
            text.color = Color.red;
        }
        gameObject.SetActive(true);
        counter = 0;
    }

    private void pointToCamera()
    {
        Vector3 relativePos = transform.position - camera.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }
}
