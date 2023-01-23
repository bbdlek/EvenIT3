using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardEnding : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen;

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
        else if (person == 13)
            original.sprite = thirteen;
        else if (person == 14)
            original.sprite = fourteen;

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
        yield return StartCoroutine(NormalChat("", "���� - ���ƿ� ��ġ����	", 0));
        yield return StartCoroutine(NormalChat("���ΰ�", "(�ݰ��� ����, ����� ������ �긮�� )��ġ����..!!", 1));
        yield return StartCoroutine(NormalChat("��ġ����", "����, ���ΰ�. �� ���п� ���� ���� �� �־���.", 2));
        yield return StartCoroutine(NormalChat("���ΰ�", "����... �������... �ٽ� ���ƿͼ� �����̾�...(����...)", 3));
        yield return StartCoroutine(NormalChat("��ġ����", "(��Ȳ, ���ΰ��� �޷���) �̾���... ��¿ ���� ������...\n��ġ������ ���� �Ǳ� ���� ���� ����� �ְ� ���� ����...", 4));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ٵ� ���� �Ʊ� �Ͼ�������� �̻��� ����� �ôµ�...\n�ʶ� ��ġ�����̶� �������� ��¸���̾���...", 5));
        yield return StartCoroutine(NormalChat("��ġ����", "��....�׷� �����׶�� ���ص� ��������.\n���� ���� ��ġ������ ����������� �Բ� ��� �Ҳ�ģ������.\n�׷��� ����� ��ġ������ � å�� �д��� �µ��� 180�� �ٲ��\n��ġ�� �۶߸��� �ٳ��...���� ������ ��å�� ����å���� ����...", 6));
        yield return StartCoroutine(NormalChat("��ġ����", "������ ���� ��ġ������ �ٸ�������� �������°� �� �� ���\n�����ϴ� ����� �����Ѱž�", 6));
        yield return StartCoroutine(NormalChat("���ΰ�", "(����...���ΰ��� ������ ��ġ������ ��ڿ��ش�)", 7));
        yield return StartCoroutine(NormalChat("", "���ΰ��� ��ġ������ �ѵ��� ������ �ϴø� �ٶ󺸰��־���...	", 8));
        yield return StartCoroutine(NormalChat("", "�� 1�ð��� ���� �� ��ġ������ õõ�� ���� ������	", 9));
        yield return StartCoroutine(NormalChat("��ġ����", "�� ���� ������ �Ұ� ����", 10));
        yield return StartCoroutine(NormalChat("���ΰ�", "��? ���� �� �ִٰ� ����...", 11));
        yield return StartCoroutine(NormalChat("��ġ����", "�ƴ� ������ ��¥ ���ư�����.\n�� �׾Ƹ��� ���� ������ ���� �׷� ������ ��ġ������ ������ Ǯ���� ���� �����ž�.\n�׷� ���־�...��ġ �� ���ϰ�!", 12));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷�, �ʵ� ������!", 13));
        yield return StartCoroutine(NormalChat("", "The End	", 14));
    }
}
