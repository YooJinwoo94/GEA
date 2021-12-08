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

    void Start()
    {

        QuestUI = FindObjectOfType<QuestUIManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (rune == null && !Runeon)
        {
            Runeon = true;
            NextLog();
        }
        if (Runeon && !Wskillon)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Wskillon = true;
                NextLog();
            }
        }
        if(subboss==null && !subboss)
        {
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
