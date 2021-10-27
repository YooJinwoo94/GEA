using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSkillCon : MonoBehaviour
{
    [SerializeField]
    Image[] skillImg;

    List<float> _timeCurrent = new List<float>();
    List<float> _timer = new List<float>();
    List<int> _waitTime = new List<int>();
    [SerializeField]
    bool []skillOn = new bool [3] ;




    private void Start()
    {       
        for (int i = 0; i<3; i++)
        {
            _timer.Add(0);
            _waitTime.Add(3);

            skillImg[i].fillAmount = 0;
        }
    }



    private void Update()
    {
      for (int i = 0; i <3;i++)
        {
            if (skillOn[i] == false) continue;
            _timer[i] += Time.deltaTime;
            skillImg[i].fillAmount = _timer[i];

            if (_timer[i] > _waitTime[0])
            {
                //Action
                _timer[i] = 0;
                skillOn[i] = false;
            }
        }
    }



    public void playerSkillUse(string skillName)
    {
        switch (skillName)
        {
            case "skill01":
                break;

            case "skill02":
                break;

            case "skill03":
                break;
        }
    }
}
