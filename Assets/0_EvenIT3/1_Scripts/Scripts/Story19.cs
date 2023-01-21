using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story19 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("5-3", "건치요정의 행방"));
        yield return StartCoroutine(NormalChat("주인공", "이제는 진짜 나올 때가 됬잖아!!!! 건치요정!!! 어딨어???!!!!!!!"));
        yield return StartCoroutine(NormalChat("뉴충치요정", "아직도 건치요정 타령이라니. 넌 혼자서 할 수 있는 일이 없는건가?"));
        yield return StartCoroutine(NormalChat("주인공", "아니! 지금까지 나 혼자서 잘 싸워왔어! 앞으로도 그럴거고!"));
    }
}
