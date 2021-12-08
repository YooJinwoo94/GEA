using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogUIManager : MonoBehaviour
{

    const string _tutorialStage = "Tutorial";
    const string _stage01 = "Stage1Scene";
    const string _stage02 = "Stage2Scene";
    const string _stage03 = "Stage3Scene";
    const string _endingStage = "Ending";
    const string _bossStage = "BossScene";

    [SerializeField]
    QuestUIManager _questUIManagerScript;
    [SerializeField]
    QuestDialogDataBase _questDialogDataBaseScript;


    [SerializeField]
    Text _questText;

    [HideInInspector]
    public bool _isQuestTexting = false;

    private void Awake()
    {
        _isQuestTexting = false;
    }

    private void Start()
    {

    }



    public void checkQuest()
    {
        _questText.text = "";
        _isQuestTexting = true;

        switch (SceneManager.GetActiveScene().name)
        {
            case _tutorialStage:
                for (int i = 0; i < _questUIManagerScript._tutorialStage.Count; i++)
                {
                    if (_questUIManagerScript._tutorialStage[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_questDialogDataBaseScript._tutorialStageQuestDialog[i]));

                        return;
                    }
                }
                break;
            case _stage01:
                for (int i = 0; i < _questUIManagerScript._stage01.Count; i++)
                {
                    if (_questUIManagerScript._stage01[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_questDialogDataBaseScript._stage01QuestDialog[i]));
                        return;
                    }
                }
                break;
            case _stage02:
                for (int i = 0; i < _questUIManagerScript._stage02.Count; i++)
                {
                    if (_questUIManagerScript._stage02[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_questDialogDataBaseScript._stage02QuestDialog[i]));
                        return;
                    }
                }
                break;
            case _stage03:
                for (int i = 0; i < _questUIManagerScript._stage03.Count; i++)
                {
                    if (_questUIManagerScript._stage03[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_questDialogDataBaseScript._stage03QuestDialog[i]));
                        return;
                    }
                }
                break;
            case _endingStage:
                for (int i = 0; i < _questUIManagerScript._endingStage.Count; i++)
                {
                    if (_questUIManagerScript._endingStage[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_questDialogDataBaseScript._endingStageQuestDialog[i]));
                        return;
                    }
                }
                break;
            case _bossStage:
                for (int i = 0; i < _questUIManagerScript._bossStage.Count; i++)
                {
                    if (_questUIManagerScript._bossStage[i] == true)
                    {
                        StartCoroutine(TypeSenetence(_questDialogDataBaseScript._bossStageQuestDialog[i]));
                        return;
                    }
                }
                break;
        }
    }
    
    IEnumerator TypeSenetence(string sentence = "")
    {
        foreach (char letter in sentence.ToCharArray())
        {
            if (_isQuestTexting == false) break;

            _questText.text += letter;
            yield return new WaitForSecondsRealtime(0.1f);
        }

        _isQuestTexting = false;
        StopCoroutine(TypeSenetence());
    }
}
