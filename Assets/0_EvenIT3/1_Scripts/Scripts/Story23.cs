using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story23 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("6-3", "알수없는 진실"));
        yield return StartCoroutine(NormalChat("주인공", "건치요정!! 이게 어떻게 된 일이야!\n너가 왜 충치요정이 된거야!"));
        yield return StartCoroutine(NormalChat("", "뉴충치요정은 머리를 부여잡고 계속 괴로워하고있다	"));
        yield return StartCoroutine(NormalChat("주인공", "대답 좀 해봐!!! 뭐라고 말을 해보라고!!!\n(속마음: 안되겠다 어서 부적을 모아서 봉인을 하면 무슨일이 일어날거야)"));
    }
}
