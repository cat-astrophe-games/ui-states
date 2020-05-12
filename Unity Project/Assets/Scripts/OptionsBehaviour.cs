using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsBehaviour : MonoBehaviour
{
    public StateOptions state;

    void Update()
    {
        // escape key does the same thing as "back" button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            state.ClickBack();
        }        
    }
}
