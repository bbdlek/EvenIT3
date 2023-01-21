using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Story2 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("1-2", "�������� �̻��ϴ�??"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ƴ� ��ҿ� �� ���ƺ����� �ʴ� �������� ���õ��� �� �̷��� ���ƺ�?"));
        yield return StartCoroutine(NormalChat("��ġ����", "�װ� ��ġ ������ ���������� ���ǵǾ��ֱ� �����̾�.��ġ ������ ���ǵ������� ��Һ��� �����ϰ� ȭ�� �ٽ����� ��������ٰ� ��"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷� ���� �˰� �ִ� �������� �ƴ� ���� �ִٴ� �ž�?"));
        yield return StartCoroutine(NormalChat("��ġ����", "�׷���. �׷��ϱ� �׻� �����ؾ� ��"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷� � ���� �������� ���Ϸ� ���߰ھ�!"));
    }
}
