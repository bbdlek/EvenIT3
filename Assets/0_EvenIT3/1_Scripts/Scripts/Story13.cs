using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story13 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("4", "\n\n\n                         다시 나타난 충치 요정?!	"));
        yield return StartCoroutine(NormalChat("4-1", "다시 퍼지는 충치 바이러스..	"));
        yield return StartCoroutine(NormalChat("", "앞자리 친구만 생긴 줄 알았던 충치가 다시 학교에 있는 학생들에게 퍼지기\n시작했는데...	"));
        yield return StartCoroutine(NormalChat("??요정", "후후, 주인공. 안녕?"));
        yield return StartCoroutine(NormalChat("주인공", "너, 누구야! (뭔데 익숙하지?)"));
        yield return StartCoroutine(NormalChat("??요정", "나? 내가 누구일 것 같아?"));
        yield return StartCoroutine(NormalChat("주인공", "그걸 내가 어떻게 알아! 도대체 정체가 뭐야?"));
        yield return StartCoroutine(NormalChat("??요정", "후후후후"));
    }
}
