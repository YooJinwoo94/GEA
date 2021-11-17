using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IngameUICon : MonoBehaviour
{
    [SerializeField]
    OptionUICon _optionUIConScript;
    [SerializeField]
    PlayerHpCon _playerHpConScript;
    [SerializeField]
    PlayerSkillUIManager _playerSkillConScript;

    public void playerHpCon(int hp,string upDown)
    {
        _playerHpConScript.hpCon(hp,upDown);
    }

    public void skillUsed(int skillNum)
    {
        _playerSkillConScript.playerSkillUse(skillNum);
    }

    public void optionBtnClick()
    {
        _optionUIConScript.isOptionOn();
    }
}
