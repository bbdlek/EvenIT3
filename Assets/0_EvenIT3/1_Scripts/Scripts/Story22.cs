using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story22 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("6-2", "�ε�! ������ ����!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� �� ��ġ�����̾� ?\n�Ʊ� 333��Ģ ���ϴ°͵� �̻��߰� �� �̻��Ѱ� �����̾�!"));
        yield return StartCoroutine(NormalChat("����ġ����", "�� ? ���� �Ҹ��� �ϴ� �ž�!\n���� ��ġ..��..��..�ε�....�� ? "));
        yield return StartCoroutine(NormalChat("", "����ġ������ ���ڱ� �Ӹ��� �ο���� ���ο��Ѵ�	"));
        yield return StartCoroutine(NormalChat("����ġ����", "��...����� ���ΰ�....�� �� ������..."));
    }
}
