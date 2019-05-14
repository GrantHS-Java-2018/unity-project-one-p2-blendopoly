using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    
    public PlayerNameHandler[] textFields = new PlayerNameHandler[4];
    void Start()
    {
        Dropdown dropdown = gameObject.GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(delegate {onChange(dropdown);});
        onChange(dropdown);
    }

    private void onChange(Dropdown dropdown)
    {
        for (int x1 = 3; x1 > dropdown.value + 1; --x1)
        {
            //Debug.Log("x1: " + x1 + " dropdownValue: " + dropdown.value);
            textFields[x1].turnOff();
        }

        for (int x1 = 0; x1 <= dropdown.value + 1; ++x1)
        {
            //Debug.Log("x1: " + x1 + " dropdownValue: " + dropdown.value);
            textFields[x1].turnOn();
            textFields[x1].setName();
        }

    }

}
