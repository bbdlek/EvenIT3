using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.UI;

public class Story20 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four;

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
        yield return StartCoroutine(NormalChat("5-4", "��ġ������ ��ġ����", 0));
        yield return StartCoroutine(NormalChat("���ΰ�", "��...���� �� ��ư���", 1));
        yield return StartCoroutine(NormalChat("����ġ����", "��...�� ���ڲ� ���� �����ϴ°ǵ�!!!!!!! (�����ϴ� �� ��ġ����)", 2));
        yield return StartCoroutine(NormalChat("", " ", 3));
        MasterAudio.PlaySound("5-4_3");
        yield return StartCoroutine(NormalChat("", "�� ��ġ������ ��������  �ֺ��� �Ͼ����� ���ΰ� �� �տ� ���� �帴�ϰ� ���̱� �����ϴµ�	", 4));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� ����? ���� ���� �ô� ��ġ����???", 4));
        Destroy(transform.parent.gameObject);
    }
}
