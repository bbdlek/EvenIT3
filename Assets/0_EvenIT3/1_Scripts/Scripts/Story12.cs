using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story12 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("3-4", "���ε� ��ġ ����"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��ġ����?"));
        yield return StartCoroutine(NormalChat("��ġ ����", "�׷��� ������ ? �;ƾƾ� ���߾�~~!!!!\n�츮�� �س¾�!!!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�;ƾƾƾƾƾƾ�"));
        yield return StartCoroutine(NormalChat("", ""));
        yield return StartCoroutine(NormalChat("", "������ �׵��� ������.... �װ��� ���� �ƴ϶�� ����....  The End...	"));
    }
}
