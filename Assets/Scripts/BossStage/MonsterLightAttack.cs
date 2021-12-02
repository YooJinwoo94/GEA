using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLightAttack : MonoBehaviour
{
    [SerializeField] GameObject atkArea;
    [SerializeField] GameObject hitEffect;

	private void Start()
	{
        
    }

    public void InvokeDisable()
	{
        Invoke("DestroyItSelf", 0.2f);
	} 

    public void DestroyItSelf()
	{
        atkArea.SetActive(false);
	} 

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterStatus>().HP -= LittleGolemController.littleGolemDamage;
            GameObject effect = Instantiate(hitEffect, other.transform.position, Quaternion.identity) as GameObject;
            effect.transform.localPosition = other.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
            Destroy(effect, 0.3f);
            atkArea.SetActive(false);
        }
        return;//Player Damage Code
    }
}
