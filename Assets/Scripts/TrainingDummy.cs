using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrainingDummy : MonoBehaviour
{
    CharacterStatus status;
    Animator animator;
    TutorialDialog dialog;

    int count;
    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<CharacterStatus>();
        animator = GetComponent<Animator>();
        dialog = GameObject.Find("DialogManager").GetComponent<TutorialDialog>();

        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0 && Input.GetKeyDown(KeyCode.Q))
        {
            Invoke("startQ", 3f);
            
        }
    }

    // 피격시 실행
    void Damage(AttackArea.AttackInfo attackInfo)
    {
        Debug.Log("damaged 실행");
        status.HP -= 10;
        animator.SetBool("Hit", true);
        // 1차 죽음
        if (status.HP <= 0 && count == 0)
        {
            count++;
            Invoke("startFirstDie", 1.0f);
        }
        else if (status.HP <= 0 && count == 1)
        {
            animator.SetTrigger("Died");
            count++;
        }
    }

    void EndHit()
    {
        animator.SetBool("Hit", false);
    }

    void startQ()
    {
        dialog.StartDialog("TrainingSkill2");
    }

    void startFirstDie()
    {
        dialog.StartDialog("TrainingSkill");
        status.HP = status.MaxHP;
    }
}
