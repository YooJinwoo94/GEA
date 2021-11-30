using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAreaTriggerController : MonoBehaviour
{
    [SerializeField] GameObject atkArea;

	private void Start()
	{
        Invoke("DestroyInSelf", 0.2f);

    }

    void DestroyInSelf()
	{
        Destroy(transform.parent.gameObject);
	} 

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterStatus>().HP -= (BossGolemController.bossGolemDamage * 2);
            Destroy(atkArea);
        }
        return;//Player Damage Code
    }
}
