using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story5 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    void Start()
    {
        StartCoroutine(Text());
    }

    IEnumerator NormalChat(string narrator, string narration)
    {
        CharacterNameTxt.text = narrator;
        writerTxt = "";

        for (int i = 0; i < narration.Length; i++)
        {
            writerTxt += narration[i];
            ChatTxt.text = writerTxt;
            yield return null;
        }

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                break;
            }
            yield return null;
        }
    }

    IEnumerator Text()
    {
        yield return StartCoroutine(NormalChat("2", "\n\n\n                                                              ��ġ������ �߾�	"));
        yield return StartCoroutine(NormalChat("2-1", "�������� ��ġ ����	"));
        yield return StartCoroutine(NormalChat("���ΰ�", "����?!! ���ڱ� �������� �� �̻������µ�?"));
        yield return StartCoroutine(NormalChat("��ġ ����", "���...��ġ ������ ���� �������� �ʹ� ������ �������� �� ����"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷� ���?"));
        yield return StartCoroutine(NormalChat("��ġ ����", "�츮�� �� �� �ִ� ���� ������ ������ �ͻ��̾�!\n�׷��� ������ ������ ������ ���� �� �����ϱ� �׳��� �����̾�.\n���� ����! �� �ʾ����� ������!"));
    }
}
