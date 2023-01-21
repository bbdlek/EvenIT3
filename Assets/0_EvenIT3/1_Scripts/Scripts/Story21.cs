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
        yield return StartCoroutine(NormalChat("6", "\n\n\n                      상상도 못한 진실	"));
        yield return StartCoroutine(NormalChat("6-1", "이게 도대체 무슨상황인거지?"));
        yield return StartCoroutine(NormalChat("주인공", "왜...봉인 시킨 충치요정이 보이는거지 ?\n그리고 되게 행복해 보여....\n도대체 여긴 어딜까 ?\n응 ? 근데 저 옆은 건치요정 ?? "));
        yield return StartCoroutine(NormalChat("뉴충치요정", "으으으으 그만!! 그만!그만!그만!"));
        yield return StartCoroutine(NormalChat("", "하얘졌던 주변공간이 다시 원래대로 돌아왔다	"));
        yield return StartCoroutine(NormalChat("주인공", "도대체 아까 그 장면은 뭐였던거지 ?\n왜 충치요정이랑 건치요정이랑 같이 있는건데 ? 설마...."));
    }
}
