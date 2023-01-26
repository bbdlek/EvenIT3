using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story4 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two;

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
        yield return StartCoroutine(NormalChat("1-4", "점점 자라나는 자신감", 0));
        yield return StartCoroutine(NormalChat("주인공", "봤어? 봤어? 나 어땠어? 잘하지?", 1));
        yield return StartCoroutine(NormalChat("건치요정", "응 봤어! 앞으로 계속 그렇게 하면 돼. 어때? 내가 쉽다고 했지?", 2));
        yield return StartCoroutine(NormalChat("주인공", "쉽지는 않았지만 이젠 요령을 좀 터득했어.\n부적을 모으는 건 시간문제야!", 1));
    }
}
