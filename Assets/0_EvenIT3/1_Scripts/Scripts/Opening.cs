using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Opening : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("�����̼�", "������... �� �б����� ���̵��� ��ġ�� ����ް� ����� ��ġ ������ ��� �־��ٴ� ������ �������� �ִµ�..."));
        yield return StartCoroutine(NormalChat("�����̼�", "��� �� �ġ�\n���� �⵵ ��� �� ������ ���� â�� û�Ҹ� �ϴ� ���ΰ�... �Ǽ��� �׾Ƹ��� �����ȴ�\n�����Կ��� ȥ���� �Ⱦ��� ���ΰ��� ���ϰ� ���� �������� ������ ������ ���ư���."));
        yield return StartCoroutine(NormalChat("", "�� �� ��                            "));
        yield return StartCoroutine(NormalChat("", "��ϴµ� ��ħ���� �̰� ���ŰŸ���... ���� ���� ������ ���ǿ� �����ߴµ� �����Ⱑ �̻��ϴ�?"));
        yield return StartCoroutine(NormalChat("", "�� ģ������ ��� ���� ���ΰ� ���뽺�����ϰ� �ִ�?"));
        yield return StartCoroutine(NormalChat("���ΰ�", "(���ڸ� ģ������) ��! ���� ���̾�?"));
        yield return StartCoroutine(NormalChat("���ڸ� ģ��", "���� ���� �б� �����������ΰ�? �׶����� �̰� ����"));
        yield return StartCoroutine(NormalChat("���ΰ�", "(�Ӹ��� : ���� ������ �̻��� )"));
        yield return StartCoroutine(NormalChat("", "�ٸ����� Ȯ���Ϸ� ���� ������ ���ϴµ�..."));
        yield return StartCoroutine(NormalChat("�ٸ� �� ģ��", "��!!! �� ü������ ü�� â���� ����!!!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "����... �� �� �߸��߳�? Ȥ��.... (���� ���߸� �׾Ƹ��� ���ø���)"));
        yield return StartCoroutine(NormalChat("", "ü�� â���� �����ߴµ� �������� ������ �ʴ´�."));
        yield return StartCoroutine(NormalChat("���ΰ�", "���� �� ġ�� �׾Ƹ� ������ �ִ��� Ȯ���� ���߰ڴ�."));
        yield return StartCoroutine(NormalChat("�����", "�߾ƾƾƾƾƾƾƾƾƾƾƾƾƾƾƾƾ�"));
        yield return StartCoroutine(NormalChat("���ΰ�", "�ƾƾƾƾƾƾƾƾӤ� ����!? (���� �ѵ��� ���� �����δ�)"));
        yield return StartCoroutine(NormalChat("��ġ ����", "���!!!!!!!!! ������!!!!!!!!!!!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "���߹��߹���"));
        yield return StartCoroutine(NormalChat("��ġ ����", "�����϶������������! ���� ��ġ �����̶��!!! ���� ���� �װ� �� �׾Ƹ� ������ �� �ڰ� �־��µ� �ῡ�� ���� !!!\n�� �׾Ƹ��� � �׾Ƹ��� �� �˾� ??? ���� ���� ��ġ ������ �����ߴ� �׾Ƹ����!!!\n���� �� ������ �� �б� �������� ��ġ�� ����� �ִ� ���̾�!!!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "��???!!!\n(�ý÷��Ÿ���)�� �׾Ƹ��� �׷��� ���δ� �ž�"));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� �װ� �߿��� �� �ƴϾ�. ��·�� �׾Ƹ��� ������ ��ġ ������ �����. ���� �װ� �ؾ� �� ���� ���� �Բ� ���� \n��ġ ������ �ٽ� �����ϴ� ��!! ���� �ʿ��� ��ġ ������ ��ȣ�� ���� ��ġ�κ��� ������ �״� �ʴ� �� ������\n��ġ ������ ��������!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "!!!!!!!!!!!?  ������:::"));
        yield return StartCoroutine(NormalChat("��ġ ����", "�ʷ� ���� ���۵����� ���� �װ� ������ ���� ������ ������ �ʴ� �� �� �־�!! ���� �Ͼ�!!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "(�Ӹ���: ������ �� �ƴϰ���;;? )\n�׷� �ѹ� �غ���!!"));
        yield return StartCoroutine(NormalChat("��ġ ����", "���� �����ϴ� ����� �˷��ٰ�~\n�� ����� ����!! ���ĺ����� ��� ���ĺ��� ������ ����� �ȴٱ�!"));
        yield return StartCoroutine(NormalChat("���ΰ�", "���ĺ��� ����? ���ٰ�? ��� �ϸ� �Ǵ� �ǵ�?"));
        yield return StartCoroutine(NormalChat("��ġ ����", "��  ����\n����� ��ġ �������� ���� �� �����Ե��� ���� ���� ���� ������ �Ծ ���ĺ��� ������ ������ �� ���� ? !������\n��! ��ġ�� ���� �� �ص� ��! �� �� ��ȣ�� �޾Ƽ� ��ġ�� ������ �ʰŵ�~\n�ѹ� �����غ���"));
    }
}
