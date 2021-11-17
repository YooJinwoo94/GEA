using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSkillUIManager : MonoBehaviour
{
    const int playerSkill = 3;

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
            maxCooldown.Add(5);
            currentCooldown.Add(5);

            fill[i].fillAmount = 0;
            _skillCoolTimeText[i].text = "";
        }
    }



    // Test
    private void Update()
    {
        // ��Ÿ�� ����
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isSkillOn[0] == true) return;
            if (Time.timeScale == 0) return;

            isSkillOn[0] = true;
            currentCooldown[0] = maxCooldown[0];
            fill[0].fillAmount = 1;
            colorImg[0].color = new Color(87 / 255f, 87 / 255f, 87 / 255f, 255);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (isSkillOn[1] == true) return;
            if (Time.timeScale == 0) return;

            isSkillOn[1] = true;
            currentCooldown[1] = maxCooldown[1];
            fill[1].fillAmount = 1;
            colorImg[1].color = new Color(87 / 255f, 87 / 255f, 87 / 255f, 255);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (isSkillOn[2] == true) return;
            if (Time.timeScale == 0) return;

            isSkillOn[2] = true;
            currentCooldown[2] = maxCooldown[2];
            fill[2].fillAmount = 1;
            colorImg[2].color = new Color(87 / 255f, 87 / 255f, 87 / 255f, 255);
        }




        for (int i = 0; i < playerSkill; i++)
        {
            if (isSkillOn[i] == false) continue;

            // ��Ÿ�� ��
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



    public void playerSkillUse(int skillNum)
    {
        if (isSkillOn[skillNum] == true) return;
        if (Time.timeScale == 0) return;

        isSkillOn[skillNum] = true;
        currentCooldown[skillNum] = maxCooldown[skillNum];

        fill[skillNum].fillAmount = 1;
    }
}
