using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSkillUIManager : MonoBehaviour
{
    const int playerSkill = 3;

    [SerializeField]
    CharacterStatus playerCharacterStatus;   
    [SerializeField]
    UIAniCon _uiAniConScript;
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
            isSkillOn.Add(false);
            maxCooldown.Add(10);
            currentCooldown.Add(5);

            fill[i].fillAmount = 0;
            _skillCoolTimeText[i].text = "";
        }
    }



    // Test
    private void Update()
    {
        checkPlayerSkillOpen();

        playerSkillCoolTimeOn();
    }



    public void playerSkillUse(int skillNum)
    { 
        //아니 이게 무슨 소리야 내가 스킬이 안나온다고? 흐어어어어엉
        switch(skillNum)
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
        }

        if (playerCharacterStatus.isgetW == false)
        {
            colorImg[1].color = new Color(87 / 255f, 87 / 255f, 87 / 255f, 255);
        }

        if (playerCharacterStatus.isgetE == false)
        {
            colorImg[2].color = new Color(87 / 255f, 87 / 255f, 87 / 255f, 255);
        }
    }
}

