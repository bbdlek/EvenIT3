using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    void Start()
    {
        StartCoroutine(Text());
    }

    IEnumerator NormalChat(string narrator, string narration)
    {
        CharacterNameTxt.text = narrator;
        writerTxt = "";

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
        yield return StartCoroutine(NormalChat("건치요정", "와....힘들었다.\n너도 고생했어! 덕분에 충치요정을 봉인할 수 있었어"));
        yield return StartCoroutine(NormalChat("주인공", "내가 뭘.... 나만 고생했나 너도 고생했지\n그래도 결과적으로 잘돼서 다행이야 ㅎ"));
        yield return StartCoroutine(NormalChat("건치요정", "그러게 말이야 ㅎㅎ\n이제 충치요정도 봉인됐으니까 나는 이만 가볼게"));
        yield return StartCoroutine(NormalChat("주인공", "벌써??? 조금만 더 있다가 가지..."));
        yield return StartCoroutine(NormalChat("건치요정", "나도 마음은 더 있고 싶지만, 충치요정을 봉인하는 데 힘을 너무 많이 써서 내가 원래 있던 세계로 돌아가야 해.\n대신 가기 전에 내가 작은 선물을 주고 갈게"));
        yield return StartCoroutine(NormalChat("주인공", "선물??"));
        yield return StartCoroutine(NormalChat("건치요정", "자 여기 있어"));
        yield return StartCoroutine(NormalChat("", "건치요정이 주인공에게 작은 이빨모양 피규어를 건네준다.	"));
        yield return StartCoroutine(NormalChat("주인공", "이게 뭐야?"));
        yield return StartCoroutine(NormalChat("건치요정", "나랑 비슷하게 생긴 아주 귀여운 피규어야.\n거기에는 내 힘이 아주 조금 들어있어서 네가 양치를 잘한다면 앞으로\n충치 생기는 일은 없을 거야 ㅎ"));
        yield return StartCoroutine(NormalChat("주인공", "고마워 ㅎㅎ 앞으로 잘 지내~~"));
        yield return StartCoroutine(NormalChat("", "건치요정은 그렇게 원래 살던 곳으로 떠났다	"));
    }
}
