using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story11 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("3-3", "��ġ ������ ������ �߾�", 0));
        yield return StartCoroutine(NormalChat("���ΰ�", "��... �������", 1));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� ��¥ �� ���� �ʾҾ�..!! ���ݸ� ������!", 2));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� �̴�� ���ϰ� ���� �� ���� ???\n���ƾ�!! ��� �ν������ھ�!!", 3));
        yield return StartCoroutine(NormalChat("���ΰ�, ��ġ ����", "�ȵſ���������������!!! ����!!!!", 4));
        Destroy(transform.parent.gameObject);
    }
}
