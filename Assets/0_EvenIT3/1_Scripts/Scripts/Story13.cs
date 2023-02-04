using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story13 : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five;

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
        yield return StartCoroutine(NormalChat("4", "다시 나타난 충치 요정?!	", 0));
        yield return StartCoroutine(NormalChat("4-1", "다시 퍼지는 충치 바이러스..	", 0));
        yield return StartCoroutine(NormalChat("", "앞자리 친구만 생긴 줄 알았던 충치가 다시 학교에 있는 학생들에게 퍼지기\n시작했는데...	", 1));
        yield return StartCoroutine(NormalChat("??요정", "후후, 주인공. 안녕?", 2));
        yield return StartCoroutine(NormalChat("주인공", "너, 누구야! (뭔데 익숙하지?)", 5));
        yield return StartCoroutine(NormalChat("??요정", "나? 내가 누구일 것 같아?", 4));
        yield return StartCoroutine(NormalChat("주인공", "그걸 내가 어떻게 알아! 도대체 정체가 뭐야?", 3));
        yield return StartCoroutine(NormalChat("??요정", "후후후후", 4));
        Destroy(transform.parent.gameObject);
    }
}
