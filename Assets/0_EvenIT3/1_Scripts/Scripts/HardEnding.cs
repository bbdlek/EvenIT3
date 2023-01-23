using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardEnding : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen;

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
        else if (person == 13)
            original.sprite = thirteen;
        else if (person == 14)
            original.sprite = fourteen;

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
        yield return StartCoroutine(NormalChat("", "엔딩 - 돌아온 건치요정	", 0));
        yield return StartCoroutine(NormalChat("주인공", "(반가운 듯이, 기쁨의 눈물을 흘리며 )건치요정..!!", 1));
        yield return StartCoroutine(NormalChat("건치요정", "고마워, 주인공. 네 덕분에 정신 차릴 수 있었어.", 2));
        yield return StartCoroutine(NormalChat("주인공", "정말... 힘들었어... 다시 돌아와서 다행이야...(눈물...)", 3));
        yield return StartCoroutine(NormalChat("건치요정", "(당황, 주인공을 달래며) 미안해... 어쩔 수가 없었어...\n충치요정이 봉인 되기 전에 내게 빅똥을 주고 갔을 줄은...", 4));
        yield return StartCoroutine(NormalChat("주인공", "근데 내가 아까 하얀공간에서 이상한 장면을 봤는데...\n너랑 충치요정이랑 사이좋게 노는모습이었어...", 5));
        yield return StartCoroutine(NormalChat("건치요정", "아....그래 너한테라면 말해도 괜찮겠지.\n실은 나랑 충치요정은 어렷을적부터 함께 놀던 소꿉친구였어.\n그러던 어느날 충치요정이 어떤 책을 읽더니 태도가 180도 바뀌고\n충치를 퍼뜨리고 다녔어...나는 아직도 그책이 무슨책인지 몰라...", 6));
        yield return StartCoroutine(NormalChat("건치요정", "하지만 나는 충치요정이 다른사람들을 괴롭히는걸 볼 수 없어서\n봉인하는 방법을 선택한거야", 6));
        yield return StartCoroutine(NormalChat("주인공", "(눈물...주인공은 말없이 건치요정을 토닥여준다)", 7));
        yield return StartCoroutine(NormalChat("", "주인공과 건치요정은 한동안 말없이 하늘만 바라보고있었다...	", 8));
        yield return StartCoroutine(NormalChat("", "약 1시간이 지난 후 건치요정이 천천히 입을 열었다	", 9));
        yield return StartCoroutine(NormalChat("건치요정", "나 이제 가봐야 할것 같아", 10));
        yield return StartCoroutine(NormalChat("주인공", "뭐? 좀만 더 있다가 가지...", 11));
        yield return StartCoroutine(NormalChat("건치요정", "아니 이제는 진짜 돌아가야해.\n저 항아리는 내가 가지고 갈게 그럼 앞으로 충치요정의 봉인이 풀리는 일은 없을거야.\n그럼 잘있어...양치 꼭 잘하고!", 12));
        yield return StartCoroutine(NormalChat("주인공", "그래, 너도 잘지내!", 13));
        yield return StartCoroutine(NormalChat("", "The End	", 14));
    }
}
