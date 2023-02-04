using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story10 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("3-2", "힘내는 건치 요정!", 0));
        yield return StartCoroutine(NormalChat("건치 요정", "헥...헥...너무 힘들어...", 1));
        yield return StartCoroutine(NormalChat("주인공", "나....나도...", 2));
        yield return StartCoroutine(NormalChat("건치 요정", "그래도 얼마 안남았어!", 3));
        yield return StartCoroutine(NormalChat("주인공", "그래! 얼마 안 남은거 빨리 모아서 해결하자고!\n가자~~!!!", 4));
        Destroy(transform.parent.gameObject);
    }
}
