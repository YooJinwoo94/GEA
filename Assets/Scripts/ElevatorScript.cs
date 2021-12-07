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
    void Start()
    {
        ElevatorTrans = gameObject.GetComponent<Transform>();
        Up = false;
        isMoving = false;
        startPos = new Vector3();
    }

    void Update()
    {
        ElevatorControl();
    }

    public void ElevatorControl()
    {
        timecheck += Time.deltaTime;
        float speed = 3.0f;
        if (Vector3.Distance(PlayerTrans.position, LeverTrans.position) <= 1.5f)
        {
            if (!isMoving && /*Input.GetKeyDown(KeyCode.F)*/ !once)//Ȱ��ȭ�� �ʿ��� Ʈ���� ���� ����
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
