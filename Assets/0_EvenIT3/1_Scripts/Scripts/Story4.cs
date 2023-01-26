using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story4 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two;

    void Start()
    {
        StartCoroutine(Text());
    }

    IEnumerator NormalChat(string narrator, string narration, int person)
    {
        CharacterNameTxt.text = narrator;
        writerTxt = "";

        if (person == 1)
            original.sprite = one;
        else if (person == 2)
            original.sprite = two;

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
        yield return StartCoroutine(NormalChat("1-4", "���� �ڶ󳪴� �ڽŰ�", 0));
        yield return StartCoroutine(NormalChat("���ΰ�", "�þ�? �þ�? �� ���? ������?", 1));
        yield return StartCoroutine(NormalChat("��ġ����", "�� �þ�! ������ ��� �׷��� �ϸ� ��. �? ���� ���ٰ� ����?", 2));
        yield return StartCoroutine(NormalChat("���ΰ�", "������ �ʾ����� ���� ����� �� �͵��߾�.\n������ ������ �� �ð�������!", 1));
    }
}
