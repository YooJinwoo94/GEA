using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttackSound : MonoBehaviour
{
    [SerializeField] GameObject SoundObject;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(SoundObject, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
