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
    public string[] _tutorialStageQuestDialog = new string[5];
    [HideInInspector]
    public string[] _stage01QuestDialog = new string[7];
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
                _tutorialStageQuestDialog[0] = "안녕 튜토리얼이야0";
                _tutorialStageQuestDialog[1] = "안녕 튜토리얼이야1";
                _tutorialStageQuestDialog[2] = "안녕 튜토리얼이야2";
                _tutorialStageQuestDialog[3] = "안녕 튜토리얼이야3";
                _tutorialStageQuestDialog[4] = "안녕 튜토리얼이야4";
                break;
            case _stage01:
                _stage01QuestDialog[0] = "사원은 묘지에 있다. 묘지 안쪽으로 이동하자";
                _stage01QuestDialog[1] = "파헤쳐진 묘지들중 빛나는아이템 조사";
                _stage01QuestDialog[2] = "무덤속에서 기술을 획득했다. W스킬을 사용해보자 ";
                _stage01QuestDialog[3] = "W스킬은 직선범위 스킬이다. ";
                _stage01QuestDialog[4] = "사원 입구를 찾아보자";
                _stage01QuestDialog[5] = "대형스켈레톤을 쓰러트리자";
                _stage01QuestDialog[6] = "열쇠로 신전 입구를 열고 안쪽으로 이동하자";
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
    }
}
