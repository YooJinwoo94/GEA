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
        Ending
    }

    enum DialogType
    {
        Notification,
        Talk
    }
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        notificationPanel = GameObject.Find("ClickPanel_Notification");
        notificationText = notificationPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();

        talkPanel = GameObject.Find("ClickPanel_Talk");
        talkText = talkPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();

        cameraManager = FindObjectOfType<CameraManager>();

        lines = new string[][]
        {
            // ���� ���� ����
            new string[]
            {
                "�⺻���� ���۹� �����Դϴ�.",
                "���� Ŭ���ϸ� �̵�, NPC�� Ŭ���ϸ� ��ȭ�� �� �ֽ��ϴ�.",
                "���� �غ�����!"
            },
            // ��Ʈ Ŭ�� ��
            new string[]
            {
                "�ȳ��Ͻʴϱ�",
                "���� ���̴°�? �� �׾��µ�..",
                "�� ���Դϴ�. ��� ������ ������ ��ް� ����������.",
                "����? �� � ��ȸ�� ���׸�..",
                "�ϳ� ��ȸ�� �ִٸ� �˰� ���� ���� ������ �ִٴ� �ɼ�.",
                "�˰� ���� ���ߴٸ� Ȥ�� �����Դϱ�?",
                "�׷��ٳ� ���Ͱ� �󸶳� ������ ������� �͵� �Ұ�������,",
                "�׷��� �������� ������� ��� �������� ��������� ����� ���� �Ͱ� ���ٳ�.",
                "�׷���, ���� �̷��� �ִٸ� � ������������ �˰� �ʹٴ� ������ �ɼ�.",
                "�� ��ġ�� �˷��ֽŴٸ� ���� ������ ���ؿ��ڽ��ϴ�.",
                "�ڳװ�? �׷�, �� �˷��ְڳ�",
                "������ �� ���� ���� ���������ʿ� �ִٳ�.",
                "�ű⿡ �ִ� ��� ���� ����ġ�� ���� �����Ծ�.",
                "�˰ڽ��ϴ�. ��ĥ�� ��ٸ��ø� �ɰ̴ϴ�."
            },
            // ���� ���� ��
            new string[]
            {
                "���� Ʃ�丮���� �����մϴ�.",
                "���콺 Ŭ������ ���͸� ���� �� �� �ֽ��ϴ�.",
                "�޸��翡 �ִ� ����ƺ� �����غ�����.",
            },
            // ����ƺ� �����ؼ� �����߸���
            new string[]
            {
                "��ų�� Q, W, EŰ�� ���� ����մϴ�.",
                "ȸ�� ��ų�� �˷��帮�ڽ��ϴ�.",
                "ȸ�� ��ų�� Q�� ������ ����մϴ�.",
                "��� �� ������."
            },
            // Q(��)��ų ����ϸ�
            new string[]
            {
                "���ϼ̽��ϴ�.",
                "���ݽ�ų�� W�� E�� ����� �� �ֽ��ϴ�.",
                "������ �����ϸ鼭 ��ų�� ���ñ� �ٶ��ϴ�.",
                "�̰����� ���� Ʃ�丮���� ��Ĩ�ϴ�.",
                "����� ������ �� ������ ��Ż�� Ÿ�� ������ ������ �ּ���."
            },
            // ����
            new string[]
            {
                "������ ã�ƿԽ��ϴ�!",
                "������ ã�ƿ� ���̾�...",
                "����.. ���� ����",
                "�׾�� ������ ã�� ���� �ʹ� ��ڱ�",
                "���� ���� ���� �� �� �ְھ�"
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
            { DialogChannel.Ending, 5 }
        };

        Down();
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
            Start("First");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �˸�â ǥ��
    void printNotification()
    {
        notificationText.text = lines[currentStory][currentLine];
    }

    // �˸�â ǥ��
    void printTalk()
    {
        talkText.text = lines[currentStory][currentLine];
    }

    // ���� ��縦 ���
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

    // ��ȭâ �ݱ�
    void Down()
    {
        notificationPanel.SetActive(false);
        talkPanel.SetActive(false);

        if (type == DialogType.Talk)
            cameraManager.ChangeCamera();

        if (channel == DialogChannel.Ending)
            SceneManager.LoadScene(0);

        currentLine = 0;
    }

    // ��ȭâ ����
    void Up()
    {
        currentLine = 0;

        if (type == DialogType.Notification)
        {
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

    // ���ϴ� ��ȭ�� �����ϴ� �Լ�
    public void Start(string s)
    {
        if (s == "First")
        {
            channel = DialogChannel.First;
            type = DialogType.Notification;
        }
        else if (s == "GhostStory")
        {
            channel = DialogChannel.Ghost;
            type = DialogType.Talk;
            GameObject.FindGameObjectWithTag("Player").SendMessage("SetDestination", GameObject.Find("Ghost/Pos").transform.position);
        }
        else if (s == "TrainingStory")
        {
            channel = DialogChannel.Training;
            type = DialogType.Notification;
        }
        else if(s == "TrainingSkill")
        {
            channel = DialogChannel.TrainingSkill;
            type = DialogType.Notification;
        }
        else if(s == "TrainingSkill2")
        {
            channel = DialogChannel.TrainingSkill2;
            type = DialogType.Notification;
        }
        else if(s == "Ending")
        {
            channel = DialogChannel.Ending;
            type = DialogType.Talk;
        }

        channelDict.TryGetValue(channel, out currentStory);

        Up();
    }

    // �� �۵��ϴ��� Ȯ���ϴ� �Լ�
    // ���� ����
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
