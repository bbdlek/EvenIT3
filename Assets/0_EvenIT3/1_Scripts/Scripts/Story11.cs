using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story11 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("3-3", "��ġ ������ ������ �߾�"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��... �������"));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� ��¥ �� ���� �ʾҾ�..!! ���ݸ� ������!"));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� �̴�� ���ϰ� ���� �� ���� ???\n���ƾ�!! ��� �ν������ھ�!!"));
        yield return StartCoroutine(NormalChat("���ΰ�, ��ġ ����", "�ȵſ���������������!!! ����!!!!"));
    }
}
