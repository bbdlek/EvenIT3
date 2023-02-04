using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.UI;

public class HardOpening : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six, seven;

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
        yield return StartCoroutine(NormalChat("", "��ġ������ ������ ��ȭ�ο� �������� ���ӵǰ� �־���	", 0));
        yield return StartCoroutine(NormalChat("", "�׷��� �����...	", 0));
        MasterAudio.PlaySound("hard opening_1 school ring");
        yield return StartCoroutine(NormalChat("", "", 1));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", "��.....", 2));
        yield return StartCoroutine(NormalChat("���ΰ�", "�� �׷�? ��� ����?", 3));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", "��ݴϰ� ������... ����ϰ� ����...", 4));
        yield return StartCoroutine(NormalChat("���ΰ�", "ġ�� �ѹ� ����", 3));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", "�׷��߰ھ�. ���� �б� ������ ���߰ڴ�.", 4));
        yield return StartCoroutine(NormalChat("", "", 1));
        yield return StartCoroutine(NormalChat("", "�� �� ��	", 1));
        yield return StartCoroutine(NormalChat("���ΰ�", "ġ�� ���� �Ծ�? ����?", 5));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", "�� �ٳ�Դµ� ��ġ�� �����", 3));
        yield return StartCoroutine(NormalChat("���ΰ�", "�� ? ��ҿ� ��ġ�� �� ������ �׷���.��ġ�� ��� �߱淡 ��ġ�� ����� ? ", 5));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", "�ƴѵ��� �� �Ϸ� 3�� ���� 3�� �̳� 3�� ���� ��ġ ������ �ߴµ� ?\n���� �󸶳� 333 ��Ģ�� �� ��Ű�µ�", 6));
        yield return StartCoroutine(NormalChat("���ΰ�", "��! �׷��� ��ġ�� ������ �ߴµ� ��ġ�� �� ����� ?\n�� ��ġ ���� �� �žƳ� ?\n(�Ӹ���: ���̡� �ƴϰ���....����...)(���� �� �Ҿ�����...)", 7));
        Destroy(transform.parent.gameObject);
    }
}
