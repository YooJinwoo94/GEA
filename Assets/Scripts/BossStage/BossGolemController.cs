using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;

public class BossGolemController : MonoBehaviour
{
    static public int bossGolemDamage = 10;

    public enum BossPatternType
	{
        Idle,
        Chase,
        MeleeAtk,
        MeleeCircleAtk,
        RangeAtk,
        UltimateAtk,
        Died
	}

    public int bossMaxHP;
    public int bossCurrrentHP;

    public bool isPlayerNear = false;
    public bool isAttacking = false;
    public bool isPuzzleClear = false;

    public Transform Player;

    public Rigidbody rigidBody;
    public SphereCollider sphereCollider;
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public Text textContainer;

    public BossPatternType currentPattern;

    public GameObject portal;
    public GameObject meleeAtkHitArea;
    public GameObject meleeCircleAtkHitAreaPrefab;

    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds Delay1500 = new WaitForSeconds(1.5f);
    WaitForSeconds Delay250 = new WaitForSeconds(0.25f);

    float StumpAttackCoolTime = 15.0f;
    float currentStumpAttackCoolTime = 0.0f;
    float ChaseLimitTime = 8.0f;
    float currentChaseLimitTime = 0.0f;

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
        if (bossCurrrentHP <= 0) {
            textContainer.text = "보물을 획득해라";
            portal.SetActive(true);
        }
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
        while (!isPuzzleClear)
		{
            yield return Delay500;
        }


        while (true)
        {
            yield return StartCoroutine(currentPattern.ToString());
        }
    }

    IEnumerator Idle()
	{
        yield return null;
        navMeshAgent.isStopped = true;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetTrigger("idle");
        }

        currentStumpAttackCoolTime += Time.deltaTime;


        if (bossCurrrentHP <= 0) {
             currentPattern = BossPatternType.Died;
        }
        else if (isAttacking)
        {
            currentPattern = BossPatternType.Idle;
        }
        else if (isPlayerNear)
		{
            if (currentStumpAttackCoolTime > StumpAttackCoolTime)
			{
                currentStumpAttackCoolTime = 0.0f;
                currentPattern = BossPatternType.MeleeCircleAtk;
			}
            else
			{
                currentPattern = BossPatternType.MeleeAtk;
            }
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

        navMeshAgent.isStopped = false;

        currentChaseLimitTime += Time.deltaTime;
        currentStumpAttackCoolTime += Time.deltaTime;

        navMeshAgent.SetDestination(Player.transform.position);
        if (bossCurrrentHP <= 0) {
             currentPattern = BossPatternType.Died;
        }
        else if (isPlayerNear)
		{
            currentPattern = BossPatternType.Idle;
        }

        if (currentChaseLimitTime > ChaseLimitTime)
		{
            currentChaseLimitTime = 0.0f;
            currentPattern = BossPatternType.RangeAtk;
		}
    }

    IEnumerator MeleeAtk()
    {
        yield return null;
        navMeshAgent.isStopped = true;
        isAttacking = true;
        yield return Delay1500;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack"))
        {
            animator.SetTrigger("lightAttack");
        }
        currentPattern = BossPatternType.Idle;
    }

    IEnumerator MeleeCircleAtk()
    {
        yield return null;
        navMeshAgent.isStopped = true;
        isAttacking = true;
        yield return Delay1500;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("StumpAttack"))
        {
            animator.SetTrigger("stumpAttack");
        }
        InstantiateMeleeCircleHitArea(this.transform);
        
        currentPattern = BossPatternType.Idle;

    }

    IEnumerator RangeAtk()
    {
        yield return null;
        navMeshAgent.isStopped = true;
        isAttacking = true;
        yield return Delay1500;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ThrowAttack"))
        {
            animator.SetTrigger("throwAttack");
        }
        InstantiateMeleeCircleHitArea(Player.transform);

        currentPattern = BossPatternType.Idle;
    }

    IEnumerator Died()
	{
        yield return null;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Died"))
        {
            animator.SetTrigger("died");
        }
        navMeshAgent.isStopped = true;
        isAttacking = false;

        Destroy(this.gameObject, 1.0f);
    }

    public void InstantiateMeleeCircleHitArea(Transform TargetTransform)
	{
        Instantiate(meleeCircleAtkHitAreaPrefab, new Vector3(TargetTransform.position.x, 0, TargetTransform.position.z), TargetTransform.rotation, transform.parent);
	}

    public void EndAttack()
	{
        isAttacking = false;
    }

    public void LightAttackHit() {
        meleeAtkHitArea.SetActive(true);
        meleeAtkHitArea.GetComponent<BossLightAttack>().InvokeDisable();
    }
    
    void Damage(AttackArea.AttackInfo attackInfo)
    {
    //    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
    //    effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
    //    Destroy(effect, 0.3f);
        if (isPuzzleClear) bossCurrrentHP -= attackInfo.attackPower;
        if (bossCurrrentHP <= 0)
        {
            bossCurrrentHP = 0;
        }
    }

    //W,E 데미지 처리 메서드 수정 이원표
    public void WDamage(WSkillCtrl.WAttackInfo wattackinfo)
    {
        //   GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
        //   effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        //   Destroy(effect, 0.3f);
        Debug.Log("WSkill Hit");
        if (isPuzzleClear) bossCurrrentHP -= wattackinfo.attackPower;
        if (bossCurrrentHP <= 0)
        {
            bossCurrrentHP = 0;
        }
    }
    public void EDamage(ESkillCtrl.EAttackInfo eattackinfo)
    {
        //   GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
        //   effect.transform.localPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        //   Destroy(effect, 0.3f);

        Debug.Log("ESkill Hit");
        if (isPuzzleClear) bossCurrrentHP -= eattackinfo.attackPower;
        if (bossCurrrentHP <= 0)
        {
            bossCurrrentHP = 0;
        }
    }

}
