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
    public int Type;

    public bool OpenDoor = false;
    void Start()
    {
        DLeftTrans = DoorLeft.GetComponent<Transform>();
        DRightTrans = DoorRight.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //float speed = 30.0f;
        //timecheck += Time.deltaTime;
        //if (timecheck <= 3.5f)
        //{
        //    DLeftTrans.Rotate(Vector3.up * Time.deltaTime * speed);
        //    DRightTrans.Rotate(Vector3.down * Time.deltaTime * speed);
        //}
        //DoorOpenAnimation();
        if (!OpenDoor)
            return;

        switch (Type)
        {
            case 0:
                VDoorOpenAnimation();
                break;
            case 1:
                HDoorOpenAnimation();
                break;
            default:
                VDoorOpenAnimation();
                break;
        }
    }

    public void VDoorOpenAnimation()
    {
        float speed = 30.0f;
        if(DLeftTrans.eulerAngles.y <= 180.0f)
            DLeftTrans.Rotate(Vector3.up * Time.deltaTime * speed);
        if(DRightTrans.eulerAngles.y >= 0.1f)
            DRightTrans.Rotate(Vector3.down * Time.deltaTime * speed);
    }

    public void HDoorOpenAnimation()
    {
        float speed = 30.0f;
        if (DLeftTrans.eulerAngles.y <= 90.0f)
            DLeftTrans.Rotate(Vector3.up * Time.deltaTime * speed);
        if (DRightTrans.eulerAngles.y >= 270.0f && DRightTrans.eulerAngles.y <= 360.0f)
            DRightTrans.Rotate(Vector3.down * Time.deltaTime * speed);
    }

    public void DoorOpen()
    {
        OpenDoor = true;
    }
}
