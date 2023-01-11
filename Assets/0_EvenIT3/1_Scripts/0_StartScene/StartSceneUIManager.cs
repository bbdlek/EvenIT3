using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneUIManager : UIControllerScript
{
    public override void InitSetup(GameObject scriptObject)
    {
        base.InitSetup(scriptObject);
        AddOnClick();
    }

    private void AddOnClick()
    {
        string[] enumArray = Enum.GetNames(typeof(StartSceneButtons));
        for (int i = 0; i < Enum.GetValues(typeof(StartSceneButtons)).Length; i++)
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
        StartSceneButtons tempClickBtn = (StartSceneButtons)clickBtn;
        switch (tempClickBtn)
        {
            //Login
            case StartSceneButtons.GoogleLoginBtn:
                OnClickGoogleLoginBtn();
                break;
            case StartSceneButtons.FBLoginBtn:
                OnClickFBLoginBtn();
                break;
            case StartSceneButtons.TouchToStartBtn:
                OnClickTouchToStartBtn();
                break;
        }
    }
    
    private enum StartSceneButtons
    {
        //Login
        GoogleLoginBtn,
        FBLoginBtn,
        
        //TouchToStart
        TouchToStartBtn,
    }
    
    private void OnClickGoogleLoginBtn()
    {
        AppManagerScript.Instance.GetComponent<LogInManager>().GoogleLogin();
    }

    private void OnClickGuestLoginBtn()
    {
        AppManagerScript.Instance.GetComponent<LogInManager>().GuestLogin();
    }
    private void OnClickFBLoginBtn()
    {
        if(Application.isEditor)
            AppManagerScript.Instance.GetComponent<LogInManager>().GuestLogin();
        else
            AppManagerScript.Instance.GetComponent<LogInManager>().FBLogin();
    }

    private void OnClickTouchToStartBtn()
    {
        AppManagerScript.Instance.ChangeScene(SceneName.MainMenuScene);
    }

    #endregion

    #region Change UI

    public enum StartScenePanels
        {
            Waiting,
            Login,
            TouchToStart
        }

    public void ChangeUI(StartScenePanels startScenePanels)
    {
        FindUIObject("WaitingPanel").SetActive(false);
        FindUIObject("LoginPanel").SetActive(false);
        FindUIObject("TouchToStartPanel").SetActive(false);
        switch (startScenePanels)
        {
            case StartScenePanels.Waiting:
                FindUIObject("WaitingPanel").SetActive(true);
                break;
            /*case StartScenePanels.ServerChecking:
                FindUIObject("ServerCheckPopup").SetActive(true);
                FindUIObject("AppStatusCheckPanel").SetActive(true);
                // FindUIObject("ServerCheckPopup").GetComponent<PopUpUIAnimation>().Show();
                FindUIObject("UpdatePopup").SetActive(false);
                break;
            case StartScenePanels.MissMatchVersion:
                FindUIObject("ServerCheckPopup").SetActive(false);
                FindUIObject("AppStatusCheckPanel").SetActive(true);
                FindUIObject("UpdatePopup").SetActive(true);
                // FindUIObject("UpdatePopup").GetComponent<PopUpUIAnimation>().Show();
                break;
            case StartScenePanels.TermsCheck:
                UpdateTermInfo();
                FindUIObject("TermsDetailPopup").SetActive(false);
                FindUIObject("TermsCheckPopup").SetActive(true);
                FindUIObject("TermsCheckPanel").SetActive(true);
                // FindUIObject("TermsCheckPopup").GetComponent<PopUpUIAnimation>().Show();
                FindUIObject("AllAgreeToggle").GetComponent<Toggle>().isOn = false;
                AllToggleUpdate();
                break;
            case StartScenePanels.ResourceDown:
                UpdateResourceInfo();
                FindUIObject("ResourceDownloadPanel").SetActive(true);
                FindUIObject("ResourceDownloadPopup").SetActive(true);
                FindUIObject("ResourceDownloadPopupBG").SetActive(true);
                // FindUIObject("ResourceDownloadPopup").GetComponent<PopUpUIAnimation>().Show();
                FindUIObject("ResourceDownloadingGroup").SetActive(false)
                break;*/
            case StartScenePanels.Login:
                FindUIObject("LoginPanel").SetActive(true);
                break;
            case StartScenePanels.TouchToStart:
                FindUIObject("TouchToStartPanel").SetActive(true);
                break;
            
        }
    }

    #endregion
}
