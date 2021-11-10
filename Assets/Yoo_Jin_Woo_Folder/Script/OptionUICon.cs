using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUICon : MonoBehaviour
{
    [SerializeField]
    GameObject optionObj;
    [SerializeField]
    Dropdown pixelDropDown;


    AudioSource audioSource;
    [SerializeField]
    Slider audioSlider;


    private void Start()
    {
        audioSource = GameObject.Find("Sound_AudioSource").GetComponent<AudioSource>();

        int i_width = Screen.width;
        int i_height = Screen.height;

        if (!(i_width == 1920 && i_height == 1080))
        {
            Screen.SetResolution(1920, 1080, true);
        }


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




    public void pixelSizeCon(Dropdown select)
    {
        switch (select.value)
        {
            case 0:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(2560, 1440, Screen.fullScreen);
                break;
        }
    }


    public void screenSizeCon(Dropdown select)
    {
        switch (select.value)
        {
            case 0:
                Screen.fullScreen = true;
                break;
            case 1:
                Screen.fullScreen = false;
                break;
        }
       
    }

    public void endGameCon()
    {
        Application.Quit();
    }






    public void audioVolumeCon()
    {
        audioSource.volume = audioSlider.value;
    }
}
