using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform t = transform as RectTransform;
        //Debug.Log("Button " + name + "size is " + t.sizeDelta);
        Debug.Log(string.Format("Button {0} size is {1}, anchored position {2}", name, t.sizeDelta, t.anchoredPosition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
