using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story17 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("5", "\n\n\n                           ���ο� ��ġ ������ ��ü	"));
        yield return StartCoroutine(NormalChat("5-1", "��� �̻��� ��ġ����"));
        yield return StartCoroutine(NormalChat("����ġ����", "��! ���ΰ� �� �׷��� 333��Ģ�� �� ��Ű�� �ִ°ž�?"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�� ? 333��Ģ ? �װ� �� �ϰ� ������ ����� ?\n�� ��ġ�� ��Ʈ���� ���� �Դٸ鼭"));
        yield return StartCoroutine(NormalChat("����ġ����", "...��? �� �׷���"));
        yield return StartCoroutine(NormalChat("���ΰ�", "(�Ӹ��� : ����? �� ��ġ���� ���� �̻���)"));
    }
}
