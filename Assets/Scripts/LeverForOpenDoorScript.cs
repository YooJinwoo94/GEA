using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverForOpenDoorScript : MonoBehaviour
{//�������� 3 �ܰ躰 �� ����� ���� ��ũ��Ʈ + �߾ӱ� �� ����
    public Transform PlayerTrans;
    public Transform FirstLever;
    public Transform SecondLever;

    public bool FirstOn = false, SecondOn = false;

    public GameObject Door;
    public GameObject CenterDoor;
    float speed = 30.0f;

    public Light[] lights;
    public AudioClip Clip;
    AudioSource Audio;

    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();
        Audio.clip = Clip;

        lights[0].color = Color.red;
        lights[1].color = Color.red;
    }

    void Update()
    {
        FirstLeverCon();
        SecondLeverCon();
        DoorOpen();
    }

    public void FirstLeverCon()
    {
        if (Vector3.Distance(PlayerTrans.position, FirstLever.position) <= 3f)
        {
            FirstOn = true;
            lights[0].color = Color.green;
            Audio.Play();
        }

        if (FirstOn && FirstLever.eulerAngles.z <= 300.0f)
        {
            FirstLever.Rotate(speed * Time.deltaTime * Vector3.forward);
        }
    }

    public void SecondLeverCon()
    {
        if (Vector3.Distance(PlayerTrans.position, SecondLever.position) <= 3f)
        {
            SecondOn = true;
            lights[1].color = Color.green;
            Audio.Play();
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
