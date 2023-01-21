using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story7 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("2-3", "느껴져 오는 불안감"));
        yield return StartCoroutine(NormalChat("주인공", "부적을 모으면 모을수록 너무 힘들어...\n나 이러다가 부적 다 못 모으면 어떡하지 ? "));
        yield return StartCoroutine(NormalChat("건치 요정", "아니야~ 넌 잘하고 있어! 약한 소리 하지맛!"));
        yield return StartCoroutine(NormalChat("주인공", "하지만 너무 불안하단 말이야... 내가 부적을 다 모을 수 있을지도 걱정이고.."));
        yield return StartCoroutine(NormalChat("건치 요정", "그마아아아아안!!! 그런 걱정은 하지 마! 내가 옆에 있잖아!\n우리 둘이 힘을 합친다면 충분히 모든 부적을 모을 수 있어!"));
        yield return StartCoroutine(NormalChat("주인공", "그래!! 난 할 수 있다!!!!"));
    }
}
