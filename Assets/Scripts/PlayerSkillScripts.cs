using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillScripts : MonoBehaviour
{
    CharacterStatus status;
    ParticleSystem QSkillEffect;
    ParticleSystem WSkillEffect;
    ParticleSystem ESkillEffect;
    bool CooltimeQ,CooltimeW,CooltimeE;
    // Start is called before the first frame update
    void Start()
    {
        status = transform.root.GetComponent<CharacterStatus>();
        if (gameObject.tag == "Player")
        {
            QSkillEffect = transform.Find("Healing").GetComponent<ParticleSystem>();
            WSkillEffect = transform.Find("Slash").GetComponent<ParticleSystem>();
            ESkillEffect = transform.Find("Slash").GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "Player")
        {
            return;
        }
        //QSKILL ȸ��
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CooltimeQ) return;
            status.HP = Mathf.Min(status.HP + status.MaxHP / 2, status.MaxHP);

            QSkillEffect.Play();
            
        }
        //WSKILL ��������
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (CooltimeW) return;

        }
        //ESKILL �÷��̾��߽ɹ���
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CooltimeE) return;
        }

    }

    //�߻�ü ���·� ���� ���� ��ƼŬȿ���� Ȯ�ο�
    void WSkill()
    {
        

         
    }

    void ESkill()
    {

    }
}

