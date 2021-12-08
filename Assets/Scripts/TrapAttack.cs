using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAttack : MonoBehaviour
{
    public int Damage = 5;
    PlayerCtrl Playerctrl;

    private void Start()
    {
        Playerctrl = FindObjectOfType<PlayerCtrl>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "Player")
        {
            Debug.Log("Trap Hit");
            Playerctrl.SendMessage("TrapDamage", Damage);
        }
    }
}
