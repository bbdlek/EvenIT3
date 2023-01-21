using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Story1 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("1", "\n\n\n                                                               ��ġ������ ����"));
        yield return StartCoroutine(NormalChat("1-1", "��ġ������ �����϶�!"));
        yield return StartCoroutine(NormalChat("", "���ΰ� ����/ ���� �� ��ȣ����"));
        yield return StartCoroutine(NormalChat("��ġ����", "�? ����?"));
        yield return StartCoroutine(NormalChat("���ΰ�", "���ٰ�???!!! �̰� ��� ���� ���� �ž�!!"));
        yield return StartCoroutine(NormalChat("��ġ����", "��? ���ĸ� ������ ���ݾ�"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷� �ʰ� �ϴ���!!"));
        yield return StartCoroutine(NormalChat("��ġ����", "(����ô�ϸ�) ������ ���� �л��� �ƴѰ�.... ���� ����̾����� �����߰���....\n�̰� �ʸ��� �� �� �ִ� ���̾�."));
        yield return StartCoroutine(NormalChat("���ΰ�", "(�Ӹ��� : ���� �� �� �ִ� ��? ��, ���� �� �����ݾ�!)\n�ѹ� �غ���!!"));
    }
}
