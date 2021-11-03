using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    const string _tutorialStage = "TutorialStage";
    const string _stage01 = "Stage01";
    const string _stage02 = "Stage02";
    const string _stage03 = "Stage03";
    const string _bossStage = "BossStage";

    [SerializeField]
    QuestManager _questManagerScript;

    [SerializeField]
    Text _questText;

    [SerializeField]
    Text _talkText;

    [HideInInspector]
    public bool _isQuestTexting;
    [HideInInspector]
    public bool _isTalkTexting;

    string[] _tutorialStageQuestDialog = new string[5];
    string[] _stage01QuestDialog = new string[5];
    string[] _stage02QuestDialog = new string[5];
    string[] _stage03QuestDialog = new string[5];
    string[] _bossStageQuestDialog = new string[5];

    private void Start()
    {
        _isQuestTexting = false;
        _isTalkTexting = false;

        switch (SceneManager.GetActiveScene().name)
        {
            case _tutorialStage:
                _tutorialStageQuestDialog[0] = "안녕 튜토리얼이야0";
                _tutorialStageQuestDialog[1] = "안녕 튜토리얼이야1";
                _tutorialStageQuestDialog[2] = "안녕 튜토리얼이야2";
                _tutorialStageQuestDialog[3] = "안녕 튜토리얼이야3";
                _tutorialStageQuestDialog[4] = "안녕 튜토리얼이야4";
                break;
            case _stage01:
                _stage01QuestDialog[0] = "안녕 스테이지1이야0";
                _stage01QuestDialog[1] = "안녕 스테이지1이야1";
                _stage01QuestDialog[2] = "안녕 스테이지1이야2";
                _stage01QuestDialog[3] = "안녕 스테이지1이야3";
                _stage01QuestDialog[4] = "안녕 스테이지1이야4";
                break;
            case _stage02:
                _stage02QuestDialog[0] = "안녕 스테이지2이야0";
                _stage02QuestDialog[1] = "안녕 스테이지2이야1";
                _stage02QuestDialog[2] = "안녕 스테이지2이야2";
                _stage02QuestDialog[3] = "안녕 스테이지2이야3";
                _stage02QuestDialog[4] = "안녕 스테이지2이야4";

                break;
            case _stage03:
                _stage03QuestDialog[0] = "안녕 스테이지3이야0";
                _stage03QuestDialog[1] = "안녕 스테이지3이야1";
                _stage03QuestDialog[2] = "안녕 스테이지3이야2";
                _stage03QuestDialog[3] = "안녕 스테이지3이야3";
                _stage03QuestDialog[4] = "안녕 스테이지3이야4";
                break;
            case _bossStage:
                _bossStageQuestDialog[0] = "안녕 보스스테이지이야0";
                _bossStageQuestDialog[1] = "안녕 보스스테이지이야1";
                _bossStageQuestDialog[2] = "안녕 보스스테이지이야2";
                _bossStageQuestDialog[3] = "안녕 보스스테이지이야3";
                _bossStageQuestDialog[4] = "안녕 보스스테이지이야4";

                break;
        }

        checkQuest();
    }


    // 호출시 현재 퀘스트의 내용을 보낸다.
    public void checkQuest()
    {
        _questText.text = "";
        _isQuestTexting = true;

        switch (SceneManager.GetActiveScene().name)
        {
            case _tutorialStage:
                for (int i = 0; i<_questManagerScript._tutorialStage.Count;i++)
                {
                    if (_questManagerScript._tutorialStage[i] == true)
                    {
                        Debug.Log(i);
                        StartCoroutine(TypeSenetence(_tutorialStageQuestDialog[i]));
                        return;
                    }
                }  
                break;
            case _stage01:
                for (int i = 0; i < _questManagerScript._stage01.Count; i++)
                {
                    if (_questManagerScript._stage01[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_stage01QuestDialog[i]));
                        return;
                    }
                }
                break;
            case _stage02:
                for (int i = 0; i < _questManagerScript._stage02.Count; i++)
                {
                    if (_questManagerScript._stage02[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_stage02QuestDialog[i]));
                        return;
                    }
                }
                break;
            case _stage03:
                for (int i = 0; i < _questManagerScript._stage03.Count; i++)
                {
                    if (_questManagerScript._stage03[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_stage03QuestDialog[i]));
                        return;
                    }
                }
                break;
            case _bossStage:
                for (int i = 0; i < _questManagerScript._bossStage.Count; i++)
                {
                    if (_questManagerScript._bossStage[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_bossStageQuestDialog[i]));
                        return;
                    }
                }
                break;
        }
    }
    IEnumerator TypeSenetence (string sentence = "")
    {
        foreach(char letter in sentence.ToCharArray())
        {
            if (_isQuestTexting == false) break;

            _questText.text += letter;
           yield return new WaitForSeconds(0.1f);
        }

        _isQuestTexting = false;
        StopCoroutine(TypeSenetence());
    } 
}
