using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story3 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("1-3", "본격적인 선생님들의 방해"));
        yield return StartCoroutine(NormalChat("주인공", "와... 선생님들이 다 너무 이상한데?"));
        yield return StartCoroutine(NormalChat("건치요정", "충치 요정의 힘이 강해지고 있다는 신호야..."));
        yield return StartCoroutine(NormalChat("주인공", "그럼 어떡해?"));
        yield return StartCoroutine(NormalChat("건치요정", "충치 요정이 더 강해지기 전에 얼른 부적을 모아 봉인을 해야 해.\n지금 이렇게 노닥거릴 시간이 없어!!! 어서 부적 모으러 가자!"));
    }
}
