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
    public bool[] selectedItem = new bool[3];
    public bool isRestart = false;

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
        SetResolution();
    }

    private void SetResolution()
    {
        int setWidth = 2560; // 사용자 설정 너비
        int setHeight = 1440; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
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
