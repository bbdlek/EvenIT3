using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story17 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("5", "새로운 충치 요정의 정체	", 0));
        yield return StartCoroutine(NormalChat("5-1", "어딘가 이상한 충치요정", 0));
        yield return StartCoroutine(NormalChat("뉴충치요정", "야! 주인공 너 그런데 333법칙은 잘 지키고 있는거야?", 1));
        yield return StartCoroutine(NormalChat("주인공", "뭐 ? 333법칙 ? 그걸 왜 니가 나한테 물어봐 ?\n넌 충치를 퍼트리기 위해 왔다면서", 2));
        yield return StartCoroutine(NormalChat("뉴충치요정", "...뭐? 아 그렇지", 1));
        yield return StartCoroutine(NormalChat("주인공", "(속마음 : 뭐지? 저 충치요정 뭔가 이상해)", 2));
        Destroy(transform.parent.gameObject);
    }
}
