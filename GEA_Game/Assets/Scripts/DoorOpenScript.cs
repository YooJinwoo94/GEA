using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    public GameObject DoorLeft;//+100
    public GameObject DoorRight;//-100
    Transform DLeftTrans;
    Transform DRightTrans;
    float timecheck = 0;
    void Start()
    {
        DLeftTrans = DoorLeft.GetComponent<Transform>();
        DRightTrans = DoorRight.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 30.0f;
        timecheck += Time.deltaTime;
        if (timecheck <= 3.5f)
        {
            DLeftTrans.Rotate(Vector3.up * Time.deltaTime * speed);
            DRightTrans.Rotate(Vector3.down * Time.deltaTime * speed);
        }
        //DoorOpenAnimation();
    }

    //public void DoorOpenAnimation()
    //{
    //    float speed = 20.0f;
    //    //if(DLeftTrans.rotation.y <= 190.0f)
    //        DLeftTrans.Rotate(Vector3.up * Time.deltaTime * speed);
    //    //if(DRightTrans.rotation.y >= -10.0f)
    //        DRightTrans.Rotate(Vector3.down * Time.deltaTime * speed);
    //}
}
