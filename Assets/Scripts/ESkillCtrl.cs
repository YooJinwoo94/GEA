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
    }


    // ���� ������ �����´�.
    EAttackInfo GetAttackInfo()
    {
        EAttackInfo attackInfo = new EAttackInfo();
        // ���ݷ� ���.
        attackInfo.attackPower = status.EPower;
        attackInfo.attacker = transform.root;

        return attackInfo;
    }

    // �¾Ҵ�.
    void OnTriggerEnter(Collider other)
    {


        if (transform.GetComponent<Collider>().enabled)
        {
            //�����񷽿� ����ó��
            if (other.GetComponent<BossGolemController>() != null) { other.GetComponent<BossGolemController>().EDamage(GetAttackInfo()); return; }
            if (other.GetComponent<LittleGolemController>() != null) { other.GetComponent<LittleGolemController>().EDamage(GetAttackInfo()); return; }
            // ���� ���� ����� Damage �޽����� ������.
            //other.SendMessage("EDamage", GetAttackInfo());
            other.GetComponent<HitArea>().transform.root.GetComponent<EnemyCtrl>().EDamage(GetAttackInfo());

            // ������ ���� ���Ǽ��� ������
            status.lastAttackTarget = other.transform.root.gameObject;
            // ����� ���.
            //EskillSeAudio.Play();
        }
        else return;

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
