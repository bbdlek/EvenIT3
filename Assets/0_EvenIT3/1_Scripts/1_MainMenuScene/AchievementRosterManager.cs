using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementRosterManager : MonoBehaviour
{
    private MainMenuSceneUIManager _mainMenuSceneUIManager;
    
    public int No;
    public int Type;
    public float NN;

    public bool canGet;

    [SerializeField] private TMP_Text _headerText;
    [SerializeField] private TMP_Text _fillText;
    [SerializeField] private Image _fillImage;

    [SerializeField] private Button _contentMoveBtn;
    [SerializeField] private Button _contentGetBtn;

    [SerializeField] private GameObject rewardRoster;

    public void InitRoster(int no, int type, float nn)
    {
        _mainMenuSceneUIManager = FindObjectOfType<MainMenuSceneUIManager>();
        No = no;
        Type = type;
        NN = nn;

        canGet = false;
        
        InitRosterUI();
        
        //contentMoveBtn.onClick.AddListener(OnClickMoveBtn);
        _contentGetBtn.onClick.AddListener(OnClickGetBtn);
    }
    
    private void InitRosterUI()
    {
        switch (Type)
        {
            case 0: // N 스테이지 최초 클리어
                _headerText.text = (No / 4 + 1) + "-" + (No % 4 + 1) + "스테이지 최초 클리어";
                break;
            case 1: // N챕터의 모든 스테이지를  한번도 실패하지 않고 연속 클리어
                _headerText.text = (No - 23) + "챕터의 모든 스테이지를 한번도 실패하지 않고 연속 클리어";
                break;
            case 2: // 돌아보기로 걸린 횟수 N회
                _headerText.text = "돌아보기로 실패한 횟수 " + NN + "회";
                break;
            case 3: // 제한시간 만료로 실패한 횟수 N회
                _headerText.text = "제한시간 만료로 실패한 횟수 " + NN + "회";
                break;
            case 4: // 데시벨 초과로 실패한 횟수 N회
                _headerText.text = "데시벨 초과로 실패한 횟수 " + NN + "회";
                break;
            case 5: // 아이템a 사용 횟수 N회
                _headerText.text = "무료아이템 사용 횟수 " + NN + "회";
                break;
            case 6: // 아이템A 사용 횟수 N회
                _headerText.text = "유료아이템 사용 횟수 " + NN + "회";
                break;
            case 7: // 누적으로 먹기 성공한 간식 개수 N개
                _headerText.text = "누적으로 먹기 성공한 간식 개수 " + NN + "개";
                break;
            case 8: // 부적 N개 획득(10개 단위)
                _headerText.text = "부적 " + NN + "개 획득";
                break;
            case 9: // 최종 엔딩 완료
                _headerText.text = "최종 엔딩 환료";
                break;
            case 10: // 일반 뽑기 누적 N회
                _headerText.text = "일반 뽑기 누적 " + NN + "회";
                break;
            case 11: // 고급 뽑기 누적 N회
                _headerText.text = "고급 뽑기 누적 " + NN + "회";
                break;
        }
        _fillText.text = Mathf.Clamp(UserManager.Instance.userData.achievementCount[No], 0, NN) + " / " + NN;
        _fillImage.fillAmount = UserManager.Instance.userData.achievementCount[No] / NN;
        canGet = UserManager.Instance.userData.achievementCount[No] == (int)NN;
        _contentGetBtn.interactable = canGet;
    }

    private void OnClickMoveBtn()
    {
        switch (Type)
        {
            case 0: // N 스테이지 최초 클리어
                _mainMenuSceneUIManager.ChangeUI(MainMenuSceneUIManager.MainMenuScenePanels.StagePanel);
                int chapter = (int) NN / 4 + 1;
                int stage = (int) NN - (chapter - 1) * 4;
                _mainMenuSceneUIManager.OnClickChapterSelectBtn(chapter);
                _mainMenuSceneUIManager.OnClickChapterToStage(stage);
                break;
            case 1: // N챕터의 모든 스테이지를  한번도 실패하지 않고 연속 클리어
                _mainMenuSceneUIManager.ChangeUI(MainMenuSceneUIManager.MainMenuScenePanels.StagePanel);
                _mainMenuSceneUIManager.OnClickChapterSelectBtn((int)NN);
                break;
            case 2: // 돌아보기로 걸린 횟수 N회
                break;
            case 3: // 제한시간 만료로 실패한 횟수 N회
                break;
            case 4: // 데시벨 초과로 실패한 횟수 N회
                break;
            case 5: // 아이템a 사용 횟수 N회
                break;
            case 6: // 아이템A 사용 횟수 N회
                break;
            case 7: // 누적으로 먹기 성공한 간식 개수 N개
                break;
            case 8: // 부적 N개 획득(10개 단위)
                break;
            case 9: // 최종 엔딩 완료
                break;
            case 10: // 일반 뽑기 누적 N회
                break;
            case 11: // 고급 뽑기 누적 N회
                break;
        }
    }

    public void OnClickGetBtn()
    {
        switch (Type)
        {
            case 0: // N 스테이지 최초 클리어
                Instantiate(Resources.Load<GameObject>("Story/Story" + (No + 1)), FindObjectOfType<Canvas>().transform);
                break;
            case 1: // N챕터의 모든 스테이지를  한번도 실패하지 않고 연속 클리어
                // 트로피 보상
                break;
            case 2: // 돌아보기로 걸린 횟수 N회
                UserManager.Instance.userData.Commodities.Gold += DBManagerScript.Instance.achievementDB[No].rewardN;
                break;
            case 3: // 제한시간 만료로 실패한 횟수 N회
                UserManager.Instance.userData.Commodities.Gold += DBManagerScript.Instance.achievementDB[No].rewardN;
                break;
            case 4: // 데시벨 초과로 실패한 횟수 N회
                UserManager.Instance.userData.Commodities.Gold += DBManagerScript.Instance.achievementDB[No].rewardN;
                break;
            case 5: // 아이템a 사용 횟수 N회
                UserManager.Instance.userData.Commodities.Gold += DBManagerScript.Instance.achievementDB[No].rewardN;
                break;
            case 6: // 아이템A 사용 횟수 N회
                UserManager.Instance.userData.Commodities.Gold += DBManagerScript.Instance.achievementDB[No].rewardN;
                break;
            case 7: // 누적으로 먹기 성공한 간식 개수 N개
                // 테두리 증정
                break;
            case 8: // 부적 N개 획득(10개 단위)
                // 트로피 증정
                break;
            case 9: // 최종 엔딩 완료
                // 트로피 증정
                break;
            case 10: // 일반 뽑기 누적 N회
                // 일반 뽑기권 증증
                UserManager.Instance.userData.normalTicket += DBManagerScript.Instance.achievementDB[No].rewardN;
                break;
            case 11: // 고급 뽑기 누적 N회
                // 고급 뽑기권 증정
                UserManager.Instance.userData.epicTicket += DBManagerScript.Instance.achievementDB[No].rewardN;
                break;
        }

        UserManager.Instance.userData.achievementList[No] = true;
        //FBManagerScript.Instance.UpdateCurrentUser();
        AppManagerScript.Instance.sceneManagerObject.GetComponent<MainMenuSceneManagerScript>().mainMenuSceneUIManager.SetTrophy();
        if(Type != 0)
        {
            gameObject.SetActive(false);
            GameObject tempRoster = Instantiate(rewardRoster,
                _mainMenuSceneUIManager.FindUIObject("AchievementPanelRewardList").transform);
            tempRoster.GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/" + DBManagerScript.Instance.achievementDB[No].reward);
            if (DBManagerScript.Instance.achievementDB[No].rewardN == 1)
            {
                tempRoster.GetComponentInChildren<TMP_Text>().text = "";
            }
            else
            {
                tempRoster.GetComponentInChildren<TMP_Text>().text = "X " + DBManagerScript.Instance.achievementDB[No].rewardN;
            }
        }

        _mainMenuSceneUIManager.FindUIObject("AchievementPanelReward").SetActive(true);
    }
}
