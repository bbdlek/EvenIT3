using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve;

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
        else if (person == 7)
            original.sprite = seven;
        else if (person == 8)
            original.sprite = eight;
        else if (person == 9)
            original.sprite = nine;
        else if (person == 10)
            original.sprite = ten;
        else if (person == 11)
            original.sprite = eleven;
        else if (person == 12)
            original.sprite = twelve;


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
        yield return StartCoroutine(NormalChat("��ġ����", "��....�������.\n�ʵ� ����߾�! ���п� ��ġ������ ������ �� �־���", 1));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� ��.... ���� ����߳� �ʵ� �������\n�׷��� ��������� �ߵż� �����̾� ��", 2));
        yield return StartCoroutine(NormalChat("��ġ����", "�׷��� ���̾� ����\n���� ��ġ������ ���ε����ϱ� ���� �̸� ������", 3));
        yield return StartCoroutine(NormalChat("���ΰ�", "����??? ���ݸ� �� �ִٰ� ����...", 4));
        yield return StartCoroutine(NormalChat("��ġ����", "���� ������ �� �ְ� ������, ��ġ������ �����ϴ� �� ���� �ʹ� ���� �Ἥ ���� ���� �ִ� ����� ���ư��� ��.\n��� ���� ���� ���� ���� ������ �ְ� ����", 5));
        yield return StartCoroutine(NormalChat("���ΰ�", "����??", 6));
        yield return StartCoroutine(NormalChat("��ġ����", "�� ���� �־�", 7));
        yield return StartCoroutine(NormalChat("", " ", 8));
        yield return StartCoroutine(NormalChat("", "��ġ������ ���ΰ����� ���� �̻���� �ǱԾ �ǳ��ش�.	", 9));
        MasterAudio.PlaySound("easy ending_8");
        yield return StartCoroutine(NormalChat("���ΰ�", "�̰� ����?", 9));
        yield return StartCoroutine(NormalChat("��ġ����", "���� ����ϰ� ���� ���� �Ϳ��� �ǱԾ��.\n�ű⿡�� �� ���� ���� ���� ����־ �װ� ��ġ�� ���Ѵٸ� ������\n��ġ ����� ���� ���� �ž� ��", 10));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� ���� ������ �� ����~~", 11));
        yield return StartCoroutine(NormalChat("", "��ġ������ �׷��� ���� ��� ������ ������	", 0));
        MasterAudio.PlaySound("easy ending_13");
        yield return StartCoroutine(NormalChat("", "������ �׵��� ������.... �װ��� ���� �ƴ϶�� ����....  The End...", 0));
        yield return StartCoroutine(NormalChat("", " ", 12));
        Destroy(transform.parent.gameObject);
    }
}
