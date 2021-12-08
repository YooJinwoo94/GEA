using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialDialog : MonoBehaviour
{
    GameObject notificationPanel;
    GameObject talkPanel;
    Text notificationText;
    Text talkText;
    string[][] lines;
    int currentLine;

    CameraManager cameraManager;

    DialogChannel channel;
    DialogType type;
    Dictionary<DialogChannel, int> channelDict;
    int currentStory;
    enum DialogChannel
    {
        First,
        Ghost,
        Training,
        TrainingSkill,
        TrainingSkill2,
        Ending,
        Warning,
        GhostNotification
    }

    enum DialogType
    {
        Notification,
        Talk
    }
    GameObject player;

    QuestUIManager questUIManager;
    DialogUIManager dialoguUIManager;

    GameObject[] subQuestWarnings;

    bool isFirst;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        notificationPanel = GameObject.Find("ClickPanel_Notification");
        notificationText = notificationPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();

        talkPanel = GameObject.Find("ClickPanel_Talk");
        talkText = talkPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();

        cameraManager = FindObjectOfType<CameraManager>();

        questUIManager = FindObjectOfType<QuestUIManager>();
        dialoguUIManager = FindObjectOfType<DialogUIManager>();

        SubQuestWarning[] temp = FindObjectsOfType<SubQuestWarning>();
        subQuestWarnings = new GameObject[temp.Length];
        for (int i = 0; i < temp.Length; i++)
            subQuestWarnings[i] = GameObject.Find("SubQuestWarning_" + i);

        lines = new string[][]
        {
            // 게임 시작 직후
            new string[]
            {
                "기본적인 조작법 설명입니다.",
                "땅을 클릭하면 이동, NPC를 클릭하면 대화할 수 있습니다.",
                "직접 해보세요!"
            },
            // 고스트 클릭 시
            new string[]
            {
                "안녕하십니까",
                "내가 보이는가? 난 죽었는데..",
                "예 보입니다. 어느 연유로 지상을 헤메고 있으신지요.",
                "내가? 내 삶에 후회는 없네만..",
                "하나 후회가 있다면 알고도 얻지 못한 보물이 있다는 걸세.",
                "알고도 얻지 못했다면 혹시 던전입니까?",
                "그렇다네 몬스터가 얼마나 많은지 숨어들어가는 것도 불가능했지,",
                "그래서 마을에서 동료들을 모아 던전으로 출발했지만 결과는 보는 것과 같다네.",
                "그러니, 내게 미련이 있다면 어떤 보물였는지라도 알고 싶다는 생각일 걸세.",
                "그 위치를 알려주신다면 제가 보물을 구해오겠습니다.",
                "자네가? 그래, 내 알려주겠네",
                "보물은 저 마을 지나 공동묘지쪽에 있다네.",
                "거기에 있는 모든 적을 물리치면 문이 열릴게야.",
                "알겠습니다. 며칠만 기다리시면 될겁니다."
            },
            // 여관 지날 때
            new string[]
            {
                "전투 튜토리얼을 시작합니다.",
                "마우스 클릭으로 몬스터를 공격 할 수 있습니다.",
                "뒷마당에 있는 허수아비를 공격해보세요.",
            },
            // 허수아비 공격해서 쓰러뜨리면
            new string[]
            {
                "스킬은 Q, W, E키를 눌러 사용합니다.",
                "회복 스킬을 알려드리겠습니다.",
                "회복 스킬은 Q를 눌러서 사용합니다.",
                "사용 해 보세요."
            },
            // Q(힐)스킬 사용하면
            new string[]
            {
                "잘하셨습니다.",
                "공격스킬은 W와 E로 사용할 수 있습니다.",
                "게임을 진행하면서 스킬을 얻어가시길 바랍니다.",
                "이것으로 전투 튜토리얼을 마칩니다.",
                "충분히 연습한 후 뒤편의 포탈을 타고 게임을 시작해 주세요."
            },
            // 엔딩
            new string[]
            {
                "보물을 찾아왔습니다!",
                "정말로 찾아올 줄이야...",
                "정말.. 정말 고맙네",
                "죽어서라도 보물을 찾은 것이 너무 기쁘군",
                "이제 나도 성불 할 수 있겠어"
            },
            // 경고문
            new string[]
            {
                "서브 퀘스트를 완료해 주세요."
            }
        };
        currentLine = 0;

        channelDict = new Dictionary<DialogChannel, int>
        {
            { DialogChannel.First, 0 },
            { DialogChannel.Ghost, 1 },
            { DialogChannel.Training, 2 },
            { DialogChannel.TrainingSkill, 3 },
            { DialogChannel.TrainingSkill2, 4 },
            { DialogChannel.Ending, 5 },
            { DialogChannel.Warning, 6 }
        };
        isFirst = true;
        Down();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            StartDialog("First");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 알림창 표시
    void printNotification()
    {
        notificationText.text = lines[currentStory][currentLine];
    }

    // 알림창 표시
    void printTalk()
    {
        talkText.text = lines[currentStory][currentLine];
    }

    // 다음 대사를 출력
    public void Next()
    {
        if (currentLine >= lines[currentStory].Length - 1)
        {
            Down();
            return;
        }
        currentLine++;

        if (type == DialogType.Notification)
            printNotification();
        else if (type == DialogType.Talk)
            printTalk();
    }

    // 대화창 닫기
    void Down()
    {
        notificationPanel.SetActive(false);
        talkPanel.SetActive(false);

        if (type == DialogType.Talk)
            cameraManager.ChangeCamera();

        if (channel == DialogChannel.Ending)
            SceneManager.LoadScene(0);

        currentLine = 0;
        Time.timeScale = 1.0f;

        if (channel != DialogChannel.Warning && !isFirst)
            questUIManager.isQuestEnd();

        if (isFirst)
            isFirst = false;
    }

    // 대화창 열기
    void Up()
    {
        currentLine = 0;

        if (type == DialogType.Notification)
        {
            // 안내창만 시간정지 대화는 정지X
            Time.timeScale = 0;

            notificationPanel.SetActive(true);

            printNotification();
        }
        else if (type == DialogType.Talk)
        {
            cameraManager.ChangeCamera();
            talkPanel.SetActive(true);

            printTalk();
        }
    }

    // 원하는 대화를 시작하는 함수
    public void StartDialog(string s)
    {
        if (s == "First" && questUIManager._tutorialStage[0])
        {
            Debug.Log("first");
            channel = DialogChannel.First;
            type = DialogType.Notification;
        }
        else if (s == "GhostStory" && questUIManager._tutorialStage[1])
        {
            channel = DialogChannel.Ghost;
            type = DialogType.Talk;

            subQuestWarnings[0].SetActive(false);

            //GameObject.FindGameObjectWithTag("Player").SendMessage("SetDestination", GameObject.Find("Ghost/Pos").transform.position);
        }
        else if (s == "TrainingStory" && questUIManager._tutorialStage[2])
        {
            channel = DialogChannel.Training;
            type = DialogType.Notification;
        }
        else if(s == "TrainingSkill" && questUIManager._tutorialStage[3])
        {
            channel = DialogChannel.TrainingSkill;
            type = DialogType.Notification;
        }
        else if(s == "TrainingSkill2" && questUIManager._tutorialStage[4])
        {
            channel = DialogChannel.TrainingSkill2;
            type = DialogType.Notification;

            subQuestWarnings[1].SetActive(false);
        }
        else if(s == "Ending")
        {
            channel = DialogChannel.Ending;
            type = DialogType.Talk;
        }
        else if(s == "Warning")
        {
            channel = DialogChannel.Warning;
            type = DialogType.Notification;
        }
        else if(dialoguUIManager._isQuestTexting)
        {
            return;
        }

        channelDict.TryGetValue(channel, out currentStory);

        Up();
    }

    // 잘 작동하는지 확인하는 함수
    // 삭제 예정
    public void test()
    {
        channel = DialogChannel.Ghost;
        channelDict.TryGetValue(channel, out currentStory);
        for (currentLine = 0; currentLine < lines[currentStory].Length; currentLine++)
        {
            Debug.Log("Story : " + lines[currentStory][currentLine] + "\n");
        }

        channel = DialogChannel.Training;
        channelDict.TryGetValue(channel, out currentStory);
        for (currentLine = 0; currentLine < lines[currentStory].Length; currentLine++)
        {
            Debug.Log("Story : " + lines[currentStory][currentLine] + "\n");
        }
    }
}
