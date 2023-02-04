using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.UI;

public class Story21 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five;

    void Start()
    {
        StartCoroutine(Text());
    }

    IEnumerator NormalChat(string narrator, string narration, int person)
    {
        CharacterNameTxt.text = narrator;
        writerTxt = "";

        if (person == 1)
            original.sprite = one;
        else if (person == 2)
            original.sprite = two;
        else if (person == 3)
            original.sprite = three;
        else if (person == 4)
            original.sprite = four;
        else if (person == 5)
            original.sprite = five;

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
        yield return StartCoroutine(NormalChat("6", "��� ���� ����	", 0));
        yield return StartCoroutine(NormalChat("6-1", "�̰� ����ü ������Ȳ�ΰ���?", 0));
        yield return StartCoroutine(NormalChat("���ΰ�", "��...���� ��Ų ��ġ������ ���̴°��� ?\n�׸��� �ǰ� �ູ�� ����....\n����ü ���� ����� ?\n�� ? �ٵ� �� ���� ��ġ���� ?? ", 1));
        yield return StartCoroutine(NormalChat("����ġ����", "�������� �׸�!! �׸�!�׸�!�׸�!", 2));
        yield return StartCoroutine(NormalChat("", " ", 3));
        yield return StartCoroutine(NormalChat("", " ", 4));
        MasterAudio.PlaySound("6-1_3");
        yield return StartCoroutine(NormalChat("", "�Ͼ����� �ֺ������� �ٽ� ������� ���ƿԴ�	", 5));
        yield return StartCoroutine(NormalChat("���ΰ�", "����ü �Ʊ� �� ����� ���������� ?\n�� ��ġ�����̶� ��ġ�����̶� ���� �ִ°ǵ� ? ����....", 5));
        Destroy(transform.parent.gameObject);
    }
}
