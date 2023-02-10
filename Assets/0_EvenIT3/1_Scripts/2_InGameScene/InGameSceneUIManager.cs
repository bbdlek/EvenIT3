using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class InGameSceneUIManager : UIControllerScript
{
    public override void InitSetup(GameObject scriptObject)
    {
        base.InitSetup(scriptObject);
        AddOnClick();
        InitEasyStars();
    }

    private void InitEasyStars()
    {
        stageSnacks = new List<Snack>();
        if (DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack1 != -1)
        {
            stageSnacks.Add(DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack1]);
        }
        if (DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack2 != -1)
        {
            stageSnacks.Add(DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack2]);
        }
        if (DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack3 != -1)
        {
            stageSnacks.Add(DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack3]);
        }
    }
    
    private void AddOnClick()
    {
        string[] enumArray = Enum.GetNames(typeof(InGameSceneButtons));
        for (int i = 0; i < Enum.GetValues(typeof(InGameSceneButtons)).Length; i++)
        {
            try
            {
                Button tempButton = FindUIObject(enumArray[i]).GetOrAddComponent<Button>();
                int temp = i;
                tempButton.onClick.AddListener(() => ButtonOnClick(temp));
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
        InGameSceneButtons tempClickBtn = (InGameSceneButtons)clickBtn;
        switch (tempClickBtn)
        {
            //Main
            case InGameSceneButtons.PauseBtn:
                OnClickPauseBtn();
                break;
            
            //Pause
            case InGameSceneButtons.PausePanelCloseBtn:
                OnClickPausePanelCloseBtn();
                break;
            case InGameSceneButtons.PausePanelResumeBtn:
                OnClickPausePanelResumeBtn();
                break;
            case InGameSceneButtons.PausePanelReplayBtn:
                OnClickPausePanelReplayBtn();
                break;
            case InGameSceneButtons.PausePanelMainMenuBtn:
                OnClickPausePanelMainMenuBtn();
                break;
            
            //FailedLook
            case InGameSceneButtons.FailedLookPanelCloseBtn:
                OnClickFailedLookPanelCloseBtn();
                break;
            case InGameSceneButtons.FailedLookPanelBuyBtn:
                OnClickFailedLookPanelBuyBtn();
                break;
            case InGameSceneButtons.FailedLookPanelRefuseBtn:
                OnClickFailedLookPanelRefuseBtn();
                break;
            
            //FailedDecibel
            case InGameSceneButtons.FailedDecibelPanelCloseBtn:
                OnClickFailedDecibelPanelCloseBtn();
                break;
            case InGameSceneButtons.FailedDecibelPanelBuyBtn:
                OnClickFailedDecibelPanelBuyBtn();
                break;
            case InGameSceneButtons.FailedDecibelPanelRefuseBtn:
                OnClickFailedDecibelPanelRefuseBtn();
                break;

            //FailedOver
            case InGameSceneButtons.FailedOverPanelCloseBtn:
                OnClickFailedOverPanelCloseBtn();
                break;
            case InGameSceneButtons.FailedOverPanelBuyBtn:
                OnClickFailedOverPanelBuyBtn();
                break;
            case InGameSceneButtons.FailedOverPanelRefuseBtn:
                OnClickFailedOverPanelRefuseBtn();
                break;
            
            //Clear
            case InGameSceneButtons.ClearPanelMainMenuBtn:
                OnClickClearPanelMainMenuBtn();
                break;
            case InGameSceneButtons.ClearPanelRetryBtn:
                OnClickClearPanelRetryBtn();
                break;
            case InGameSceneButtons.ClearPanelNextStageBtn:
                OnClickClearPanelNextStageBtn();
                break;
            
            //Fail
            case InGameSceneButtons.FailPanelMainMenuBtn:
                OnClickFailPanelMainMenuBtn();
                break;
            case InGameSceneButtons.FailPanelPrevStageBtn:
                OnClickFailPanelPrevStageBtn();
                break;
            case InGameSceneButtons.FailPanelRetryBtn:
                OnClickFailPanelRetryBtn();
                break;
            
            //Item
            case InGameSceneButtons.Item1Btn:
                OnClickItem1Btn();
                break;
            case InGameSceneButtons.Item2Btn:
                OnClickItem2Btn();
                break;
            case InGameSceneButtons.Item3Btn:
                OnClickItem3Btn();
                break;
        }
    }
    
    private enum InGameSceneButtons
    {
        //Main
        PauseBtn,
        
        //Item
        Item1Btn,
        Item2Btn,
        Item3Btn,
        
        //Pause
        PausePanelCloseBtn,
        PausePanelResumeBtn,
        PausePanelReplayBtn,
        PausePanelMainMenuBtn,
        
        //FailedLook
        FailedLookPanelCloseBtn,
        FailedLookPanelBuyBtn,
        FailedLookPanelRefuseBtn,
        
        //FailedDecibel
        FailedDecibelPanelCloseBtn,
        FailedDecibelPanelBuyBtn,
        FailedDecibelPanelRefuseBtn,
        
        //FailedOver
        FailedOverPanelCloseBtn,
        FailedOverPanelBuyBtn,
        FailedOverPanelRefuseBtn,
        
        //ClearPanel
        ClearPanelMainMenuBtn,
        ClearPanelRetryBtn,
        ClearPanelNextStageBtn,
        
        //FailPanel
        FailPanelMainMenuBtn,
        FailPanelPrevStageBtn,
        FailPanelRetryBtn,
        
    }
    
    //Main
    private void OnClickPauseBtn()
    {
        GameManager.Instance.gameState = GameManager.GameState.Pause;
        Time.timeScale = 0;
        FindUIObject("PausePanel").SetActive(true);
    }

    //Pause
    private void OnClickPausePanelCloseBtn()
    {
        Time.timeScale = 1;
        FindUIObject("PausePanel").SetActive(false);
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }

    private void OnClickPausePanelResumeBtn()
    {
        Time.timeScale = 1;
        FindUIObject("PausePanel").SetActive(false);
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }

    private void OnClickPausePanelReplayBtn()
    {
        AppManagerScript.Instance.isRestart = true;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }
    
    private void OnClickPausePanelMainMenuBtn()
    {
        AppManagerScript.Instance.isRestart = false;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }

    //FailedLook
    private void OnClickFailedLookPanelCloseBtn()
    {
        OnClickFailedLookPanelRefuseBtn();
    }
    
    private void OnClickFailedLookPanelBuyBtn()
    {
        UserManager.Instance.userData.achievementCount[43] += 1;
        UserManager.Instance.userData.achievementCount[44] += 1;
        UserManager.Instance.userData.achievementCount[45] += 1;
        GameManager.Instance.shieldItem = 0;
        Time.timeScale = 1;
        FindUIObject("FailedLookPanel").SetActive(false);
        FindUIObject("SurpriseEffect").SetActive(false);
        GameManager.Instance.teacher.teacherState = TeacherController.TeacherState.Idle;
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }
    
    public void OnClickFailedLookPanelRefuseBtn()
    {
        FindUIObject("FailedLookPanel").SetActive(false);
        FindUIObject("FailPanel").SetActive(true);
        MasterAudio.PlaySound("GameOver");
        UserManager.Instance.userData.achievementCount[30] += 1;
        UserManager.Instance.userData.achievementCount[31] += 1;
        UserManager.Instance.userData.achievementCount[32] += 1;
        AppManagerScript.Instance.continuousStage[AppManagerScript.Instance.selectedChapter - 1] = 0;
        UserManager.Instance.UseHeart();
        //FBManagerScript.Instance.UpdateCurrentUser();
    }
    
    //FailedDecibel
    private void OnClickFailedDecibelPanelCloseBtn()
    {
        OnClickFailedDecibelPanelRefuseBtn();
    }
    
    private void OnClickFailedDecibelPanelBuyBtn()
    {
        GameManager.Instance.player.curDecibelAmount = 0;
        GameManager.Instance.shieldItem = 0;
        Time.timeScale = 1;
        FindUIObject("FailedDecibelPanel").SetActive(false);
        FindUIObject("SurpriseEffect").SetActive(false);
        GameManager.Instance.teacher.teacherState = TeacherController.TeacherState.Idle;
        GameManager.Instance.player.playerState = Player.State.Idle;
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }
    
    public void OnClickFailedDecibelPanelRefuseBtn()
    {
        FindUIObject("FailedDecibelPanel").SetActive(false);
        FindUIObject("FailPanel").SetActive(true);
        MasterAudio.PlaySound("GameOver");
        UserManager.Instance.userData.achievementCount[36] += 1;
        UserManager.Instance.userData.achievementCount[37] += 1;
        UserManager.Instance.userData.achievementCount[38] += 1;
        AppManagerScript.Instance.continuousStage[AppManagerScript.Instance.selectedChapter - 1] = 0;
        UserManager.Instance.UseHeart();
        //FBManagerScript.Instance.UpdateCurrentUser();
    }
    
    //FailedOver
    private void OnClickFailedOverPanelCloseBtn()
    {
        OnClickFailedOverPanelRefuseBtn();
    }
    
    private void OnClickFailedOverPanelBuyBtn()
    {
        GameManager.Instance.curTime = DBManagerScript.Instance.itemDB[4].NN;
        GameManager.Instance.timerItem = 0;
        Time.timeScale = 1;
        FindUIObject("FailedOverPanel").SetActive(false);
        FindUIObject("SurpriseEffect").SetActive(false);
        GameManager.Instance._isTimer = true;
        GameManager.Instance.teacher.teacherState = TeacherController.TeacherState.Idle;
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }
    
    public void OnClickFailedOverPanelRefuseBtn()
    {
        FindUIObject("FailedOverPanel").SetActive(false);
        FindUIObject("FailPanel").SetActive(true);
        MasterAudio.PlaySound("GameOver");
        UserManager.Instance.userData.achievementCount[33] += 1;
        UserManager.Instance.userData.achievementCount[34] += 1;
        UserManager.Instance.userData.achievementCount[35] += 1;
        AppManagerScript.Instance.continuousStage[AppManagerScript.Instance.selectedChapter - 1] = 0;
        UserManager.Instance.UseHeart();
        //FBManagerScript.Instance.UpdateCurrentUser();
    }

    public void OnClickClearPanelMainMenuBtn()
    {
        Time.timeScale = 1;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }
    
    private void OnClickClearPanelRetryBtn()
    {
        Time.timeScale = 1;
        AppManagerScript.Instance.isRestart = true;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }
    
    private void OnClickClearPanelNextStageBtn()
    {
        AppManagerScript.Instance.isRestart = true;
        if (AppManagerScript.Instance.selectedStage == 4)
        {
            if(AppManagerScript.Instance.selectedChapter != 6)
            {
                AppManagerScript.Instance.selectedChapter += 1;
                AppManagerScript.Instance.selectedStage = 1;
            }
        }
        else
        {
            AppManagerScript.Instance.selectedStage += 1;
        }
        Time.timeScale = 1;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }

    private void OnClickFailPanelMainMenuBtn()
    {
        Time.timeScale = 1;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }
    
    private void OnClickFailPanelPrevStageBtn()
    {
        AppManagerScript.Instance.isRestart = true;
        if (AppManagerScript.Instance.selectedStage == 1)
        {
            if(AppManagerScript.Instance.selectedChapter != 1)
            {
                AppManagerScript.Instance.selectedChapter -= 1;
                AppManagerScript.Instance.selectedStage = 4;
            }
        }
        else
        {
            AppManagerScript.Instance.selectedStage -= 1;
        }
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }
    
    private void OnClickFailPanelRetryBtn()
    {
        AppManagerScript.Instance.isRestart = true;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }

    //Item
    private void OnClickItem1Btn()
    {
        UserManager.Instance.userData.achievementCount[30] += 1;
        UserManager.Instance.userData.achievementCount[31] += 1;
        UserManager.Instance.userData.achievementCount[32] += 1;
        StartCoroutine(Player.Instance.Buff_Ice());
    }
    
    private void OnClickItem2Btn()
    {
        UserManager.Instance.userData.achievementCount[30] += 1;
        UserManager.Instance.userData.achievementCount[31] += 1;
        UserManager.Instance.userData.achievementCount[32] += 1;
        StartCoroutine(Player.Instance.Buff_Milk());
    }
    
    private void OnClickItem3Btn()
    {
        UserManager.Instance.userData.achievementCount[30] += 1;
        UserManager.Instance.userData.achievementCount[31] += 1;
        UserManager.Instance.userData.achievementCount[32] += 1;
        StartCoroutine(Player.Instance.Buff_Mask());
    }
    
    
    #endregion

    public void TimerUpdate(float percentage)
    {
        FindUIObject("TimerGaugeFill").GetComponent<Image>().fillAmount = percentage;
    }

    public void QuantityUpdate(float percentage)
    {
        if (Mathf.RoundToInt(percentage * 100) % 5 == 0)
        {
            FindUIObject("QuantitySnackIcon").GetComponent<Image>().fillAmount = 1 - percentage;   
        }
    }

    public void PressEatBtnDown()
    {
        Player.Instance.playerState = Player.State.Eating;
    }
    
    public void PressEatBtnUp()
    {
        Player.Instance.playerState = Player.State.Idle;
    }

    [SerializeField] private GameObject rewardSnackPrefab;
    public int maxSnackNum;
    public int divide1;
    public int divide2;
    public int divide3;
    public List<Snack> rewardSnacks;
    public List<Sprite> rewardIcons;
    public List<int> rewardSnackNums;
    public int rewardSilverNum;
    public int rewardGoldNum;
    public List<Snack> stageSnacks;

    public void SetUpStarIcons(int stars)
    {
        //Achievement
        if(GameManager.Instance.stageNum == 11)
        {
            if (UserManager.Instance.userData.starList.Count < GameManager.Instance.stageNum + 1)
            {
                if(!PlayerPrefs.HasKey("LookEnding"))
                {
                    PlayerPrefs.SetInt("LookEnding", 1);
                    Instantiate(Resources.Load<GameObject>("Story/Ending"), transform);
                }
            }
        }
        
        if(GameManager.Instance.stageNum == 23)
        {
            if (UserManager.Instance.userData.starList.Count < GameManager.Instance.stageNum + 1)
            {
                if(!PlayerPrefs.HasKey("LookHardEnding"))
                {
                    PlayerPrefs.SetInt("LookHardEnding", 1);
                    Instantiate(Resources.Load<GameObject>("Story/HardEnding"), transform);
                }
            }
        }

        rewardGoldNum = 0;

        switch (GameManager.Instance.maxSnack)
        {
            case 1:
                rewardSnacks.Add(DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack1]);
                rewardIcons.Add(Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack1].name));
                break;
            case 2:
                rewardSnacks.Add(DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack1]);
                rewardSnacks.Add(DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack2]);
                rewardIcons.Add(Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack1].name));
                rewardIcons.Add(Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack2].name));
                break;
            case 3:
                rewardSnacks.Add(DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack1]);
                rewardSnacks.Add(DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack2]);
                rewardSnacks.Add(DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack3]);
                rewardIcons.Add(Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack1].name));
                rewardIcons.Add(Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack2].name));
                rewardIcons.Add(Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[DBManagerScript.Instance.stageDB[GameManager.Instance.stageNum].snack3].name));
                break;
        }

        /*if (UserManager.Instance.userData.snackList[snackNum] == 20)
        {
            SetUpStarIcons(stars);
            return;
        }*/

        //
        FindUIObject("ClearPanelStars1").SetActive(false);
        FindUIObject("ClearPanelStars2").SetActive(false);
        FindUIObject("ClearPanelStars3").SetActive(false);
        rewardSnackNums = new List<int>();
        switch (stars)
        {
            case 1:
                FindUIObject("ClearPanelStars1").SetActive(true);
                if(GameManager.Instance.stageNum < 12)
                {
                    maxSnackNum = Random.Range(1, 3);
                    rewardSilverNum = 300;
                }
                else
                {
                    maxSnackNum = Random.Range(0, 3);
                    rewardSilverNum = 500;
                }
                if (UserManager.Instance.userData.starList.Count < GameManager.Instance.stageNum + 1)
                {
                    UserManager.Instance.userData.starList.Add(1);
                }
                else
                {
                    if(UserManager.Instance.userData.starList[GameManager.Instance.stageNum] < 1)
                        UserManager.Instance.userData.starList[GameManager.Instance.stageNum] = 1;
                }
                break;
            case 2:
                FindUIObject("ClearPanelStars2").SetActive(true);
                if(GameManager.Instance.stageNum < 12)
                {
                    maxSnackNum = Random.Range(1, 4);
                    rewardSilverNum = 400;
                }
                else
                {
                    maxSnackNum = Random.Range(1, 3);
                    rewardSilverNum = 600;
                }
                if (UserManager.Instance.userData.starList.Count < GameManager.Instance.stageNum + 1)
                {
                    UserManager.Instance.userData.starList.Add(2);
                }
                else
                {
                    if(UserManager.Instance.userData.starList[GameManager.Instance.stageNum] < 2)
                        UserManager.Instance.userData.starList[GameManager.Instance.stageNum] = 2;
                }
                break;
            case 3:
                FindUIObject("ClearPanelStars3").SetActive(true);
                if(GameManager.Instance.stageNum < 12)
                {
                    maxSnackNum = Random.Range(2, 5);
                    rewardSilverNum = 500;
                }
                else
                {
                    maxSnackNum = Random.Range(2, 4);
                    rewardSilverNum = 700;
                }
                if (UserManager.Instance.userData.starList.Count < GameManager.Instance.stageNum + 1)
                {
                    UserManager.Instance.userData.starList.Add(3);
                }
                else
                {
                    UserManager.Instance.userData.starList[GameManager.Instance.stageNum] = 3;
                }
                break;
        }

        if (GameManager.Instance.isFirst)
        {
            
            if(GameManager.Instance.stageNum < 12)
            {
                rewardSilverNum = 500;
                rewardGoldNum = 5;
            }
            else
            {
                rewardSilverNum = 1000;
                rewardGoldNum = 5;
            }
            
            
            switch (GameManager.Instance.maxSnack)
            {
                case 1:
                    divide1 = maxSnackNum;
                    rewardSnackNums.Add(divide1);
                    break;
                case 2:
                    divide1 = Random.Range(0, maxSnackNum + 1);
                    divide2 = maxSnackNum - divide1;
                    rewardSnackNums.Add(divide1);
                    rewardSnackNums.Add(divide2);
                    break;
                case 3:
                    divide1 = Random.Range(0, maxSnackNum + 1);
                    divide2 = Random.Range(0, maxSnackNum - divide1 + 1);
                    divide3 = maxSnackNum - divide1 - divide2;
                    rewardSnackNums.Add(divide1);
                    rewardSnackNums.Add(divide2);
                    rewardSnackNums.Add(divide3);
                    break;
            }
            
            GameObject GoldReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
            GoldReward.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rewards/Reward_Gold");
            GoldReward.GetComponentInChildren<TMP_Text>().text = rewardGoldNum.ToString();
            
            GameObject SilverReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
            SilverReward.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rewards/Reward_Silver");
            SilverReward.GetComponentInChildren<TMP_Text>().text = rewardSilverNum.ToString();

            for (int i = 0; i < rewardSnackNums.Count; i++)
            {
                Debug.Log(rewardSnackNums[i]);
            }
            switch (rewardSnackNums.Count)
            {
                case 1:
                    if (UserManager.Instance.userData.snackList[rewardSnacks[0].no] == rewardSnacks[0].P2A)
                    {
                        rewardSnackNums[0] = 0;
                    }
                    if (rewardSnackNums[0] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[0];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[0].ToString();
                    }
                    break;
                case 2:
                    if (UserManager.Instance.userData.snackList[rewardSnacks[0].no] == rewardSnacks[0].P2A)
                    {
                        if (UserManager.Instance.userData.snackList[rewardSnacks[1].no] == rewardSnacks[1].P2A)
                        {
                            rewardSnackNums[1] = 0;
                        }
                        else
                        {
                            if (rewardSnackNums[1] == 0) rewardSnackNums[1] = rewardSnackNums[0];
                        }

                        rewardSnackNums[0] = 0;
                    }
                    if (rewardSnackNums[0] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[0];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[0].ToString();
                    }
                    if (rewardSnackNums[1] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[1];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[1].ToString();
                    }
                    break;
                case 3:
                    if (UserManager.Instance.userData.snackList[rewardSnacks[0].no] == rewardSnacks[0].P2A)
                    {
                        if (UserManager.Instance.userData.snackList[rewardSnacks[1].no] == rewardSnacks[1].P2A)
                        {
                            if (UserManager.Instance.userData.snackList[rewardSnacks[2].no] == rewardSnacks[2].P2A)
                            {
                                rewardSnackNums[2] = 0;
                            }
                            else
                            {
                                if (rewardSnackNums[2] == 0)
                                {
                                    if(rewardSnackNums[0] == 0)
                                    {
                                        rewardSnackNums[2] = rewardSnackNums[1];
                                    }
                                    else
                                    {
                                        rewardSnackNums[2] = rewardSnackNums[0];
                                    }
                                }
                            }
                            rewardSnackNums[1] = 0;
                        }
                        else
                        {
                            if (rewardSnackNums[1] == 0) rewardSnackNums[1] = rewardSnackNums[0];
                        }

                        rewardSnackNums[0] = 0;
                    }
                    if (rewardSnackNums[0] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[0];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[0].ToString();
                    }
                    if (rewardSnackNums[1] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[1];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[1].ToString();
                    }
                    if (rewardSnackNums[2] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[2];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[2].ToString();
                    }
                    break;
            }
            
            /*for (int i = 0; i < rewardSnackNums.Count; i++)
            {
                if (UserManager.Instance.userData.snackList[rewardSnacks[i].no] == 20)
                {
                    rewardSnackNums[i] = 0;
                }
                if (rewardSnackNums[i] != 0)
                {
                    GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                    SnackReward.GetComponent<Image>().sprite = rewardIcons[i];
                    SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[i].ToString();
                }
            }*/
        }
        else
        {
            GameObject SilverReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
            SilverReward.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rewards/Reward_Silver");
            SilverReward.GetComponentInChildren<TMP_Text>().text = rewardSilverNum.ToString();
            switch (GameManager.Instance.maxSnack)
            {
                case 1:
                    divide1 = maxSnackNum;
                    rewardSnackNums.Add(divide1);
                    break;
                case 2:
                    divide1 = Random.Range(0, maxSnackNum + 1);
                    divide2 = maxSnackNum - divide1;
                    rewardSnackNums.Add(divide1);
                    rewardSnackNums.Add(divide2);
                    break;
                case 3:
                    divide1 = Random.Range(0, maxSnackNum + 1);
                    divide2 = Random.Range(0, maxSnackNum - divide1 + 1);
                    divide3 = maxSnackNum - divide1 - divide2;
                    rewardSnackNums.Add(divide1);
                    rewardSnackNums.Add(divide2);
                    rewardSnackNums.Add(divide3);
                    break;
            }

            for (int i = 0; i < rewardSnackNums.Count; i++)
            {
                Debug.Log(rewardSnackNums[i]);
            }
            switch (rewardSnackNums.Count)
            {
                case 1:
                    if (UserManager.Instance.userData.snackList[rewardSnacks[0].no] == rewardSnacks[0].P2A)
                    {
                        rewardSnackNums[0] = 0;
                    }
                    if (rewardSnackNums[0] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[0];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[0].ToString();
                    }
                    break;
                case 2:
                    if (UserManager.Instance.userData.snackList[rewardSnacks[0].no] == rewardSnacks[0].P2A)
                    {
                        if (UserManager.Instance.userData.snackList[rewardSnacks[1].no] == rewardSnacks[1].P2A)
                        {
                            rewardSnackNums[1] = 0;
                        }
                        else
                        {
                            if (rewardSnackNums[1] == 0) rewardSnackNums[1] = rewardSnackNums[0];
                        }

                        rewardSnackNums[0] = 0;
                    }
                    if (rewardSnackNums[0] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[0];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[0].ToString();
                    }
                    if (rewardSnackNums[1] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[1];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[1].ToString();
                    }
                    break;
                case 3:
                    if (UserManager.Instance.userData.snackList[rewardSnacks[0].no] == rewardSnacks[0].P2A)
                    {
                        if (UserManager.Instance.userData.snackList[rewardSnacks[1].no] == rewardSnacks[1].P2A)
                        {
                            if (UserManager.Instance.userData.snackList[rewardSnacks[2].no] == rewardSnacks[2].P2A)
                            {
                                rewardSnackNums[2] = 0;
                            }
                            else
                            {
                                if (rewardSnackNums[2] == 0)
                                {
                                    if(rewardSnackNums[0] == 0)
                                    {
                                        rewardSnackNums[2] = rewardSnackNums[1];
                                    }
                                    else
                                    {
                                        rewardSnackNums[2] = rewardSnackNums[0];
                                    }
                                }
                            }
                            rewardSnackNums[1] = 0;
                        }
                        else
                        {
                            if (rewardSnackNums[1] == 0) rewardSnackNums[1] = rewardSnackNums[0];
                        }

                        rewardSnackNums[0] = 0;
                    }
                    if (rewardSnackNums[0] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[0];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[0].ToString();
                    }
                    if (rewardSnackNums[1] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[1];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[1].ToString();
                    }
                    if (rewardSnackNums[2] != 0)
                    {
                        GameObject SnackReward =  Instantiate(rewardSnackPrefab, FindUIObject("ClearPanelRewards").transform);
                        SnackReward.GetComponent<Image>().sprite = rewardIcons[2];
                        SnackReward.GetComponentInChildren<TMP_Text>().text = rewardSnackNums[2].ToString();
                    }
                    break;
            }
        }

        UserManager.Instance.userData.Commodities.Gold += rewardGoldNum;
        UserManager.Instance.userData.Commodities.Silver += rewardSilverNum;
        for (int i = 0; i < rewardSnacks.Count; i++)
        {
            UserManager.Instance.userData.snackList[rewardSnacks[i].no] += rewardSnackNums[i];
            if (UserManager.Instance.userData.snackList[rewardSnacks[i].no] > rewardSnacks[i].P2A)
            {
                UserManager.Instance.userData.snackList[rewardSnacks[i].no] = rewardSnacks[i].P2A;
            } 
        }

        //FBManagerScript.Instance.UpdateCurrentUser();
        FindUIObject("ClearPanel").SetActive(true);
        if (!UserManager.Instance.userData.tutorial4)
        {
            FindUIObject("Tutorial4-1").SetActive(true);
        }
    }
}
