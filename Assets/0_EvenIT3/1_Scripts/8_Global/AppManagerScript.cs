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
