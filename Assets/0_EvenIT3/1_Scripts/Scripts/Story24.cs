using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story24 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("6-4", "최후의 결전(마지막 결투)"));
        yield return StartCoroutine(NormalChat("주인공", "뉴충치요정 이 부적을 받아라!!!!!!"));
        yield return StartCoroutine(NormalChat("건치요정", "싫어!! 저리가!!! 저리가란말이야!!!"));
        yield return StartCoroutine(NormalChat("주인공", "아니.난 절대 물러설 수 없어!\n기다려 건치요정! 내가 널 꼭 구해줄게!!"));
        yield return StartCoroutine(NormalChat("건치요정", "으아아아아아아!!!"));
    }
}
