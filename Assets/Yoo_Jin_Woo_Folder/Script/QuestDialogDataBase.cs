using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class QuestDialogDataBase : MonoBehaviour
{
    const string _tutorialStage = "Tutorial";
    const string _stage01 = "Stage1Scene";
    const string _stage02 = "Stage2Scene";
    const string _stage03 = "Stage3Scene";
    const string _bossStage = "BossScene";

    [HideInInspector]
    public string[] _tutorialStageQuestDialog = new string[6];
    [HideInInspector]
    public string[] _stage01QuestDialog = new string[5];
    [HideInInspector]
    public string[] _stage02QuestDialog = new string[5];
    [HideInInspector]
    public string[] _stage03QuestDialog = new string[5];
    [HideInInspector]
    public string[] _bossStageQuestDialog = new string[5];



    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case _tutorialStage:
                _tutorialStageQuestDialog[0] = "튜토리얼 시작";
                _tutorialStageQuestDialog[1] = "아래에 있는 유령에게 말을 걸어보자";
                _tutorialStageQuestDialog[2] = "여관으로 이동하자";
                _tutorialStageQuestDialog[3] = "훈련용 인형을 공격하자";
                _tutorialStageQuestDialog[4] = "회복 스킬을 사용하자";
                _tutorialStageQuestDialog[5] = "다음 지역으로 이동하자";
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
                _bossStageQuestDialog[0] = "사원의 안쪽을 조사하자";
                _bossStageQuestDialog[1] = "사원의 장치를 작동시키자";
                _bossStageQuestDialog[2] = "사원을 지키는 거대골렘을 쓰러트리자";
                _bossStageQuestDialog[3] = "보물을 획득하자";
                _bossStageQuestDialog[4] = "보물을 획득해라";

                break;
        }
    }
}
