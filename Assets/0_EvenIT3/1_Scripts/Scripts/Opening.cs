using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Opening : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen, twenty, twentyone, twentytwo;

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
        else if (person == 6)
            original.sprite = six;
        else if (person == 7)
            original.sprite = seven;
        else if (person == 8)
            original.sprite = eight;
        else if (person == 9)
            original.sprite = nine;
        else if (person == 10)
            original.sprite = ten;

        else if (person == 11)
            original.sprite = eleven;
        else if (person == 12)
            original.sprite = twelve;
        else if (person == 13)
            original.sprite = thirteen;
        else if (person == 14)
            original.sprite = fourteen;
        else if (person == 15)
            original.sprite = fifteen;
        else if (person == 16)
            original.sprite = sixteen;
        else if (person == 17)
            original.sprite = seventeen;
        else if (person == 18)
            original.sprite = eighteen;
        else if (person == 19)
            original.sprite = nineteen;
        else if (person == 20)
            original.sprite = twenty;

        else if (person == 21)
            original.sprite = twentyone;
        else if (person == 22)
            original.sprite = twentytwo;

        for (int i = 0; i < narration.Length; i++)
        {
            writerTxt += narration[i];
            ChatTxt.text = writerTxt;
            yield return null;
        }

        while(true)
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
        yield return StartCoroutine(NormalChat("�����̼�", "������... �� �б����� ���̵��� ��ġ�� ����ް� ����� ��ġ ������ ��� �־��ٴ� ������ �������� �ִµ�...", 0));
        yield return StartCoroutine(NormalChat("�����̼�", "��� �� �ġ�", 2));
        yield return StartCoroutine(NormalChat("�����̼�", "���� �⵵ ��� �� ������ ���� â�� û�Ҹ� �ϴ� ���ΰ�... �Ǽ��� �׾Ƹ��� �����ȴ�", 2));
        yield return StartCoroutine(NormalChat("", " ", 3));
        yield return StartCoroutine(NormalChat("�����̼�", "�����Կ��� ȥ���� �Ⱦ��� ���ΰ��� ���ϰ� ���� �������� ������ ������ ���ư���.", 2));
        yield return StartCoroutine(NormalChat("", "�� �� ��                            ", 0));
        yield return StartCoroutine(NormalChat("", "��ϴµ� ��ħ���� �̰� ���ŰŸ���... ���� ���� ������ ���ǿ� �����ߴµ� �����Ⱑ �̻��ϴ�?", 4));
        yield return StartCoroutine(NormalChat("", "�� ģ������ ��� ���� ���ΰ� ���뽺�����ϰ� �ִ�?", 5));
        yield return StartCoroutine(NormalChat("���ΰ�", "(���ڸ� ģ������) ��! ���� ���̾�?", 6));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", "���� ���� �б� �����������ΰ�? �׶����� �̰� ����", 7));
        yield return StartCoroutine(NormalChat("���ΰ�", "(�Ӹ��� : ���� ������ �̻��� )", 8));
        yield return StartCoroutine(NormalChat("", "�ٸ����� Ȯ���Ϸ� ���� ������ ���ϴµ�...", 9));
        yield return StartCoroutine(NormalChat("�ٸ� �� ģ��", "��!!! �� ü������ ü�� â���� ����!!!", 10));
        yield return StartCoroutine(NormalChat("���ΰ�", "����... �� �� �߸��߳�? Ȥ��.... (���� ���߸� �׾Ƹ��� ���ø���)", 8));
        yield return StartCoroutine(NormalChat("", "ü�� â���� �����ߴµ� �������� ������ �ʴ´�.", 2));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� �� ġ�� �׾Ƹ� ������ �ִ��� Ȯ���� ���߰ڴ�.", 9));
        yield return StartCoroutine(NormalChat("�����", "�߾ƾƾƾƾƾƾƾƾƾƾƾƾƾƾƾƾ�", 10));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ƾƾƾƾƾƾƾƾӤ� ����!? (���� �ѵ��� ���� �����δ�)", 11));
        yield return StartCoroutine(NormalChat("��ġ ����", "���!!!!!!!!! ������!!!!!!!!!!!", 12));
        yield return StartCoroutine(NormalChat("���ΰ�", "���߹��߹���", 13));
        yield return StartCoroutine(NormalChat("��ġ ����", "�����϶������������! ���� ��ġ �����̶��!!! ���� ���� �װ� �� �׾Ƹ� ������ �� �ڰ� �־��µ� �ῡ�� ���� !!!\n�� �׾Ƹ��� � �׾Ƹ��� �� �˾� ??? ���� ���� ��ġ ������ �����ߴ� �׾Ƹ����!!!\n���� �� ������ �� �б� �������� ��ġ�� ����� �ִ� ���̾�!!!", 14));
        yield return StartCoroutine(NormalChat("���ΰ�", "��???!!!\n(�ý÷��Ÿ���)�� �׾Ƹ��� �׷��� ���δ� �ž�", 15));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� �װ� �߿��� �� �ƴϾ�. ��·�� �׾Ƹ��� ������ ��ġ ������ �����. ���� �װ� �ؾ� �� ���� ���� �Բ� ���� \n��ġ ������ �ٽ� �����ϴ� ��!! ���� �ʿ��� ��ġ ������ ��ȣ�� ���� ��ġ�κ��� ������ �״� �ʴ� �� ������\n��ġ ������ ��������!", 16));
        yield return StartCoroutine(NormalChat("���ΰ�", "!!!!!!!!!!!?  ������:::", 17));
        yield return StartCoroutine(NormalChat("��ġ ����", "�ʷ� ���� ���۵����� ���� �װ� ������ ���� ������ ������ �ʴ� �� �� �־�!! ���� �Ͼ�!!", 18));
        yield return StartCoroutine(NormalChat("���ΰ�", "(�Ӹ���: ������ �� �ƴϰ���;;? )\n�׷� �ѹ� �غ���!!", 19));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� �����ϴ� ����� �˷��ٰ�~\n�� ����� ����!! ���ĺ����� ��� ���ĺ��� ������ ����� �ȴٱ�!", 20));
        yield return StartCoroutine(NormalChat("���ΰ�", "���ĺ��� ����? ���ٰ�? ��� �ϸ� �Ǵ� �ǵ�?", 21));
        yield return StartCoroutine(NormalChat("��ġ ����", "��  ����\n����� ��ġ �������� ���� �� �����Ե��� ���� ���� ���� ������ �Ծ ���ĺ��� ������ ������ �� ���� ? !������\n��! ��ġ�� ���� �� �ص� ��! �� �� ��ȣ�� �޾Ƽ� ��ġ�� ������ �ʰŵ�~\n�ѹ� �����غ���", 22));
    }
}
