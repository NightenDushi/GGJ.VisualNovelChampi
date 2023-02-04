using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Selector : MonoBehaviour
{
    public UnityEvent onRightClicked;
    public UnityEvent onLeftClicked;
    public Part part;

    public enum Part 
    {
        BODY, HEAD, HAT, EYES
    }

    public void leftClicked()
    {   
        

        onLeftClicked.Invoke();
    }

    public void rightClicked()
    {
        onRightClicked.Invoke();
    }
}
