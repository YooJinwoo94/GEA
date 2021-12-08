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
                _tutorialStageQuestDialog[1] = "�Ʒ��� �ִ� ���ɿ��� ���� �����ÿ�.";
                _tutorialStageQuestDialog[2] = "�������� �̵��Ͻÿ�.";
                _tutorialStageQuestDialog[3] = "�Ʒÿ� ������ �����Ͻÿ�.";
                _tutorialStageQuestDialog[4] = "ȸ�� ��ų�� ����Ͻÿ�.";
                _tutorialStageQuestDialog[5] = "���� �������� �̵��Ͻÿ�.";
                break;
            case _stage01:
                _stage01QuestDialog[0] = "������ ã�� ���� �������� �̵�";
                _stage01QuestDialog[1] = "���� ���ʿ� ������ �������� ����";
                _stage01QuestDialog[2] = "W��ų�� ���";
                _stage01QuestDialog[3] = "���� �Ա��� ã�� �������� �̵�";
                _stage01QuestDialog[4] = "���� ���͸� óġ";
                _stage01QuestDialog[5] = "����� ���� �Ա��� ���� �������� �̵�";
                break;
            case _stage02:
                _stage02QuestDialog[0] = "���͸� óġ�Ͻÿ�.";
                _stage02QuestDialog[1] = "������ �۵��Ͻÿ�.(0/2)";
                _stage02QuestDialog[2] = "������ �۵��Ͻÿ�.(1/2)";
                _stage02QuestDialog[3] = "���� ���͸� óġ�Ͻÿ�";
                _stage02QuestDialog[4] = "���� �������� �̵��Ͻÿ�";

                break;
            case _stage03:
                _stage03QuestDialog[0] = "���͸� óġ�Ͻÿ�.";
                _stage03QuestDialog[1] = "ù ��° ������ �����Ͻÿ�.";
                _stage03QuestDialog[2] = "�� ��° ������ �����Ͻÿ�.";
                _stage03QuestDialog[3] = "���� ���и� óġ�Ͻÿ�.";
                _stage03QuestDialog[4] = "���� �������� �̵��Ͻÿ�.";
                break;
            case _endingStage:
                _endingStageQuestDialog[0] = "������ ������ ���ÿ�.";
                _endingStageQuestDialog[1] = "������ ������ ���ÿ�.";
                _endingStageQuestDialog[2] = "������ ������ ���ÿ�.";
                _endingStageQuestDialog[3] = "������ ������ ���ÿ�.";
                _endingStageQuestDialog[4] = "������ ������ ���ÿ�.";
                break;
            case _bossStage:
                _bossStageQuestDialog[0] = "����� ������ �����Ͻÿ�.";
                _bossStageQuestDialog[1] = "����� ��ġ�� �۵���Ű�ÿ�.";
                _bossStageQuestDialog[2] = "����� ��Ű�� �Ŵ���� óġ�Ͻÿ�.";
                _bossStageQuestDialog[3] = "������ ȹ���Ͻÿ�.";
                _bossStageQuestDialog[4] = "������ ȹ���Ͻÿ�.";

                break;
        }
    }
}
