using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillScripts : MonoBehaviour
{
    CharacterStatus status;
    ParticleSystem QSkillEffect;
    // Start is called before the first frame update
    void Start()
    {
        status = transform.root.GetComponent<CharacterStatus>();
        if (gameObject.tag == "Player")
        {
            QSkillEffect = transform.Find("QSkillEffect").GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "Player")
        {
            return;
        }
        //QSKILL 회복
        if (Input.GetKeyDown(KeyCode.Q))
        {
            status.HP = Mathf.Min(status.HP + status.MaxHP / 2, status.MaxHP);

            QSkillEffect.Play();
            
        }
        //WSKILL 직선범위
        if(Input.GetKeyDown(KeyCode.W))
        {

        }
        //ESKILL 플레이어중심범위
        if (Input.GetKeyDown(KeyCode.E))
        {

        }

    }
}
