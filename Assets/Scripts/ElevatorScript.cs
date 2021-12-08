using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public float height;
    public Transform PlayerTrans;
    public Transform LeverTrans;
    Transform ElevatorTrans;
    public bool Up, isMoving;
    Vector3 startPos;
    bool once = false;
    float timecheck = 0;
    public AudioClip Clip;
    AudioSource Audio;

    void Start()
    {
        ElevatorTrans = gameObject.GetComponent<Transform>();
        Up = false;
        isMoving = false;
        startPos = new Vector3();

        Audio = gameObject.GetComponent<AudioSource>();
        Audio.clip = Clip;
    }

    void Update()
    {
        ElevatorControl();
    }

    public void ElevatorControl()
    {
        timecheck += Time.deltaTime;
        float speed = 3.0f;
        //if (Vector3.Distance(PlayerTrans.position, LeverTrans.position) <= 1.5f)
        {
            if (!isMoving && Vector3.Distance(PlayerTrans.position, LeverTrans.position) <= 1.5f && !once)//활성화에 필요한 트리거 이후 변경
            {
                startPos = ElevatorTrans.position;
                isMoving = true;
                Up = true;
                Audio.Play();
            }
            if (isMoving)
            {
                if (Up)
                {
                    ElevatorTrans.Translate(Vector3.up * Time.deltaTime * speed);
                    float y = startPos.y + height;
                    if(ElevatorTrans.position.y >= y)
                    {
                        Up = false;
                        isMoving = false;
                        once = true;
                        timecheck = 0;
                    }
                }
            }         
        }

        if(!Up && !isMoving && once)
        {              
            if(timecheck >= 5.0f)
            {
                ElevatorTrans.Translate(Vector3.down * Time.deltaTime * speed);
                float y = startPos.y;
                if (ElevatorTrans.position.y <= y)
                {
                    once = false;
                }
            }
        }
    }
}
