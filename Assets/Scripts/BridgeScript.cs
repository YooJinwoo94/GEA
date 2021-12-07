using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    public Transform BridgeTrans;
    public GameObject ForthFloorLever;
    public GameObject FifthFloorLever;
    public bool FirstOn = false, SecondOn = false;
    bool DownFinished = false;
    public Transform playerTrans;
    public Light[] lights;

    void Start()
    {
        playerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
        lights[0].color = Color.red;
        lights[1].color = Color.red;
    }

    void Update()
    {
        BridgeDown();
        ForthFLeverControl();
        FifthFLeverControl();
    }

    public void BridgeDown()
    {
        float speed = 30.0f;
        if(FirstOn && SecondOn && !DownFinished)
        {
            BridgeTrans.Rotate(Vector3.back * Time.deltaTime * speed);
            if (BridgeTrans.eulerAngles.z <= 10.0f)
            {
                DownFinished = true; 
            }
        }
    }

    public void ForthFLeverControl()
    {
        Transform LeverTrans = ForthFloorLever.GetComponent<Transform>();

        if(Vector3.Distance(playerTrans.position, LeverTrans.position) <= 3.0f)
        {
            FirstOn = true;
            lights[0].color = Color.green;
        }

        if (FirstOn && LeverTrans.eulerAngles.z <= 50.0f)
        {
            float speed = 30.0f;
            LeverTrans.Rotate(speed * Time.deltaTime * Vector3.forward);
        }
    }

    public void FifthFLeverControl()
    {
        Transform LeverTrans = FifthFloorLever.GetComponent<Transform>();

        if (Vector3.Distance(playerTrans.position, LeverTrans.position) <= 3.0f)
        {
            SecondOn = true;
            lights[1].color = Color.green;
        }

        if (SecondOn && LeverTrans.eulerAngles.z <= 50.0f)
        {
            float speed = 30.0f;
            LeverTrans.Rotate(speed * Time.deltaTime * Vector3.forward);
        }
    }
}
