using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardEnding : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("", "\n\n\n                    엔딩 - 돌아온 건치요정	"));
        yield return StartCoroutine(NormalChat("주인공", "(반가운 듯이, 기쁨의 눈물을 흘리며 )건치요정..!!"));
        yield return StartCoroutine(NormalChat("건치요정", "고마워, 주인공. 네 덕분에 정신 차릴 수 있었어."));
        yield return StartCoroutine(NormalChat("주인공", "정말... 힘들었어... 다시 돌아와서 다행이야...(눈물...)"));
        yield return StartCoroutine(NormalChat("건치요정", "(당황, 주인공을 달래며) 미안해... 어쩔 수가 없었어...\n충치요정이 봉인 되기 전에 내게 빅똥을 주고 갔을 줄은..."));
        yield return StartCoroutine(NormalChat("주인공", "근데 내가 아까 하얀공간에서 이상한 장면을 봤는데...\n너랑 충치요정이랑 사이좋게 노는모습이었어..."));
        yield return StartCoroutine(NormalChat("건치요정", "아....그래 너한테라면 말해도 괜찮겠지.\n실은 나랑 충치요정은 어렷을적부터 함께 놀던 소꿉친구였어.\n그러던 어느날 충치요정이 어떤 책을 읽더니 태도가 180도 바뀌고\n충치를 퍼뜨리고 다녔어...나는 아직도 그책이 무슨책인지 몰라...\n하지만 나는 충치요정이 다른사람들을 괴롭히는걸 볼 수 없어서\n봉인하는 방법을 선택한거야"));
        yield return StartCoroutine(NormalChat("주인공", "(눈물...주인공은 말없이 건치요정을 토닥여준다)"));
        yield return StartCoroutine(NormalChat("", "주인공과 건치요정은 한동안 말없이 하늘만 바라보고있었다...	"));
        yield return StartCoroutine(NormalChat("", "약 1시간이 지난 후 건치요정이 천천히 입을 열었다	"));
        yield return StartCoroutine(NormalChat("건치요정", "나 이제 가봐야 할것 같아"));
        yield return StartCoroutine(NormalChat("주인공", "뭐? 좀만 더 있다가 가지..."));
        yield return StartCoroutine(NormalChat("건치요정", "아니 이제는 진짜 돌아가야해.\n저 항아리는 내가 가지고 갈게 그럼 앞으로 충치요정의 봉인이 풀리는 일은 없을거야.\n그럼 잘있어...양치 꼭 잘하고!"));
        yield return StartCoroutine(NormalChat("주인공", "그래, 너도 잘지내!"));
        yield return StartCoroutine(NormalChat("", "The End	"));
    }
}
