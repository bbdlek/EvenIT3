using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.UI;


public class Opening : MonoBehaviour
{
    public Text ChatTxt, CharacterNameTxt;

    public string writerTxt = "";

    public Image original;
    public Sprite one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen, twenty, twentyone, twentytwo;

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
        else if (person == 15)
            original.sprite = fifteen;
        else if (person == 16)
            original.sprite = sixteen;
        else if (person == 17)
            original.sprite = seventeen;
        else if (person == 18)
            original.sprite = eighteen;
        else if (person == 19)
            original.sprite = nineteen;
        else if (person == 20)
            original.sprite = twenty;

        else if (person == 21)
            original.sprite = twentyone;
        else if (person == 22)
            original.sprite = twentytwo;

        for (int i = 0; i < narration.Length; i++)
        {
            writerTxt += narration[i];
            ChatTxt.text = writerTxt;
            yield return null;
        }

        while(true)
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
        yield return StartCoroutine(NormalChat("내레이션", "오래전... 이 학교에는 아이들을 충치로 고통받게 만드는 충치 요정이 살고 있었다는 전설이 내려오고 있는데...", 0));
        yield return StartCoroutine(NormalChat("내레이션", "몇십 년 후…", 2));
        MasterAudio.PlaySound("easy opening_2");
        yield return StartCoroutine(NormalChat("", "                                                          ", 3));
        yield return StartCoroutine(NormalChat("내레이션", "땡땡 년도 어느 날 지각한 벌로 창고 청소를 하던 주인공... 실수로 항아리를 깨버렸다", 2));
        yield return StartCoroutine(NormalChat("내레이션", "선생님에게 혼나기 싫었던 주인공은 급하게 깨진 조각들을 버리고 집으로 돌아갔다.", 2));
        yield return StartCoroutine(NormalChat("", "다 음 날                            ", 0));
        yield return StartCoroutine(NormalChat("", "등교하는데 아침부터 이가 욱신거린다... 아픈 것을 참으며 교실에 도착했는데 분위기가 이상하다?", 4));
        yield return StartCoroutine(NormalChat("", "반 친구들이 모두 볼을 감싸고 고통스러워하고 있다?", 5));
        yield return StartCoroutine(NormalChat("주인공", "(앞자리 친구에게) 야! 무슨 일이야?", 6));
        yield return StartCoroutine(NormalChat("앞자리 친구", "몰라 어제 학교 끝나고부터인가? 그때부터 이가 아파", 7));
        yield return StartCoroutine(NormalChat("주인공", "(속마음 : 뭔가 느낌이 이상해 )", 8));
        MasterAudio.PlaySound("easy opening_9 walking sound");
        yield return StartCoroutine(NormalChat("", "다른반을 확인하러 교실 밖으로 향하는데...", 9));
        yield return StartCoroutine(NormalChat("다른 반 친구", "야!!! 너 체육쌤이 체육 창고로 오래!!!", 10));
        yield return StartCoroutine(NormalChat("주인공", "뭐지... 나 뭐 잘못했나? 혹시.... (어제 깨뜨린 항아리를 떠올린다)", 8));
        MasterAudio.PlaySound("easy opening_12 door open");
        yield return StartCoroutine(NormalChat("", "체육 창고에 도착했는데 선생님이 보이지 않는다.	", 2));
        yield return StartCoroutine(NormalChat("주인공", "어제 덜 치운 항아리 조각이 있는지 확인해 봐야겠다.", 11));
        yield return StartCoroutine(NormalChat("빛덩어리", "야아아아아아아아아아아아아아아아아아", 12));
        yield return StartCoroutine(NormalChat("주인공", "아아아아아아아아앙ㄱ 뭐야!? (벌레 쫓듯이 손을 휘적인다)", 13));
        yield return StartCoroutine(NormalChat("건치 요정", "잠깐!!!!!!!!! 진정해!!!!!!!!!!!", 14));
        yield return StartCoroutine(NormalChat("주인공", "뭐야뭐야뭐야", 15));
        yield return StartCoroutine(NormalChat("건치 요정", "진정하라고오오오오오! 나는 건치 요정이라고!!! 나는 어제 네가 깬 항아리 때문에 잘 자고 있었는데 잠에서 깼어 !!!\n그 항아리가 어떤 항아리인 줄 알아??? 아주 못된 충치 요정을 봉인했던 항아리라고!!!\n지금 너 때문에 온 학교 전교생이 충치가 생기고 있단 말이야!!!", 16));
        yield return StartCoroutine(NormalChat("주인공", "뭐???!!!\n(궁시렁거리며)왜 항아리를 그런데 놔두는 거야", 15));
        yield return StartCoroutine(NormalChat("건치 요정", "지금 그게 중요한 게 아니야.\n어쨌든 항아리는 깨졌고 충치 요정은 깨어났어.\n이제 네가 해야 할 일은 나와 함께 못된 충치 요정을 다시 봉인하는 일!!\n내가 너에게 건치 요정의 가호를 내려 충치로부터 막아줄 테니 너는 그 힘으로 충치 요정을 봉인하자!", 16));
        yield return StartCoroutine(NormalChat("주인공", "!!!!!!!!!!!?  ㅇㅂㅇ:::", 17));
        yield return StartCoroutine(NormalChat("건치 요정", "너로 인해 시작됐으니 끝도 네가 내야지 내가 있으니 괜찮아 너는 할 수 있어!! 나만 믿어!!", 18));
        yield return StartCoroutine(NormalChat("주인공", "(속마음: 위험한 건 아니겠지;;? )\n그래 한번 해보자!!", 19));
        /*yield return StartCoroutine(NormalChat("건치 요정", "내가 봉인하는 방법을 알려줄게~\n그 방법은 쉬워!! 간식봉지를 모아 간식봉지 부적을 만들면 된다구!", 20));
        yield return StartCoroutine(NormalChat("주인공", "간식봉지 부적? 쉽다고? 어떻게 하면 되는 건데?", 21));
        yield return StartCoroutine(NormalChat("건치 요정", "응  쉬워\n방법은 충치 요정에게 빙의 된 선생님들의 눈을 피해 몰래 간식을 먹어서 간식봉지 부적을 모으면 돼 쉽지 ? !ㅎㅎㅎ\n아! 충치는 걱정 안 해도 되! 넌 내 가호를 받아서 충치가 생기지 않거든~\n한번 연습해보자", 22));*/
        Destroy(transform.parent.gameObject);
        FindObjectOfType<MainMenuSceneUIManager>().ChangeUI(MainMenuSceneUIManager.MainMenuScenePanels.SetNickNamePanel);
    }
}
