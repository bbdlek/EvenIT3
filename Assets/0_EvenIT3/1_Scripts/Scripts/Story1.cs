using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Story1 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("1", "��ġ������ ����", 0));
        yield return StartCoroutine(NormalChat("1-1", "��ġ������ �����϶�!", 0));
        yield return StartCoroutine(NormalChat("", "���ΰ� ����/ ���� �� ��ȣ����", 1));
        yield return StartCoroutine(NormalChat("��ġ����", "�? ����?", 2));
        yield return StartCoroutine(NormalChat("���ΰ�", "���ٰ�???!!! �̰� ��� ���� ���� �ž�!!", 3));
        yield return StartCoroutine(NormalChat("��ġ����", "��? ���ĸ� ������ ���ݾ�", 4));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷� �ʰ� �ϴ���!!", 3));
        yield return StartCoroutine(NormalChat("��ġ����", "(����ô�ϸ�) ������ ���� �л��� �ƴѰ�.... ���� ����̾����� �����߰���....\n�̰� �ʸ��� �� �� �ִ� ���̾�.", 5));
        yield return StartCoroutine(NormalChat("���ΰ�", "(�Ӹ��� : ���� �� �� �ִ� ��? ��, ���� �� �����ݾ�!)\n�ѹ� �غ���!!", 6));
    }
}
