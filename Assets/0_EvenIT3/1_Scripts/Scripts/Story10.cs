using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story10 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("3-2", "힘내는 건치 요정!"));
        yield return StartCoroutine(NormalChat("건치 요정", "헥...헥...너무 힘들어..."));
        yield return StartCoroutine(NormalChat("주인공", "나....나도..."));
        yield return StartCoroutine(NormalChat("건치 요정", "그래도 얼마 안남았어!"));
        yield return StartCoroutine(NormalChat("주인공", "그래! 얼마 안 남은거 빨리 모아서 해결하자고!\n가자~~!!!"));
    }
}
