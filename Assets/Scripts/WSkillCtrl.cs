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

    }


    // ���� ������ �����´�.
    WAttackInfo GetAttackInfo()
    {
        WAttackInfo wattackInfo = new WAttackInfo();
        // ���ݷ� ���.
        wattackInfo.attackPower = status.WPower;

        wattackInfo.attacker = transform.root;

        return wattackInfo;
    }

    // �¾Ҵ�.
    void OnTriggerEnter(Collider other)
    {
        if (transform.GetComponent<Collider>().enabled)
        {
            //������ ���������� ������ ���Ǽ���
            if (other.GetComponent<BossGolemController>() != null) { other.GetComponent<BossGolemController>().WDamage(GetAttackInfo()); return; }
            // ���� ���� ����� Damage �޽����� ������.
            //other.SendMessage("WDamage", GetAttackInfo());
            other.GetComponent<HitArea>().transform.root.GetComponent<EnemyCtrl>().WDamage(GetAttackInfo());

            // ������ ���� ���Ǽ��� ������
            status.lastAttackTarget = other.transform.root.gameObject;
            // ����� ���.
            //WskillSeAudio.Play();
        }
        else return;

    }


    // ���� ������ ��ȿ�� �Ѵ�.
    void OnAttack()
    {
        Debug.Log("WSkill");
        GetComponent<Collider>().enabled = true;
    }


    // ���� ������ ��ȿ�� �Ѵ�.
    void OnAttackTermination()
    {
        GetComponent<Collider>().enabled = false;
    }
}
