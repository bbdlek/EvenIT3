using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story9 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("3", "\n\n\n                                                            ����, ��ġ ������ �����ض�!	"));
        yield return StartCoroutine(NormalChat("3-1", "��ġ ������ ����?"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��... ���.... �̰� �ʹ� ���� �ȵ��ݾ�!"));
        yield return StartCoroutine(NormalChat("��ġ ����", "�׸�ŭ ��ġ ������ ���� Ŀ���ٴ� �ž�.\n�ű�� ��ġ �������� ���Ѽ� �� ���� ���Ⱑ �����..."));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� ���Ⱑ ��ƴٴ�? ��� �� �غ�!"));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� ����ϰ� �ִ� ���̾�!!!"));
    }
}
