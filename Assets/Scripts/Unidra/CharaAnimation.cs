using UnityEngine;

public class CharaAnimation : MonoBehaviour
{
	Animator animator;
	CharacterStatus status;
	Vector3 prePosition;
	bool isDown = false;
	bool attacked = false;
    public CharacterMove CM;
	PlayerSkillScripts SC;
	
	public bool IsAttacked()
	{
		return attacked;
	}
	
	void StartAttackHit()
	{
		Debug.Log ("StartAttackHit");
	}
	
	void EndAttackHit()
	{
		Debug.Log ("EndAttackHit");
	}
	
	void EndAttack()
	{
		attacked = true;
	}
	
	void Start ()
	{
		animator = GetComponent<Animator>();
		status = GetComponent<CharacterStatus>();
		CM = GetComponent<CharacterMove>();
		SC = GetComponent<PlayerSkillScripts>();

		prePosition = transform.position;
	}
	void Update ()
	{
        Vector3 des = CM.GetDestination();

        float dis = Vector3.Distance(new Vector3(prePosition.x, des.y , prePosition.z), des);       

        if(!CM.Arrived())
            animator.SetFloat("Speed", dis);
        else if (CM.Arrived() || dis <= 0.6f)
            animator.SetFloat("Speed", 0);

        //Vector3 delta_position = transform.position - prePosition;
        //animator.SetFloat("Speed", delta_position.magnitude / Time.deltaTime);

        if (attacked && !status.attacking)
		{
			attacked = false;
		}
		animator.SetBool("Attacking", (!attacked && status.attacking));
		
		if(!isDown && status.died)
		{
			isDown = true;
			animator.SetTrigger("Down");
		}
		if (gameObject.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.W) && status.isgetW )
			{
				CM.StopMove();
				animator.SetTrigger("SkillW");
			}
			if (Input.GetKeyDown(KeyCode.E) && status.isgetE )
			{
				CM.StopMove();
				animator.SetTrigger("SkillE");
			}
		}
		prePosition = transform.position;
	}


}