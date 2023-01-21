using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story22 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("6-2", "두둥! 밝혀진 진실!"));
        yield return StartCoroutine(NormalChat("주인공", "설마 너 건치요정이야 ?\n아까 333법칙 말하는것도 이상했고 너 이상한거 투성이야!"));
        yield return StartCoroutine(NormalChat("뉴충치요정", "뭐 ? 무슨 소리를 하는 거야!\n나는 충치..요..정..인데....어 ? "));
        yield return StartCoroutine(NormalChat("", "뉴충치요정이 갑자기 머리를 부여잡고 괴로워한다	"));
        yield return StartCoroutine(NormalChat("뉴충치요정", "사...살려줘 주인공....날 좀 구해줘..."));
    }
}
