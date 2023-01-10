using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManagerScript : Singleton<AppManagerScript>
{
    private GamabaseManager _gamabaseManager;
    private FBManagerScript _fbManager;
    public GameObject sceneManagerObject;

    public SceneName sceneName;

    public int selectedChapter;
    public int selectedStage;

    public override void Awake()
    {
        SetApp();
        RemoveDuplicates();
        _fbManager = GetComponent<FBManagerScript>();
        _gamabaseManager = GetComponent<GamabaseManager>();
    }

    private void Start()
    {
        InitApp();
    }

    private void SetApp()
    {
        Application.targetFrameRate = 60;
    }

    private void InitApp()
    {
        _fbManager.InitFirebase();
        _gamabaseManager.Initialize();
    }
    

    public void ChangeScene(SceneName changeSceneName)
    {
        sceneName = changeSceneName;
        SceneManager.LoadScene(sceneName.ToString());
    }
    
}
