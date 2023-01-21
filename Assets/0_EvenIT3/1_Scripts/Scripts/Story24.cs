using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story24 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("6-4", "������ ����(������ ����)"));
        yield return StartCoroutine(NormalChat("���ΰ�", "����ġ���� �� ������ �޾ƶ�!!!!!!"));
        yield return StartCoroutine(NormalChat("��ġ����", "�Ⱦ�!! ������!!! �����������̾�!!!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ƴ�.�� ���� ������ �� ����!\n��ٷ� ��ġ����! ���� �� �� �����ٰ�!!"));
        yield return StartCoroutine(NormalChat("��ġ����", "���ƾƾƾƾƾ�!!!"));
    }
}
