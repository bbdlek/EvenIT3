using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story19 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("5-3", "��ġ������ ���"));
        yield return StartCoroutine(NormalChat("���ΰ�", "������ ��¥ ���� ���� ���ݾ�!!!! ��ġ����!!! �����???!!!!!!!"));
        yield return StartCoroutine(NormalChat("����ġ����", "������ ��ġ���� Ÿ���̶��. �� ȥ�ڼ� �� �� �ִ� ���� ���°ǰ�?"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ƴ�! ���ݱ��� �� ȥ�ڼ� �� �ο��Ծ�! �����ε� �׷��Ű�!"));
    }
}
