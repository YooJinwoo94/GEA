using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapScript : MonoBehaviour
{
    public Transform SawTrans;
    public bool Right = false, Left = true;
    public float length;
    public Transform StartPos, EndPos;
    public Transform SawBody;
    void Start()
    {
        
    }


    void Update()
    {
        SawRotation();
        SawMoving();
    }

    public void SawRotation()
    {
        float speed = 150.0f;
        SawBody.Rotate(speed * Time.deltaTime * Vector3.left); 
    }

    public void SawMoving()
    {
        float speed = 2.0f;
        if (Left)
        {
            SawTrans.Translate(speed * Time.deltaTime * Vector3.forward);
            if(SawTrans.position.z >= StartPos.position.z)
            {
                Left = false;
                Right = true;
            }
        }
        if (Right)
        {
            SawTrans.Translate(speed * Time.deltaTime * Vector3.back);
            if (SawTrans.position.z <= EndPos.position.z)
            {
                Left = true;
                Right = false;
            }
        }
    }
}
