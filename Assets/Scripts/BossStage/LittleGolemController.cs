using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LittleGolemController : MonoBehaviour
{
    static public int littleGolemDamage = 10;

    public enum BossPatternType
	{
        Idle,
        Chase,
        MeleeAtk,
        Died
	}

    public int monsterMaxHP;
    public int monsterCurrrentHP;

    public bool isPlayerNear = false;
    public bool isAttacking = false;

    public Transform Player;

    public Rigidbody rigidBody;
    public CapsuleCollider capsuleCollider;
    public SphereCollider sphereCollider;
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    public BossPatternType currentPattern;

    public GameObject meleeAtkHitArea;

    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds Delay1500 = new WaitForSeconds(1.5f);
    WaitForSeconds Delay250 = new WaitForSeconds(0.25f);

    public GameObject EnemyHpUI = null;
    public Slider EnemyHpUIBar = null;
    public Text EnemyHpUIText = null;

    public AudioSource GolemWalkSound;
    public AudioSource GolemPunchSound;
    public AudioSource GolemDeathSound;

    public float diedTime = 20.0f;
    float diedTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //InstantiateMeleeCircleHitArea();
        currentPattern = BossPatternType.Idle;
        StartCoroutine(FSM());
    }

    // Update is called once per frame
    void Update()
    {

    }

	void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player")) isPlayerNear = true;
	}

	void OnTriggerExit(Collider other)
	{
        if (other.CompareTag("Player")) isPlayerNear = false;

    }

    IEnumerator FSM()
	{
        yield return null;

        while (true)
        {
            yield return StartCoroutine(currentPattern.ToString());
        }
    }

    IEnumerator Idle()
	{
        yield return null;
        navMeshAgent.isStopped = true;
        GolemWalkSound.Stop();

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetTrigger("idle");
        }

        if (monsterCurrrentHP <= 0) currentPattern = BossPatternType.Died;
        else if (isAttacking)
        {
            currentPattern = BossPatternType.Idle;
        }
        else if (isPlayerNear)
		{
            currentPattern = BossPatternType.MeleeAtk;
		}
        else
		{
            currentPattern = BossPatternType.Chase;
		}
	}

    IEnumerator Chase()
    {
        yield return null;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            animator.SetTrigger("walk");
        }
        if (!GolemWalkSound.isPlaying) {
            GolemWalkSound.Play();
        }

        navMeshAgent.isStopped = false;

        navMeshAgent.SetDestination(Player.transform.position);

        if (isPlayerNear)
		{
            currentPattern = BossPatternType.Idle;
        }
    }

    IEnumerator MeleeAtk()
    {
        yield return null;
        GolemWalkSound.Stop();
        navMeshAgent.isStopped = true;
        isAttacking = true;
        yield return Delay1500;
        if (!GolemPunchSound.isPlaying) Invoke("SoundInvoke", 0.7f);

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack"))
        {
            animator.SetTrigger("lightAttack");
        }
        currentPattern = BossPatternType.Idle;
    }
    
    void SoundInvoke() {
        GolemPunchSound.Play();
    }

    IEnumerator Died() {
        yield return null;
        GolemWalkSound.Stop();
        capsuleCollider.enabled = false;
        navMeshAgent.isStopped = true;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Died"))
        {
            animator.SetTrigger("died");
            DeathSoundInvoke();
        }
        
        if (diedTimer > diedTime) {
            EndAttack();
            capsuleCollider.enabled = true;
            diedTimer = 0.0f;
            monsterCurrrentHP = monsterMaxHP;
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetTrigger("idle");
            }
            currentPattern = BossPatternType.Idle;
            yield return Delay1500;
        }
        else {
            diedTimer += Time.deltaTime;
        }

    }

    public void DeathSoundInvoke() {
        if (GolemDeathSound.isPlaying) return;
        GolemDeathSound.Play();
    }

    public void EndAttack()
	{
        isAttacking = false;
    }

    public void LightAttackHit() {
        meleeAtkHitArea.SetActive(true);
        meleeAtkHitArea.GetComponent<MonsterLightAttack>().InvokeDisable();
    }
    
    void Damage(AttackArea.AttackInfo attackInfo)
    {
    //    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
    //    effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
    //    Destroy(effect, 0.3f);

        monsterCurrrentHP -= attackInfo.attackPower;
        if (monsterCurrrentHP <= 0)
        {
            monsterCurrrentHP = 0;
            HpUIUpdate();
            EnemyHpUI.SetActive(false);
            return;
        }
        HpUIUpdate();
    }

    //W,E 데미지 처리 메서드 수정 이원표
    public void WDamage(WSkillCtrl.WAttackInfo wattackinfo)
    {
        //   GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
        //   effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        //   Destroy(effect, 0.3f);
        Debug.Log("WSkill Hit");
        monsterCurrrentHP -= wattackinfo.attackPower;
        if (monsterCurrrentHP <= 0)
        {
            monsterCurrrentHP = 0;
            HpUIUpdate();
            EnemyHpUI.SetActive(false);
            return;
        }
        HpUIUpdate();
    }
    public void EDamage(ESkillCtrl.EAttackInfo eattackinfo)
    {
        //   GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
        //   effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        //   Destroy(effect, 0.3f);

        Debug.Log("ESkill Hit");
        monsterCurrrentHP -= eattackinfo.attackPower;
        if (monsterCurrrentHP <= 0)
        {
            monsterCurrrentHP = 0;
            HpUIUpdate();
            EnemyHpUI.SetActive(false);
            return;
        }
        HpUIUpdate();
    }

    void HpUIUpdate() {
        EnemyHpUI.SetActive(true);
        EnemyHpUIText.text = "소형 가디언";
        EnemyHpUIBar.value = ((float)monsterCurrrentHP / (float)monsterMaxHP) * 100.0f;
    }

}
