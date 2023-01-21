using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story8 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("2-4", "충치 요정에게 들킨 건치 요정"));
        yield return StartCoroutine(NormalChat("충치 요정", "아니, 너는 건치요정...? 네가 감히...!! 네가 어떻게 나한테...!!"));
        yield return StartCoroutine(NormalChat("건치 요정", "앗! 들켰잖아. 이제 그만해, 충치 요정!"));
        yield return StartCoroutine(NormalChat("충치 요정", "내가 왜 그만둬야 하지?"));
        yield return StartCoroutine(NormalChat("건치 요정", "사람들이 충치로 괴로워하는 거 안 보여?"));
        yield return StartCoroutine(NormalChat("충치 요정", "흐음....내가 왜 저 사람들의 고통을 생각해줘야 하는 거지 ?\n난 잘 모르겠는데 말이지..."));
        yield return StartCoroutine(NormalChat("주인공", "야!!! 충치가 얼마나 아픈 줄 알아??? 너 일로 와!!"));
        yield return StartCoroutine(NormalChat("건치 요정", "둘다 그마아아아아안!"));
    }
}
