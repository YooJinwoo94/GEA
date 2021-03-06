using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSkillUIManager : MonoBehaviour
{
    const int playerSkill = 3;

    [SerializeField]
    GameObject[] skillBlockIcon;
    [SerializeField]
    CharacterStatus playerCharacterStatus;   
    [SerializeField]
    Image[] colorImg;
    [SerializeField]
    Image[] fill;
    [SerializeField]
    Text[] _skillCoolTimeText;

    List<bool> isSkillOn = new List<bool>();
    List<float> maxCooldown = new List<float>();
    List<float> currentCooldown = new List<float>();




    private void Start()
    {
        for (int i = 0; i < playerSkill; i++)
        {
            if(skillBlockIcon[i].activeInHierarchy == true) skillBlockIcon[i].SetActive(false);

            isSkillOn.Add(false);
            maxCooldown.Add(10);
            currentCooldown.Add(5);

            fill[i].fillAmount = 0;
            _skillCoolTimeText[i].text = "";
        }

        if (GameObject.Find("Player") == true)
        {
            playerCharacterStatus = GameObject.Find("Player").GetComponent<CharacterStatus>();
        }
    }



    // Test
    private void Update()
    {
         if (GameObject.Find("Player") == false) return;

        playerSkillUse();
        checkPlayerSkillOpen();
        playerSkillCoolTimeOn();
    }



    //현재 참조만 되어있음 == 사용안하고 있음
    public void playerSkillUse(int skillNum)
    { 
        //아니 이게 무슨 소리야 내가 스킬이 안나온다고? 흐어어어어엉
      //  switch(skillNum)
      //  {
      //      case 0:
       //         if (playerCharacterStatus.isgetQ == false) return;
       //         break;

       //     case 1:
       //         if (playerCharacterStatus.isgetW == false) return;
         //       break;

       //     case 2:
       //         if (playerCharacterStatus.isgetE == false) return;
       //         break;
     //   }

        if (isSkillOn[skillNum] == true) return;
        if (Time.timeScale == 0) return;

        isSkillOn[skillNum] = true;
        currentCooldown[skillNum] = maxCooldown[skillNum];

        fill[skillNum].fillAmount = 1;
    }



    void playerSkillUse()
    {
        int skillNum = -1;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            skillNum = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            skillNum = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            skillNum = 2;
        }
        if (skillNum == -1) return;
        //아니 이게 무슨 소리야 내가 스킬이 안나온다고? 흐어어어어엉
        switch (skillNum)
        {
            case 0:
                if (playerCharacterStatus.isgetQ == false) return;
                break;

            case 1:
                if (playerCharacterStatus.isgetW == false) return;
                break;

            case 2:
                if (playerCharacterStatus.isgetE == false) return;
                break;
        }
        if (isSkillOn[skillNum] == true) return;
        if (Time.timeScale == 0) return;

        isSkillOn[skillNum] = true;
        currentCooldown[skillNum] = maxCooldown[skillNum];

        fill[skillNum].fillAmount = 1;
    }

    void playerSkillCoolTimeOn()
    {
        for (int i = 0; i < playerSkill; i++)
        {
            if (isSkillOn[i] == false) continue;

            // 쿨타임 끝
            if (fill[i].fillAmount <= 0)
            {
                isSkillOn[i] = false;
                currentCooldown[i] = maxCooldown[i];
                fill[i].fillAmount = 0;
                _skillCoolTimeText[i].text = "";
                colorImg[i].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255);
                continue;
            }

            currentCooldown[i] = currentCooldown[i] - Time.deltaTime;
            fill[i].fillAmount = currentCooldown[i] / maxCooldown[i];

            if (currentCooldown[i] <= 1.0)
            {
                _skillCoolTimeText[i].text = System.Math.Round(currentCooldown[i], 1).ToString();
            }
            else
            {
                _skillCoolTimeText[i].text = System.Math.Round(currentCooldown[i]).ToString();
            }
        }
    }
    void checkPlayerSkillOpen()
    {
        if(playerCharacterStatus.isgetQ == false)
        {
            colorImg[0].color = new Color(87 / 255f, 87 / 255f, 87 / 255f, 255);
            skillBlockIcon[0].SetActive(true);
        }
        else
        {
            colorImg[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255);
            skillBlockIcon[0].SetActive(false);
        }

        if (playerCharacterStatus.isgetW == false)
        {
            colorImg[1].color = new Color(87 / 255f, 87 / 255f, 87 / 255f, 255);
            skillBlockIcon[1].SetActive(true);
        }
        else
        {
            colorImg[1].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255);
            skillBlockIcon[1].SetActive(false);
        }

        if (playerCharacterStatus.isgetE == false)
        {
            colorImg[2].color = new Color(87 / 255f, 87 / 255f, 87 / 255f, 255);
            skillBlockIcon[2].SetActive(true);
        }
        else
        {
            colorImg[2].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255);
            skillBlockIcon[2].SetActive(false);
        }
    }
}

