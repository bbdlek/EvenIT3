using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story8 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six;

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
        else if (person == 5)
            original.sprite = five;
        else if (person == 6)
            original.sprite = six;

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
        yield return StartCoroutine(NormalChat("2-4", "충치 요정에게 들킨 건치 요정", 0));
        yield return StartCoroutine(NormalChat("충치 요정", "아니, 너는 건치요정...? 네가 감히...!! 네가 어떻게 나한테...!!", 1));
        yield return StartCoroutine(NormalChat("건치 요정", "앗! 들켰잖아. 이제 그만해, 충치 요정!", 2));
        yield return StartCoroutine(NormalChat("충치 요정", "내가 왜 그만둬야 하지?", 3));
        yield return StartCoroutine(NormalChat("건치 요정", "사람들이 충치로 괴로워하는 거 안 보여?", 4));
        yield return StartCoroutine(NormalChat("충치 요정", "흐음....내가 왜 저 사람들의 고통을 생각해줘야 하는 거지 ?\n난 잘 모르겠는데 말이지...", 3));
        yield return StartCoroutine(NormalChat("주인공", "야!!! 충치가 얼마나 아픈 줄 알아??? 너 일로 와!!", 5));
        yield return StartCoroutine(NormalChat("건치 요정", "둘다 그마아아아아안!", 6));
    }
}
