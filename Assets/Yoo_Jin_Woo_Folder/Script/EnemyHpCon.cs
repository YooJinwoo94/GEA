using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHpCon : MonoBehaviour
{
    [SerializeField]
    GameObject enemyHp;

    [SerializeField]
    CharacterStatus playerStatus;


    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "BossScene") return;

        if (GameObject.Find("Player") == false) return;
        playerStatus = GameObject.Find("Player").GetComponent<CharacterStatus>();
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "BossScene") return;
        if (GameObject.Find("Player") == false) return;
        ifEnemyDamagedUiCon();
    }


    //적 채력은 100을 기준으로 되어있습니다. 
    void ifEnemyDamagedUiCon()
    {
        if (playerStatus.lastAttackTarget != null && playerStatus.lastAttackTarget.name != "map")
        {
            CharacterStatus target_status = playerStatus.lastAttackTarget.GetComponent<CharacterStatus>();
            DrawCharacterStatus(target_status);
        }
    }
    void DrawCharacterStatus(CharacterStatus status)
    {
        if(GameObject.Find("Enemy_hp(Clone)") == false)
        {
            Instantiate(enemyHp);
        }
        
        Slider enemyHpSlider = GameObject.Find("Enemy_hp(Clone)").GetComponentInChildren<Slider>();
        Text enemyName = GameObject.Find("Enemy_hp(Clone)").GetComponentInChildren<Text>();

        enemyName.text = status.characterName;
        enemyHpSlider.maxValue = status.MaxHP;
        enemyHpSlider.value = status.HP;
    }
}
