using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("��ġ����", "��....�������.\n�ʵ� ����߾�! ���п� ��ġ������ ������ �� �־���"));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� ��.... ���� ����߳� �ʵ� �������\n�׷��� ��������� �ߵż� �����̾� ��"));
        yield return StartCoroutine(NormalChat("��ġ����", "�׷��� ���̾� ����\n���� ��ġ������ ���ε����ϱ� ���� �̸� ������"));
        yield return StartCoroutine(NormalChat("���ΰ�", "����??? ���ݸ� �� �ִٰ� ����..."));
        yield return StartCoroutine(NormalChat("��ġ����", "���� ������ �� �ְ� ������, ��ġ������ �����ϴ� �� ���� �ʹ� ���� �Ἥ ���� ���� �ִ� ����� ���ư��� ��.\n��� ���� ���� ���� ���� ������ �ְ� ����"));
        yield return StartCoroutine(NormalChat("���ΰ�", "����??"));
        yield return StartCoroutine(NormalChat("��ġ����", "�� ���� �־�"));
        yield return StartCoroutine(NormalChat("", "��ġ������ ���ΰ����� ���� �̻���� �ǱԾ �ǳ��ش�.	"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�̰� ����?"));
        yield return StartCoroutine(NormalChat("��ġ����", "���� ����ϰ� ���� ���� �Ϳ��� �ǱԾ��.\n�ű⿡�� �� ���� ���� ���� ����־ �װ� ��ġ�� ���Ѵٸ� ������\n��ġ ����� ���� ���� �ž� ��"));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� ���� ������ �� ����~~"));
        yield return StartCoroutine(NormalChat("", "��ġ������ �׷��� ���� ��� ������ ������	"));
    }
}
