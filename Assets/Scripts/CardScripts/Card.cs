using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public Sprite renderedSprite;
    
    public abstract void action();
}
