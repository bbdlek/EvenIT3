using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardOpening : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("", "��ġ������ ������ ��ȭ�ο� �������� ���ӵǰ� �־���	"));
        yield return StartCoroutine(NormalChat("", "�׷��� �����...	"));
        yield return StartCoroutine(NormalChat("", ""));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", ""));
        yield return StartCoroutine(NormalChat("���ΰ�", ""));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", ""));
        yield return StartCoroutine(NormalChat("���ΰ�", ""));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", ""));
        yield return StartCoroutine(NormalChat("", ""));
        yield return StartCoroutine(NormalChat("", "�� �� ��	"));
        yield return StartCoroutine(NormalChat("���ΰ�", "ġ�� ���� �Ծ�? ����?"));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", "�� �ٳ�Դµ� ��ġ�� �����"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�� ? ��ҿ� ��ġ�� �� ������ �׷���.��ġ�� ��� �߱淡 ��ġ�� ����� ? "));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", "�ƴѵ��� �� �Ϸ� 3�� ���� 3�� �̳� 3�� ���� ��ġ ������ �ߴµ� ?\n���� �󸶳� 333 ��Ģ�� �� ��Ű�µ�"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��! �׷��� ��ġ�� ������ �ߴµ� ��ġ�� �� ����� ?\n�� ��ġ ���� �� �žƳ� ?\n(�Ӹ���: ���̡� �ƴϰ���....����...)(���� �� �Ҿ�����...)"));
    }
}
