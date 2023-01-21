using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story18 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("5-2", "�ܷο� �ο�"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��.....�̹����� �������� �Ѿ��...ȥ�ڼ� �Ϸ��ϱ� �ʹ� �����..."));
        yield return StartCoroutine(NormalChat("����ġ����", "ũũũ �� ȥ�ڼ� ��¥ �س� �� �ִٰ� �����ϳ� ?\n�׷� ��� ����� ����!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ƴϾ�! �� �� �� �ִٰ�! �ΰ�� �� ���� ���� ��Ű�ھ�!"));
    }
}
