using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve;

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
        else if (person == 7)
            original.sprite = seven;
        else if (person == 8)
            original.sprite = eight;
        else if (person == 9)
            original.sprite = nine;
        else if (person == 10)
            original.sprite = ten;
        else if (person == 11)
            original.sprite = eleven;
        else if (person == 12)
            original.sprite = twelve;


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
        yield return StartCoroutine(NormalChat("건치요정", "와....힘들었다.\n너도 고생했어! 덕분에 충치요정을 봉인할 수 있었어", 1));
        yield return StartCoroutine(NormalChat("주인공", "내가 뭘.... 나만 고생했나 너도 고생했지\n그래도 결과적으로 잘돼서 다행이야 ㅎ", 2));
        yield return StartCoroutine(NormalChat("건치요정", "그러게 말이야 ㅎㅎ\n이제 충치요정도 봉인됐으니까 나는 이만 가볼게", 3));
        yield return StartCoroutine(NormalChat("주인공", "벌써??? 조금만 더 있다가 가지...", 4));
        yield return StartCoroutine(NormalChat("건치요정", "나도 마음은 더 있고 싶지만, 충치요정을 봉인하는 데 힘을 너무 많이 써서 내가 원래 있던 세계로 돌아가야 해.\n대신 가기 전에 내가 작은 선물을 주고 갈게", 5));
        yield return StartCoroutine(NormalChat("주인공", "선물??", 6));
        yield return StartCoroutine(NormalChat("건치요정", "자 여기 있어", 7));
        yield return StartCoroutine(NormalChat("", " ", 8));
        yield return StartCoroutine(NormalChat("", "건치요정이 주인공에게 작은 이빨모양 피규어를 건네준다.	", 9));
        MasterAudio.PlaySound("easy ending_8");
        yield return StartCoroutine(NormalChat("주인공", "이게 뭐야?", 9));
        yield return StartCoroutine(NormalChat("건치요정", "나랑 비슷하게 생긴 아주 귀여운 피규어야.\n거기에는 내 힘이 아주 조금 들어있어서 네가 양치를 잘한다면 앞으로\n충치 생기는 일은 없을 거야 ㅎ", 10));
        yield return StartCoroutine(NormalChat("주인공", "고마워 ㅎㅎ 앞으로 잘 지내~~", 11));
        yield return StartCoroutine(NormalChat("", "건치요정은 그렇게 원래 살던 곳으로 떠났다	", 0));
        MasterAudio.PlaySound("easy ending_13");
        yield return StartCoroutine(NormalChat("", "하지만 그들은 몰랐다.... 그것이 끝이 아니라는 것을....  The End...", 0));
        yield return StartCoroutine(NormalChat("", " ", 12));
        Destroy(transform.parent.gameObject);
    }
}
