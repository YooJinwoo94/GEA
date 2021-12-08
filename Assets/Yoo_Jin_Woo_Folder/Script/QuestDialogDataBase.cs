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
    const string _endingStage = "Ending";
    const string _bossStage = "BossScene";

    [HideInInspector]
    public string[] _tutorialStageQuestDialog;
    [HideInInspector]
    public string[] _stage01QuestDialog;
    [HideInInspector]
    public string[] _stage02QuestDialog;
    [HideInInspector]
    public string[] _stage03QuestDialog;
    [HideInInspector]
    public string[] _endingStageQuestDialog;
    [HideInInspector]
    public string[] _bossStageQuestDialog;



    private void Start()
    {
        _tutorialStageQuestDialog = new string[6];
        _stage01QuestDialog = new string[6];
        _stage02QuestDialog = new string[5];
        _stage03QuestDialog = new string[5];
        _endingStageQuestDialog = new string[5];
        _bossStageQuestDialog = new string[5];

        switch (SceneManager.GetActiveScene().name)
        {
            case _tutorialStage:
                _tutorialStageQuestDialog[0] = "";
                _tutorialStageQuestDialog[1] = "아래에 있는 유령에게 말을 걸으시오.";
                _tutorialStageQuestDialog[2] = "여관으로 이동하시오.";
                _tutorialStageQuestDialog[3] = "훈련용 인형을 공격하시오.";
                _tutorialStageQuestDialog[4] = "회복 스킬을 사용하시오.";
                _tutorialStageQuestDialog[5] = "다음 지역으로 이동하시오.";
                break;
            case _stage01:
                _stage01QuestDialog[0] = "신전을 찾아 묘지 안쪽으로 이동";
                _stage01QuestDialog[1] = "묘지 안쪽에 빛나는 아이템을 조사";
                _stage01QuestDialog[2] = "W스킬을 사용";
                _stage01QuestDialog[3] = "신전 입구를 찾아 안쪽으로 이동";
                _stage01QuestDialog[4] = "정예 몬스터를 처치";
                _stage01QuestDialog[5] = "열쇠로 신전 입구를 열고 안쪽으로 이동";
                break;
            case _stage02:
                _stage02QuestDialog[0] = "몬스터를 처치하시오.";
                _stage02QuestDialog[1] = "레버를 작동하시오.(0/2)";
                _stage02QuestDialog[2] = "레버를 작동하시오.(1/2)";
                _stage02QuestDialog[3] = "정예 몬스터를 처치하시오";
                _stage02QuestDialog[4] = "다음 지역으로 이동하시오";

                break;
            case _stage03:
                _stage03QuestDialog[0] = "몬스터를 처치하시오.";
                _stage03QuestDialog[1] = "첫 번째 관문을 개방하시오.";
                _stage03QuestDialog[2] = "두 번째 관문을 개방하시오.";
                _stage03QuestDialog[3] = "정예 몬스털르 처치하시오.";
                _stage03QuestDialog[4] = "다음 지역으로 이동하시오.";
                break;
            case _endingStage:
                _endingStageQuestDialog[0] = "유령을 만나러 가시오.";
                _endingStageQuestDialog[1] = "유령을 만나러 가시오.";
                _endingStageQuestDialog[2] = "유령을 만나러 가시오.";
                _endingStageQuestDialog[3] = "유령을 만나러 가시오.";
                _endingStageQuestDialog[4] = "유령을 만나러 가시오.";
                break;
            case _bossStage:
                _bossStageQuestDialog[0] = "사원의 안쪽을 조사하시오.";
                _bossStageQuestDialog[1] = "사원의 장치를 작동시키시오.";
                _bossStageQuestDialog[2] = "사원을 지키는 거대골렘을 처치하시오.";
                _bossStageQuestDialog[3] = "보물을 획득하시오.";
                _bossStageQuestDialog[4] = "보물을 획득하시오.";

                break;
        }
    }
}
