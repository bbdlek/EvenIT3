using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story14 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("4-2", "남아있는 충치요정의 기운?!	", 0));
        yield return StartCoroutine(NormalChat("주인공", "설마 충치요정...?!? !\n내가 아는 그 충치요정이랑 다르게 생겼는데...", 1));
        yield return StartCoroutine(NormalChat("뉴충치요정", "그렇겠지 나는 니가 아는 그 약해빠진 충치요정이 아니니까\n난 그 녀석보다 훨씬 강하다고! 그런 녀석과 나를 비교하지 마!", 2));
        yield return StartCoroutine(NormalChat("주인공", "아… 알았어\n(속마음: 와… 성질이 아주 고약한데 ?)\n너가 그 녀석보다 더 강하다는 건 알겠는데 왜 이 학교에\n나타난 거야 ? ", 3));
        yield return StartCoroutine(NormalChat("뉴충치요정", "왜 나타났냐고 ? 그런 걸 왜 물어보는 거지 ? 당연히 충치를 퍼트리기 위해서지", 4));
        yield return StartCoroutine(NormalChat("주인공", "도와줘 건치요정!!! 큰일 났어!!! 충치요정이 다시 나타났다구!!!!!", 5));
    }
}
