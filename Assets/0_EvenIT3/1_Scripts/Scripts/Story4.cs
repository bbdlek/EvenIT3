using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story4 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("1-4", "���� �ڶ󳪴� �ڽŰ�"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�þ�? �þ�? �� ���? ������?"));
        yield return StartCoroutine(NormalChat("��ġ����", "�� �þ�! ������ ��� �׷��� �ϸ� ��. �? ���� ���ٰ� ����?"));
        yield return StartCoroutine(NormalChat("���ΰ�", "������ �ʾ����� ���� ����� �� �͵��߾�.\n������ ������ �� �ð�������!"));
    }
}
