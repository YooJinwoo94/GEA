using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Dialog : MonoBehaviour
{
    QuestUIManager QuestUI;
    DialogUIManager DiaUI;
    GameObject player;
    public GameObject rune;
    public GameObject subboss;
    // Start is called before the first frame update
    public bool Runeon = false;
    public bool Subon = false;
    public bool Wskillon = false;

    public int QuestNum = 0;
    void Start()
    {

        QuestUI = FindObjectOfType<QuestUIManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (rune == null && !Runeon && QuestNum==1)
        {
            QuestNum++;
            Runeon = true;
            NextLog();
        }
        if (Runeon && !Wskillon && QuestNum == 2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                QuestNum++;
                Wskillon = true;
                NextLog();
            }
        }
        if(subboss==null && !subboss && QuestNum == 4)
        {
            QuestNum++;
            Subon = true;
            NextLog();
        }
    }


    public void NextLog()
    {
        QuestUI.isQuestEnd();
    }

    // Update is called once per frame

}
