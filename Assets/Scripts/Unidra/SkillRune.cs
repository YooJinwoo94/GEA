using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRune : MonoBehaviour
{
    public enum SkillKind
    {
        QSkill,
        WSkill,
        ESkill,
    };
    public SkillKind skill;

    public AudioClip itemSeClip;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CharacterStatus aStatus = other.GetComponent<CharacterStatus>();
            
            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(itemSeClip, transform.position);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 60 * Time.deltaTime);
    }
}
