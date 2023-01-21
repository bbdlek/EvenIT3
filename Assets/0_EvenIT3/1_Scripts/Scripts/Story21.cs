using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story21 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("6", "\n\n\n                      ��� ���� ����	"));
        yield return StartCoroutine(NormalChat("6-1", "�̰� ����ü ������Ȳ�ΰ���?"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��...���� ��Ų ��ġ������ ���̴°��� ?\n�׸��� �ǰ� �ູ�� ����....\n����ü ���� ����� ?\n�� ? �ٵ� �� ���� ��ġ���� ?? "));
        yield return StartCoroutine(NormalChat("����ġ����", "�������� �׸�!! �׸�!�׸�!�׸�!"));
        yield return StartCoroutine(NormalChat("", "�Ͼ����� �ֺ������� �ٽ� ������� ���ƿԴ�	"));
        yield return StartCoroutine(NormalChat("���ΰ�", "����ü �Ʊ� �� ����� ���������� ?\n�� ��ġ�����̶� ��ġ�����̶� ���� �ִ°ǵ� ? ����...."));
    }
}
