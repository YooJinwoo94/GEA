using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleElevatorScript : MonoBehaviour
{
    public GameObject Exit;
    public GameObject Enterance;
    public Transform ElevatorBody;
    [Header("Translate Positions")]
    public Transform StartPos;
    public Transform FirstPos;
    //public Transform SecondPos;
    //public Transform EndPos;

    public float speed = 3.0f;
    int curPos = 0;
    bool BlockingPlayer = false; //플레이어 이동 막기 true = active, false = Not active;
    public Transform player;
    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(player.position, StartPos.position) <= 1.5f)
        {
            StartMove();
        }

        if(BlockingPlayer)
            TranslateElevator();
    }

    public void StartMove()
    {
        BlockingPlayer = true;
        Enterance.SetActive(true);
    }

    public void TranslateElevator()
    {
        if(curPos == 0)
        {
            ElevatorBody.Translate(speed * Time.deltaTime * Vector3.down);
            if(ElevatorBody.position.y <= FirstPos.position.y)
            {
                curPos = 1;
                Exit.SetActive(false);
            }
        }
    }
}
