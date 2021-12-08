using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapScript : MonoBehaviour
{
    public Transform SawTrans;
    public bool Right = false, Left = true;
    public bool Forward = false, Back = true;
    public int type;
    public Transform StartPos, EndPos;
    public Transform SawBody;
    public AudioClip Clip;
    AudioSource Audio;

    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();
        Audio.clip = Clip;
        Audio.Play();
    }


    void Update()
    {
        SawRotation();
        switch (type)
        {
            case 0:
                SawMovingFB();
                break;
            case 1:
                SawMovingRL();
                break;
        }
    }

    public void SawRotation()
    {
        float speed = 150.0f;
        SawBody.Rotate(speed * Time.deltaTime * Vector3.left); 
    }

    public void SawMovingFB()
    {
        float speed = 2.0f;
        if (Forward)
        {
            SawTrans.Translate(speed * Time.deltaTime * Vector3.forward);
            if(SawTrans.position.z >= StartPos.position.z)
            {
                Forward = false;
                Back = true;
            }
        }
        if (Back)
        {
            SawTrans.Translate(speed * Time.deltaTime * Vector3.back);
            if (SawTrans.position.z <= EndPos.position.z)
            {
                Forward = true;
                Back = false;
            }
        }
    }

    public void SawMovingRL()
    {
        float speed = 2.0f;
        if (Right)
        {
            SawTrans.Translate(speed * Time.deltaTime * Vector3.forward);
            if (SawTrans.position.x >= StartPos.position.x)
            {
                Right = false;
                Left = true;
            }
        }
        if (Left)
        {
            SawTrans.Translate(speed * Time.deltaTime * Vector3.back);
            if (SawTrans.position.x <= EndPos.position.x)
            {
                Right = true;
                Left = false;
            }
        }
    }
}
