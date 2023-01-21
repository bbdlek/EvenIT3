using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story20 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("5-4", "��ġ������ ��ġ����"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��...���� �� ��ư���"));
        yield return StartCoroutine(NormalChat("����ġ����", "��...�� ���ڲ� ���� �����ϴ°ǵ�!!!!!!! (�����ϴ� �� ��ġ����)"));
        yield return StartCoroutine(NormalChat("", "�� ��ġ������ ��������  �ֺ��� �Ͼ����� ���ΰ� �� �տ� ���� �帴�ϰ� ���̱� �����ϴµ�	"));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� ����? ���� ���� �ô� ��ġ����???"));
    }
}
