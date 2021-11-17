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
                "�⺻���� ���۹� �����Դϴ�.",
                "���� Ŭ���ϸ� �̵�, NPC�� Ŭ���ϸ� ��ȭ�� �� �ֽ��ϴ�.",
                "���� �غ�����!"
            },
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
            new string[]
            {
                "���� Ʃ�丮���� �����մϴ�.",
                "���콺 Ŭ������ ���͸� ���� �� �� �ֽ��ϴ�.",
                "��ų�� Q, W, EŰ�� ���� ����մϴ�.",
                "ȸ�� ��ų�� �˷��帱�״� ����� ���ʽÿ�.",
                "�̰����� ���� Ʃ�丮���� ��Ĩ�ϴ�.",
                "����� ������ �� ������ ��Ż�� Ÿ�� ������ ������ �ּ���."
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

    // ��ȭâ ǥ��
    void printDialog()
    {
        text.text = lines[currentStory][currentLine];
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
        printDialog();
    }

    // ��ȭâ �ݱ�
    void Down()
    {
        panel.SetActive(false);
        currentLine = 0;
    }

    // ��ȭâ ����
    void Up()
    {
        panel.SetActive(true);
        currentLine = 0;
        printDialog();
    }

    // ���ϴ� ��ȭ�� �����ϴ� �Լ�
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
