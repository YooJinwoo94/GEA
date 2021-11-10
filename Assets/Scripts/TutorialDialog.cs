using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialog : MonoBehaviour
{
    GameObject panel;
    Text text;
    string[][] lines;
    int currentLine;

    DialogChannel channel;
    Dictionary<DialogChannel, int> channelDict;
    int currentStory;
    enum DialogChannel
    {
        First,
        Ghost,
        Training
    }

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("ClickPanel");
        text = panel.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        lines = new string[][]
        {
            new string[]
            {
                "기본적인 조작법 설명입니다.",
                "땅을 클릭하면 이동, NPC를 클릭하면 대화할 수 있습니다.",
                "직접 해보세요!"
            },
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
            new string[]
            {
                "전투 튜토리얼을 시작합니다.",
                "마우스 클릭으로 몬스터를 공격 할 수 있습니다.",
                "스킬은 Q, W, E키를 눌러 사용합니다.",
                "회복 스킬을 알려드릴테니 사용해 보십시오.",
                "이것으로 전투 튜토리얼을 마칩니다.",
                "충분히 연습한 후 뒤편의 포탈을 타고 게임을 시작해 주세요."
            }

        };
        currentLine = 0;
        printDialog();

        channelDict = new Dictionary<DialogChannel, int>
        {
            { DialogChannel.First, 0 },
            { DialogChannel.Ghost, 1 },
            { DialogChannel.Training, 2 }
        };

        Start("First");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 대화창 표시
    void printDialog()
    {
        text.text = lines[currentStory][currentLine];
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
        printDialog();
    }

    // 대화창 닫기
    void Down()
    {
        panel.SetActive(false);
        currentLine = 0;
    }

    // 대화창 열기
    void Up()
    {
        panel.SetActive(true);
        currentLine = 0;
        printDialog();
    }

    // 원하는 대화를 시작하는 함수
    public void Start(string s)
    {
        if(s == "First")
            channel = DialogChannel.First;
        else if(s =="GhostStory")
            channel = DialogChannel.Ghost;
        else if (s == "TrainingStory")
            channel = DialogChannel.Training;

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
