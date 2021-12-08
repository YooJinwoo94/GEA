using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1QuestTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    Stage1Dialog Quest;
    bool triggerOn=false;
    void Start()
    {
        Quest= FindObjectOfType<Stage1Dialog>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerOn)
        {
            Quest.NextLog();
            triggerOn = true;
        }
    }
}
