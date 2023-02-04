using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using Toast.Gamebase;
using UnityEngine;

public class MainMenuSceneManagerScript : MonoBehaviour
{
    public MainMenuSceneUIManager mainMenuSceneUIManager;

    private void Awake()
    {
        MasterAudio.ChangePlaylistByName("BGM_Main");
        InitSceneManager();
        CheckNewUser();
        mainMenuSceneUIManager.InitSetup(gameObject);
    }

    private void InitSceneManager()
    {
        AppManagerScript.Instance.sceneManagerObject = gameObject;
        if (!mainMenuSceneUIManager) mainMenuSceneUIManager = FindObjectOfType<MainMenuSceneUIManager>();
    }

    private async void CheckNewUser()
    {
        if (!await FBManagerScript.Instance.CheckNewUser(UserManager.Instance.userID))
        {
            mainMenuSceneUIManager.ChangeUI(MainMenuSceneUIManager.MainMenuScenePanels.StoryPanel);
        }
        else
        {
            FBManagerScript.Instance.GetUserData();
            mainMenuSceneUIManager.ChangeUI(MainMenuSceneUIManager.MainMenuScenePanels.MainMenuTouchPanel);
            mainMenuSceneUIManager.CheckRestart();
            mainMenuSceneUIManager.ResetCommodities();
            mainMenuSceneUIManager.ResetItems();
            mainMenuSceneUIManager.InitProfile();
            mainMenuSceneUIManager.SetCollectionNum();
            mainMenuSceneUIManager.InitCollection();
            mainMenuSceneUIManager.InitProfileEdges();
            mainMenuSceneUIManager.InitProfileImages();
            mainMenuSceneUIManager.InitProfileCollection();
            mainMenuSceneUIManager.InitProfileScore();
            mainMenuSceneUIManager.InitEnergy();
            mainMenuSceneUIManager.InitAchievement();
        }
    }
}
