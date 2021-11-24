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

        WSkillCtrl[] WattackAreas = transform.GetComponentsInChildren<WSkillCtrl>();
        WskillAreaColliders = new Collider[WattackAreas.Length];
        for(int WattackAreasCnt = 0; WattackAreasCnt< WattackAreas.Length; WattackAreasCnt++)
        {
            // AttackArea
            WskillAreaColliders[WattackAreasCnt] = WattackAreas[WattackAreasCnt].GetComponent<Collider>();
            WskillAreaColliders[WattackAreasCnt].enabled = false;  
        }

        ESkillCtrl[] EattackAreas = transform.GetComponentsInChildren<ESkillCtrl>();
        EskillAreaColliders = new Collider[EattackAreas.Length];
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

     
        foreach (Collider attackAreaCollider in WskillAreaColliders)
        {
            attackAreaCollider.enabled = true;
        }
        WSkillEffect.Play();

        StartCoroutine(WWait());


        //RaycastHit[] rayHits = Physics.RaycastAll(transform.position, transform.forward, 14f, LayerMask.GetMask("EnemyHit"));
        //foreach (RaycastHit hitObj in rayHits)
        //{
        //    Debug.Log("rayhit");
        //    hitObj.transform.GetComponent<EnemyCtrl>().WDamage();
        //}

    }

    void ESkill()
    {
        

        foreach (Collider attackAreaCollider in EskillAreaColliders)
        {
            attackAreaCollider.enabled = true;
        }
        ESkillEffect.Play();

        StartCoroutine(EWait());

        //RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 3, Vector3.up, 0f, LayerMask.GetMask("EnemyHit"));
        //foreach (RaycastHit hitObj in rayHits)
        //{
        //    Debug.Log("rayhit");
        //    hitObj.transform.GetComponent<EnemyCtrl>().EDamage();
        //}

    }


    IEnumerator WWait()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (Collider attackAreaCollider in WskillAreaColliders)
            attackAreaCollider.enabled = false;

        
    }
    IEnumerator EWait()
    {
        yield return new WaitForSeconds(0.3f);
        foreach (Collider attackAreaCollider in EskillAreaColliders)
            attackAreaCollider.enabled = false;

        
    }


}

