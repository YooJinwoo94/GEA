using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriggerObjScript : MonoBehaviour
{
    public Stage2_3QManagerScript QM;

    void Start()
    {
        QM = FindObjectOfType<Stage2_3QManagerScript>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            QM.UpdateQText();
            Destroy(gameObject);
        }
    }
}
