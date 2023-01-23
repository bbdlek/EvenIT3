using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story8 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six;

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
        else if (person == 5)
            original.sprite = five;
        else if (person == 6)
            original.sprite = six;

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
        yield return StartCoroutine(NormalChat("2-4", "��ġ �������� ��Ų ��ġ ����", 0));
        yield return StartCoroutine(NormalChat("��ġ ����", "�ƴ�, �ʴ� ��ġ����...? �װ� ����...!! �װ� ��� ������...!!", 1));
        yield return StartCoroutine(NormalChat("��ġ ����", "��! �����ݾ�. ���� �׸���, ��ġ ����!", 2));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� �� �׸��־� ����?", 3));
        yield return StartCoroutine(NormalChat("��ġ ����", "������� ��ġ�� ���ο��ϴ� �� �� ����?", 4));
        yield return StartCoroutine(NormalChat("��ġ ����", "����....���� �� �� ������� ������ ��������� �ϴ� ���� ?\n�� �� �𸣰ڴµ� ������...", 3));
        yield return StartCoroutine(NormalChat("���ΰ�", "��!!! ��ġ�� �󸶳� ���� �� �˾�??? �� �Ϸ� ��!!", 5));
        yield return StartCoroutine(NormalChat("��ġ ����", "�Ѵ� �׸��ƾƾƾƾ�!", 6));
    }
}
