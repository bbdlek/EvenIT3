using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story15 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("4-3", "건치요정이 사라졌다?	", 0));
        yield return StartCoroutine(NormalChat("주인공", "이상하다… 건치요정이 왜 답이 없지.\n저번엔 충치요정이 나타나자마자 나왔었는데....", 1));
        yield return StartCoroutine(NormalChat("", "주인공은 건치요정을 찾기 위해 학교를 사방팔방 뛰어다녔다.\n하지만 건치요정은 보이지 않고...", 2));
        yield return StartCoroutine(NormalChat("주인공", "어쩔 수 없지! 나 혼자서라도 일단 싸워보자!", 3));
        yield return StartCoroutine(NormalChat("뉴충치요정", "너 혼자서 뭘 할 수 있다는 거지? 할 수 있으면 한번 해봐!", 4));
    }
}
