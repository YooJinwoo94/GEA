using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverForOpenDoorScript : MonoBehaviour
{//스테이지 3 단계별 문 개방용 레버 스크립트 + 중앙길 문 개방
    public Transform PlayerTrans;
    public Transform FirstLever;
    public Transform SecondLever;

    public bool FirstOn = false, SecondOn = false;

    public GameObject Door;
    public GameObject CenterDoor;
    float speed = 30.0f;

    void Start()
    {
        
    }

    void Update()
    {
        FirstLeverCon();
        SecondLeverCon();
        DoorOpen();
    }

    public void FirstLeverCon()
    {
        if (Vector3.Distance(PlayerTrans.position, FirstLever.position) <= 2.5f)
        {
            FirstOn = true;
        }

        if (FirstOn && FirstLever.eulerAngles.z <= 300.0f)
        {
            FirstLever.Rotate(speed * Time.deltaTime * Vector3.forward);
        }
    }

    public void SecondLeverCon()
    {
        if (Vector3.Distance(PlayerTrans.position, SecondLever.position) <= 2.5f)
        {
            SecondOn = true;
        }

        if (SecondOn && SecondLever.eulerAngles.z <= 300.0f)
        {
            SecondLever.Rotate(speed * Time.deltaTime * Vector3.forward);
        }
    }

    public void DoorOpen()
    {
        if(FirstOn && SecondOn)
        {
            Door.GetComponent<DoorOpenScript>().DoorOpen();
            CenterDoor.GetComponent<DoorOpenScript>().DoorOpen();
        }
    }
}
