using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUICon : MonoBehaviour
{
    [SerializeField]
    GameObject optionObj;






    private void Start()
    {
        if (optionObj.activeInHierarchy != true) return;
        optionObj.SetActive(false);
    }




    public void isOptionOn()
    {
        switch(optionObj.activeInHierarchy)
            {
            // ²¨!
                case true:
                optionObj.SetActive(false);
                break;

                // ÄÑ!
                case false:
                optionObj.SetActive(true);
                    break;
            }
    }
}
