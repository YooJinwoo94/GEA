using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    CharacterStatus aStatus;
    // Start is called before the first frame update
    public GameObject kDoor;
    Transform doortrans;
    bool dooropen=false;
    void Start()
    {
        doortrans=kDoor.GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("enter");
            aStatus = other.GetComponent<CharacterStatus>();
            if (aStatus.isKey)
            {
                dooropen=true;
            }
        }
    }
    private void Update()
    {
        if (dooropen)
        {
            openKeyDoor();
        }
    }
    void openKeyDoor()
    {

        if (doortrans.eulerAngles.y <= 100.0f)
        {
            float speed = 40.0f;
            doortrans.Rotate(Vector3.up * Time.deltaTime * speed) ;
        }
        else
        {
            aStatus.isKey = false;
        }
    }
    
}
