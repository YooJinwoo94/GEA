using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTrigger : MonoBehaviour
{
    TutorialDialog tutorialDialog;

    // Start is called before the first frame update
    void Start()
    {
        tutorialDialog = GameObject.Find("DialogManager").GetComponent<TutorialDialog>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            tutorialDialog.Start("TrainingStory");
    }
}
