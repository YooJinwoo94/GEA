using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStoneTrapScript : MonoBehaviour
{
    public GameObject Stone;
    public Transform SpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Stone, SpawnPos.position, SpawnPos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(Stone, SpawnPos.position, SpawnPos.rotation);
        }
    }
}
