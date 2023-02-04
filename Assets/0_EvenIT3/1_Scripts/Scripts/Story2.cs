using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Story2 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("1-2", "선생님이 이상하다??", 0));
        yield return StartCoroutine(NormalChat("주인공", "아니 평소에 잘 돌아보지도 않던 선생님이 오늘따라 왜 이렇게 돌아봐?", 1));
        yield return StartCoroutine(NormalChat("건치요정", "그건 충치 요정이 선생님한테 빙의되어있기 때문이야.충치 요정이 빙의되있으면 평소보다 예민하고 화를 다스리기 어려워진다고 해", 2));
        yield return StartCoroutine(NormalChat("주인공", "그럼 내가 알고 있는 선생님이 아닐 수도 있다는 거야?", 1));
        yield return StartCoroutine(NormalChat("건치요정", "그렇지. 그러니까 항상 조심해야 해", 2));
        yield return StartCoroutine(NormalChat("주인공", "그럼 어서 빨리 선생님을 구하러 가야겠어!", 3));
        Destroy(transform.parent.gameObject);
    }
}
