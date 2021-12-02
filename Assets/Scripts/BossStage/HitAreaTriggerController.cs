using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAreaTriggerController : MonoBehaviour
{
    [SerializeField] GameObject atkArea;
    [SerializeField] GameObject hitEffect;

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
            GameObject effect = Instantiate(hitEffect, other.transform.position, Quaternion.identity) as GameObject;
            effect.transform.localPosition = other.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
            Destroy(effect, 0.3f);
            Destroy(atkArea);
        }
        return;//Player Damage Code
    }
}
