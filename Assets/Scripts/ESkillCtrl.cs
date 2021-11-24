using System.Collections;
using UnityEngine;

public class ESkillCtrl : MonoBehaviour
{
    CharacterStatus status;

    public AudioClip EskillSeClip;
    AudioSource EskillSeAudio;

    public ParticleSystem ESkillEffect;

    void Start()
    {
        status = transform.root.GetComponent<CharacterStatus>();

        // 오디오 초기화.
        EskillSeAudio = gameObject.AddComponent<AudioSource>();
        EskillSeAudio.clip = EskillSeClip;
        EskillSeAudio.loop = false;

        ESkillEffect = transform.Find("Toon expoision").GetComponent<ParticleSystem>();
    }


    public class EAttackInfo
    {
        public int attackPower; // 이 공격의 공격력.
        public Transform attacker; // 공격자.

        //수정자 이원표
        public int WPower; //W 공격력
        public int EPower; //E 공격력
    }


    // 공격 정보를 가져온다.
    EAttackInfo GetAttackInfo()
    {
        EAttackInfo attackInfo = new EAttackInfo();
        // 공격력 계산.
        attackInfo.attackPower = status.Power;
        attackInfo.attacker = transform.root;

        return attackInfo;
    }

    // 맞았다.
    void OnTriggerEnter(Collider other)
    {
        // 공격 당한 상대의 Damage 메시지를 보낸다.
        other.SendMessage("EDamage", GetAttackInfo());

        // 떄린거 저장 임의수정 정승훈
        status.lastAttackTarget = other.transform.root.gameObject;


        // 오디오 재생.
        EskillSeAudio.Play();


    }


    // 공격 판정을 유효로 한다.
    void OnAttack()
    {
        Debug.Log("ESkill");
        GetComponent<Collider>().enabled = true;
    }


    // 공격 판정을 무효로 한다.
    void OnAttackTermination()
    {
        GetComponent<Collider>().enabled = false;
    }
}
