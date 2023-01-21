using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story13 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("4", "\n\n\n                         �ٽ� ��Ÿ�� ��ġ ����?!	"));
        yield return StartCoroutine(NormalChat("4-1", "�ٽ� ������ ��ġ ���̷���..	"));
        yield return StartCoroutine(NormalChat("", "���ڸ� ģ���� ���� �� �˾Ҵ� ��ġ�� �ٽ� �б��� �ִ� �л��鿡�� ������\n�����ߴµ�...	"));
        yield return StartCoroutine(NormalChat("??����", "����, ���ΰ�. �ȳ�?"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��, ������! (���� �ͼ�����?)"));
        yield return StartCoroutine(NormalChat("??����", "��? ���� ������ �� ����?"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�װ� ���� ��� �˾�! ����ü ��ü�� ����?"));
        yield return StartCoroutine(NormalChat("??����", "��������"));
    }
}
