using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSkillCtrl : MonoBehaviour
{
    CharacterStatus status;

    public AudioClip WskillSeClip;
    AudioSource WskillSeAudio;

    public ParticleSystem WSkillEffect;

    void Start()
    {
        status = transform.root.GetComponent<CharacterStatus>();

        // 오디오 초기화.
        WskillSeAudio = gameObject.AddComponent<AudioSource>();
        WskillSeAudio.clip = WskillSeClip;
        WskillSeAudio.loop = false;

        WSkillEffect = transform.Find("Slash").GetComponent<ParticleSystem>();
    }


    public class WAttackInfo
    {
        public int attackPower; // 이 공격의 공격력.
        public Transform attacker; // 공격자.

    }


    // 공격 정보를 가져온다.
    WAttackInfo GetAttackInfo()
    {
        WAttackInfo wattackInfo = new WAttackInfo();
        // 공격력 계산.
        wattackInfo.attackPower = status.WPower;

        wattackInfo.attacker = transform.root;

        return wattackInfo;
    }

    // 맞았다.
    void OnTriggerEnter(Collider other)
    {
        if (transform.GetComponent<Collider>().enabled)
        {
            //보스씬 오류때문에 양지훈 임의수정
            if (other.GetComponent<BossGolemController>() != null) { other.GetComponent<BossGolemController>().WDamage(GetAttackInfo()); return; }
            // 공격 당한 상대의 Damage 메시지를 보낸다.
            //other.SendMessage("WDamage", GetAttackInfo());
            other.GetComponent<HitArea>().transform.root.GetComponent<EnemyCtrl>().WDamage(GetAttackInfo());

            // 떄린거 저장 임의수정 정승훈
            status.lastAttackTarget = other.transform.root.gameObject;
            // 오디오 재생.
            //WskillSeAudio.Play();
        }
        else return;

    }


    // 공격 판정을 유효로 한다.
    void OnAttack()
    {
        Debug.Log("WSkill");
        GetComponent<Collider>().enabled = true;
    }


    // 공격 판정을 무효로 한다.
    void OnAttackTermination()
    {
        GetComponent<Collider>().enabled = false;
    }
}
