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
            Destroy(atkArea);
        }
        return;//데미지 함수
    }
}
