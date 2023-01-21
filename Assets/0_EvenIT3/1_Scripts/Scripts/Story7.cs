using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story7 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("2-3", "������ ���� �ҾȰ�"));
        yield return StartCoroutine(NormalChat("���ΰ�", "������ ������ �������� �ʹ� �����...\n�� �̷��ٰ� ���� �� �� ������ ����� ? "));
        yield return StartCoroutine(NormalChat("��ġ ����", "�ƴϾ�~ �� ���ϰ� �־�! ���� �Ҹ� ������!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "������ �ʹ� �Ҿ��ϴ� ���̾�... ���� ������ �� ���� �� �������� �����̰�.."));
        yield return StartCoroutine(NormalChat("��ġ ����", "�׸��ƾƾƾƾ�!!! �׷� ������ ���� ��! ���� ���� ���ݾ�!\n�츮 ���� ���� ��ģ�ٸ� ����� ��� ������ ���� �� �־�!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷�!! �� �� �� �ִ�!!!!"));
    }
}
