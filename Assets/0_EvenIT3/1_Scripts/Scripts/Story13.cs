using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story13 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five;

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
        yield return StartCoroutine(NormalChat("4", "�ٽ� ��Ÿ�� ��ġ ����?!	", 0));
        yield return StartCoroutine(NormalChat("4-1", "�ٽ� ������ ��ġ ���̷���..	", 0));
        yield return StartCoroutine(NormalChat("", "���ڸ� ģ���� ���� �� �˾Ҵ� ��ġ�� �ٽ� �б��� �ִ� �л��鿡�� ������\n�����ߴµ�...	", 1));
        yield return StartCoroutine(NormalChat("??����", "����, ���ΰ�. �ȳ�?", 2));
        yield return StartCoroutine(NormalChat("���ΰ�", "��, ������! (���� �ͼ�����?)", 5));
        yield return StartCoroutine(NormalChat("??����", "��? ���� ������ �� ����?", 4));
        yield return StartCoroutine(NormalChat("���ΰ�", "�װ� ���� ��� �˾�! ����ü ��ü�� ����?", 3));
        yield return StartCoroutine(NormalChat("??����", "��������", 4));
        Destroy(transform.parent.gameObject);
    }
}
