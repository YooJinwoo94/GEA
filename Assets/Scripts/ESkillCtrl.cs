using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Eskill 폭발범위체크
public class ESkillCrl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject E_Effect;
    CharacterStatus status;
    public float radius = 3.0f;
    
  

    private new MeshRenderer renderer;


    private Transform tr;
    private Rigidbody rb;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        status = GetComponent<CharacterStatus>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject ESkill = Instantiate(E_Effect, tr.position, Quaternion.identity);

        Destroy(E_Effect, 3.0f);

        ESkillHit(tr.position);
    }

    void ESkillHit(Vector3 pos)
    {
       

    }
}
