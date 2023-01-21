using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story12 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("3-4", "봉인된 충치 요정"));
        yield return StartCoroutine(NormalChat("주인공", "해치웠나?"));
        yield return StartCoroutine(NormalChat("건치 요정", "그런것 같은데 ? 와아아아 잘했어~~!!!!\n우리가 해냈어!!!"));
        yield return StartCoroutine(NormalChat("주인공", "와아아아아아아아"));
        yield return StartCoroutine(NormalChat("", ""));
        yield return StartCoroutine(NormalChat("", "하지만 그들은 몰랐다.... 그것이 끝이 아니라는 것을....  The End...	"));
    }
}
