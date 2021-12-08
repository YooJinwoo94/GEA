using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Dialog : MonoBehaviour
{
    QuestUIManager QuestUI;
    DialogUIManager DiaUI;
    GameObject player;
    public GameObject rune;
    // Start is called before the first frame update
    public bool Questclear1, Questclear2, Questclear3, Questclear4, Questclear5;




    void Start()
    {

        QuestUI = FindObjectOfType<QuestUIManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        
 
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
