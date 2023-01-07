using System;
using System.Collections;
using System.Collections.Generic;
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
        
        //FailedOver
        FailedOverPanelCloseBtn,
        FailedOverPanelBuyBtn,
        FailedOverPanelRefuseBtn,
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
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }
    
    private void OnClickFailedLookPanelRefuseBtn()
    {
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }
    
    //FailedOver
    private void OnClickFailedOverPanelCloseBtn()
    {
        OnClickFailedOverPanelRefuseBtn();
    }
    
    private void OnClickFailedOverPanelBuyBtn()
    {
        GameManager.Instance.curTime = DBManagerScript.Instance.itemDB[4].NN;
        Time.timeScale = 1;
        TimerOff();
        FindUIObject("FailedOverPanel").SetActive(false);
        GameManager.Instance._isTimer = true;
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }
    
    private void OnClickFailedOverPanelRefuseBtn()
    {
        Time.timeScale = 1;
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
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
        FindUIObject("TimerGaugeSlider").GetComponent<Slider>().value = percentage;
        if (percentage > 0.33f)
        {
            FindUIObject("TimerGaugeIcon1On").SetActive(true);
        }
        
        if (percentage > 0.66f)
        {
            FindUIObject("TimerGaugeIcon2On").SetActive(true);
        }
        
        if (percentage > 0.99f)
        {
            FindUIObject("TimerGaugeIcon3On").SetActive(true);
        }
    }

    public void QuantityUpdate(float percentage)
    {
        FindUIObject("QuantitySnackIcon").GetComponent<Image>().fillAmount = percentage;
    }

    public void TimerOff()
    {
        FindUIObject("TimerGaugeIcon1On").SetActive(false);
        FindUIObject("TimerGaugeIcon2On").SetActive(false);
        FindUIObject("TimerGaugeIcon3On").SetActive(false);
    }
    
    public void PressEatBtnDown()
    {
        Player.Instance.playerState = Player.State.Eating;
    }
    
    public void PressEatBtnUp()
    {
        Player.Instance.playerState = Player.State.Idle;
    }
}
