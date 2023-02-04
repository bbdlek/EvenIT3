using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story9 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four;


    void Start()
    {
        StartCoroutine(Text());
    }

    IEnumerator NormalChat(string narrator, string narration, int person)
    {
        CharacterNameTxt.text = narrator;
        writerTxt = "";

        if (person == 1)
            original.sprite = one;
        else if (person == 2)
            original.sprite = two;
        else if (person == 3)
            original.sprite = three;
        else if (person == 4)
            original.sprite = four;

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
        yield return StartCoroutine(NormalChat("3", "결전, 충치 요정을 봉인해라!	", 0));
        yield return StartCoroutine(NormalChat("3-1", "건치 요정의 위기?", 0));
        yield return StartCoroutine(NormalChat("주인공", "자... 잠깐만.... 이건 너무 말도 안되잖아!", 1));
        yield return StartCoroutine(NormalChat("건치 요정", "그만큼 충치 요정의 힘도 커졌다는 거야.\n거기다 충치 요정한테 들켜서 더 힘을 쓰기가 어려워...", 2));
        yield return StartCoroutine(NormalChat("주인공", "힘을 쓰기가 어렵다니? 어떻게 좀 해봐!", 3));
        yield return StartCoroutine(NormalChat("건치 요정", "나도 노력하고 있단 말이야!!!", 4));
        Destroy(transform.parent.gameObject);
    }
}
