using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story8 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("2-4", "��ġ �������� ��Ų ��ġ ����"));
        yield return StartCoroutine(NormalChat("��ġ ����", "�ƴ�, �ʴ� ��ġ����...? �װ� ����...!! �װ� ��� ������...!!"));
        yield return StartCoroutine(NormalChat("��ġ ����", "��! �����ݾ�. ���� �׸���, ��ġ ����!"));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� �� �׸��־� ����?"));
        yield return StartCoroutine(NormalChat("��ġ ����", "������� ��ġ�� ���ο��ϴ� �� �� ����?"));
        yield return StartCoroutine(NormalChat("��ġ ����", "����....���� �� �� ������� ������ ��������� �ϴ� ���� ?\n�� �� �𸣰ڴµ� ������..."));
        yield return StartCoroutine(NormalChat("���ΰ�", "��!!! ��ġ�� �󸶳� ���� �� �˾�??? �� �Ϸ� ��!!"));
        yield return StartCoroutine(NormalChat("��ġ ����", "�Ѵ� �׸��ƾƾƾƾ�!"));
    }
}
