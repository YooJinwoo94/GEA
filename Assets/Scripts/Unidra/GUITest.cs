using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 40), "Label");

        if(GUI.Button(new Rect(10,50,100,50), "Button"))
        {
            Debug.Log("Push Button");
        }
    }
}
