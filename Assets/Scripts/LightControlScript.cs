using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControlScript : MonoBehaviour
{
    public GameObject lightObj;
    public Transform playerTrans;
    public float distance = 25.0f;

    void Start()
    {
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(Vector3.Distance(playerTrans.position,gameObject.transform.position) >= distance)
        {
            lightObj.SetActive(false);
        }
        if(Vector3.Distance(playerTrans.position,gameObject.transform.position) < distance)
        {
            lightObj.SetActive(true);
        }
    }
}
