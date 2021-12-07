using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossQuestTaskLine : MonoBehaviour
{
    [SerializeField] QuestUIManager questUIManager;
    [SerializeField] Text textContainer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //textContainer.text = "사원의 안쪽을 조사해라";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questUIManager.isQuestEnd();
            //textContainer.text = "사원의 장치를 작동시켜라";
            Destroy(this.gameObject);
        }
    }
}
