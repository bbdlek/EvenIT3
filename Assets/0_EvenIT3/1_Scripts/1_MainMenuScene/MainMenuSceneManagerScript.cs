using System;
using System.Collections;
using System.Collections.Generic;
using Toast.Gamebase;
using UnityEngine;

public class MainMenuSceneManagerScript : MonoBehaviour
{
    public MainMenuSceneUIManager mainMenuSceneUIManager;

    private void Awake()
    {
        InitSceneManager();
    }

    private void Start()
    {
        CheckNewUser();
    }

    private void InitSceneManager()
    {
        AppManagerScript.Instance.sceneManagerObject = gameObject;
        if (!mainMenuSceneUIManager) mainMenuSceneUIManager = FindObjectOfType<MainMenuSceneUIManager>();

        mainMenuSceneUIManager.InitSetup(gameObject);
    }

    private async void CheckNewUser()
    {
        if (!await FBManagerScript.Instance.CheckNewUser(UserManager.Instance.userID))
        {
            mainMenuSceneUIManager.ChangeUI(MainMenuSceneUIManager.MainMenuScenePanels.SetNickNamePanel);
        }
        else
        {
            mainMenuSceneUIManager.ChangeUI(MainMenuSceneUIManager.MainMenuScenePanels.MainMenuTouchPanel);
            mainMenuSceneUIManager.CheckRestart();
            mainMenuSceneUIManager.ResetCommodities();
            mainMenuSceneUIManager.ResetItems();
        }
    }
}
