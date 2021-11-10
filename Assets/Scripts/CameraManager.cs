using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera mainCamera;
    Camera dialogCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        dialogCamera = GameObject.Find("DialogCamera").GetComponent<Camera>();
        dialogCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCamera()
    {
        if(mainCamera.enabled)
        {
            mainCamera.enabled = false;
            dialogCamera.enabled = true;
        }
        else
        {
            mainCamera.enabled = true;
            dialogCamera.enabled = false;
        }
    }
}
