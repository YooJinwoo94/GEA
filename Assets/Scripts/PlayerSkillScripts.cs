using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillScripts : MonoBehaviour
{
    CharacterStatus status;
    ParticleSystem QSkillEffect;
    ParticleSystem WSkillEffect;
    ParticleSystem ESkillEffect;

    Collider[] WskillAreaColliders;
    Collider[] EskillAreaColliders;

    bool CooltimeQ,CooltimeW,CooltimeE;

    // Start is called before the first frame update
    void Start()
    {
        ESkillCtrl[] EattackAreas = GetComponentsInChildren<ESkillCtrl>();
        WSkillCtrl[] WattackAreas = GetComponentsInChildren<WSkillCtrl>();
        WskillAreaColliders = new Collider[WattackAreas.Length];
        EskillAreaColliders = new Collider[EattackAreas.Length];

        for(int WattackAreasCnt = 0; WattackAreasCnt< WattackAreas.Length; WattackAreasCnt++)
        {
            // AttackArea
            WskillAreaColliders[WattackAreasCnt] = WattackAreas[WattackAreasCnt].GetComponent<Collider>();
            WskillAreaColliders[WattackAreasCnt].enabled = false;  
        }

        for (int EattackAreasCnt = 0; EattackAreasCnt < EattackAreas.Length; EattackAreasCnt++)
        {
            // AttackArea 
            EskillAreaColliders[EattackAreasCnt] = EattackAreas[EattackAreasCnt].GetComponent<Collider>();
            EskillAreaColliders[EattackAreasCnt].enabled = false;  
        }

        status = transform.root.GetComponent<CharacterStatus>();
        if (gameObject.tag == "Player")
        {
            QSkillEffect = transform.Find("Healing").GetComponent<ParticleSystem>();
            //WSkillEffect = transform.Find("Slash").GetComponent<ParticleSystem>();
            //ESkillEffect = transform.Find("Toon expoision").GetComponent<ParticleSystem>();
            WSkillEffect = transform.Find("WSkill").Find("Slash").GetComponent<ParticleSystem>();
            ESkillEffect = transform.Find("ESkill").Find("Toon expoision").GetComponent<ParticleSystem>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "Player")
        {
            return;
        }
        //QSKILL 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CooltimeQ) return;
            status.HP = Mathf.Min(status.HP + status.MaxHP / 2, status.MaxHP);

            QSkillEffect.Play();
            
        }
        //WSKILL 
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (CooltimeW) return;
            WSkill();


        }
        //ESKILL
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CooltimeE) return;
            ESkill();
        }

    }

    //�߻�ü ���·� ���� ���� ��ƼŬȿ���� Ȯ�ο�
    void WSkill()
    {

        WSkillEffect.Play();

        if(Col)
        foreach (Collider attackAreaCollider in WskillAreaColliders)
            attackAreaCollider.enabled = true;

        StartCoroutine(WWait());
        //RaycastHit[] rayHits = Physics.RaycastAll(transform.position, transform.forward, 14f, LayerMask.GetMask("EnemyHit"));
        //foreach (Collider hitObj in rayHits)
        //{
        //    hitObj.transform.GetComponent<EnemyCtrl>().EDamage();
        //}

    }

    void ESkill()
    {
        ESkillEffect.Play();

        foreach (Collider attackAreaCollider in EskillAreaColliders)
            attackAreaCollider.enabled = true;

        StartCoroutine(EWait());
        //RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 3, Vector3.up, 0f, LayerMask.GetMask("EnemyHit"));
        //foreach (RaycastHit hitObj in rayHits)
        //{
        //    hitObj.transform.GetComponent<EnemyCtrl>().EDamage();
        //}

    }


    IEnumerator WWait()
    {

        foreach (Collider attackAreaCollider in WskillAreaColliders)
            attackAreaCollider.enabled = false;

        yield return new WaitForSeconds(1f);
    }
    IEnumerator EWait()
    {

        foreach (Collider attackAreaCollider in EskillAreaColliders)
            attackAreaCollider.enabled = false;

        yield return new WaitForSeconds(1f);
    }


}

