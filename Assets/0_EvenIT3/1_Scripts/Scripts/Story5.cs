using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story5 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four;

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
        else if (person == 3)
            original.sprite = three;
        else if (person == 4)
            original.sprite = four;

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
        yield return StartCoroutine(NormalChat("2", "��ġ������ �߾�	", 0));
        yield return StartCoroutine(NormalChat("2-1", "�������� ��ġ ����	", 0));
        yield return StartCoroutine(NormalChat("���ΰ�", "����?!! ���ڱ� �������� �� �̻������µ�?", 1));
        yield return StartCoroutine(NormalChat("��ġ ����", "���...��ġ ������ ���� �������� �ʹ� ������ �������� �� ����", 2));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷� ���?", 3));
        yield return StartCoroutine(NormalChat("��ġ ����", "�츮�� �� �� �ִ� ���� ������ ������ �ͻ��̾�!\n�׷��� ������ ������ ������ ���� �� �����ϱ� �׳��� �����̾�.\n���� ����! �� �ʾ����� ������!", 4));
    }
}
