using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story5 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("2", "충치요정의 발악	", 0));
        yield return StartCoroutine(NormalChat("2-1", "강력해진 충치 요정	", 0));
        yield return StartCoroutine(NormalChat("주인공", "뭐야?!! 갑자기 선생님이 더 이상해졌는데?", 1));
        yield return StartCoroutine(NormalChat("건치 요정", "어떻게...충치 요정의 힘이 생각보다 너무 빠르게 강해지는 것 같아", 2));
        yield return StartCoroutine(NormalChat("주인공", "그럼 어떡해?", 3));
        yield return StartCoroutine(NormalChat("건치 요정", "우리가 할 수 있는 것은 부적을 모으는 것뿐이야!\n그래도 부적을 모으면 버프를 받을 수 있으니까 그나마 다행이야.\n빨리 가자! 더 늦어지면 위험해!", 4));
    }
}
