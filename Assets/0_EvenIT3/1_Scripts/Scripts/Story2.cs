using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Story2 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three;

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
        yield return StartCoroutine(NormalChat("1-2", "�������� �̻��ϴ�??", 0));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ƴ� ��ҿ� �� ���ƺ����� �ʴ� �������� ���õ��� �� �̷��� ���ƺ�?", 1));
        yield return StartCoroutine(NormalChat("��ġ����", "�װ� ��ġ ������ ���������� ���ǵǾ��ֱ� �����̾�.��ġ ������ ���ǵ������� ��Һ��� �����ϰ� ȭ�� �ٽ����� ��������ٰ� ��", 2));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷� ���� �˰� �ִ� �������� �ƴ� ���� �ִٴ� �ž�?", 1));
        yield return StartCoroutine(NormalChat("��ġ����", "�׷���. �׷��ϱ� �׻� �����ؾ� ��", 2));
        yield return StartCoroutine(NormalChat("���ΰ�", "�׷� � ���� �������� ���Ϸ� ���߰ھ�!", 3));
        Destroy(transform.parent.gameObject);
    }
}
