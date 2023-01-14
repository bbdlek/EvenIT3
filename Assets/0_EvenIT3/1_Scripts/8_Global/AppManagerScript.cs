using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
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

    public Settings appSettings;

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
        InitSettings();
    }
    

    public void ChangeScene(SceneName changeSceneName)
    {
        Time.timeScale = 1;
        sceneName = changeSceneName;
        SceneManager.LoadScene(sceneName.ToString());
    }

    private void InitSettings()
    {
        if(PlayerPrefs.HasKey("IsFirst"))
        {
            if(PlayerPrefs.GetInt("IsFirst") == 1)
            {
                appSettings = JsonHelper.Load();
            }
        }
        else
        {
            PlayerPrefs.SetInt("IsFirst", 1);
            JsonHelper.SaveSettings(new Settings(1, 1, true));
        }
        //배경음악
        MasterAudio.Instance._masterPlaylistVolume = appSettings.BgmVolume;
        //효과음
        MasterAudio.Instance._masterAudioVolume = appSettings.EffectVolume;
        //진동
        //푸시알림
    }
    
}
