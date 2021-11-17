using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpearTrapScript : MonoBehaviour
{
    public Transform PlayerTrans;
    public Transform SencerTrans;
    public Transform SpearTrans;
    public bool Up = true, Down = false;
    bool isMoving;
    [Header("0-Auto, 1-Sencer")]
    public int Type = 0;
    Vector3 StartPos;
    public float MaxHeightValue = 3.0f;
    public float Upspeed = 16f;
    public float Downspeed = 1.5f;
    public bool Shoot = false;
    float timecheck = 0f;

    void Start()
    {
        StartPos = SpearTrans.position;
        isMoving = false;
    }

    void Update()
    {
        TypeofTrap(Type);
    }
    
    public void TypeofTrap(int type)
    {
        switch (type)
        {
            case 1:
                SencerTrap();
                break;
            case 0:
                AutoTrap();
                break;
            default:
                AutoTrap();
                break;
        }
    }

    public void SencerTrap()
    {
        if (Shoot)
        {
            AutoTrap();

            if(timecheck >= 3.0f)
            {
                SpearTrans.position = StartPos;
                timecheck = 0;
            }
        }

        if (!Shoot)
        {
            SpearTrans.position = StartPos;
            timecheck = 0;
        }
    }
    public void AutoTrap()
    {
        if (Up)
        {
            timecheck += Time.deltaTime;
            isMoving = true;
            SpearTrans.Translate(Upspeed * Time.deltaTime * Vector3.up);
            if(SpearTrans.position.y > (StartPos.y+MaxHeightValue))
            {
                Up = false;
                Down = true;
            }
        }

        if (Down)
        {
            SpearTrans.Translate(Downspeed * Time.deltaTime * Vector3.down);
            if(SpearTrans.position.y <= StartPos.y)
            {
                Up = true;
                Down = false;
                isMoving = false;
            }
        }
    }

    public void Shooting()
    {
        Shoot = true;
    }
    public void StopShooting()
    {
        Shoot = false;
    }
}
