using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    QuestUIManager QuestUI;
    DialogUIManager DiaUI;


    GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        QuestUi = FindObjectOfType<QuestUIManager>();
        DiaUI = FindObjectOfType<> 
        player = GameObject.FindGameObjectWithTag("Player");

        questUIManager = FindObjectOfType<QuestUIManager>();

    }

    public void NextLog()
    {
        QuestUI.isQuestEnd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
