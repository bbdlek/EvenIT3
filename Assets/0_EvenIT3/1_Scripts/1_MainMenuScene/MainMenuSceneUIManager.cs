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
        InitCollection();
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
        ChangeUI(MainMenuScenePanels.ShopPanel);
    }
    
    private void OnClickInventoryMoveBtn()
    {
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
        AppManagerScript.Instance.selectedItem[0] = FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn;
        AppManagerScript.Instance.selectedItem[1] = FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn;
        AppManagerScript.Instance.selectedItem[2] = FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn;
        if (FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn) UserManager.Instance.userData.milkItem--;
        if (FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn) UserManager.Instance.userData.clockItem--;
        if (FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn) UserManager.Instance.userData.maskItem--;
        
        AppManagerScript.Instance.ChangeScene(SceneName.InGameScene);
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
    private void OnClickProfileCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
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

    public void InitCollection()
    {
        if (UserManager.Instance.userData.starList.Count > 0)
        {
            FindUIObject("Buff1Txt").GetComponent<TMP_Text>().text = "간식 양 5% 감소";
            FindUIObject("Buff1CountTxt").GetComponent<TMP_Text>().text = "(1/1)";
            FindUIObject("Buff1Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[0] = true;
        }
        
        if (UserManager.Instance.userData.starList.Count > 5)
        {
            FindUIObject("Buff2Txt").GetComponent<TMP_Text>().text = "발생 데시벨 5% 감소";
            FindUIObject("Buff2CountTxt").GetComponent<TMP_Text>().text = "(1/1)";
            FindUIObject("Buff2Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[1] = true;
        }
        
        if (UserManager.Instance.userData.starList.Count > 8)
        {
            FindUIObject("Buff3Txt").GetComponent<TMP_Text>().text = "최대 데시벨 7% 증가";
            FindUIObject("Buff3CountTxt").GetComponent<TMP_Text>().text = "(1/1)";
            FindUIObject("Buff3Stamp Img").SetActive(true);
            AppManagerScript.Instance.buff[2] = true;
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
        FindUIObject("StagePageItem1").GetComponent<Toggle>().interactable = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem2").GetComponent<Toggle>().interactable = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem3").GetComponent<Toggle>().interactable = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem1").GetComponent<Toggle>().isOn = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem2").GetComponent<Toggle>().isOn = UserManager.Instance.userData.milkItem > 0;
        FindUIObject("StagePageItem3").GetComponent<Toggle>().isOn = UserManager.Instance.userData.milkItem > 0;
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
