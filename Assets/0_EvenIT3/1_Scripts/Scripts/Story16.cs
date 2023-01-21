using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story16 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("4-4", "����ü ��𰣰ž�??!!!	"));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� �� ȥ�ڼ��� ������... ��ġ������ ������ �ʿ���.\n�� ��ġ�������״� �����۵� �����ϰ�...\n��� ����ü ��𰣰ž� ? !? !�� ���� �ǱԾ��� ��ȣ�����δ� ����ٰ�!!"));
        yield return StartCoroutine(NormalChat("����ġ����", "������ ���� �׸� �����ϴ� �� � ?\n�� ȥ�ڼ��� ���� ���� ����� �� ������ ? "));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ƴ�! �� ���� ���� �� ��!"));
    }
}
