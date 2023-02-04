using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story6 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three;

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
        yield return StartCoroutine(NormalChat("2-2", "아슬아슬 위태로운 줄타기", 0));
        yield return StartCoroutine(NormalChat("주인공", "와....위험했다...", 1));
        yield return StartCoroutine(NormalChat("건치 요정", "그러게, 보는 내가 더 조마조마하더라.\n그래도 잘하고 있어! 역시 너한테 맡기길 잘했어 ㅎㅎ", 2));
        yield return StartCoroutine(NormalChat("주인공", "(부끄러워하며) 그러지마아~ 부끄럽잖아~빨리 부적 모으러 가자!", 3));
        Destroy(transform.parent.gameObject);
    }
}
