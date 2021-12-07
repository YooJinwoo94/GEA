using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubQuestWarning : MonoBehaviour
{
    TutorialDialog tutorialDialog;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        tutorialDialog = GameObject.Find("DialogManager").GetComponent<TutorialDialog>();

        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && count == 0)
        {
            tutorialDialog.StartDialog("Warning");
            //count++;
        }
    }
}
