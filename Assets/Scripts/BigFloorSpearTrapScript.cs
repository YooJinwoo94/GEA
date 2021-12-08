using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFloorSpearTrapScript : MonoBehaviour
{
    public Transform[] Spear;

    public bool Up, Down;
    public bool First, Second;

    float MaxHeightValue = 3.0f;
    public float Upspeed = 16f;
    public float Downspeed = 1.5f;
    Vector3[] StartPos;

    float timecheck;
    public float delay = 0.7f;
    public AudioClip Clip;
    AudioSource Audio;

    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();
        Audio.clip = Clip;

        StartPos = new Vector3[4];
        StartPos[0] = Spear[0].position;
        StartPos[1] = Spear[1].position;
        StartPos[2] = Spear[2].position;
        StartPos[3] = Spear[3].position;

        Up = true;
        First = true;
        Down = false;
        Second = false;
        timecheck = 0;
    }

    void Update()
    {
        timecheck += Time.deltaTime;
        if(timecheck >= delay)
        {
            if (First)
                AutoTrap(0);
            else if (Second)
                AutoTrap(1);
        }
    }

    public void AutoTrap(int type)
    {
        if (Up)
        {
            Audio.Play();

            Spear[type].Translate(Upspeed * Time.deltaTime * Vector3.up);
            Spear[type + 2].Translate(Upspeed * Time.deltaTime * Vector3.up);
            if(Spear[type].position.y > (StartPos[type].y + MaxHeightValue) &&
                Spear[type + 2].position.y > (StartPos[type + 2].y + MaxHeightValue))
            {
                Up = false;
                Down = true;
            }
        }

        else if (Down)
        {
            //Audio.Pause();

            Spear[type].Translate(Downspeed * Time.deltaTime * Vector3.down);
            Spear[type + 2].Translate(Downspeed * Time.deltaTime * Vector3.down);
            if (Spear[type].position.y <= StartPos[type].y &&
                Spear[type + 2].position.y <= StartPos[type + 2].y )
            {
                Up = true;
                Down = false;
                timecheck = 0;

                changeBoolValue();
            }
        }
    }

    public void changeBoolValue()
    {
        if(First)
        {
            First = false;
            Second = true;
        }

        else if (Second)
        {
            First = true;
            Second = false;
        }
    }
}
