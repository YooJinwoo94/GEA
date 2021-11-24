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

    public bool isPlayerNear;

    public Transform Player;

    public Rigidbody rigidBody;
    public SphereCollider sphereCollider;
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    public BossPatternType currentPattern;

    public GameObject meleeCircleAtkHitAreaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateMeleeCircleHitArea();
        currentPattern = BossPatternType.Idle;
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

    IEnumerator Idle()
	{
        yield return null;
	}

    IEnumerator Chase()
    {
        yield return null;
    }

    IEnumerator MeleeAtk()
    {
        yield return null;
    }

    IEnumerator MeleeCircleAtk()
    {
        yield return null;
    }

    IEnumerator RangeAtk()
    {
        yield return null;
    }

    IEnumerator UltimateAtk()
	{
        yield return null;
    }

    public void InstantiateMeleeCircleHitArea()
	{
        Instantiate(meleeCircleAtkHitAreaPrefab, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation, transform.parent);
	}
}
