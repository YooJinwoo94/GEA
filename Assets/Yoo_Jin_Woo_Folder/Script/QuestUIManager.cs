using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuestUIManager : MonoBehaviour
{
    [HideInInspector]
    public const int _tutorialStageNum = 6;
    [HideInInspector]
    public const int _stage01Num = 5;
    [HideInInspector]
    public const int _stage02Num = 5;
    [HideInInspector]
    public const int _stage03Num = 5;
    [HideInInspector]
    public const int _bossStageNum = 5;

    [HideInInspector]
    public List<bool> _tutorialStage = new List<bool>();
    [HideInInspector]
    public List<bool> _stage01 = new List<bool>();
    [HideInInspector]
    public List<bool> _stage02 = new List<bool>();
    [HideInInspector]
    public List<bool> _stage03 = new List<bool>();
    [HideInInspector]
    public List<bool> _bossStage = new List<bool>();


    [SerializeField]
    DialogUIManager _dialogUIManagerScript;

    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Tutorial":
                for (int i = 0; i < _tutorialStageNum; i++)
                {
                    _tutorialStage.Add(false);
                }
                _tutorialStage[0] = true;
                break;
            case "Stage1Scene":
                for (int i = 0; i < _stage01Num; i++)
                {
                    _stage01.Add(false);
                }
                _stage01[0] = true;
                break;
            case "Stage2Scene":
                for (int i = 0; i < _stage02Num; i++)
                {
                    _stage02.Add(false);
                }
                _stage02[0] = true;
                break;
            case "Stage3Scene":
                for (int i = 0; i < _stage03Num; i++)
                {
                    _stage03.Add(false);
                }
                _stage03[0] = true;
                break;
            case "BossScene":
                for (int i = 0; i < _bossStageNum; i++)
                {
                    _bossStage.Add(false);
                }
                _bossStage[0] = true;
                break;
        }

        _dialogUIManagerScript.checkQuest();
    }



    // 해당 함수 호출시 퀘스트 다음내용으로 넘김
    public void isQuestEnd()
    {
        if (_dialogUIManagerScript._isQuestTexting == true) return;

        switch (SceneManager.GetActiveScene().name)
        {
            case "Tutorial":
                for (int i = 0; i < _tutorialStageNum; i++)
                {
                    if (_tutorialStage[i] == true)
                    {
                        _tutorialStage[i] = false;
                        if (i == _tutorialStageNum - 1) return;
                        _tutorialStage[i + 1] = true;
                        _dialogUIManagerScript.checkQuest();
                        break;
                    }
                }
                break;
            case "Stage1Scene":
                for (int i = 0; i < _stage01Num; i++)
                {
                    if (_stage01[i] == true)
                    {
                        _stage01[i] = false;
                        if (i == _stage01Num - 1) return;
                        _stage01[i + 1] = true;
                        _dialogUIManagerScript.checkQuest();
                        break;
                    }
                }
                break;
            case "Stage2Scene":
                for (int i = 0; i < _stage02Num; i++)
                {
                    if (_stage02[i] == true)
                    {
                        _stage02[i] = false;
                        if (i == _stage02Num - 1) return;
                        _stage02[i + 1] = true;
                        _dialogUIManagerScript.checkQuest();
                        break;
                    }
                }
                break;
            case "Stage3Scene":
                for (int i = 0; i < _stage03Num; i++)
                {
                    if (_stage03[i] == true)
                    {
                        _stage03[i] = false;
                        if (i == _stage03Num - 1) return;
                        _stage03[i + 1] = true;
                        _dialogUIManagerScript.checkQuest();
                        break;
                    }
                }
                break;
            case "BossScene":
                for (int i = 0; i < _bossStageNum; i++)
                {
                    if (_bossStage[i] == true)
                    {
                        _bossStage[i] = false;
                        if (i == _bossStageNum - 1) return;
                        _bossStage[i + 1] = true;
                        _dialogUIManagerScript.checkQuest();
                        break;
                    }
                }
                break;
        }
    }
}
