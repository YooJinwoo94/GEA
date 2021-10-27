using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class TitleSceneManager : MonoBehaviour
{

    [Header("3 : EndGame ")]
    [Header("2 : Thanks ")]
    [Header("1 : Setting ")]
    [Header("0 : None ")]


    [SerializeField]
    GameObject[] sceneObj;





    public void btnClick(string name)
    {
        switch (name)
        {
            case "StartGame":
                SceneManager.LoadScene("TutorialScene");
                break;

            case "Setting":
                if (sceneObj[1].activeInHierarchy == true) sceneObj[1].SetActive(false);
                else sceneObj[1].SetActive(true);
                break;

            case "Thanks":
                break;

            case "EndGame":
                break;
        }
    }
}
