using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story20 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("5-4", "충치요정과 건치요정"));
        yield return StartCoroutine(NormalChat("주인공", "휴...거의 다 모아간다"));
        yield return StartCoroutine(NormalChat("뉴충치요정", "윽...너 왜자꾸 나를 방해하는건데!!!!!!! (폭주하는 뉴 충치요정)"));
        yield return StartCoroutine(NormalChat("", "뉴 충치요정이 폭주하자  주변이 하얘졌고 주인공 눈 앞에 뭔가 흐릿하게 보이기 시작하는데	"));
        yield return StartCoroutine(NormalChat("주인공", "저게 뭐지? 전에 내가 봤던 충치요정???"));
    }
}
