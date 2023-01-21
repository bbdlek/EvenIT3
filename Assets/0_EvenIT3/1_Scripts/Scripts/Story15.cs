using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story15 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("4-3", "��ġ������ �������?	"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�̻��ϴ١� ��ġ������ �� ���� ����.\n������ ��ġ������ ��Ÿ���ڸ��� ���Ծ��µ�...."));
        yield return StartCoroutine(NormalChat("", "���ΰ��� ��ġ������ ã�� ���� �б��� ����ȹ� �پ�ٳ��.\n������ ��ġ������ ������ �ʰ�..."));
        yield return StartCoroutine(NormalChat("���ΰ�", "��¿ �� ����! �� ȥ�ڼ��� �ϴ� �ο�����!"));
        yield return StartCoroutine(NormalChat("����ġ����", "�� ȥ�ڼ� �� �� �� �ִٴ� ����? �� �� ������ �ѹ� �غ�!"));
    }
}
