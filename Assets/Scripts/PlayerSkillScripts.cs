using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillScripts : MonoBehaviour
{
    CharacterStatus status;
    ParticleSystem QSkillEffect;
    ParticleSystem WSkillEffect;
    ParticleSystem ESkillEffect;


    public AudioClip QSkillSeClip;
    AudioSource QSkillSeAudio;
    public AudioClip WSkillSeClip;
    AudioSource WSkillSeAudio;
    public AudioClip ESkillSeClip;
    AudioSource ESkillSeAudio;


    Collider[] WskillAreaColliders;
    Collider[] EskillAreaColliders;

    public float CooltimeQ=5f,CooltimeW=5f,CooltimeE=5f;
    public bool isCooltimeQ = false, isCooltimeW=false, isCooltimeE=false;
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
         
        QSkillSeAudio = gameObject.AddComponent<AudioSource>();        
        QSkillSeAudio.clip = QSkillSeClip;
        QSkillSeAudio.loop = false;

        WSkillSeAudio = gameObject.AddComponent<AudioSource>();
        WSkillSeAudio.clip = WSkillSeClip;
        WSkillSeAudio.loop = false;

        ESkillSeAudio = gameObject.AddComponent<AudioSource>();
        ESkillSeAudio.clip = ESkillSeClip;
        ESkillSeAudio.loop = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "Player")
        {
            return;
        }
        //QSKILL 
        if (Input.GetKeyDown(KeyCode.Q) && status.isgetQ)
        {
            if (!isCooltimeQ)
            {
                status.HP = Mathf.Min(status.HP + status.QPower, status.MaxHP);

                QSkillEffect.Play();
                QSkillSeAudio.Play();
                isCooltimeQ = true;
                StartCoroutine(Qdelay());
            }

        }
        //WSKILL 
        if(Input.GetKeyDown(KeyCode.W) && status.isgetW)
        {
            if (!isCooltimeW)
            {
                WSkill();
                isCooltimeW = true;
                StartCoroutine(Wdelay());
            }
        }
        //ESKILL
        if (Input.GetKeyDown(KeyCode.E) && status.isgetE)
        {
            if (!isCooltimeE)
            {
                ESkill();
                isCooltimeE = true;
                StartCoroutine(Edelay());
            }
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
        WSkillSeAudio.Play();
        StartCoroutine(WReset());


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
        
       ESkillSeAudio.Play();
        StartCoroutine(EReset());

        //RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 3, Vector3.up, 0f, LayerMask.GetMask("EnemyHit"));
        //foreach (RaycastHit hitObj in rayHits)
        //{
        //    Debug.Log("rayhit");
        //    hitObj.transform.GetComponent<EnemyCtrl>().EDamage();
        //}

    }
    IEnumerator Qdelay()
    {
        yield return new WaitForSeconds(CooltimeQ);
        isCooltimeQ = false;
    }
    IEnumerator Wdelay()
    {
        yield return new WaitForSeconds(CooltimeW);
        isCooltimeW = false;
    }
    IEnumerator Edelay()
    {
        yield return new WaitForSeconds(CooltimeE);
        isCooltimeE = false;
    }

    IEnumerator WReset()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (Collider attackAreaCollider in WskillAreaColliders)
            attackAreaCollider.enabled = false;

        
    }
    IEnumerator EReset()
    {
        yield return new WaitForSeconds(0.3f);
        foreach (Collider attackAreaCollider in EskillAreaColliders)
            attackAreaCollider.enabled = false;

        
    }


}

