using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_3QManagerScript : MonoBehaviour
{
    public QuestUIManager QUI;
    public int QuestOrder = 0;
    public GameObject EliteMob;
    public GameObject Potal;
    public DoorOpenScript Door;

    void Start()
    {
        QUI = FindObjectOfType<QuestUIManager>();
        Potal.SetActive(false);
    }

    void Update()
    {
        if(EliteMob == null && QuestOrder > 2)
        {
            Potal.SetActive(true);
            Door.DoorOpen();
            UpdateQText();
        }
    }

    public void UpdateQText()
    {
        QuestOrder++;
        QUI.isQuestEnd();
    }
}
