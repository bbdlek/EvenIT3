using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DarkTonic.MasterAudio;
using TMPro;
using Toast.Gamebase;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenuSceneUIManager : UIControllerScript
{
    public override void InitSetup(GameObject scriptObject)
    {
        base.InitSetup(scriptObject);
        AddOnClick();
        InitProfileSprites();
        InitSettingUI();
        AppManagerScript.Instance.isStageTutorial = false;
        FindUIObject("StagePageTutorialToggle").GetComponent<Toggle>().isOn = false;
    }

    private void OnDisable()
    {
        Debug.Log("Disabled");
    }

    public void CheckRestart()
    {
        if (AppManagerScript.Instance.isRestart)
        {
            ChangeUI(MainMenuScenePanels.StagePanel);
            OnClickChapterSelectBtn(AppManagerScript.Instance.selectedChapter);
            OnClickChapterToStage(AppManagerScript.Instance.selectedStage);
            AppManagerScript.Instance.isRestart = false;
        }
        else
        {
            if (UserManager.Instance.userData.tutorial41)
            {
                if(!UserManager.Instance.userData.tutorial4)
                    FindUIObject("Tutorial4-4").SetActive(true);
            }
        }
    }

    private void AddOnClick()
    {
        string[] enumArray = Enum.GetNames(typeof(MainMenuSceneButtons));
        for (int i = 0; i < Enum.GetValues(typeof(MainMenuSceneButtons)).Length; i++)
        {
            try
            {
                Button tempButton = FindUIObject(enumArray[i]).GetOrAddComponent<Button>();
                int temp = i;
                tempButton.onClick.AddListener(() => ButtonOnClick(temp));
                tempButton.onClick.AddListener(() => MasterAudio.PlaySound("IconCLick"));
            }
            catch (Exception)
            {
                Debug.Log(enumArray[i]);
            }
        }
    }
    
    #region ButtonClick

    protected override void ButtonOnClick(int clickBtn)
    {
        base.ButtonOnClick(clickBtn);
        MainMenuSceneButtons tempClickBtn = (MainMenuSceneButtons)clickBtn;
        switch (tempClickBtn)
        {
            //ETC
            case MainMenuSceneButtons.EnergyBuyBtn:
                OnClickEnergyBuyBtn();
                break;
            
            //Set Nick Name
            case MainMenuSceneButtons.SetNickNameConfirmBtn:
#pragma warning disable CS4014
                OnClickSetNickNameConfirmBtn();
#pragma warning restore CS4014
                break;
            
            //Move Btns
            case MainMenuSceneButtons.StageMoveBtn:
                OnClickStageMoveBtn();
                OnClickChapterSelectBtn(1);
                break;
            case MainMenuSceneButtons.AchievementMoveBtn:
                OnClickAchievementMoveBtn();
                break;
            case MainMenuSceneButtons.CollectionMoveBtn:
                OnClickCollectionMoveBtn();
                break;
            case MainMenuSceneButtons.ShopMoveBtn:
                OnClickShopMoveBtn();
                break;
            case MainMenuSceneButtons.InventoryMoveBtn:
                OnClickInventoryMoveBtn();
                break;
            case MainMenuSceneButtons.OptionMoveBtn:
                OnClickOptionMoveBtn();
                break;
            case MainMenuSceneButtons.ProfileMoveBtn:
                OnClickProfileMoveBtn();
                break;
            
            //Chapter
            case MainMenuSceneButtons.Chapter1SelectBtn:
                OnClickChapterSelectBtn(1);
                break;
            case MainMenuSceneButtons.Chapter2SelectBtn:
                OnClickChapterSelectBtn(2);
                break;
            case MainMenuSceneButtons.Chapter3SelectBtn:
                OnClickChapterSelectBtn(3);
                break;
            case MainMenuSceneButtons.Chapter4SelectBtn:
                OnClickChapterSelectBtn(4);
                break;
            case MainMenuSceneButtons.Chapter5SelectBtn:
                OnClickChapterSelectBtn(5);
                break;
            case MainMenuSceneButtons.Chapter6SelectBtn:
                OnClickChapterSelectBtn(6);
                break;
            case MainMenuSceneButtons.ChapterPageCloseBtn:
                OnClickChapterPageCloseBtn();
                break;
            case MainMenuSceneButtons.HallOfFamePageMoveBtn:
                OnClickHallOfFamePageMoveBtn();
                break;
            
            case MainMenuSceneButtons.ChapterToStage1:
                OnClickChapterToStage(1);
                break;
            case MainMenuSceneButtons.ChapterToStage2:
                OnClickChapterToStage(2);
                break;
            case MainMenuSceneButtons.ChapterToStage3:
                OnClickChapterToStage(3);
                break;
            case MainMenuSceneButtons.ChapterToStage4:
                OnClickChapterToStage(4);
                break;
            case MainMenuSceneButtons.StagePageCloseBtn:
                OnClickStagePageCloseBtn();
                break;
            
            case MainMenuSceneButtons.HChapter1SelectBtn:
                OnClickChapterSelectBtn(1);
                break;
            case MainMenuSceneButtons.HChapter2SelectBtn:
                OnClickChapterSelectBtn(2);
                break;
            case MainMenuSceneButtons.HChapter3SelectBtn:
                OnClickChapterSelectBtn(3);
                break;
            case MainMenuSceneButtons.HChapter4SelectBtn:
                OnClickChapterSelectBtn(4);
                break;
            case MainMenuSceneButtons.HChapter5SelectBtn:
                OnClickChapterSelectBtn(5);
                break;
            case MainMenuSceneButtons.HChapter6SelectBtn:
                OnClickChapterSelectBtn(6);
                break;
            case MainMenuSceneButtons.HallOfFamePageScoreTableBtn:
                OnClickHallOfFamePageScoreTableBtn();
                break;
            case MainMenuSceneButtons.HallOfFamePageScoreTableCloseBtn:
                OnClickHallOfFamePageScoreTableCloseBtn();
                break;
            case MainMenuSceneButtons.HallOfFamePageBGCloseBtn:
                OnClickHallOfFamePageBGCloseBtn();
                break;
            case MainMenuSceneButtons.HallOfFamePagePrevBtn:
                OnClickHallOfFamePagePrevBtn();
                break;
            case MainMenuSceneButtons.HallOfFamePageNextBtn:
                OnClickHallOfFamePageNextBtn();
                break;
            
            //Stage
            case MainMenuSceneButtons.StageStartBtn:
                OnClickStageStartBtn();
                break;

            //Achievement
            case MainMenuSceneButtons.AchievementCloseBtn:
                OnClickAchievementCloseBtn();
                break;
            case MainMenuSceneButtons.AchievementAllObtainBtn:
                OnClickAchievementAllObtainBtn();
                break;
            
            //Collection
            case MainMenuSceneButtons.CollectionCloseBtn:
                OnClickCollectionCloseBtn();
                break;
            case MainMenuSceneButtons.BuffBtn:
                OnClickBuffBtn();
                break;
            case MainMenuSceneButtons.Chapter1Btn:
                OnClickChapter1Btn();
                break;
            case MainMenuSceneButtons.Chapter2Btn:
                OnClickChapter2Btn();
                break;
            case MainMenuSceneButtons.Chapter3Btn:
                OnClickChapter3Btn();
                break;
            case MainMenuSceneButtons.NextPage_Btn:
                OnClickNextPage_Btn();
                break;
            case MainMenuSceneButtons.Chapter4Btn:
                OnClickChapter4Btn();
                break;
            case MainMenuSceneButtons.Chapter5Btn:
                OnClickChapter5Btn();
                break;
            case MainMenuSceneButtons.Chapter6Btn:
                OnClickChapter6Btn();
                break;
            
            //Shop
            case MainMenuSceneButtons.AzummaPanel:
                OnClickAzummaPanel();
                break;
            case MainMenuSceneButtons.ShopCloseBtn:
                OnClickShopCloseBtn();
                break;
            case MainMenuSceneButtons.GachaBtn:
                GetComponent<Shop>().ClickGacha();
                break;
            case MainMenuSceneButtons.ItemBtn:
                GetComponent<Shop>().ClickItem();
                break;
            case MainMenuSceneButtons.PackageBtn:
                GetComponent<Shop>().ClickPackage();
                break;
            case MainMenuSceneButtons.MoneyBtn:
                GetComponent<Shop>().ClickPaid();
                break;
            
            case MainMenuSceneButtons.NormalGachaOnce:
                OnClickNormalGachaOnce();
                break;
            case MainMenuSceneButtons.NormalGachaFifth:
                OnClickNormalGachaFifth();
                break;
            case MainMenuSceneButtons.HighGachaOnce:
                OnClickHighGachaOnce();
                break;
            case MainMenuSceneButtons.HighGachaFifth:
                OnClickHighGachaFifth();
                break;
            
            
            case MainMenuSceneButtons.ClockBtn:
                OnClickClockBtn();
                break;
            case MainMenuSceneButtons.MaskBtn:
                OnClickMaskBtn();
                break;
            case MainMenuSceneButtons.MilkBtn:
                OnClickMilkBtn();
                break;

            case MainMenuSceneButtons.Package1Btn:
                OnClickPackage1Btn();
                break;
            case MainMenuSceneButtons.Package2Btn:
                OnClickPackage2Btn();
                break;
            
            case MainMenuSceneButtons.Free1Btn:
                OnClickFree1Btn();
                break;
            case MainMenuSceneButtons.Free2Btn:
                OnClickFree2Btn();
                break;
            case MainMenuSceneButtons.Free3Btn:
                OnClickFree3Btn();
                break;
            /*case MainMenuSceneButtons.Paid1Btn:
                OnClickPaid1Btn();
                break;
            case MainMenuSceneButtons.Paid2Btn:
                OnClickPaid2Btn();
                break;
            case MainMenuSceneButtons.Paid3Btn:
                OnClickPaid3Btn();
                break;*/

            case MainMenuSceneButtons.BuyCheckYesBtn:
                OnClickBuyCheckYesBtn();
                break;
            case MainMenuSceneButtons.BuyCheckNoBtn:
                OnClickBuyCheckNoBtn();
                break;
            case MainMenuSceneButtons.GachaPopupRewardClose:
                OnclickGachaPopupRewardClose();
                break;
            
            //Inventory
            case MainMenuSceneButtons.InventoryCloseBtn:
                OnClickInventoryCloseBtn();
                break;
            case MainMenuSceneButtons.InventoryGoToShopBtn:
                OnClickInventoryGoToShopBtn();
                break;
            case MainMenuSceneButtons.InventoryClockBtn:
                OnClickInventoryClockBtn();
                break;
            case MainMenuSceneButtons.InventoryMilkBtn:
                OnClickInventoryMilkBtn();
                break;
            case MainMenuSceneButtons.InventoryMaskBtn:
                OnClickInventoryMaskBtn();
                break;
            case MainMenuSceneButtons.ClockBackBtn:
                OnClickClockBackBtn();
                break;
            case MainMenuSceneButtons.MilkBackBtn:
                OnClickMilkBackBtn();
                break;
            case MainMenuSceneButtons.MaskBackBtn:
                OnClickMaskBackBtn();
                break;
        
            //Option
            case MainMenuSceneButtons.OptionCloseBtn:
                OnClickOptionCloseBtn();
                break;
            case MainMenuSceneButtons.CustomerServicePanelTerm1BG:
                OnClickOptionTerm1Btn();
                break;
            case MainMenuSceneButtons.CustomerServicePanelTerm2BG:
                OnClickOptionTerm2Btn();
                break;
            case MainMenuSceneButtons.CustomerServicePanelBlogBG:
                OnClickOptionBlogBtn();
                break;
            case MainMenuSceneButtons.CustomerServicePanelInstaBG:
                OnClickOptionInstaBtn();
                break;
            case MainMenuSceneButtons.CustomerServicePanelCouponBG:
                OnClickOptionCouponBtn();
                break;
            case MainMenuSceneButtons.CustomerServicePanelCustomerServiceBG:
                OnClickOptionCSBtn();
                break;
            case MainMenuSceneButtons.OptionLogOutBtn:
                OnClickOptionLogOutBtn();
                break;
            case MainMenuSceneButtons.OptionWithDrawBtn:
                OnClickOptionWithDrawBtn();
                break;
            case MainMenuSceneButtons.LogOutConfirmBtn:
                OnClickLogOutConfirmBtn();
                break;
            case MainMenuSceneButtons.LogOutDenyBtn:
                OnClickLogOutDenyBtn();
                break;
            case MainMenuSceneButtons.WithdrawConfirmBtn:
                OnClickWithdrawConfirmBtn();
                break;
            case MainMenuSceneButtons.WithdrawDenyBtn:
                OnClickWithdrawDenyBtn();
                break;
            case MainMenuSceneButtons.CouponPanelAcceptBtn:
                OnClickCouponPanelAcceptBtn();
                break;
            
            //Profile
            case MainMenuSceneButtons.ProfileCloseBtn:
                OnClickProfileCloseBtn();
                break;
            case MainMenuSceneButtons.ProfileImageEditBtn:
                OnClickProfileImageEditBtn();
                break;
            case MainMenuSceneButtons.ProfileNickNameEditBtn:
                OnClickProfileNickNameEditBtn();
                break;
            case MainMenuSceneButtons.ProfileEdgeBtn:
                OnClickProfileEdgeBtn();
                break;
            case MainMenuSceneButtons.ProfileEditBtn:
                OnClickProfileEditBtn();
                break;
            case MainMenuSceneButtons.ProfileEditCloseBtn:
                OnClickProfileEditCloseBtn();
                break;
            case MainMenuSceneButtons.EditNickNameConfirmBtn:
                OnClickEditNickNameConfirmBtn();
                break;
            case MainMenuSceneButtons.EditNickNamePanelCloseBtn:
                OnClickEditNickNamePanelCloseBtn();
                break;
            
            case MainMenuSceneButtons.EnergyBuyPanelADBtn:
                ADManagerScript.Instance.ShowEnergyRewardAd();
                break;
            case MainMenuSceneButtons.EnergyBuyPanelBuyBtn:
                OnClickEnergyBuyPanelBuyBtn();
                break;
        }
    }
    
    private enum MainMenuSceneButtons
    {
        //ETC
        EnergyBuyBtn,
        
        //SetNickName
        SetNickNameConfirmBtn,
        
        //Move Btns
        StageMoveBtn,
        AchievementMoveBtn,
        CollectionMoveBtn,
        ShopMoveBtn,
        InventoryMoveBtn,
        OptionMoveBtn,
        ProfileMoveBtn,
        
        //Chapter
        Chapter1SelectBtn,
        Chapter2SelectBtn,
        Chapter3SelectBtn,
        Chapter4SelectBtn,
        Chapter5SelectBtn,
        Chapter6SelectBtn,
        HChapter1SelectBtn,
        HChapter2SelectBtn,
        HChapter3SelectBtn,
        HChapter4SelectBtn,
        HChapter5SelectBtn,
        HChapter6SelectBtn,
        ChapterPageCloseBtn,
        HallOfFamePageMoveBtn,
        
        ChapterToStage1,
        ChapterToStage2,
        ChapterToStage3,
        ChapterToStage4,
        StagePageCloseBtn,
        
        HallOfFamePageScoreTableBtn,
        HallOfFamePageScoreTableCloseBtn,
        HallOfFamePageBGCloseBtn,
        HallOfFamePagePrevBtn,
        HallOfFamePageNextBtn,


        //Stage
        StageStartBtn,
        
        //Achievement
        AchievementCloseBtn,
        AchievementAllObtainBtn,
        
        //Collection
        CollectionCloseBtn,
        BuffBtn,
        Chapter1Btn,
        Chapter2Btn,
        Chapter3Btn,
        NextPage_Btn,
        Chapter4Btn,
        Chapter5Btn,
        Chapter6Btn,

        //Shop
        AzummaPanel,
        ShopCloseBtn,
        GachaBtn,
        ItemBtn,
        PackageBtn,
        MoneyBtn,

            //Gotcha
        NormalGachaOnce,
        NormalGachaFifth,
        HighGachaOnce,
        HighGachaFifth,

            //Item
        ClockBtn,
        MaskBtn,
        MilkBtn,
        
            //Package
        Package1Btn,
        Package2Btn,
        
            //Money
        Free1Btn,
        Free2Btn,
        Free3Btn,
        /*Paid1Btn,
        Paid2Btn,
        Paid3Btn,*/

        //BuyCheck
        BuyCheckYesBtn,
        BuyCheckNoBtn,
        
        GachaPopupRewardClose,
        
        
        //Inventory
        InventoryCloseBtn,
        InventoryGoToShopBtn,
        InventoryClockBtn,
        InventoryMilkBtn,
        InventoryMaskBtn,
        ClockBackBtn,
        MilkBackBtn,
        MaskBackBtn,
        
        //Option
        OptionCloseBtn,
        CustomerServicePanelTerm1BG,
        CustomerServicePanelTerm2BG,
        CustomerServicePanelBlogBG,
        CustomerServicePanelInstaBG,
        CustomerServicePanelCouponBG,
        CustomerServicePanelCustomerServiceBG,
        CouponPanelAcceptBtn,

        OptionLogOutBtn,
        OptionWithDrawBtn,
        LogOutConfirmBtn,
        LogOutDenyBtn,
        WithdrawConfirmBtn,
        WithdrawDenyBtn,
        
        //Profile
        ProfileCloseBtn,
        ProfileImageEditBtn,
        ProfileNickNameEditBtn,
        ProfileEditBtn,
        ProfileEdgeBtn,
        ProfileEditCloseBtn,
        EditNickNameConfirmBtn,
        EditNickNamePanelCloseBtn,
        
        //EnergyBuyPanel
        EnergyBuyPanelADBtn,
        EnergyBuyPanelBuyBtn
    }

    private void OnClickEnergyBuyBtn()
    {
        UserManager.Instance.SetRechargeScheduler();
        FindUIObject("EnergyBuyPanel").SetActive(true);
    }
    
    //Set Nick Name
    private async Task OnClickSetNickNameConfirmBtn()
    {
        string nickName = FindUIObject("SetNickNameInput").GetComponent<TMP_InputField>().text;
        string errorTxt;
        // 1 ~ 6글자
        if (nickName.Length < 1 || nickName.Length > 6)
        {
            errorTxt = "1~6자의 영문 대소문자, 숫자, 한글만 가능합니다.";
            FindUIObject("SetNickNameInputErrorTxt").GetComponent<TMP_Text>().text = errorTxt;
        }
        // 중복
        else if (await FBManagerScript.Instance.CheckNicknameExist(nickName))
        {
            errorTxt = "중복된 닉네임입니다.";
            FindUIObject("SetNickNameInputErrorTxt").GetComponent<TMP_Text>().text = errorTxt;
        }
        // 특수문자
        else if (Regex.IsMatch(nickName, @"[^a-zA-Z0-9가-힣]"))
        {
            errorTxt = "1~6자의 영문 대소문자, 숫자, 한글만 가능합니다.";
            FindUIObject("SetNickNameInputErrorTxt").GetComponent<TMP_Text>().text = errorTxt;
        }
        else
        {
            errorTxt = "";
            FindUIObject("SetNickNameInputErrorTxt").GetComponent<TMP_Text>().text = errorTxt;
            FBManagerScript.Instance.WriteNewUser(UserManager.Instance.userID, nickName);
            FBManagerScript.Instance.GetUserData();
            FindUIObject("SetNickNamePanel").SetActive(false);
            if(!UserManager.Instance.userData.tutorial1)
                FindUIObject("Tutorial1").SetActive(true);
            ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
            ResetCommodities();
            ResetItems();
            InitProfile();
            SetCollectionNum();
            InitCollection();
            InitProfileEdges();
            InitProfileImages();
            InitProfileCollection();
            InitProfileScore();
            InitAchievement();
        }
    }

    //Move Btns
    private void OnClickStageMoveBtn()
    {
        MasterAudio.PlaySound("StageClick");
        ChangeUI(MainMenuScenePanels.StagePanel);
    }
    
    private void OnClickAchievementMoveBtn()
    {
        ChangeUI(MainMenuScenePanels.AchievementPanel);
    }
    
    public void OnClickCollectionMoveBtn()
    {
        SetCollectionNum();
        MasterAudio.PlaySound("CollectionClick");
        ChangeUI(MainMenuScenePanels.CollectionPanel);
    }
    
    private void OnClickShopMoveBtn()
    {
        MasterAudio.PlaySound("DoorClick");
        SetTickets();
        ChangeUI(MainMenuScenePanels.ShopPanel);  
    }

    public void SetTickets()
    {
        FindUIObject("NormalGachaOnceText").SetActive(true);
        FindUIObject("NormalGachaOnceCouponImg").SetActive(false);
        FindUIObject("NormalGachaFifthText").SetActive(true);
        FindUIObject("NormalGachaFifthCouponImg").SetActive(false);
        
        if (UserManager.Instance.userData.normalTicket >= 1)
        {
            FindUIObject("NormalGachaOnceText").SetActive(false);
            FindUIObject("NormalGachaOnceCouponImg").SetActive(true);
        }
        
        if (UserManager.Instance.userData.normalTicket >= 5)
        {
            FindUIObject("NormalGachaFifthText").SetActive(false);
            FindUIObject("NormalGachaFifthCouponImg").SetActive(true);
        }
        
        FindUIObject("HighGachaOnceText").SetActive(true);
        FindUIObject("HighGachaOnceCouponImg").SetActive(false);
        FindUIObject("HighGachaFifthText").SetActive(true);
        FindUIObject("HighGachaFifthCouponImg").SetActive(false);
        
        if (UserManager.Instance.userData.epicTicket >= 1)
        {
            FindUIObject("HighGachaOnceText").SetActive(false);
            FindUIObject("HighGachaOnceCouponImg").SetActive(true);
        }
        
        if (UserManager.Instance.userData.epicTicket >= 5)
        {
            FindUIObject("HighGachaFifthText").SetActive(false);
            FindUIObject("HighGachaFifthCouponImg").SetActive(true);
        }
    }
    
    private void OnClickInventoryMoveBtn()
    {
        ResetItems();
        MasterAudio.PlaySound("InventoryClick");
        ChangeUI(MainMenuScenePanels.InventoryPanel);
    }
    
    private void OnClickOptionMoveBtn()
    {
        ChangeUI(MainMenuScenePanels.OptionPanel);
    }

    private void OnClickProfileMoveBtn()
    {
        ChangeUI(MainMenuScenePanels.ProfilePanel);
    }
    
    //Chapter
    
    public void OnClickChapterSelectBtn(int chapter)
    {
        FindUIObject("HallOfFamePageBG").SetActive(false);
        AppManagerScript.Instance.selectedChapter = chapter;
        CheckStageStar();
        FindUIObject("ChapterPageHeader").GetComponent<TMP_Text>().text = "챕터 " + chapter;
        string body = null;
        switch (chapter)
        {
            case 1:
                body = "충치요정의 등장!";
                break;
            case 2:
                body = "충치요정의 발악";
                break;
            case 3:
                body = "결전, 충치요정을 봉인해라!";
                break;
            case 4:
                body = "다시 나타난 충치 요정?!";
                break;
            case 5:
                body = "새로운 충치 요정의 정체";
                break;
            case 6:
                body = "상상도 못한 진실";
                break;
        }
        FindUIObject("ChapterPageBody").GetComponent<TMP_Text>().text = body;
        FindUIObject("ChapterPageImg").GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Stage/chapter_icon_" + chapter);

        //별 불러오기
    }

    private void OnClickChapterPageCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickHallOfFamePageMoveBtn()
    {
        FindUIObject("HallOfFamePageP1").SetActive(true);
        FindUIObject("HallOfFameLeftPage").SetActive(false);
        FindUIObject("HallOfFameRightPage").SetActive(false);
        FindUIObject("HallOfFamePageBG").SetActive(true);
    }

    [SerializeField] private GameObject stagePageItemRoster;

    [SerializeField] private List<LeaderboardUserInfo> leaderBoardUserList;
    public async void OnClickChapterToStage(int stage)
    {
        /*if (UserManager.Instance.userData.starList.Count == 0)
        {
            FindUIObject("Tutorial2-2").SetActive(true);
        }*/
        
        AppManagerScript.Instance.selectedStage = stage;

        FindUIObject("StagePageTutorialToggle").SetActive(AppManagerScript.Instance.selectedChapter == 1 && AppManagerScript.Instance.selectedStage == 1);
        
        int stageNum = (AppManagerScript.Instance.selectedChapter - 1) * 4 + AppManagerScript.Instance.selectedStage - 1;

        int SnackNum = 0;
        if (DBManagerScript.Instance.stageDB[stageNum].snack1 != -1) SnackNum++;
        if (DBManagerScript.Instance.stageDB[stageNum].snack2 != -1) SnackNum++;
        if (DBManagerScript.Instance.stageDB[stageNum].snack3 != -1) SnackNum++;
        FindUIObject("StagePageExplainBody").GetComponent<TMP_Text>().text = "제한시간 내에\n" + SnackNum + "개의 간식을 모두 먹어라!";

        leaderBoardUserList.Clear();
        leaderBoardUserList = LeaderboardManagerScript.Instance.GetTop5Users(stageNum);
        
        for (int n = 0; n < leaderBoardUserList.Count; n++)
        {
            if (leaderBoardUserList[n].userId == "None")
            {
                FindUIObject("StageRankingTop5Panel").transform.GetChild(n + 1).gameObject.SetActive(false);
            }
            else
            {
                FindUIObject("StageRankingTop5Panel").transform.GetChild(n + 1).gameObject.SetActive(true);
                string nickName = await Task.Run(() =>  FBManagerScript.Instance.GetUserNickName(leaderBoardUserList[n].userId));
                FindUIObject("StageRankingTop5Panel").transform.GetChild(n + 1).GetChild(1).GetComponent<TMP_Text>()
                    .text = nickName;
                FindUIObject("StageRankingTop5Panel").transform.GetChild(n + 1).GetChild(2).GetComponent<TMP_Text>()
                    .text = leaderBoardUserList[n].score.ToString();
            }
        }

        var leaderBoardMyRank = LeaderboardManagerScript.Instance.GetMyRank(stageNum);
        Debug.Log(leaderBoardMyRank.userId);
        
        FindUIObject("StageRankingMineImg").SetActive(false);
        FindUIObject("StageRankingMineTxt").SetActive(false);
        
        if (leaderBoardMyRank.rank == 0)
        {
            FindUIObject("StageRankingMineTxt").SetActive(true);
            FindUIObject("StageRankingMineTxt").GetComponent<TMP_Text>().text = "999위";
            FindUIObject("StageRankingMineNickName").GetComponent<TMP_Text>().text = UserManager.Instance.userData.nickName;
            FindUIObject("StageRankingMineRecord").GetComponent<TMP_Text>().text = 0.ToString();
        }
        else
        {
            if (leaderBoardMyRank.rank == 1)
            {
                FindUIObject("StageRankingMineImg").SetActive(true);
                FindUIObject("StageRankingMineImg").GetComponent<Image>().color = new Color32(255, 215, 0, 255);
            } 
            else if (leaderBoardMyRank.rank == 2)
            {
                FindUIObject("StageRankingMineImg").SetActive(true);
                FindUIObject("StageRankingMineImg").GetComponent<Image>().color = new Color32(192, 192, 192, 255);
            } 
            else if (leaderBoardMyRank.rank == 3)
            {
                FindUIObject("StageRankingMineImg").SetActive(true);
                FindUIObject("StageRankingMineImg").GetComponent<Image>().color = new Color32(205, 127, 50, 255);
            }
            else
            {
                FindUIObject("StageRankingMineTxt").SetActive(true);
                FindUIObject("StageRankingMineTxt").GetComponent<TMP_Text>().text = leaderBoardMyRank.rank + "위";
            }
            FindUIObject("StageRankingMineNickName").GetComponent<TMP_Text>().text = UserManager.Instance.userData.nickName;
            FindUIObject("StageRankingMineRecord").GetComponent<TMP_Text>().text = leaderBoardMyRank.score.ToString();
        }
        

        for (int i = 0; i < FindUIObject("StagePageItemList").transform.childCount; i++)
        {
            Destroy(FindUIObject("StagePageItemList").transform.GetChild(i).gameObject);
        }
        
        if (DBManagerScript.Instance.stageDB[stageNum].snack1 != -1)
        {
            GameObject temp = Instantiate(stagePageItemRoster, FindUIObject("StagePageItemList").transform);
            temp.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Snacks/" +
                DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[stageNum].snack1].name);
        }
        if (DBManagerScript.Instance.stageDB[stageNum].snack2 != -1)
        {
            GameObject temp = Instantiate(stagePageItemRoster, FindUIObject("StagePageItemList").transform);
            temp.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Snacks/" +
                DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[stageNum].snack2].name);
        }
        if (DBManagerScript.Instance.stageDB[stageNum].snack3 != -1)
        {
            GameObject temp = Instantiate(stagePageItemRoster, FindUIObject("StagePageItemList").transform);
            temp.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Snacks/" +
                DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[stageNum].snack3].name);
        }
        FindUIObject("StagePageBosangGoldClear").SetActive(UserManager.Instance.userData.starList.Count >= stageNum + 1);

        CheckStageEnable();
        switch (stage)
        {
            case 1:
                FindUIObject("StagePageTeacherImg").GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Stage/art_teacher_korean");
                break;
            case 2:
                FindUIObject("StagePageTeacherImg").GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Stage/art_teacher_english");
                break;
            case 3:
                FindUIObject("StagePageTeacherImg").GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Stage/art_teacher_music");
                break;
            case 4:
                FindUIObject("StagePageTeacherImg").GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Stage/art_teacher_history");
                break;
        }
        FindUIObject("StagePageHeader").GetComponent<TMP_Text>().text = "Stage " +
                                                                        AppManagerScript.Instance.selectedChapter +
                                                                        "-" + AppManagerScript.Instance.selectedStage;
        FindUIObject("StagePageTeacherName").GetComponent<TMP_Text>().text = DBManagerScript.Instance.teacherDB[DBManagerScript.Instance.stageDB[stageNum].teacherNo ].name_kr;
        FindUIObject("StagePageTeacherExplain").GetComponent<TMP_Text>().text = DBManagerScript.Instance.teacherDB[DBManagerScript.Instance.stageDB[stageNum].teacherNo ].explain;

        if(stageNum < 12)
        {
            //Check Item
            FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn = false;
            FindUIObject("StagePageItem1").GetComponent<Toggle>().interactable = UserManager.Instance.userData.milkItem != 0;
            FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn = false;
            FindUIObject("StagePageItem2").GetComponent<Toggle>().interactable = UserManager.Instance.userData.clockItem != 0;
            FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn = false;
            FindUIObject("StagePageItem3").GetComponent<Toggle>().interactable = UserManager.Instance.userData.maskItem != 0;
            FindUIObject("StagePageItem1Cross").SetActive(false);
            FindUIObject("StagePageItem2Cross").SetActive(false);
            FindUIObject("StagePageItem3Cross").SetActive(false);
            FindUIObject("StageStartBtn").GetComponent<Image>().color = Color.white;
        }
        else
        {
            FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn = false;
            FindUIObject("StagePageItem1").GetComponent<Toggle>().interactable = false;
            FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn = false;
            FindUIObject("StagePageItem2").GetComponent<Toggle>().interactable = false;
            FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn = false;
            FindUIObject("StagePageItem3").GetComponent<Toggle>().interactable = false;
            FindUIObject("StagePageItem1Cross").SetActive(true);
            FindUIObject("StagePageItem2Cross").SetActive(true);
            FindUIObject("StagePageItem3Cross").SetActive(true);
            FindUIObject("StageStartBtn").GetComponent<Image>().color = Color.black;
        }

        FindUIObject("ChapterPageBG").SetActive(false);
        FindUIObject("StagePageBG").SetActive(true);
    }
    
    private void OnClickStagePageCloseBtn()
    {
        FindUIObject("ChapterPageBG").SetActive(true);
        FindUIObject("StagePageBG").SetActive(false);
    }

    private void OnClickHallOfFamePageScoreTableBtn()
    {
        FindUIObject("HallOfFamePageScoreTableBG").SetActive(true);
    }

    private void OnClickHallOfFamePageScoreTableCloseBtn()
    {
        FindUIObject("HallOfFamePageScoreTableBG").SetActive(false);
    }

    private void OnClickHallOfFamePageBGCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    [SerializeField] private int curPage = 0;

    private void OnClickHallOfFamePagePrevBtn()
    {
        curPage -= 2;
    }
    
    private void OnClickHallOfFamePageNextBtn()
    {
        curPage += 2;
    }
    
    //Stage
    private void OnClickStageStartBtn()
    {
        if (UserManager.Instance.userData.energy == 0)
        {
            AppManagerScript.Instance.InitCautionPanel(0);
            return;
        }
        int stageNum = (AppManagerScript.Instance.selectedChapter - 1) * 4 + AppManagerScript.Instance.selectedStage - 1;
        if(stageNum < 12)
        {
            AppManagerScript.Instance.selectedItem[0] = FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn;
            AppManagerScript.Instance.selectedItem[1] = FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn;
            AppManagerScript.Instance.selectedItem[2] = FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn;
            if (FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn) UserManager.Instance.userData.milkItem--;
            if (FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn) UserManager.Instance.userData.clockItem--;
            if (FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn) UserManager.Instance.userData.maskItem--;

            AppManagerScript.Instance.ChangeScene(SceneName.InGameScene_Easy);
        }
        else
        {
            AppManagerScript.Instance.selectedItem[0] = false;
            AppManagerScript.Instance.selectedItem[1] = false;
            AppManagerScript.Instance.selectedItem[2] = false;
            
            AppManagerScript.Instance.ChangeScene(SceneName.InGameScene_Hard);
        }
    }
        
    //Achievement

    [SerializeField] private GameObject achievementContentRoster;

    public void InitAchievement()
    {
        for (int c = 0; c < FindUIObject("AchievementContent").transform.childCount; c++)
        {
            Destroy(FindUIObject("AchievementContent").transform.GetChild(c).gameObject);
        }

        for (int i = 24; i < DBManagerScript.Instance.achievementDB.Length; i++)
        {
            GameObject tempRoster = Instantiate(achievementContentRoster, FindUIObject("AchievementContent").transform);
            var rosterManager = tempRoster.GetComponent<AchievementRosterManager>();
            rosterManager.InitRoster(DBManagerScript.Instance.achievementDB[i].no, DBManagerScript.Instance.achievementDB[i].type, DBManagerScript.Instance.achievementDB[i].NN);
            if(DBManagerScript.Instance.achievementDB[i].no > 23)
                tempRoster.SetActive(!UserManager.Instance.userData.achievementList[i]);
        }

        SetTrophy();
    }

    public void SetTrophy()
    {
        if (UserManager.Instance.userData.achievementList[24])
            FindUIObject("AchievementTrophyBlack").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_black_1");
        if (UserManager.Instance.userData.achievementList[25])
            FindUIObject("AchievementTrophyBlack").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_black_2");
        if (UserManager.Instance.userData.achievementList[26])
            FindUIObject("AchievementTrophyBlack").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_black_3");
        
        if (UserManager.Instance.userData.achievementList[27])
            FindUIObject("AchievementTrophyWhite").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_white_1");
        if (UserManager.Instance.userData.achievementList[28])
            FindUIObject("AchievementTrophyWhite").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_white_2");
        if (UserManager.Instance.userData.achievementList[29])
            FindUIObject("AchievementTrophyWhite").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_white_3");
        
        if (UserManager.Instance.userData.achievementList[50])
            FindUIObject("AchievementTrophyBujeok").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_bujeok_1");
        if (UserManager.Instance.userData.achievementList[51])
            FindUIObject("AchievementTrophyBujeok").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_bujeok_2");
        if (UserManager.Instance.userData.achievementList[52])
            FindUIObject("AchievementTrophyBujeok").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_bujeok_3");
        if (UserManager.Instance.userData.achievementList[53])
            FindUIObject("AchievementTrophyBujeok").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_bujeok_4");
        
        if (UserManager.Instance.userData.achievementList[54])
            FindUIObject("AchievementTrophyMain").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Achievements/trophy_main");
    }
    
    private void OnClickAchievementCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickAchievementAllObtainBtn()
    {
        for (int i = 0; i < FindUIObject("AchievementContent").transform.childCount; i++)
        {
            if (FindUIObject("AchievementContent").transform.GetChild(i).GetComponent<AchievementRosterManager>().canGet 
                && FindUIObject("AchievementContent").transform.GetChild(i).gameObject.activeSelf && FindUIObject("AchievementContent").transform.GetChild(i).GetComponent<AchievementRosterManager>().No > 23)
            {
                Debug.Log("HelloWorld");
                FindUIObject("AchievementContent").transform.GetChild(i).GetComponent<AchievementRosterManager>().OnClickGetBtn();
            }
        }
    }
    
    //Collection
    private void OnClickCollectionCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    public void OnClickBuffBtn()
    {
        FindUIObject("CollectionExplainPanel").SetActive(true);
        FindUIObject("Chapter1Panel").SetActive(false);
        FindUIObject("Chapter2Panel").SetActive(false);
        FindUIObject("Chapter3Panel").SetActive(false);
        FindUIObject("Chapter3Panel2").SetActive(false);
        FindUIObject("Chapter4Panel").SetActive(false);
        FindUIObject("Chapter5Panel").SetActive(false);
        FindUIObject("Chapter6Panel").SetActive(false);
    }

    public void OnClickChapter1Btn()
    {
        FindUIObject("CollectionExplainPanel").SetActive(false);
        FindUIObject("Chapter1Panel").SetActive(true);
        FindUIObject("Chapter2Panel").SetActive(false);
        FindUIObject("Chapter3Panel").SetActive(false);
        FindUIObject("Chapter3Panel2").SetActive(false);
        FindUIObject("Chapter4Panel").SetActive(false);
        FindUIObject("Chapter5Panel").SetActive(false);
        FindUIObject("Chapter6Panel").SetActive(false);
    }
    private void OnClickChapter2Btn()
    {
        FindUIObject("CollectionExplainPanel").SetActive(false);
        FindUIObject("Chapter1Panel").SetActive(false);
        FindUIObject("Chapter2Panel").SetActive(true);
        FindUIObject("Chapter3Panel").SetActive(false);
        FindUIObject("Chapter3Panel2").SetActive(false);
        FindUIObject("Chapter4Panel").SetActive(false);
        FindUIObject("Chapter5Panel").SetActive(false);
        FindUIObject("Chapter6Panel").SetActive(false);
    }
    private void OnClickChapter3Btn()
    {
        FindUIObject("CollectionExplainPanel").SetActive(false);
        FindUIObject("Chapter1Panel").SetActive(false);
        FindUIObject("Chapter2Panel").SetActive(false);
        FindUIObject("Chapter3Panel").SetActive(true);
        FindUIObject("Chapter3Panel2").SetActive(false);
        FindUIObject("Chapter4Panel").SetActive(false);
        FindUIObject("Chapter5Panel").SetActive(false);
        FindUIObject("Chapter6Panel").SetActive(false);
    }

    private void OnClickNextPage_Btn()
    {
        FindUIObject("CollectionExplainPanel").SetActive(false);
        FindUIObject("Chapter1Panel").SetActive(false);
        FindUIObject("Chapter2Panel").SetActive(false);
        FindUIObject("Chapter3Panel").SetActive(false);
        FindUIObject("Chapter3Panel2").SetActive(true);
        FindUIObject("Chapter4Panel").SetActive(false);
        FindUIObject("Chapter5Panel").SetActive(false);
        FindUIObject("Chapter6Panel").SetActive(false);
    }
    private void OnClickChapter4Btn()
    {
        FindUIObject("CollectionExplainPanel").SetActive(false);
        FindUIObject("Chapter1Panel").SetActive(false);
        FindUIObject("Chapter2Panel").SetActive(false);
        FindUIObject("Chapter3Panel").SetActive(false);
        FindUIObject("Chapter3Panel2").SetActive(false);
        FindUIObject("Chapter4Panel").SetActive(true);
        FindUIObject("Chapter5Panel").SetActive(false);
        FindUIObject("Chapter6Panel").SetActive(false);
    }
    private void OnClickChapter5Btn()
    {
        FindUIObject("CollectionExplainPanel").SetActive(false);
        FindUIObject("Chapter1Panel").SetActive(false);
        FindUIObject("Chapter2Panel").SetActive(false);
        FindUIObject("Chapter3Panel").SetActive(false);
        FindUIObject("Chapter3Panel2").SetActive(false);
        FindUIObject("Chapter4Panel").SetActive(false);
        FindUIObject("Chapter5Panel").SetActive(true);
        FindUIObject("Chapter6Panel").SetActive(false);
    }
    private void OnClickChapter6Btn()
    {
        FindUIObject("CollectionExplainPanel").SetActive(false);
        FindUIObject("Chapter1Panel").SetActive(false);
        FindUIObject("Chapter2Panel").SetActive(false);
        FindUIObject("Chapter3Panel").SetActive(false);
        FindUIObject("Chapter3Panel2").SetActive(false);
        FindUIObject("Chapter4Panel").SetActive(false);
        FindUIObject("Chapter5Panel").SetActive(false);
        FindUIObject("Chapter6Panel").SetActive(true);
    }
        
    //Shop

    private IEnumerator AzummaWork()
    {
        FindUIObject("AzummaPanel").SetActive(true);
        yield return new WaitForSeconds(2f);
        FindUIObject("AzummaPanel").SetActive(false);
    }

    public void StopAzumma()
    {
        StopCoroutine(azummaCor);
        FindUIObject("AzummaPanel").SetActive(false);
    }

    private Coroutine azummaCor;

    private void OnClickAzummaPanel()
    {
        StopAzumma();
    }
    
    private void OnClickShopCloseBtn()
    {
        SetCollectionNum();
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    [SerializeField] private ShopItemList itemType;

    private void OnClickNormalGachaOnce()
    {
        if (UserManager.Instance.userData.normalTicket < 1 && UserManager.Instance.userData.Commodities.Silver < 2000)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.NormalGacha1;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickNormalGachaFifth()
    {
        if (UserManager.Instance.userData.normalTicket < 5 && UserManager.Instance.userData.Commodities.Silver < 8000)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.NormalGacha5;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickHighGachaOnce()
    {
        if (UserManager.Instance.userData.epicTicket < 1 && UserManager.Instance.userData.Commodities.Silver < 3000)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.SpecialGacha1;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickHighGachaFifth()
    {
        if (UserManager.Instance.userData.epicTicket < 5 && UserManager.Instance.userData.Commodities.Silver < 13500)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.SpecialGacha5;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }

    private void OnClickClockBtn()
    {
        if (UserManager.Instance.userData.Commodities.Silver < 1300)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.ClockItem;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickMaskBtn()
    {
        if (UserManager.Instance.userData.Commodities.Silver < 900)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.MaskItem;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickMilkBtn()
    {
        if (UserManager.Instance.userData.Commodities.Silver < 900)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.MilkItem;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }

    private void OnClickPackage1Btn()
    {
        if (UserManager.Instance.userData.Commodities.Silver < 2800)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.Package1;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickPackage2Btn()
    {
        if (UserManager.Instance.userData.Commodities.Silver < 27000)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.Package2;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }

    private void OnClickFree1Btn()
    {
        if (UserManager.Instance.userData.Commodities.Gold < 1)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.Silver1000;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickFree2Btn()
    {
        if (UserManager.Instance.userData.Commodities.Gold < 5)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.Silver5000;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickFree3Btn()
    {
        if (UserManager.Instance.userData.Commodities.Gold < 9)
        {
            azummaCor = StartCoroutine(AzummaWork());
            return;
        }
        itemType = ShopItemList.Silver10000;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }

    public void OnClickPaid1Btn()
    {
        FindUIObject("FreeMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Silver.ToString();
        FindUIObject("PaidMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Gold.ToString();
    }
    public void OnClickPaid2Btn()
    {
        FindUIObject("FreeMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Silver.ToString();
        FindUIObject("PaidMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Gold.ToString();
    }
    public void OnClickPaid3Btn()
    {
        FindUIObject("FreeMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Silver.ToString();
        FindUIObject("PaidMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Gold.ToString();
    }

    private void OnClickBuyCheckYesBtn()
    {
        switch (itemType)
        {
            case ShopItemList.ClockItem:
                UserManager.Instance.userData.clockItem++;
                UserManager.Instance.userData.Commodities.Silver -= 1300;
                break;
            case ShopItemList.MaskItem:
                UserManager.Instance.userData.maskItem++;
                UserManager.Instance.userData.Commodities.Silver -= 900;
                break;
            case ShopItemList.MilkItem:
                UserManager.Instance.userData.milkItem++;
                UserManager.Instance.userData.Commodities.Silver -= 900;
                break;
            case ShopItemList.Package1:
                UserManager.Instance.userData.milkItem++;
                UserManager.Instance.userData.clockItem++;
                UserManager.Instance.userData.maskItem++;
                UserManager.Instance.userData.Commodities.Silver -= 2800;
                break;
            case ShopItemList.Package2:
                UserManager.Instance.userData.milkItem += 10;
                UserManager.Instance.userData.clockItem += 10;
                UserManager.Instance.userData.maskItem += 10;
                UserManager.Instance.userData.Commodities.Silver -= 27000;
                break;
            case ShopItemList.Silver1000:
                UserManager.Instance.userData.Commodities.Silver += 1000;
                UserManager.Instance.userData.Commodities.Gold -= 1;
                break;
            case ShopItemList.Silver5000:
                UserManager.Instance.userData.Commodities.Silver += 5000;
                UserManager.Instance.userData.Commodities.Gold -= 5;
                break;
            case ShopItemList.Silver10000:
                UserManager.Instance.userData.Commodities.Silver += 10000;
                UserManager.Instance.userData.Commodities.Gold -= 9;
                break;
            case ShopItemList.NormalGacha1:
                if (UserManager.Instance.userData.normalTicket >= 1)
                {
                    UserManager.Instance.userData.normalTicket--;
                }
                else if(UserManager.Instance.userData.Commodities.Silver >= 2000)
                {
                    UserManager.Instance.userData.Commodities.Silver -= 2000;
                }
                UserManager.Instance.userData.achievementCount[55] += 1;
                UserManager.Instance.userData.achievementCount[56] += 1;
                UserManager.Instance.userData.achievementCount[57] += 1;
                UserManager.Instance.userData.achievementCount[58] += 1;
                UserManager.Instance.userData.achievementCount[59] += 1;
                FindUIObject("DoGachaPopup").SetActive(true);
                FindUIObject("DoGachaNormal").GetComponent<GachaManager>().DoNormalGachaOnce();
                break;
            case ShopItemList.NormalGacha5:
                if (UserManager.Instance.userData.normalTicket >= 5)
                {
                    UserManager.Instance.userData.normalTicket -= 5;
                }
                else if(UserManager.Instance.userData.Commodities.Silver >= 8000)
                {
                    UserManager.Instance.userData.Commodities.Silver -= 8000;
                }
                UserManager.Instance.userData.achievementCount[55] += 5;
                UserManager.Instance.userData.achievementCount[56] += 5;
                UserManager.Instance.userData.achievementCount[57] += 5;
                UserManager.Instance.userData.achievementCount[58] += 5;
                UserManager.Instance.userData.achievementCount[59] += 5;
                FindUIObject("DoGachaPopup").SetActive(true);
                FindUIObject("DoGachaNormal").GetComponent<GachaManager>().DoNormalGachaFifth();
                break;
            case ShopItemList.SpecialGacha1:
                if (UserManager.Instance.userData.epicTicket >= 1)
                {
                    UserManager.Instance.userData.epicTicket--;
                }
                else if(UserManager.Instance.userData.Commodities.Silver >= 3000)
                {
                    UserManager.Instance.userData.Commodities.Silver -= 3000;
                }
                UserManager.Instance.userData.achievementCount[60] += 1;
                UserManager.Instance.userData.achievementCount[61] += 1;
                UserManager.Instance.userData.achievementCount[62] += 1;
                UserManager.Instance.userData.achievementCount[63] += 1;
                UserManager.Instance.userData.achievementCount[64] += 1;
                FindUIObject("DoGachaPopup").SetActive(true);
                FindUIObject("DoGachaEpic").GetComponent<GachaManager>().DoEpicGachaOnce();
                break;
            case ShopItemList.SpecialGacha5:
                if (UserManager.Instance.userData.epicTicket >= 5)
                {
                    UserManager.Instance.userData.epicTicket -= 5;
                }
                else if(UserManager.Instance.userData.Commodities.Silver >= 13500)
                {
                    UserManager.Instance.userData.Commodities.Silver -= 13500;
                }
                UserManager.Instance.userData.achievementCount[60] += 5;
                UserManager.Instance.userData.achievementCount[61] += 5;
                UserManager.Instance.userData.achievementCount[62] += 5;
                UserManager.Instance.userData.achievementCount[63] += 5;
                UserManager.Instance.userData.achievementCount[64] += 5;
                FindUIObject("DoGachaPopup").SetActive(true);
                FindUIObject("DoGachaEpic").GetComponent<GachaManager>().DoEpicGachaFifth();
                break;
        }
        
        //FBManagerScript.Instance.UpdateCurrentUser();
        SetTickets();
        FindUIObject("FreeMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Silver.ToString();
        FindUIObject("PaidMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Gold.ToString();
        FindUIObject("BuyCheckPopup").SetActive(false);
    }
    
    private void OnClickBuyCheckNoBtn()
    {
        FindUIObject("BuyCheckPopup").SetActive(false);
    }

    private void OnclickGachaPopupRewardClose()
    {
        FindUIObject("DoGachaPopup").SetActive(false);
        FindUIObject("GachaPopupReward").SetActive(false);
    }
        
    //Inventory
    private void OnClickInventoryCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickInventoryGoToShopBtn()
    {
        ChangeUI(MainMenuScenePanels.ShopPanel);
    }

    private IEnumerator ItemPanelCoroutine(string panelName)
    {
        FindUIObject(panelName).SetActive(true);
        yield return new WaitForSeconds(2f);
        FindUIObject(panelName).SetActive(false);
    }

    private Coroutine itemPanelCor;

    private void OnClickInventoryClockBtn()
    {
        itemPanelCor = StartCoroutine(ItemPanelCoroutine("InventoryClockExPanel"));
    }
    
    private void OnClickInventoryMilkBtn()
    {
        itemPanelCor = StartCoroutine(ItemPanelCoroutine("InventoryMilkExPanel"));
    }
    
    private void OnClickInventoryMaskBtn()
    {
        itemPanelCor = StartCoroutine(ItemPanelCoroutine("InventoryMaskExPanel"));
    }

    private void OnClickClockBackBtn()
    {
        FindUIObject("InventoryClockExPanel").SetActive(false);
        StopCoroutine(itemPanelCor);
    }
    
    private void OnClickMilkBackBtn()
    {
        FindUIObject("InventoryMilkExPanel").SetActive(false);
        StopCoroutine(itemPanelCor);
    }
    
    private void OnClickMaskBackBtn()
    {
        FindUIObject("InventoryMaskExPanel").SetActive(false);
        StopCoroutine(itemPanelCor);
    }
        
    //Option
    private void OnClickOptionCloseBtn()
    {
        //++Save
        AppManagerScript.Instance.SaveSettings();
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickOptionTerm1Btn()
    {
        Application.OpenURL("https://api-storage.cloud.toast.com/v1/AUTH_3a96d957f48e4d219e96ae174542a211/tos-Q4V7wZwf/329-1437-ko.html");
    }
    
    private void OnClickOptionTerm2Btn()
    {
        Application.OpenURL("https://api-storage.cloud.toast.com/v1/AUTH_3a96d957f48e4d219e96ae174542a211/tos-Q4V7wZwf/329-1438-ko.html");
    }
    
    private void OnClickOptionBlogBtn()
    {
        Application.OpenURL("https://m.blog.naver.com/snackcatcher");
    }
    
    private void OnClickOptionInstaBtn()
    {
        Application.OpenURL("https://www.instagram.com/snackcatcher_official/");
    }

    private void OnClickOptionCouponBtn()
    {
        //쿠폰 입력창
        FindUIObject("CouponPanel").SetActive(true);
        FindUIObject("CouponPanelInputErrorTxt").GetComponent<TMP_Text>().text = "";
    }

    private void OnClickOptionCSBtn()
    {
        Gamebase.Contact.OpenContact((error) =>
        {
            if (Gamebase.IsSuccess(error) == true)
            {
                // A user close the contact web view.
            }
            else if (error.code == GamebaseErrorCode.UI_CONTACT_FAIL_INVALID_URL)  // 6911
            {
                // TODO: Gamebase Console Service Center URL is invalid.
                // Please check the url field in the TOAST Gamebase Console.
            } 
            else if (error.code == GamebaseErrorCode.UI_CONTACT_FAIL_ANDROID_DUPLICATED_VIEW) // 6913
            { 
                // The customer center web view is already opened.
            } 
            else 
            {
                // An error occur when opening the contact web view.
            }
        });
    }

    private void OnClickOptionLogOutBtn()
    {
        FindUIObject("LogOutPanel").SetActive(true);
    }

    private void OnClickOptionWithDrawBtn()
    {
        FindUIObject("WithdrawPanel").SetActive(true);
    }

    private void OnClickLogOutConfirmBtn()
    {
        AppManagerScript.Instance.isWithDraw = true;
        PlayerPrefs.SetInt("IsFirst", 0);
        AppManagerScript.Instance.GetComponent<LogInManager>().LogOut();
    }

    private void OnClickLogOutDenyBtn()
    {
        FindUIObject("LogOutPanel").SetActive(false);
    }
    
    private void OnClickWithdrawConfirmBtn()
    {
        AppManagerScript.Instance.isWithDraw = true;
        PlayerPrefs.SetInt("IsFirst", 0);
        FBManagerScript.Instance.DeleteCurrentUser(UserManager.Instance.userID);
        AppManagerScript.Instance.GetComponent<LogInManager>().WithDraw();
    }

    private void OnClickWithdrawDenyBtn()
    {
        FindUIObject("WithdrawPanel").SetActive(false);
    }

    private void OnClickCouponPanelAcceptBtn()
    {
        //Temp Code
        if (String.CompareOrdinal(FindUIObject("CouponPanelInput").GetComponent<TMP_InputField>().text, "ILOVESNACKERS")  == 0)
        {
            if (UserManager.Instance.userData.firstCouponUsed)
            {
                FindUIObject("CouponPanelInputErrorTxt").GetComponent<TMP_Text>().color = new Color32(226, 51, 0, 255);
                FindUIObject("CouponPanelInputErrorTxt").GetComponent<TMP_Text>().text = "이미 사용된 쿠폰 번호입니다.";
                return;
            }
            UserManager.Instance.userData.firstCouponUsed = true;
            UserManager.Instance.userData.clockItem += 1;
            UserManager.Instance.userData.maskItem += 1;
            UserManager.Instance.userData.milkItem += 1;
            UserManager.Instance.userData.epicTicket += 1;
            //FBManagerScript.Instance.UpdateCurrentUser();
            FindUIObject("CouponPanelInputErrorTxt").GetComponent<TMP_Text>().color = new Color32(41, 140, 0, 255);
            FindUIObject("CouponPanelInputErrorTxt").GetComponent<TMP_Text>().text = "보상이 지급되었습니다.";
        }
        else
        {
            FindUIObject("CouponPanelInputErrorTxt").GetComponent<TMP_Text>().color = new Color32(226, 51, 0, 255);
            FindUIObject("CouponPanelInputErrorTxt").GetComponent<TMP_Text>().text = "잘못된 쿠폰 번호입니다.";
        }
    }
    
    //Profile

    private Sprite[] _profileImageList;
    private Sprite[] _profileEdgeList;
    
    [SerializeField] private GameObject profileEditRosterPrefab;

    public void InitProfileCollection()
    {
        Debug.Log((float)collection / DBManagerScript.Instance.snackDB.Length);
        FindUIObject("ProfileCollectionPercentageBody").GetComponent<TMP_Text>().text =
            ((float)collection / DBManagerScript.Instance.snackDB.Length * 100).ToString("F2");
        int achievement = 0;
        for (int i = 0; i < UserManager.Instance.userData.achievementList.Count; i++)
        {
            if (UserManager.Instance.userData.achievementList[i]) achievement++;
        }
        FindUIObject("ProfileAchievementBody").GetComponent<TMP_Text>().text =
            ((float)achievement / DBManagerScript.Instance.achievementDB.Length * 100).ToString("F2");
    }

    public void InitProfileScore()
    {
        
    }
    
    private void InitProfileSprites()
    {
        _profileImageList = Resources.LoadAll<Sprite>($"ProfileImages");
        _profileEdgeList = Resources.LoadAll<Sprite>($"ProfileEdges");
    }

    [SerializeField] private int tempSelectProfileImage;
    [SerializeField] private int tempSelectProfileEdge;
    
    public void InitProfileImages()
    {
        tempSelectProfileEdge = UserManager.Instance.userData.profileImageIndex;
        tempSelectProfileEdge = UserManager.Instance.userData.profileEdgeIndex;
        FindUIObject("ProfileImage").GetComponent<Image>().sprite =
            _profileImageList[UserManager.Instance.userData.profileImageIndex];
        
        Transform profileImageContent = FindUIObject("ProfileEditPopupImagePanelContent").transform;
        for (int i = 0; i < _profileImageList.Length; i++)
        {
            GameObject tempProfile = Instantiate(profileEditRosterPrefab, profileImageContent);
            tempProfile.GetComponent<Image>().sprite = _profileEdgeList[UserManager.Instance.userData.profileEdgeIndex];
            tempProfile.transform.GetChild(0).GetComponent<Image>().sprite = _profileImageList[i];
            tempProfile.GetComponent<Button>().onClick.AddListener(() =>
            {
                MasterAudio.PlaySound("IconClick");
                tempSelectProfileImage = tempProfile.transform.GetSiblingIndex();
                for (int k = 0; k < FindUIObject("ProfileEditPopupImagePanelContent").transform.childCount; k++)
                {
                    var color = FindUIObject("ProfileEditPopupImagePanelContent").transform.GetChild(k).GetChild(1).GetComponent<Image>().color;
                    color.a = 0;
                    FindUIObject("ProfileEditPopupImagePanelContent").transform.GetChild(k).GetChild(1).GetComponent<Image>().color = color;
                }
                for (int j = 0; j < FindUIObject("ProfileEditPopupEdgePanelContent").transform.childCount; j++)
                {
                    FindUIObject("ProfileEditPopupEdgePanelContent").transform.GetChild(j).GetChild(0).GetComponent<Image>().sprite = _profileImageList[tempSelectProfileImage];
                }

                var colorTemp = tempProfile.transform.GetChild(1).GetComponent<Image>().color;
                colorTemp.a = 1;
                tempProfile.transform.GetChild(1).GetComponent<Image>().color = colorTemp;
            });
            if (i == UserManager.Instance.userData.profileImageIndex)
            {
                var color = FindUIObject("ProfileEditPopupImagePanelContent").transform.GetChild(i).GetChild(1).GetComponent<Image>().color;
                color.a = 1;
                FindUIObject("ProfileEditPopupImagePanelContent").transform.GetChild(i).GetChild(1).GetComponent<Image>().color = color;
            }
            else
            {
                var color = FindUIObject("ProfileEditPopupImagePanelContent").transform.GetChild(i).GetChild(1).GetComponent<Image>().color;
                color.a = 0;
                FindUIObject("ProfileEditPopupImagePanelContent").transform.GetChild(i).GetChild(1).GetComponent<Image>().color = color;
            }
        }
    }
    
    public void InitProfileEdges()
    {
        FindUIObject("ProfileImageBG").GetComponent<Image>().sprite =
            _profileEdgeList[UserManager.Instance.userData.profileEdgeIndex];
        
        Transform profileImageContent = FindUIObject("ProfileEditPopupEdgePanelContent").transform;
        for (int i = 0; i < _profileEdgeList.Length; i++)
        {
            GameObject tempProfile = Instantiate(profileEditRosterPrefab, profileImageContent);
            tempProfile.GetComponent<Image>().sprite = _profileEdgeList[i];
            tempProfile.transform.GetChild(0).GetComponent<Image>().sprite = _profileImageList[UserManager.Instance.userData.profileImageIndex];
            tempProfile.GetComponent<Button>().onClick.AddListener(() =>
            {
                MasterAudio.PlaySound("IconClick");
                tempSelectProfileEdge = tempProfile.transform.GetSiblingIndex();
                for (int k = 0; k < FindUIObject("ProfileEditPopupEdgePanelContent").transform.childCount; k++)
                {
                    var color = FindUIObject("ProfileEditPopupEdgePanelContent").transform.GetChild(k).GetChild(1).GetComponent<Image>().color;
                    color.a = 0;
                    FindUIObject("ProfileEditPopupEdgePanelContent").transform.GetChild(k).GetChild(1).GetComponent<Image>().color = color;
                }
                for (int j = 0; j < FindUIObject("ProfileEditPopupImagePanelContent").transform.childCount; j++)
                {
                    FindUIObject("ProfileEditPopupImagePanelContent").transform.GetChild(j).GetComponent<Image>().sprite = _profileEdgeList[tempSelectProfileEdge];
                }
                var colorTemp = tempProfile.transform.GetChild(1).GetComponent<Image>().color;
                colorTemp.a = 1;
                tempProfile.transform.GetChild(1).GetComponent<Image>().color = colorTemp;
            });
            if (i == UserManager.Instance.userData.profileEdgeIndex)
            {
                var color = FindUIObject("ProfileEditPopupEdgePanelContent").transform.GetChild(i).GetChild(1).GetComponent<Image>().color;
                color.a = 1;
                FindUIObject("ProfileEditPopupEdgePanelContent").transform.GetChild(i).GetChild(1).GetComponent<Image>().color = color;
            }
            else
            {
                var color = FindUIObject("ProfileEditPopupEdgePanelContent").transform.GetChild(i).GetChild(1).GetComponent<Image>().color;
                color.a = 0;
                FindUIObject("ProfileEditPopupEdgePanelContent").transform.GetChild(i).GetChild(1).GetComponent<Image>().color = color;
            }
        }
        
        profileImageContent.GetChild(3).GetComponent<Button>().interactable = UserManager.Instance.userData.achievementList[46];
        profileImageContent.GetChild(6).GetComponent<Button>().interactable = UserManager.Instance.userData.achievementList[47];
        profileImageContent.GetChild(5).GetComponent<Button>().interactable = UserManager.Instance.userData.achievementList[48];
        profileImageContent.GetChild(4).GetComponent<Button>().interactable = UserManager.Instance.userData.achievementList[49];

    }
    
    private void OnClickProfileCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickProfileImageEditBtn()
    {
        FindUIObject("ProfileEdgeBtn").transform.SetSiblingIndex(1);
        FindUIObject("ProfileEditBtn").transform.SetSiblingIndex(4);
        FindUIObject("ProfileEditPopupEdgePanel").SetActive(false);
        FindUIObject("ProfileEditPopupImagePanel").SetActive(true);
        FindUIObject("ProfileEditPopup").SetActive(true);
        
    }

    private void OnClickProfileNickNameEditBtn()
    {
        FindUIObject("EditNickNamePanel").SetActive(true);
    }

    private void OnClickProfileEdgeBtn()
    {
        FindUIObject("ProfileEdgeBtn").transform.SetSiblingIndex(4);
        FindUIObject("ProfileEditBtn").transform.SetSiblingIndex(1);
        FindUIObject("ProfileEditPopupEdgePanel").SetActive(true);
        FindUIObject("ProfileEditPopupImagePanel").SetActive(false);
    }

    private void OnClickProfileEditBtn()
    {
        FindUIObject("ProfileEdgeBtn").transform.SetSiblingIndex(1);
        FindUIObject("ProfileEditBtn").transform.SetSiblingIndex(4);
        FindUIObject("ProfileEditPopupEdgePanel").SetActive(false);
        FindUIObject("ProfileEditPopupImagePanel").SetActive(true);
    }

    private void OnClickProfileEditCloseBtn()
    {
        UserManager.Instance.userData.profileEdgeIndex = tempSelectProfileEdge;
        UserManager.Instance.userData.profileImageIndex = tempSelectProfileImage;
        //FBManagerScript.Instance.UpdateCurrentUser();
        FindUIObject("ProfileImage").GetComponent<Image>().sprite =
            _profileImageList[UserManager.Instance.userData.profileImageIndex];
        FindUIObject("ProfileImageBG").GetComponent<Image>().sprite =
            _profileEdgeList[UserManager.Instance.userData.profileEdgeIndex];
        FindUIObject("ProfileEditPopup").SetActive(false);
    }

    private async void OnClickEditNickNameConfirmBtn()
    {
        string nickName = FindUIObject("EditNickNameInput").GetComponent<TMP_InputField>().text;
        string errorTxt;
        // 1 ~ 6글자
        if (nickName.Length < 1 || nickName.Length > 6)
        {
            errorTxt = "1~6자의 영문 대소문자, 숫자, 한글만 가능합니다.";
            FindUIObject("EditNickNameInputErrorTxt").GetComponent<TMP_Text>().text = errorTxt;
        }
        // 중복
        else if (await FBManagerScript.Instance.CheckNicknameExist(nickName))
        {
            errorTxt = "중복된 닉네임입니다.";
            FindUIObject("EditNickNameInputErrorTxt").GetComponent<TMP_Text>().text = errorTxt;
        }
        // 특수문자
        else if (Regex.IsMatch(nickName, @"[^a-zA-Z0-9가-힣]"))
        {
            errorTxt = "1~6자의 영문 대소문자, 숫자, 한글만 가능합니다.";
            FindUIObject("EditNickNameInputErrorTxt").GetComponent<TMP_Text>().text = errorTxt;
        }
        else
        {
            errorTxt = "";
            FindUIObject("SetNickNameInputErrorTxt").GetComponent<TMP_Text>().text = errorTxt;
            UserManager.Instance.userData.nickName = nickName;
            FBManagerScript.Instance.UpdateCurrentUser();
            FindUIObject("SetNickNamePanel").SetActive(false);
            InitProfile();
            FindUIObject("EditNickNamePanel").SetActive(false);
            ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
        }
    }

    private void OnClickEditNickNamePanelCloseBtn()
    {
        FindUIObject("EditNickNamePanel").SetActive(false);
    }

    private void OnClickEnergyBuyPanelBuyBtn()
    {
        if (UserManager.Instance.userData.Commodities.Gold < 5)
        {
            AppManagerScript.Instance.InitCautionPanel(2);
        }
        else
        {
            UserManager.Instance.userData.Commodities.Gold -= 5;
            UserManager.Instance.userData.energy += 5;
            //FBManagerScript.Instance.UpdateCurrentUser();
            FindUIObject("EnergyBuyPanel").SetActive(false);
        }
    }

    #endregion

    #region Change UI

    public enum MainMenuScenePanels
    {
        SetNickNamePanel,
        StoryPanel,
        MainMenuTouchPanel,
        StagePanel,
        AchievementPanel,
        CollectionPanel,
        ShopPanel,
        InventoryPanel,
        OptionPanel,
        ProfilePanel,
        TutorialPanel,
    }

    public void ChangeUI(MainMenuScenePanels mainMenuScenePanels)
    {
        FindUIObject("SetNickNamePanel").SetActive(false);
        FindUIObject("MainMenuTouchPanel").SetActive(false);
        FindUIObject("ChapterPanel").SetActive(false);
        FindUIObject("AchievementPanel").SetActive(false);
        FindUIObject("CollectionPanel").SetActive(false);
        FindUIObject("ShopPanel").SetActive(false);
        FindUIObject("InventoryPanel").SetActive(false);
        FindUIObject("OptionPanel").SetActive(false);
        FindUIObject("ProfilePanel").SetActive(false);

        switch (mainMenuScenePanels)
        {
            case MainMenuScenePanels.SetNickNamePanel:
                FindUIObject("SetNickNamePanel").SetActive(true);
                break;
            case MainMenuScenePanels.MainMenuTouchPanel:
                FindUIObject("MainMenuTouchPanel").SetActive(true);
                break;
            case MainMenuScenePanels.StagePanel:
                FindUIObject("ChapterPageBG").SetActive(true);
                FindUIObject("StagePageBG").SetActive(false);
                FindUIObject("ChapterPanel").SetActive(true);
                if(!UserManager.Instance.userData.tutorial2)
                {
                    if (UserManager.Instance.userData.starList.Count == 0)
                    {
                        FindUIObject("Tutorial2-1").SetActive(true);
                    }
                }
                /*FindUIObject("Chapter4SelectBtn").SetActive(UserManager.Instance.userData.starList.Count >= 12);
                FindUIObject("Chapter5SelectBtn").SetActive(UserManager.Instance.userData.starList.Count >= 12);
                FindUIObject("Chapter6SelectBtn").SetActive(UserManager.Instance.userData.starList.Count >= 12);*/
                break;
            case MainMenuScenePanels.AchievementPanel:
                InitAchievement();
                FindUIObject("AchievementPanel").SetActive(true);
                break;
            case MainMenuScenePanels.CollectionPanel:
                FindUIObject("CollectionExplainPanel").SetActive(true);
                FindUIObject("Chapter1Panel").SetActive(false);
                FindUIObject("Chapter2Panel").SetActive(false);
                FindUIObject("Chapter3Panel").SetActive(false);
                FindUIObject("Chapter3Panel2").SetActive(false);
                FindUIObject("Chapter4Panel").SetActive(false);
                FindUIObject("Chapter5Panel").SetActive(false);
                FindUIObject("Chapter6Panel").SetActive(false);
                /*FindUIObject("Chapter4Btn").SetActive(UserManager.Instance.userData.starList.Count > 12);
                FindUIObject("Chapter5Btn").SetActive(UserManager.Instance.userData.starList.Count > 12);
                FindUIObject("Chapter6Btn").SetActive(UserManager.Instance.userData.starList.Count > 12);*/
                FindUIObject("CollectionPanel").SetActive(true);
                break;
            case MainMenuScenePanels.ShopPanel:
                FindUIObject("ShopPanel").SetActive(true);
                FindUIObject("FreeMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Silver.ToString();
                FindUIObject("PaidMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Gold.ToString();
                FindUIObject("ShopMoveBtn").GetComponent<Animator>().SetTrigger("OpenDoor");
                break;
            case MainMenuScenePanels.InventoryPanel:
                FindUIObject("InventoryPanel").SetActive(true);
                break;
            case MainMenuScenePanels.OptionPanel:
                FindUIObject("OptionPanel").SetActive(true);
                break;
            case MainMenuScenePanels.ProfilePanel:
                FindUIObject("ProfilePanel").SetActive(true);
                break;
            case MainMenuScenePanels.TutorialPanel:
                FindUIObject("MainMenuTouchPanel").SetActive(true);
                FindUIObject("TutorialPanel").SetActive(true);
                break;
            case MainMenuScenePanels.StoryPanel:
                Instantiate(Resources.Load<GameObject>("Story/Opening"), transform);
                break;
        }
    }

    #endregion
    
    //Profile
    public void InitProfile()
    {
        FindUIObject("ProfileNickNameBody").GetComponent<TMP_Text>().text = UserManager.Instance.userData.nickName;
    }

    [SerializeField] private int collection;

    public void SetCollectionNum()
    {
        collection = 0;
        for (int i = 0; i < UserManager.Instance.userData.snackList.Count; i++)
        {
            if (FindUIObject(DBManagerScript.Instance.snackDB[i].name))
            {
                FindUIObject(DBManagerScript.Instance.snackDB[i].name).transform.GetChild(2).GetComponent<Text>().text =
                    "(" + UserManager.Instance.userData.snackList[i] + "/" + DBManagerScript.Instance.snackDB[i].P2A + ")";

                if (UserManager.Instance.userData.snackList[i] > 0)
                {
                    FindUIObject(DBManagerScript.Instance.snackDB[i].name).transform.GetChild(0).GetComponent<Image>()
                        .material = null;
                }
                
                if (UserManager.Instance.userData.snackList[i] >= DBManagerScript.Instance.snackDB[i].P2A)
                {
                    UserManager.Instance.userData.snackList[i] = DBManagerScript.Instance.snackDB[i].P2A;
                    collection++;
                    FindUIObject(DBManagerScript.Instance.snackDB[i].name).transform.GetChild(3).gameObject
                        .SetActive(true);
                }
            }
        }
        UserManager.Instance.userData.achievementCount[50] = collection;
        UserManager.Instance.userData.achievementCount[51] = collection;
        UserManager.Instance.userData.achievementCount[52] = collection;
        UserManager.Instance.userData.achievementCount[53] = collection;
    }

    public void InitCollection()
    {
        FindUIObject("Buff1CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 1) + "/1)";
        FindUIObject("Buff2CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 5) + "/5)";
        FindUIObject("Buff3CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 15) + "/15)";
        FindUIObject("Buff4CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 25) + "/25)";
        FindUIObject("Buff5CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 35) + "/35)";
        if (collection >= 1)
        {
            FindUIObject("Buff1Txt").GetComponent<TMP_Text>().text = "간식 양 " + DBManagerScript.Instance.buffDB[0].NN + "% 감소";
            FindUIObject("Buff1Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[0] = true;
        }
        
        if (collection >= 5)
        {
            FindUIObject("Buff2Txt").GetComponent<TMP_Text>().text = "발생 데시벨 " + DBManagerScript.Instance.buffDB[1].NN + "% 감소";
            FindUIObject("Buff2Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[1] = true;
        }
        
        if (collection >= 15)
        {
            FindUIObject("Buff3Txt").GetComponent<TMP_Text>().text = "최대 데시벨 " + DBManagerScript.Instance.buffDB[2].NN + "% 증가";
            FindUIObject("Buff3Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[2] = true;
        }
        
        if (collection >= 25)
        {
            FindUIObject("Buff4Txt").GetComponent<TMP_Text>().text = "발생 데시벨 " + DBManagerScript.Instance.buffDB[3].NN + "% 감소";
            FindUIObject("Buff4Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[3] = true;
        }
        
        if (collection >= 35)
        {
            FindUIObject("Buff5Txt").GetComponent<TMP_Text>().text = "먹는 속도 " + DBManagerScript.Instance.buffDB[4].NN + " 증가";
            FindUIObject("Buff5Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[4] = true;
        }
    }
    
    
    //Settings

    public void InitSettingUI()
    {
        FindUIObject("OptionSoundPanelBGSlider").GetComponent<Slider>().value =
            AppManagerScript.Instance.bgmVolume;
        FindUIObject("OptionSoundPanelEffectSlider").GetComponent<Slider>().value =
            AppManagerScript.Instance.effectVolume;
        FindUIObject("OptionVibrationOnToggle").GetComponent<Toggle>().isOn =
            AppManagerScript.Instance.isVibration;
        Gamebase.Push.QueryTokenInfo((data, error)=> 
        {
            if (Gamebase.IsSuccess(error)) 
            {
                // Succeeded.
                bool enablePush = data.agreement.pushEnabled;
                FindUIObject("OptionPushOnToggle").GetComponent<Toggle>().isOn = enablePush;
            }
        });

    }

    private void Update()
    {
        SettingBgmVolume();
        SettingEffectVolume();
        ResetCommodities();
        ResetEnergy();
    }

    public void SettingBgmVolume()
    {
        AppManagerScript.Instance.bgmVolume = FindUIObject("OptionSoundPanelBGSlider").GetComponent<Slider>().value;
        MasterAudio.PlaylistMasterVolume = FindUIObject("OptionSoundPanelBGSlider").GetComponent<Slider>().value;
    }
    
    public void SettingEffectVolume()
    {
        AppManagerScript.Instance.effectVolume = FindUIObject("OptionSoundPanelEffectSlider").GetComponent<Slider>().value;
        MasterAudio.Instance._masterAudioVolume = FindUIObject("OptionSoundPanelEffectSlider").GetComponent<Slider>().value;
    }

    public void SettingVibration()
    {
        AppManagerScript.Instance.isVibration = FindUIObject("OptionVibrationOnToggle").GetComponent<Toggle>().isOn;
    }

    public void SettingPushAlarm()
    {
        GamebaseRequest.Push.PushConfiguration pushConfiguration = new GamebaseRequest.Push.PushConfiguration();
        Gamebase.Push.RegisterPush(pushConfiguration, (error) =>
        {
            if (Gamebase.IsSuccess(error))
            {
                pushConfiguration.pushEnabled = FindUIObject("OptionPushOnToggle").GetComponent<Toggle>().isOn;     
            }
            else
            {
                Debug.Log(string.Format("SaveTerms failed. error:{0}", error));
            }
        });
    }
    
    
    //Commodities
    public void ResetCommodities()
    {
        if(UserManager.Instance)
        {
            FindUIObject("FreeTxt").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Silver.ToString();
            FindUIObject("PaidTxt").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Gold.ToString();
        }
    }

    public void ResetItems()
    {
        FindUIObject("InventoryClockText").GetComponent<TMP_Text>().text = "보유량 : " + UserManager.Instance.userData.clockItem + "개";
        FindUIObject("InventoryMilkText").GetComponent<TMP_Text>().text = "보유량 : " + UserManager.Instance.userData.milkItem + "개";
        FindUIObject("InventoryMaskText").GetComponent<TMP_Text>().text = "보유량 : " + UserManager.Instance.userData.maskItem + "개";
        /*FindUIObject("StagePageItem1").GetComponent<Toggle>().interactable = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem2").GetComponent<Toggle>().interactable = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem3").GetComponent<Toggle>().interactable = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn = UserManager.Instance.userData.milkItem > 0;*/
    }

    public void InitEnergy()
    {
        UserManager.Instance.LoadFromDB();
        FindUIObject("EnergyTxt").GetComponent<TMP_Text>().text = UserManager.Instance.userData.energy + " / 5";
    }

    public void ResetEnergy()
    {
        FindUIObject("EnergyTxt").GetComponent<TMP_Text>().text = UserManager.Instance.userData.energy + " / 5";;
        FindUIObject("EnergyBuyPanelCount").GetComponent<TMP_Text>().text = UserManager.Instance.userData.energy + " / 5";;
        FindUIObject("EnergyBuyPanelTimer").GetComponent<TMP_Text>().text =
            (UserManager.Instance.m_RechargeRemainTime / 60) + " : " +
            (UserManager.Instance.m_RechargeRemainTime % 60);
    }
    
    //Stage
    public void CheckStageStar()
    {
        int chapter = (AppManagerScript.Instance.selectedChapter - 1) * 4;
        Debug.Log(chapter);
        if (chapter + 0 < UserManager.Instance.userData.starList.Count)
        {
            SetStageStar(UserManager.Instance.userData.starList[chapter + 0], FindUIObject("Stage1Stars"));
        }
        else
        {
            SetStageStar(0, FindUIObject("Stage1Stars"));
        }
        if (chapter + 1 < UserManager.Instance.userData.starList.Count)
        {
            SetStageStar(UserManager.Instance.userData.starList[chapter + 1], FindUIObject("Stage2Stars"));
        }
        else
        {
            SetStageStar(0, FindUIObject("Stage2Stars"));
        }
        if (chapter + 2 < UserManager.Instance.userData.starList.Count)
        {
            SetStageStar(UserManager.Instance.userData.starList[chapter + 2], FindUIObject("Stage3Stars"));
        }
        else
        {
            SetStageStar(0, FindUIObject("Stage3Stars"));
        }
        if (chapter + 3 < UserManager.Instance.userData.starList.Count)
        {
            SetStageStar(UserManager.Instance.userData.starList[chapter + 3], FindUIObject("Stage4Stars"));
        }
        else
        {
            SetStageStar(0, FindUIObject("Stage4Stars"));
        }
    }

    private void SetStageStar(int star, GameObject go)
    {
        switch (star)
        {
            case 0:
                go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Stage/icon_stagechoice_star_0");
                break;
            case 1:
                go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Stage/icon_stagechoice_star_1");
                break;
            case 2:
                go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Stage/icon_stagechoice_star_2");
                break;
            case 3:
                go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Stage/icon_stagechoice_star_3");
                break;
        }
    }
    
    public void CheckStageEnable()
    {
        int stageIndex = (AppManagerScript.Instance.selectedChapter - 1) * 4 + AppManagerScript.Instance.selectedStage - 1;
        if (UserManager.Instance.userData.starList.Count < stageIndex)
        {
            //Disable
            FindUIObject("StageStartBtn").GetComponent<Button>().interactable = false;
        }
        else
        {
            //Enable
            FindUIObject("StageStartBtn").GetComponent<Button>().interactable = true;
        }
    }

    public void UpdateSetNickNameUI()
    {
        string nickName = FindUIObject("SetNickNameInput").GetComponent<TMP_InputField>().text;
        FindUIObject("SetNickNameInputLength").GetComponent<TMP_Text>().text = nickName.Length + "/" + 6;
    }

    public void TutorialToggleCheck()
    {
        AppManagerScript.Instance.isStageTutorial = FindUIObject("StagePageTutorialToggle").GetComponent<Toggle>().isOn;
    }
}
