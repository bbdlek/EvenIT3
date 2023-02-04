using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story16 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("4-4", "도대체 어디간거야??!!!	", 0));
        yield return StartCoroutine(NormalChat("주인공", "역시 나 혼자서는 무리야... 건치요정의 도움이 필요해.\n저 충치요정한테는 아이템도 안통하고...\n얘는 도대체 어디간거야 ? !? !이 작은 피규어의 가호만으로는 힘들다고!!", 1));
        yield return StartCoroutine(NormalChat("뉴충치요정", "후후후 이제 그만 포기하는 건 어때 ?\n너 혼자서는 절대 나를 상대할 수 없을걸 ? ", 2));
        yield return StartCoroutine(NormalChat("주인공", "아니! 난 절대 포기 안 해!", 3));
        Destroy(transform.parent.gameObject);
    }
}
