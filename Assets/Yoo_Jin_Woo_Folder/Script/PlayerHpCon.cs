using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHpCon : MonoBehaviour
{
    [SerializeField]
    Slider hp;

     public void hpCon(int hpGage, string upDown)
    {
        switch (upDown)
        {
            case "up":
                hp.value += hpGage;
                break;

            case "down":
                hp.value -= hpGage;
                break;
        }
    }
}
