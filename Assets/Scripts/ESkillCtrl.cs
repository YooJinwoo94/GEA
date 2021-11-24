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

        // ����� �ʱ�ȭ.
        EskillSeAudio = gameObject.AddComponent<AudioSource>();
        EskillSeAudio.clip = EskillSeClip;
        EskillSeAudio.loop = false;

        ESkillEffect = transform.Find("Toon expoision").GetComponent<ParticleSystem>();
    }


    public class EAttackInfo
    {
        public int attackPower; // �� ������ ���ݷ�.
        public Transform attacker; // ������.

        //������ �̿�ǥ
        public int WPower; //W ���ݷ�
        public int EPower; //E ���ݷ�
    }


    // ���� ������ �����´�.
    EAttackInfo GetAttackInfo()
    {
        EAttackInfo attackInfo = new EAttackInfo();
        // ���ݷ� ���.
        attackInfo.attackPower = status.Power;
        attackInfo.attacker = transform.root;

        return attackInfo;
    }

    // �¾Ҵ�.
    void OnTriggerEnter(Collider other)
    {
        // ���� ���� ����� Damage �޽����� ������.
        other.SendMessage("EDamage", GetAttackInfo());

        // ������ ���� ���Ǽ��� ������
        status.lastAttackTarget = other.transform.root.gameObject;


        // ����� ���.
        EskillSeAudio.Play();


    }


    // ���� ������ ��ȿ�� �Ѵ�.
    void OnAttack()
    {
        Debug.Log("ESkill");
        GetComponent<Collider>().enabled = true;
    }


    // ���� ������ ��ȿ�� �Ѵ�.
    void OnAttackTermination()
    {
        GetComponent<Collider>().enabled = false;
    }
}
