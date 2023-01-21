using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story14 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("4-2", "�����ִ� ��ġ������ ���?!	"));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� ��ġ����...?!? !\n���� �ƴ� �� ��ġ�����̶� �ٸ��� ����µ�..."));
        yield return StartCoroutine(NormalChat("����ġ����", "�׷����� ���� �ϰ� �ƴ� �� ���غ��� ��ġ������ �ƴϴϱ�\n�� �� �༮���� �ξ� ���ϴٰ�! �׷� �༮�� ���� ������ ��!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ơ� �˾Ҿ�\n(�Ӹ���: �͡� ������ ���� ����ѵ� ?)\n�ʰ� �� �༮���� �� ���ϴٴ� �� �˰ڴµ� �� �� �б���\n��Ÿ�� �ž� ? "));
        yield return StartCoroutine(NormalChat("����ġ����", "�� ��Ÿ���İ� ? �׷� �� �� ����� ���� ? �翬�� ��ġ�� ��Ʈ���� ���ؼ���"));
        yield return StartCoroutine(NormalChat("���ΰ�", "������ ��ġ����!!! ū�� ����!!! ��ġ������ �ٽ� ��Ÿ���ٱ�!!!!!"));
    }
}
