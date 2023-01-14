using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManagerScript : MonoBehaviour
{
    public StartSceneUIManager startSceneUIManager;

    private void Start()
    {
        AppManagerScript.Instance.sceneManagerObject = gameObject;
        InitSceneManager();
    }

    public void InitSceneManager()
    {
        AppManagerScript.Instance.sceneManagerObject = gameObject;
        if (!startSceneUIManager) startSceneUIManager = FindObjectOfType<StartSceneUIManager>();

        startSceneUIManager.InitSetup(gameObject);
        /*if (UserManager.Instance != null)
        {
            AppManagerScript.Instance.GetComponent<LogInManager>().LoginForLastLoggedInProvider();
        }*/
    }

}
