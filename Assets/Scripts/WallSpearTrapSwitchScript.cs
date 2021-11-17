using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpearTrapSwitchScript : MonoBehaviour
{
    public FloorSpearTrapScript WallTrap;
    public bool Type;//true = on switch, false = off switch;

    void Start()
    {
    }

    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Type)
            {
                WallTrap.Shooting();
            }

            else if (!Type)
            {
                WallTrap.StopShooting();
            }
        }
        
    }
}
