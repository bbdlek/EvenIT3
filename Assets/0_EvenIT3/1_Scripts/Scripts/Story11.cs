using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story11 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("3-3", "충치 요정의 마지막 발악"));
        yield return StartCoroutine(NormalChat("주인공", "휴... 힘들었다"));
        yield return StartCoroutine(NormalChat("건치 요정", "이제 진짜 얼마 남지 않았어..!! 조금만 힘내자!"));
        yield return StartCoroutine(NormalChat("충치 요정", "내가 이대로 당하고만 있을 것 같아 ???\n으아악!! 모두 부숴버리겠어!!"));
        yield return StartCoroutine(NormalChat("주인공, 건치 요정", "안돼에에에에에에에에!!! 멈춰!!!!"));
    }
}
