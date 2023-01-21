using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using TMPro;
using Toast.Gamebase;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSceneUIManager : UIControllerScript
{
    public override void InitSetup(GameObject scriptObject)
    {
        base.InitSetup(scriptObject);
        AddOnClick();
        InitProfileSprites();
    }

    private void OnDisable()
    {
        Debug.Log("Diabled");
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
            //Set Nick Name
            case MainMenuSceneButtons.SetNickNameConfirmBtn:
                OnClickSetNickNameConfirmBtn();
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
            case MainMenuSceneButtons.ShopCloseBtn:
                OnClickShopCloseBtn();
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
            case MainMenuSceneButtons.BuyCheckYesBtn:
                OnClickBuyCheckYesBtn();
                break;
            case MainMenuSceneButtons.BuyCheckNoBtn:
                OnClickBuyCheckNoBtn();
                break;
            
            //Inventory
            case MainMenuSceneButtons.InventoryCloseBtn:
                OnClickInventoryCloseBtn();
                break;
            case MainMenuSceneButtons.InventoryGoToShopBtn:
                OnClickInventoryGoToShopBtn();
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
            case MainMenuSceneButtons.OptionLogOutBtn:
                OnClickOptionLogOutBtn();
                break;
            case MainMenuSceneButtons.OptionWithDrawBtn:
                OnClickOptionWithDrawBtn();
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

        }
    }
    
    private enum MainMenuSceneButtons
    {
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
        ChapterPageCloseBtn,
        
        ChapterToStage1,
        ChapterToStage2,
        ChapterToStage3,
        ChapterToStage4,
        StagePageCloseBtn,

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
        ShopCloseBtn,
            //Gotcha
        
            //Item
        ClockBtn,
        MaskBtn,
        MilkBtn,
            //BuyCheck
        BuyCheckYesBtn,
        BuyCheckNoBtn,
        
        
        //Inventory
        InventoryCloseBtn,
        InventoryGoToShopBtn,
        
        //Option
        OptionCloseBtn,
        CustomerServicePanelTerm1BG,
        CustomerServicePanelTerm2BG,
        CustomerServicePanelBlogBG,
        CustomerServicePanelInstaBG,
        
        OptionLogOutBtn,
        OptionWithDrawBtn,
        
        //Profile
        ProfileCloseBtn,
        ProfileImageEditBtn,
        ProfileNickNameEditBtn,
        ProfileEditBtn,
        ProfileEdgeBtn,
        ProfileEditCloseBtn
    }
    
    //Set Nick Name
    private void OnClickSetNickNameConfirmBtn()
    {
        string nickName = FindUIObject("SetNickNameInputField").GetComponent<TMP_InputField>().text;
        FBManagerScript.Instance.WriteNewUser(UserManager.Instance.userID, nickName);
        FBManagerScript.Instance.GetUserData();
        FindUIObject("SetNickNamePanel").SetActive(false);
        ResetCommodities();
        ResetItems();
        InitProfile();
        SetCollectionNum();
        InitCollection();
        InitProfileEdges();
        InitProfileImages();
        InitProfileCollection();
        InitProfileScore();
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
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
    
    private void OnClickCollectionMoveBtn()
    {
        MasterAudio.PlaySound("CollectionClick");
        FindUIObject("CollectionExplainPanel").SetActive(true);
        FindUIObject("Chapter1Panel").SetActive(false);
        FindUIObject("Chapter2Panel").SetActive(false);
        FindUIObject("Chapter3Panel").SetActive(false);
        FindUIObject("Chapter3Panel2").SetActive(false);
        FindUIObject("Chapter4Panel").SetActive(false);
        FindUIObject("Chapter5Panel").SetActive(false);
        FindUIObject("Chapter6Panel").SetActive(false);
        ChangeUI(MainMenuScenePanels.CollectionPanel);
    }
    
    private void OnClickShopMoveBtn()
    {
        MasterAudio.PlaySound("DoorClick");
        FindUIObject("FreeMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Silver.ToString();
        FindUIObject("PaidMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Gold.ToString();
        ChangeUI(MainMenuScenePanels.ShopPanel);
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
    
    private void OnClickChapterSelectBtn(int chapter)
    {
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
        
        //별 불러오기
    }

    private void OnClickChapterPageCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickChapterToStage(int stage)
    {
        AppManagerScript.Instance.selectedStage = stage;
        int stageNum = (AppManagerScript.Instance.selectedChapter - 1) * 4 + AppManagerScript.Instance.selectedStage - 1;
        CheckStageEnable();
        switch (stage)
        {
            case 1:
                FindUIObject("StagePageTeacherImg").GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Stage/art_teacher_korean");
                break;
            case 2:
                FindUIObject("StagePageTeacherImg").GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Stage/art_teacher_history");
                break;
            case 3:
                FindUIObject("StagePageTeacherImg").GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Stage/art_teacher_music");
                break;
            case 4:
                FindUIObject("StagePageTeacherImg").GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Stage/art_teacher_english");
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
            FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn = UserManager.Instance.userData.milkItem != 0;
            FindUIObject("StagePageItem1").GetComponent<Toggle>().interactable = UserManager.Instance.userData.milkItem != 0;
            FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn = UserManager.Instance.userData.clockItem != 0;
            FindUIObject("StagePageItem2").GetComponent<Toggle>().interactable = UserManager.Instance.userData.clockItem != 0;
            FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn = UserManager.Instance.userData.maskItem != 0;
            FindUIObject("StagePageItem3").GetComponent<Toggle>().interactable = UserManager.Instance.userData.maskItem != 0;
        }
        else
        {
            FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn = false;
            FindUIObject("StagePageItem1").GetComponent<Toggle>().interactable = false;
            FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn = false;
            FindUIObject("StagePageItem2").GetComponent<Toggle>().interactable = false;
            FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn = false;
            FindUIObject("StagePageItem3").GetComponent<Toggle>().interactable = false;    
        }

        FindUIObject("ChapterPageBG").SetActive(false);
        FindUIObject("StagePageBG").SetActive(true);
    }
    
    private void OnClickStagePageCloseBtn()
    {
        FindUIObject("ChapterPageBG").SetActive(true);
        FindUIObject("StagePageBG").SetActive(false);
    }
    
    //Stage
    private void OnClickStageStartBtn()
    {
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
    private void OnClickAchievementCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickAchievementAllObtainBtn()
    {
        
    }
    
    //Collection
    private void OnClickCollectionCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickBuffBtn()
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

    private void OnClickChapter1Btn()
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
    private void OnClickShopCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickClockBtn()
    {
        if(UserManager.Instance.userData.Commodities.Silver < 900) return;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickMaskBtn()
    {
        if(UserManager.Instance.userData.Commodities.Silver < 900) return;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }
    
    private void OnClickMilkBtn()
    {
        if(UserManager.Instance.userData.Commodities.Silver < 900) return;
        FindUIObject("BuyCheckPopup").SetActive(true);
    }

    private void OnClickBuyCheckYesBtn()
    {
        UserManager.Instance.userData.clockItem++;
        UserManager.Instance.userData.Commodities.Silver -= 900;
        FBManagerScript.Instance.UpdateCurrentUser();
        FindUIObject("FreeMoneyText").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Silver.ToString();
        FindUIObject("BuyCheckPopup").SetActive(false);
    }
    
    private void OnClickBuyCheckNoBtn()
    {
        FindUIObject("BuyCheckPopup").SetActive(false);
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
        
    //Option
    private void OnClickOptionCloseBtn()
    {
        //++Save
        JsonHelper.SaveSettings(AppManagerScript.Instance.appSettings);
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickOptionTerm1Btn()
    {
        Application.OpenURL("https://api-storage.cloud.toast.com/v1/AUTH_3a96d957f48e4d219e96ae174542a211/tos/sample.html");
    }
    
    private void OnClickOptionTerm2Btn()
    {
        Application.OpenURL("https://api-storage.cloud.toast.com/v1/AUTH_3a96d957f48e4d219e96ae174542a211/tos/sample.html");
    }
    
    private void OnClickOptionBlogBtn()
    {
        Application.OpenURL("https://m.blog.naver.com/snackcatcher");
    }
    
    private void OnClickOptionInstaBtn()
    {
        Application.OpenURL("https://www.instagram.com/snackcatcher_official/");
    }

    private void OnClickOptionLogOutBtn()
    {
        AppManagerScript.Instance.isWithDraw = true;
        PlayerPrefs.SetInt("IsFirst", 0);
        AppManagerScript.Instance.GetComponent<LogInManager>().LogOut();
    }

    private void OnClickOptionWithDrawBtn()
    {
        AppManagerScript.Instance.isWithDraw = true;
        PlayerPrefs.SetInt("IsFirst", 0);
        FBManagerScript.Instance.DeleteCurrentUser(UserManager.Instance.userID);
        AppManagerScript.Instance.GetComponent<LogInManager>().WithDraw();
    }
    
    //Profile

    private Sprite[] _profileImageList;
    private Sprite[] _profileEdgeList;
    
    [SerializeField] private GameObject profileEditRosterPrefab;

    public void InitProfileCollection()
    {
        Debug.Log((float)collection / DBManagerScript.Instance.snackDB.Length);
        FindUIObject("ProfileCollectionPercentageBody").GetComponent<TMP_Text>().text =
            ((float)collection / DBManagerScript.Instance.snackDB.Length).ToString("F2");
    }

    public void InitProfileScore()
    {
        
    }
    
    private void InitProfileSprites()
    {
        _profileImageList = Resources.LoadAll<Sprite>($"ProfileImages");
        _profileEdgeList = Resources.LoadAll<Sprite>($"ProfileEdges");
        tempSelectProfileEdge = UserManager.Instance.userData.profileImageIndex;
        tempSelectProfileEdge = UserManager.Instance.userData.profileEdgeIndex;
    }

    [SerializeField] private int tempSelectProfileImage;
    [SerializeField] private int tempSelectProfileEdge;
    
    public void InitProfileImages()
    {
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
                for (int j = 0; j < FindUIObject("ProfileEditPopupEdgePanelContent").transform.childCount; j++)
                {
                    FindUIObject("ProfileEditPopupEdgePanelContent").transform.GetChild(j).GetChild(0).GetComponent<Image>().sprite = _profileImageList[tempSelectProfileImage];
                }
            });
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
                for (int j = 0; j < FindUIObject("ProfileEditPopupImagePanelContent").transform.childCount; j++)
                {
                    FindUIObject("ProfileEditPopupImagePanelContent").transform.GetChild(j).GetComponent<Image>().sprite = _profileEdgeList[tempSelectProfileEdge];
                }
            });
        }
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
        FBManagerScript.Instance.UpdateCurrentUser();
        FindUIObject("ProfileImage").GetComponent<Image>().sprite =
            _profileImageList[UserManager.Instance.userData.profileImageIndex];
        FindUIObject("ProfileImageBG").GetComponent<Image>().sprite =
            _profileEdgeList[UserManager.Instance.userData.profileEdgeIndex];
        FindUIObject("ProfileEditPopup").SetActive(false);
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
        ProfilePanel
    }

    public void ChangeUI(MainMenuScenePanels mainMenuScenePanels)
    {
        FindUIObject("SetNickNamePanel").SetActive(false);
        FindUIObject("StoryPanel").SetActive(false);
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
            case MainMenuScenePanels.StoryPanel:
                FindUIObject("StoryPanel").SetActive(true);
                break;
            case MainMenuScenePanels.MainMenuTouchPanel:
                FindUIObject("MainMenuTouchPanel").SetActive(true);
                break;
            case MainMenuScenePanels.StagePanel:
                FindUIObject("ChapterPageBG").SetActive(true);
                FindUIObject("StagePageBG").SetActive(false);
                FindUIObject("ChapterPanel").SetActive(true);
                break;
            case MainMenuScenePanels.AchievementPanel:
                FindUIObject("AchievementPanel").SetActive(true);
                break;
            case MainMenuScenePanels.CollectionPanel:
                FindUIObject("CollectionPanel").SetActive(true);
                break;
            case MainMenuScenePanels.ShopPanel:
                FindUIObject("ShopPanel").SetActive(true);
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
                    "(" + UserManager.Instance.userData.snackList[i] + "/20)";

                if (UserManager.Instance.userData.snackList[i] == 20)
                {
                    collection++;
                    FindUIObject(DBManagerScript.Instance.snackDB[i].name).transform.GetChild(0).GetComponent<Image>()
                        .material = null;
                    FindUIObject(DBManagerScript.Instance.snackDB[i].name).transform.GetChild(3).gameObject
                        .SetActive(true);
                }
            }
        }
    }

    public void InitCollection()
    {
        if (collection >= 1)
        {
            FindUIObject("Buff1Txt").GetComponent<TMP_Text>().text = "간식 양 " + DBManagerScript.Instance.buffDB[0].NN + "% 감소";
            FindUIObject("Buff1CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 1) + "/1)";
            FindUIObject("Buff1Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[0] = true;
        }
        
        if (collection >= 5)
        {
            FindUIObject("Buff2Txt").GetComponent<TMP_Text>().text = "발생 데시벨 " + DBManagerScript.Instance.buffDB[1].NN + "% 감소";
            FindUIObject("Buff2CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 5) + "/5)";
            FindUIObject("Buff2Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[1] = true;
        }
        
        if (collection >= 15)
        {
            FindUIObject("Buff3Txt").GetComponent<TMP_Text>().text = "최대 데시벨 " + DBManagerScript.Instance.buffDB[2].NN + "% 증가";
            FindUIObject("Buff3CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 15) + "/15)";
            FindUIObject("Buff3Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[2] = true;
        }
        
        if (collection >= 25)
        {
            FindUIObject("Buff4Txt").GetComponent<TMP_Text>().text = "발생 데시벨 " + DBManagerScript.Instance.buffDB[3].NN + "% 감소";
            FindUIObject("Buff4CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 25) + "/25)";
            FindUIObject("Buff4Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[3] = true;
        }
        
        if (collection >= 35)
        {
            FindUIObject("Buff4Txt").GetComponent<TMP_Text>().text = "최대 데시벨 " + DBManagerScript.Instance.buffDB[4].NN + "% 증가";
            FindUIObject("Buff4CountTxt").GetComponent<TMP_Text>().text = "(" + Mathf.Clamp(collection,0, 35) + "/35)";
            FindUIObject("Buff4Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[4] = true;
        }
    }
    
    
    //Settings

    public void InitSettingUI()
    {
        FindUIObject("OptionSoundPanelBGSlider").GetComponent<Slider>().value =
            AppManagerScript.Instance.appSettings.BgmVolume;
        FindUIObject("OptionSoundPanelBGSlider").GetComponent<Slider>().value =
            AppManagerScript.Instance.appSettings.EffectVolume;
        FindUIObject("OptionVibrationOnToggle").GetComponent<Toggle>().isOn =
            AppManagerScript.Instance.appSettings.IsVibration;
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
    }

    public void SettingBgmVolume()
    {
        MasterAudio.Instance._masterPlaylistVolume = FindUIObject("OptionSoundPanelBGSlider").GetComponent<Slider>().value;
    }
    
    public void SettingEffectVolume()
    {
        MasterAudio.Instance._masterAudioVolume = FindUIObject("OptionSoundPanelEffectSlider").GetComponent<Slider>().value;
    }

    public void SettingVibration()
    {
        AppManagerScript.Instance.appSettings.IsVibration =
            FindUIObject("OptionVibrationOnToggle").GetComponent<Toggle>().isOn;
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
        Debug.Log(FindUIObject("FreeTxt"));
        FindUIObject("FreeTxt").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Silver.ToString();
        FindUIObject("PaidTxt").GetComponent<TMP_Text>().text = UserManager.Instance.userData.Commodities.Gold.ToString();
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
}
