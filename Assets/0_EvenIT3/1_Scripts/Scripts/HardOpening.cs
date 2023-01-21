using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardOpening : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("", "건치요정이 떠나고 평화로운 나날들이 지속되고 있었다	"));
        yield return StartCoroutine(NormalChat("", "그러던 어느날...	"));
        yield return StartCoroutine(NormalChat("", ""));
        yield return StartCoroutine(NormalChat("앞자리 친구", ""));
        yield return StartCoroutine(NormalChat("주인공", ""));
        yield return StartCoroutine(NormalChat("앞자리 친구", ""));
        yield return StartCoroutine(NormalChat("주인공", ""));
        yield return StartCoroutine(NormalChat("앞자리 친구", ""));
        yield return StartCoroutine(NormalChat("", ""));
        yield return StartCoroutine(NormalChat("", "다 음 날	"));
        yield return StartCoroutine(NormalChat("주인공", "치과 갔다 왔어? 뭐래?"));
        yield return StartCoroutine(NormalChat("앞자리 친구", "응 다녀왔는데 충치가 생겼대"));
        yield return StartCoroutine(NormalChat("주인공", "뭐 ? 평소에 양치를 좀 잘하지 그랬어.양치를 어떻게 했길래 충치가 생기냐 ? "));
        yield return StartCoroutine(NormalChat("앞자리 친구", "아닌데… 나 하루 3번 식후 3분 이내 3분 동안 양치 열심히 했는데 ?\n내가 얼마나 333 법칙을 잘 지키는데"));
        yield return StartCoroutine(NormalChat("주인공", "야! 그렇게 양치를 열심히 했는데 충치가 왜 생기냐 ?\n너 양치 대충 한 거아냐 ?\n(속마음: 에이… 아니겠지....설마...)(뭐지 이 불안함은...)"));
    }
}
