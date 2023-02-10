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

    public GameObject cautionPanelPrefab;

    [SerializeField] private Sprite[] cautionIcons;

    public int selectedChapter;
    public int selectedStage;
    public bool[] selectedItem = new bool[3];
    public bool isRestart = false;
    public bool isWithDraw = false;
    public bool isStageTutorial = false;
    
    //Achievements
    public int[] continuousStage = new int[4];

    #region Settings

    //배경음악
    public float bgmVolume;
    //효과음
    public float effectVolume;
    //진동효과
    public bool isVibration;

    #endregion

    public bool[] buff = new bool[5];

    public void InitCautionPanel(int type)
    {
        GameObject tempCautionPanel = Instantiate(cautionPanelPrefab, FindObjectOfType<Canvas>().transform);
        switch (type)
        {
            case 0: //에너지
                tempCautionPanel.transform.GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite =
                    cautionIcons[0];
                tempCautionPanel.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TMP_Text>().text =
                    "X 5\n금화 5개";
                tempCautionPanel.transform.GetChild(2).GetComponent<TMPro.TMP_Text>().text =
                    "보유하신 에너지가 부족합니다.\n충전하시겠습니까?";
                tempCautionPanel.transform.GetChild(3).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(
                    () =>
                    {
                        if (UserManager.Instance.userData.Commodities.Gold >= 5)
                        {
                            UserManager.Instance.userData.Commodities.Gold -= 5;
                            UserManager.Instance.userData.energy += 5;
                            _fbManager.UpdateCurrentUser();
                        }
                        else
                        {
                            InitCautionPanel(2);
                        }
                        Destroy(tempCautionPanel);
                    });
                break;
            case 1: //은화
                tempCautionPanel.transform.GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite =
                    cautionIcons[1];
                tempCautionPanel.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TMP_Text>().text =
                    "X 1000\n금화 1개";
                tempCautionPanel.transform.GetChild(2).GetComponent<TMPro.TMP_Text>().text =
                    "보유하신 은화가 부족합니다.\n충전하시겠습니까?";
                tempCautionPanel.transform.GetChild(3).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(
                    () =>
                    {
                        if (UserManager.Instance.userData.Commodities.Gold >= 1)
                        {
                            UserManager.Instance.userData.Commodities.Gold -= 1;
                            UserManager.Instance.userData.Commodities.Silver += 1000;
                            _fbManager.UpdateCurrentUser();
                        }
                        else
                        {
                            InitCautionPanel(2);
                        }
                        Destroy(tempCautionPanel);
                    });
                break;
            case 2: //금화
                tempCautionPanel.transform.GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite =
                    cautionIcons[2];
                tempCautionPanel.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TMP_Text>().text =
                    "X 2\n1000원";
                tempCautionPanel.transform.GetChild(2).GetComponent<TMPro.TMP_Text>().text =
                    "보유하신 금화가 부족합니다.\n충전하시겠습니까?";
                tempCautionPanel.transform.GetChild(3).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(
                    () =>
                    {
                        FindObjectOfType<SnackIAPManager>().BuyGold2();
                        Destroy(tempCautionPanel);
                    });
                break;
        }
    }
    
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
