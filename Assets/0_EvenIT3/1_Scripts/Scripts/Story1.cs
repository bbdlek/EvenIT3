using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Story1 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("1", "충치요정의 등장", 0));
        yield return StartCoroutine(NormalChat("1-1", "충치요정을 봉인하라!", 0));
        yield return StartCoroutine(NormalChat("", "주인공 버프/ 먹을 때 보호해줌", 1));
        yield return StartCoroutine(NormalChat("건치요정", "어때? 쉽지?", 2));
        yield return StartCoroutine(NormalChat("주인공", "쉽다고???!!! 이게 어디 봐서 쉬운 거야!!", 3));
        yield return StartCoroutine(NormalChat("건치요정", "왜? 간식만 먹으면 되잖아", 4));
        yield return StartCoroutine(NormalChat("주인공", "그럼 너가 하던가!!", 3));
        yield return StartCoroutine(NormalChat("건치요정", "(슬픈척하며) 하지만 나는 학생이 아닌걸.... 내가 사람이었으면 직접했겠지....\n이건 너만이 할 수 있는 일이야.", 5));
        yield return StartCoroutine(NormalChat("주인공", "(속마음 : 나만 할 수 있는 일? 오, 뭐야 나 멋있잖아!)\n한번 해볼게!!", 6));
    }
}
