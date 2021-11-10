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
        //QSKILL 회복
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CooltimeQ) return;
            status.HP = Mathf.Min(status.HP + status.MaxHP / 2, status.MaxHP);

            QSkillEffect.Play();
            
        }
        //WSKILL 직선범위
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (CooltimeW) return;

        }
        //ESKILL 플레이어중심범위
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CooltimeE) return;
        }

    }

    //발사체 형태로 구현 예정 파티클효과만 확인용
    void WSkill()
    {
        

         
    }

    void ESkill()
    {

    }
}

