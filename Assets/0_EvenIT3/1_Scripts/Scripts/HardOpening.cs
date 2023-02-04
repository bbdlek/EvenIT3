using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.UI;

public class HardOpening : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six, seven;

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
        yield return StartCoroutine(NormalChat("", "건치요정이 떠나고 평화로운 나날들이 지속되고 있었다	", 0));
        yield return StartCoroutine(NormalChat("", "그러던 어느날...	", 0));
        MasterAudio.PlaySound("hard opening_1 school ring");
        yield return StartCoroutine(NormalChat("", "", 1));
        yield return StartCoroutine(NormalChat("앞자리 친구", "으.....", 2));
        yield return StartCoroutine(NormalChat("주인공", "왜 그래? 어디 아파?", 3));
        yield return StartCoroutine(NormalChat("앞자리 친구", "어금니가 아프네... 사랑니가 났나...", 4));
        yield return StartCoroutine(NormalChat("주인공", "치과 한번 가봐", 3));
        yield return StartCoroutine(NormalChat("앞자리 친구", "그래야겠어. 오늘 학교 끝나고 가야겠다.", 4));
        yield return StartCoroutine(NormalChat("", "", 1));
        yield return StartCoroutine(NormalChat("", "다 음 날	", 1));
        yield return StartCoroutine(NormalChat("주인공", "치과 갔다 왔어? 뭐래?", 5));
        yield return StartCoroutine(NormalChat("앞자리 친구", "응 다녀왔는데 충치가 생겼대", 3));
        yield return StartCoroutine(NormalChat("주인공", "뭐 ? 평소에 양치를 좀 잘하지 그랬어.양치를 어떻게 했길래 충치가 생기냐 ? ", 5));
        yield return StartCoroutine(NormalChat("앞자리 친구", "아닌데… 나 하루 3번 식후 3분 이내 3분 동안 양치 열심히 했는데 ?\n내가 얼마나 333 법칙을 잘 지키는데", 6));
        yield return StartCoroutine(NormalChat("주인공", "야! 그렇게 양치를 열심히 했는데 충치가 왜 생기냐 ?\n너 양치 대충 한 거아냐 ?\n(속마음: 에이… 아니겠지....설마...)(뭐지 이 불안함은...)", 7));
        Destroy(transform.parent.gameObject);
    }
}
