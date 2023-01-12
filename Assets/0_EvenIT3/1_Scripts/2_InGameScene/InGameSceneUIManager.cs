using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameSceneUIManager : UIControllerScript
{
    public override void InitSetup(GameObject scriptObject)
    {
        base.InitSetup(scriptObject);
        AddOnClick();
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
            
            //EasyClear
            case InGameSceneButtons.EasyClearPanelMainMenuBtn:
                OnClickEasyClearPanelMainMenuBtn();
                break;
            case InGameSceneButtons.EasyClearPanelRetryBtn:
                OnClickEasyClearPanelRetryBtn();
                break;
            case InGameSceneButtons.EasyClearPanelNextStageBtn:
                OnClickEasyClearPanelNextStageBtn();
                break;
            
            //EasyFail
            case InGameSceneButtons.EasyFailPanelMainMenuBtn:
                OnClickEasyFailPanelMainMenuBtn();
                break;
            case InGameSceneButtons.EasyFailPanelPrevStageBtn:
                OnClickEasyFailPanelPrevStageBtn();
                break;
            case InGameSceneButtons.EasyFailPanelRetryBtn:
                OnClickEasyFailPanelRetryBtn();
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
        
        //EasyClearPanel
        EasyClearPanelMainMenuBtn,
        EasyClearPanelRetryBtn,
        EasyClearPanelNextStageBtn,
        
        //EasyFailPanel
        EasyFailPanelMainMenuBtn,
        EasyFailPanelPrevStageBtn,
        EasyFailPanelRetryBtn,
        
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
        AppManagerScript.Instance.ChangeScene(SceneName.InGameScene);
    }
    
    private void OnClickPausePanelMainMenuBtn()
    {
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }

    //FailedLook
    private void OnClickFailedLookPanelCloseBtn()
    {
        OnClickFailedLookPanelRefuseBtn();
    }
    
    private void OnClickFailedLookPanelBuyBtn()
    {
        Time.timeScale = 1;
        FindUIObject("FailedLookPanel").SetActive(false);
        FindUIObject("SurpriseEffect").SetActive(false);
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }
    
    public void OnClickFailedLookPanelRefuseBtn()
    {
        FindUIObject("FailedLookPanel").SetActive(false);
        FindUIObject("EasyFailPanel").SetActive(true);
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
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }
    
    public void OnClickFailedDecibelPanelRefuseBtn()
    {
        FindUIObject("FailedDecibelPanel").SetActive(false);
        FindUIObject("EasyFailPanel").SetActive(true);
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
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }
    
    public void OnClickFailedOverPanelRefuseBtn()
    {
        FindUIObject("FailedOverPanel").SetActive(false);
        FindUIObject("EasyFailPanel").SetActive(true);
    }

    private void OnClickEasyClearPanelMainMenuBtn()
    {
        Time.timeScale = 1;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }
    
    private void OnClickEasyClearPanelRetryBtn()
    {
        Time.timeScale = 1;
        AppManagerScript.Instance.ChangeScene(SceneName.InGameScene);
    }
    
    private void OnClickEasyClearPanelNextStageBtn()
    {
        if (AppManagerScript.Instance.selectedStage == 4)
        {
            AppManagerScript.Instance.selectedChapter += 1;
            AppManagerScript.Instance.selectedStage = 1;
        }
        else
        {
            AppManagerScript.Instance.selectedStage += 1;
        }
        Time.timeScale = 1;
        AppManagerScript.Instance.ChangeScene(SceneName.InGameScene);
    }

    private void OnClickEasyFailPanelMainMenuBtn()
    {
        Time.timeScale = 1;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }
    
    private void OnClickEasyFailPanelPrevStageBtn()
    {
        if (AppManagerScript.Instance.selectedStage == 1)
        {
            AppManagerScript.Instance.selectedChapter -= 1;
            AppManagerScript.Instance.selectedStage = 4;
        }
        else
        {
            AppManagerScript.Instance.selectedStage -= 1;
        }
        AppManagerScript.Instance.ChangeScene(SceneName.InGameScene);
    }
    
    private void OnClickEasyFailPanelRetryBtn()
    {
        AppManagerScript.Instance.ChangeScene(SceneName.InGameScene);
    }

    //Item
    private void OnClickItem1Btn()
    {
        StartCoroutine(Player.Instance.Buff_Ice());
    }
    
    private void OnClickItem2Btn()
    {
        StartCoroutine(Player.Instance.Buff_Milk());
    }
    
    private void OnClickItem3Btn()
    {
        StartCoroutine(Player.Instance.Buff_Mask());
    }
    
    
    #endregion

    #region Change UI

    public enum InGameScenePanels
    {

    }

    public void ChangeUI(InGameScenePanels mainMenuScenePanels)
    {
        switch (mainMenuScenePanels)
        {
            /*case MainMenuScenePanels.SetNickNamePanel:
                FindUIObject("SetNickNamePanel").SetActive(true);
                break;*/
        }
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

    public void SetUpStarIcons(int stars)
    {
        //Easy
        FindUIObject("EasyClearPanelStars1").SetActive(false);
        FindUIObject("EasyClearPanelStars2").SetActive(false);
        FindUIObject("EasyClearPanelStars3").SetActive(false);
        switch (stars)
        {
            case 1:
                FindUIObject("EasyClearPanelStars1").SetActive(true);
                break;
            case 2:
                FindUIObject("EasyClearPanelStars2").SetActive(true);
                break;
            case 3:
                FindUIObject("EasyClearPanelStars3").SetActive(true);
                break;
        }
        FindUIObject("EasyClearPanel").SetActive(true);
    }
}
