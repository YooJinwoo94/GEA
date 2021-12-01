using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLightAttack : MonoBehaviour
{
    [SerializeField] GameObject atkArea;

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
            atkArea.SetActive(false);
        }
        return;//Player Damage Code
    }
}
