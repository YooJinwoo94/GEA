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

        // ����� �ʱ�ȭ.
        WskillSeAudio = gameObject.AddComponent<AudioSource>();
        WskillSeAudio.clip = WskillSeClip;
        WskillSeAudio.loop = false;

        WSkillEffect = transform.Find("Slash").GetComponent<ParticleSystem>();
    }


    public class WAttackInfo
    {
        public int attackPower; // �� ������ ���ݷ�.
        public Transform attacker; // ������.

        //������ �̿�ǥ
        public int WPower; //W ���ݷ�
        public int EPower; //E ���ݷ�
    }


    // ���� ������ �����´�.
    WAttackInfo GetAttackInfo()
    {
        WAttackInfo attackInfo = new WAttackInfo();
        // ���ݷ� ���.
        attackInfo.attackPower = status.Power;
        attackInfo.attacker = transform.root;

        return attackInfo;
    }

    // �¾Ҵ�.
    void OnTriggerEnter(Collider other)
    {
        // ���� ���� ����� Damage �޽����� ������.
        other.SendMessage("WDamage", GetAttackInfo());

        // ������ ���� ���Ǽ��� ������
        status.lastAttackTarget = other.transform.root.gameObject;


        // ����� ���.
        WskillSeAudio.Play();


    }


    // ���� ������ ��ȿ�� �Ѵ�.
    void OnAttack()
    {
        GetComponent<Collider>().enabled = true;
    }


    // ���� ������ ��ȿ�� �Ѵ�.
    void OnAttackTermination()
    {
        GetComponent<Collider>().enabled = false;
    }
}
