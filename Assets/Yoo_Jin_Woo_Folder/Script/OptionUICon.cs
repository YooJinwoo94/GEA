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
                Time.timeScale = 1;
                optionObj.SetActive(false);
                break;

                // ÄÑ!
                case false:
                Time.timeScale = 0;
                optionObj.SetActive(true);
                    break;
            }
    }
}
