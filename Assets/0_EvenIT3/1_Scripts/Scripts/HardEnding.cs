using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardEnding : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("", "\n\n\n                    ���� - ���ƿ� ��ġ����	"));
        yield return StartCoroutine(NormalChat("���ΰ�", "(�ݰ��� ����, ����� ������ �긮�� )��ġ����..!!"));
        yield return StartCoroutine(NormalChat("��ġ����", "����, ���ΰ�. �� ���п� ���� ���� �� �־���."));
        yield return StartCoroutine(NormalChat("���ΰ�", "����... �������... �ٽ� ���ƿͼ� �����̾�...(����...)"));
        yield return StartCoroutine(NormalChat("��ġ����", "(��Ȳ, ���ΰ��� �޷���) �̾���... ��¿ ���� ������...\n��ġ������ ���� �Ǳ� ���� ���� ����� �ְ� ���� ����..."));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ٵ� ���� �Ʊ� �Ͼ�������� �̻��� ����� �ôµ�...\n�ʶ� ��ġ�����̶� �������� ��¸���̾���..."));
        yield return StartCoroutine(NormalChat("��ġ����", "��....�׷� �����׶�� ���ص� ��������.\n���� ���� ��ġ������ ����������� �Բ� ��� �Ҳ�ģ������.\n�׷��� ����� ��ġ������ � å�� �д��� �µ��� 180�� �ٲ��\n��ġ�� �۶߸��� �ٳ��...���� ������ ��å�� ����å���� ����...\n������ ���� ��ġ������ �ٸ�������� �������°� �� �� ���\n�����ϴ� ����� �����Ѱž�"));
        yield return StartCoroutine(NormalChat("���ΰ�", "(����...���ΰ��� ������ ��ġ������ ��ڿ��ش�)"));
        yield return StartCoroutine(NormalChat("", "���ΰ��� ��ġ������ �ѵ��� ������ �ϴø� �ٶ󺸰��־���...	"));
        yield return StartCoroutine(NormalChat("", "�� 1�ð��� ���� �� ��ġ������ õõ�� ���� ������	"));
        yield return StartCoroutine(NormalChat("��ġ����", "�� ���� ������ �Ұ� ����"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��? ���� �� �ִٰ� ����..."));
        yield return StartCoroutine(NormalChat("��ġ����", "�ƴ� ������ ��¥ ���ư�����.\n�� �׾Ƹ��� ���� ������ ���� �׷� ������ ��ġ������ ������ Ǯ���� ���� �����ž�.\n�׷� ���־�...��ġ �� ���ϰ�!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷�, �ʵ� ������!"));
        yield return StartCoroutine(NormalChat("", "The End	"));
    }
}
