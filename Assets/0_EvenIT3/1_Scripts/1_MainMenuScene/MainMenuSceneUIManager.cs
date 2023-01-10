using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
            
            //Stage
            case MainMenuSceneButtons.Stage1Btn:
                OnClickStage1Btn();
                break;
        
            //Achievement
            case MainMenuSceneButtons.AchievementCloseBtn:
                OnClickAchievementCloseBtn();
                break;
            case MainMenuSceneButtons.AchievementAllObtainBtn:
                OnClickAchievementAllObtainBtn();
                break;
            
            //Collection
        
            //Shop
        
            //Inventory
            case MainMenuSceneButtons.InventoryCloseBtn:
                OnClickInventoryCloseBtn();
                break;
        
            //Option
            case MainMenuSceneButtons.OptionCloseBtn:
                OnClickOptionCloseBtn();
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
        
        //Stage
        Stage1Btn,
        
        //Achievement
        AchievementCloseBtn,
        AchievementAllObtainBtn,
        
        //Collection
        
        //Shop
        
        //Inventory
        InventoryCloseBtn,
        
        //Option
        OptionCloseBtn,
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
        FindUIObject("SetNickNamePanel").SetActive(false);
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    //Move Btns
    private void OnClickStageMoveBtn()
    {
        ChangeUI(MainMenuScenePanels.StagePanel);
    }
    
    private void OnClickAchievementMoveBtn()
    {
        ChangeUI(MainMenuScenePanels.AchievementPanel);
    }
    
    private void OnClickCollectionMoveBtn()
    {
        ChangeUI(MainMenuScenePanels.CollectionPanel);
    }
    
    private void OnClickShopMoveBtn()
    {
        ChangeUI(MainMenuScenePanels.ShopPanel);
    }
    
    private void OnClickInventoryMoveBtn()
    {
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
    
    //Stage
    private void OnClickStage1Btn()
    {
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
        
    //Shop
        
    //Inventory
    private void OnClickInventoryCloseBtn()
    {
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }
        
    //Option
    private void OnClickOptionCloseBtn()
    {
        //++Save
        ChangeUI(MainMenuScenePanels.MainMenuTouchPanel);
    }

    private void OnClickOptionLogOutBtn()
    {
        AppManagerScript.Instance.GetComponent<LogInManager>().LogOut();
    }

    private void OnClickOptionWithDrawBtn()
    {
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
        FindUIObject("StagePanel").SetActive(false);
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
                FindUIObject("StagePanel").SetActive(true);
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
}
