﻿using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour
{

    //---------- 공격 장에서 사용한다. ----------
    // 체력.
    public int HP = 100;
    public int MaxHP = 100;

    // 공격력.
    public int Power = 10;

    //수정자 이원표 스킬데미지
    public int QPower = 50;
    public int WPower = 100;
    public int EPower = 100;
    

    // 마지막에 공격한 대상.
    public GameObject lastAttackTarget = null;

    //---------- GUI 및 네트워크 장에서 사용한다. ----------
    // 플레이어 이름.
    public string characterName = "Player";

    //--------- 애니메이션 장에서 사용한다. -----------
    // 상태.
    public bool attacking = false;
    public bool died = false;

    public bool isgetQ = true;
    public bool isgetW = true;
    public bool isgetE = true;
    public bool isKey = false;
    [SerializeField] GameObject gameOverUI = null;
    // 공격력 강화.
    //public bool powerBoost = false;
    // 공격력 강화 시간.
    //float powerBoostTime = 0.0f;

    // 공격력 강화 효과.
    //ParticleSystem powerUpEffect;

    // 아이템 획득.
    public void GetItem(DropItem.ItemKind itemKind)
    {
        switch (itemKind)
        {
            //case DropItem.ItemKind.Attack:
            //    powerBoostTime = 5.0f;
            //    powerUpEffect.Play();
            //    break;
            //case DropItem.ItemKind.Heal:
            //    // MaxHP의 절반 회복.
            //    HP = Mathf.Min(HP + MaxHP / 2, MaxHP);
            //    break;

            case DropItem.ItemKind.KEY:
                isKey = true;
                break;
        }
    }
    public void GetSkill(SkillRune.SkillKind skillKind)
    {
        switch (skillKind)
        {
            case SkillRune.SkillKind.QSkill:
                isgetQ = true;
                break;
            case SkillRune.SkillKind.WSkill:
                isgetW = true;
                break;
            case SkillRune.SkillKind.ESkill:
                isgetE = true;
                break;
        }
    }

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            //powerUpEffect = transform.Find("PowerUpEffect").GetComponent<ParticleSystem>();
        }
        Time.timeScale = 1;

    }

    void Update()
    {
        if (gameObject.tag != "Player")
        {
            return;
        }
        if (HP <= 0) {
            Debug.Log("Death");
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
        //powerBoost = false;
        //if (powerBoostTime > 0.0f)
        //{
        //    powerBoost = true;
        //    powerBoostTime = Mathf.Max(powerBoostTime - Time.deltaTime, 0.0f);
        //}
        //else
        //{
        //    powerUpEffect.Stop();
        //}
    }

}