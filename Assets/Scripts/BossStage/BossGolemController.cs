using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class BossGolemController : MonoBehaviour
{
    public enum BossPatternType
	{
        Idle,
        Chase,
        MeleeAtk,
        MeleeCircleAtk,
        RangeAtk,
        UltimateAtk
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

    public BossPatternType currentPattern;

    public GameObject meleeCircleAtkHitAreaPrefab;

    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds Delay1500 = new WaitForSeconds(1.5f);
    WaitForSeconds Delay250 = new WaitForSeconds(0.25f);

    float StumpAttackCoolTime = 8.0f;
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



        if (isAttacking)
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

        navMeshAgent.SetDestination(Player.transform.position);

        if (isPlayerNear)
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

    IEnumerator UltimateAtk()
	{
        yield return null;
    }

    public void InstantiateMeleeCircleHitArea(Transform TargetTransform)
	{
        Instantiate(meleeCircleAtkHitAreaPrefab, new Vector3(TargetTransform.position.x, 0, TargetTransform.position.z), TargetTransform.rotation, transform.parent);
	}

    public void EndAttack()
	{
        isAttacking = false;
    }

}
