using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class AppManagerScript : Singleton<AppManagerScript>
{
    private GamabaseManager _gamabaseManager;
    private FBManagerScript _fbManager;
    public GameObject sceneManagerObject;

    public SceneName sceneName;

    public int selectedChapter;
    public int selectedStage;
    public bool[] selectedItem = new bool[3];
    public bool isRestart = false;
    public bool isWithDraw = false;
    public bool isStageTutorial = false;

    #region Settings

    //배경음악
    public float bgmVolume;
    //효과음
    public float effectVolume;
    //진동효과
    public bool isVibration;

    #endregion

    public bool[] buff = new bool[5];
    
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
        if(PlayerPrefs.HasKey("bgmVolume"))
        {
            bgmVolume = PlayerPrefs.GetFloat("bgmVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("bgmVolume", 1);
            bgmVolume = PlayerPrefs.GetFloat("bgmVolume");
        }
        
        if(PlayerPrefs.HasKey("effectVolume"))
        {
            effectVolume = PlayerPrefs.GetFloat("effectVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("effectVolume", 1);
            effectVolume = PlayerPrefs.GetFloat("effectVolume");
        }

        if (PlayerPrefs.HasKey("isVibration"))
        {
            isVibration = PlayerPrefs.GetInt("isVibration") == 1;
        }
        else
        {
            PlayerPrefs.SetInt("isVibration", 1);
            isVibration = PlayerPrefs.GetInt("isVibration") == 1;
        }
        //배경음악
        MasterAudio.PlaylistMasterVolume = bgmVolume;
        //효과음
        MasterAudio.Instance._masterAudioVolume = effectVolume;
        //진동
        //푸시알림
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("bgmVolume", bgmVolume);
        PlayerPrefs.SetFloat("effectVolume", effectVolume);
        
        switch (isVibration)
        {
            case true:
                PlayerPrefs.SetInt("isVibration", 1);
                break;
            case false:
                PlayerPrefs.SetInt("isVibration", 0);
                break;
        }
    }
    
}
