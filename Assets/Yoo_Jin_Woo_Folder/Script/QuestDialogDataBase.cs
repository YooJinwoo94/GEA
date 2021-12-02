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
                _tutorialStageQuestDialog[0] = "�ȳ� Ʃ�丮���̾�0";
                _tutorialStageQuestDialog[1] = "�ȳ� Ʃ�丮���̾�1";
                _tutorialStageQuestDialog[2] = "�ȳ� Ʃ�丮���̾�2";
                _tutorialStageQuestDialog[3] = "�ȳ� Ʃ�丮���̾�3";
                _tutorialStageQuestDialog[4] = "�ȳ� Ʃ�丮���̾�4";
                break;
            case _stage01:
                _stage01QuestDialog[0] = "�ȳ� ��������1�̾�0";
                _stage01QuestDialog[1] = "�ȳ� ��������1�̾�1";
                _stage01QuestDialog[2] = "�ȳ� ��������1�̾�2";
                _stage01QuestDialog[3] = "�ȳ� ��������1�̾�3";
                _stage01QuestDialog[4] = "�ȳ� ��������1�̾�4";
                break;
            case _stage02:
                _stage02QuestDialog[0] = "�ȳ� ��������2�̾�0";
                _stage02QuestDialog[1] = "�ȳ� ��������2�̾�1";
                _stage02QuestDialog[2] = "�ȳ� ��������2�̾�2";
                _stage02QuestDialog[3] = "�ȳ� ��������2�̾�3";
                _stage02QuestDialog[4] = "�ȳ� ��������2�̾�4";

                break;
            case _stage03:
                _stage03QuestDialog[0] = "�ȳ� ��������3�̾�0";
                _stage03QuestDialog[1] = "�ȳ� ��������3�̾�1";
                _stage03QuestDialog[2] = "�ȳ� ��������3�̾�2";
                _stage03QuestDialog[3] = "�ȳ� ��������3�̾�3";
                _stage03QuestDialog[4] = "�ȳ� ��������3�̾�4";
                break;
            case _bossStage:
                _bossStageQuestDialog[0] = "�ȳ� �������������̾�0";
                _bossStageQuestDialog[1] = "�ȳ� �������������̾�1";
                _bossStageQuestDialog[2] = "�ȳ� �������������̾�2";
                _bossStageQuestDialog[3] = "�ȳ� �������������̾�3";
                _bossStageQuestDialog[4] = "�ȳ� �������������̾�4";

                break;
        }
    }
}
