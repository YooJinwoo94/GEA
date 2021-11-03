using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public float height;
    public Transform PlayerTrans;
    public Transform LeverTrans;
    Transform ElevatorTrans;
    public bool Up, /*Down,*/ isMoving;
    Vector3 startPos;
    bool once = false;
    void Start()
    {
        ElevatorTrans = gameObject.GetComponent<Transform>();
        Up = false;
        //Down = false;
        isMoving = false;
        startPos = new Vector3();
    }

    void Update()
    {
        ElevatorControl();
    }

    public void ElevatorControl()
    {
        float speed = 3.0f;
        //if (Vector3.Distance(PlayerTrans.position, LeverTrans.position) >= 1.0f)
        {
            if (!isMoving && Input.GetKeyDown(KeyCode.E) && !once)//활성화에 필요한 트리거 이후 변경
            {
                startPos = ElevatorTrans.position;
                isMoving = true;
                Up = true;
            }
            if (isMoving)
            {
                if (Up)
                {
                    ElevatorTrans.Translate(Vector3.up * Time.deltaTime * speed);
                    //Down = false;
                    float y = startPos.y + height;
                    if(ElevatorTrans.position.y >= y)
                    {
                        Up = false;
                        isMoving = false;
                        once = true;
                    }
                }

                //if (Down)
                //{
                //    ElevatorTrans.Translate(Vector3.down * Time.deltaTime * speed);
                //    Up = true;
                //}
            }
            
        }
    }
}
