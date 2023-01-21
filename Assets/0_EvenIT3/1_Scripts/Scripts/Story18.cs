using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story18 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("5-2", "외로운 싸움"));
        yield return StartCoroutine(NormalChat("주인공", "하.....이번에도 어찌저찌 넘어갔다...혼자서 하려니까 너무 힘드네..."));
        yield return StartCoroutine(NormalChat("뉴충치요정", "크크크 너 혼자서 진짜 해낼 수 있다고 생각하나 ?\n그런 헛된 희망은 버려!"));
        yield return StartCoroutine(NormalChat("주인공", "아니야! 난 할 수 있다고! 두고봐 넌 내가 봉인 시키겠어!"));
    }
}
