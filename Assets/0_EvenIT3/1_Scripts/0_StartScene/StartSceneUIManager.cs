using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Sequence = DG.Tweening.Sequence;

public class StartSceneUIManager : UIControllerScript
{
    public override void InitSetup(GameObject scriptObject)
    {
        base.InitSetup(scriptObject);
        AddOnClick();
        CheckLogOut();
        LoadingSequence();
        FindUIObject("VersionTxt").GetComponent<TMP_Text>().text = "ver " + Application.version;
    }

    private void CheckLogOut()
    {
        if (AppManagerScript.Instance.isWithDraw)
        {
            ChangeUI(StartScenePanels.Login);
        }
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
        StartSceneButtons tempClickBtn = (StartSceneButtons)clickBtn;
        switch (tempClickBtn)
        {
            //Login
            case StartSceneButtons.GoogleLoginBtn:
                OnClickGoogleLoginBtn();
                break;
            case StartSceneButtons.FacebookLoginBtn:
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
        FacebookLoginBtn,
        
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
        FBManagerScript.Instance.GetUserData();
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
                TitleOpened();
                break;
            case StartScenePanels.TouchToStart:
                FindUIObject("TouchToStartPanel").SetActive(true);
                TtsBlink();
                break;

        }
    }

    #endregion

    private Sequence _titleSequence;

    private void LoadingSequence()
    {
        FindUIObject("DBInfo").GetComponent<TMP_Text>().DOText("출석부 쓰는중...", 1f).SetLoops(-1, LoopType.Yoyo);
    }

    private void TitleOpened()
    {
        _titleSequence = DOTween.Sequence().OnStart(() =>
            {
                FindUIObject("LoginHeadImage").transform.localScale = Vector3.zero;
                var color = FindUIObject("LoginHeadImage").GetComponent<Image>().color;
                color.a = 0f;
            })
            .Append(FindUIObject("LoginHeadImage").transform.DOScale(1, 1).SetEase(Ease.OutBounce))
            .Join(FindUIObject("LoginHeadImage").GetComponent<Image>().DOFade(1, 1))
            .SetDelay(0.5f);
    }

    private void TtsBlink()
    {
        FindUIObject("TouchToStartTxt").GetComponent<TMP_Text>().DOFade(0, 1f).SetEase(Ease.InQuad)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
