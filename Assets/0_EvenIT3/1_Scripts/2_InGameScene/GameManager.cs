using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        InGame, Pause
    }

    public GameState gameState;
    
    public InGameSceneUIManager inGameSceneUIManager;
    public Stage curStage;
    public Player player;
    public TeacherController teacher;

    private int _stageNum;
    
    //필요 변수
    public float quantity;
    public Snack selectedSnack;
    public int shieldItem;
    public float maxDecibel;

    private void Start()
    {
        inGameSceneUIManager = FindObjectOfType<InGameSceneUIManager>();
        inGameSceneUIManager.InitSetup(gameObject);
        player = GetComponent<Player>();
        teacher = GetComponent<TeacherController>();
        gameState = GameState.InGame;
        _stageNum = (AppManagerScript.Instance.selectedChapter - 1) * 4 + AppManagerScript.Instance.selectedStage - 1;
        SetStageUI();
        InitStage();
    }

    private void Update()
    {
        if (gameState == GameState.InGame)
        {
            TimerCount();
            CheckDecibel();
            CheckQuantity();
            CheckTurn();
        }
    }

    //Set Stage

    private void InitStage()
    {
        //Stage
        SetStageInfo();
        SelectSnack();
        shieldItem = 1;

        //Timer
        curTime = setTime;
        
        //GameStart
        _isTimer = true;
    }

    private void SetStageUI()
    {
        if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 5)
        {
            teacher.SetTeacherImg(0);
            inGameSceneUIManager.FindUIObject("BG_Board").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Stage/art_languageteacher_board");
        }
        else if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 9)
        {
            teacher.SetTeacherImg(1);
            inGameSceneUIManager.FindUIObject("BG_Board").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Stage/art_history teacher_board");
        }
        else if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 13)
        {
            teacher.SetTeacherImg(2);
            inGameSceneUIManager.FindUIObject("BG_Board").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Stage/art_music teacher_board");
        }
        else if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 17)
        {
            teacher.SetTeacherImg(3);
            inGameSceneUIManager.FindUIObject("BG_Board").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Stage/art_english teacher_board");
        }
        
        switch (AppManagerScript.Instance.selectedChapter)
        {
            case 1:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 30 / 100, -44, 0);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 40 / 100, -44, 0);
                break;
            case 2:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 20 / 120, -44, 0);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 30 / 120, -44, 0);
                break;
            case 3:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 10 / 140, -44, 0);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 20 / 140, -44, 0);
                break;
            case 4:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 30 / 100, -44, 0);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 40 / 100, -44, 0);
                break;
            case 5:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 20 / 120, -44, 0);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 30 / 120, -44, 0);
                break;
            case 6:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 10 / 140, -44, 0);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().position =
                    new Vector3(1500 * 20 / 140, -44, 0);
                break;
        }
    }
    
    private void SetStageInfo()
    {
        curStage = new Stage();
        curStage.no = DBManagerScript.Instance.stageDB[_stageNum].no;
        curStage.name = DBManagerScript.Instance.stageDB[_stageNum].name;
        curStage.teacherNo = DBManagerScript.Instance.stageDB[_stageNum].teacherNo;
        curStage.snackNoList = DBManagerScript.Instance.stageDB[_stageNum].snackNoList.ToList();
        curStage.reward_1 = DBManagerScript.Instance.stageDB[_stageNum].reward_1;
        curStage.reward_2 = DBManagerScript.Instance.stageDB[_stageNum].reward_2;
        curStage.reward_3 = DBManagerScript.Instance.stageDB[_stageNum].reward_3;
        setTime = DBManagerScript.Instance.stageDB[_stageNum].stageTime;
        maxDecibel = DBManagerScript.Instance.teacherDB[curStage.teacherNo - 1].maxDecibel;
    }

    private void SelectSnack()
    {
        int select = curStage.snackNoList[Random.Range(0, curStage.snackNoList.Count)];
        selectedSnack = DBManagerScript.Instance.snackDB[select];
        inGameSceneUIManager.FindUIObject("QuantityBG").GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Snacks/" + selectedSnack.name);
        inGameSceneUIManager.FindUIObject("QuantitySnackIcon").GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Snacks/" + selectedSnack.name);
        player.SetBasePlayerStat();
    }
    
    //Timer
    public float setTime = 100f;
    public float curTime;
    public bool _isTimer;
    
    private void TimerCount()
    {
        if(_isTimer)
        {
            inGameSceneUIManager.TimerUpdate(1 - curTime / setTime);
            curTime -= Time.deltaTime;
            if (curTime <= 0)
            {
                _isTimer = false;
                curTime = 0;
                Time.timeScale = 0;
                if (shieldItem == 0)
                {
                    inGameSceneUIManager.FindUIObject("FailedOverPanelBuyBtn").GetComponent<UnityEngine.UI.Button>()
                        .interactable = false;
                }
                else
                {
                    inGameSceneUIManager.FindUIObject("FailedOverPanelBuyBtn").GetComponent<UnityEngine.UI.Button>()
                        .interactable = true;
                }
                inGameSceneUIManager.FindUIObject("FailedOverPanel").SetActive(true);
            }
        }
    }
    
    //Decibel
    private void CheckDecibel()
    {
        inGameSceneUIManager.FindUIObject("DecibelImg_eating").SetActive(false);
        inGameSceneUIManager.FindUIObject("DecibelImg_normal").SetActive(false);
        inGameSceneUIManager.FindUIObject("DecibelImg_warning").SetActive(false);
        float decibel = player.curDecibelAmount;
        if (maxDecibel - 15f <= decibel && teacher.teacherState == TeacherController.TeacherState.Idle)
        {
            inGameSceneUIManager.FindUIObject("TeacherBubbleTxt").GetComponent<TMPro.TMP_Text>().text = "무슨 소리가 들리는 것 같은데...";
            inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(true);
            inGameSceneUIManager.FindUIObject("DecibelImg_warning").SetActive(true);
        }
        else
        {
            inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(false);
            if(player.playerState == Player.State.Eating)
                inGameSceneUIManager.FindUIObject("DecibelImg_eating").SetActive(true);
            else
                inGameSceneUIManager.FindUIObject("DecibelImg_normal").SetActive(true);
        }
        if (maxDecibel <= decibel)
        {
            inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(false);
            Debug.Log("Failed");
            gameState = GameState.Pause;
            Time.timeScale = 0;
            if (shieldItem == 0)
            {
                inGameSceneUIManager.FindUIObject("FailedDecibelPanelBuyBtn").GetComponent<UnityEngine.UI.Button>()
                    .interactable = false;
            }
            else
            {
                inGameSceneUIManager.FindUIObject("FailedDecibelPanelBuyBtn").GetComponent<UnityEngine.UI.Button>()
                    .interactable = true;
            }
            inGameSceneUIManager.FindUIObject("FailedDecibelPanel").SetActive(true);
        }
    }

    private void CheckQuantity()
    {
        float curQuantity = player.curQuantity;
        inGameSceneUIManager.QuantityUpdate(curQuantity / quantity);
        if (quantity <= curQuantity)
        {
            Debug.Log("Succeed");
            gameState = GameState.Pause;
            Time.timeScale = 0;
        }
    }

    private void CheckTurn()
    {
        if (teacher.teacherState == TeacherController.TeacherState.Look)
        {
            if (player.playerState == Player.State.Eating)
            {
                Debug.Log("Failed");
                gameState = GameState.Pause;
                Time.timeScale = 0;
                inGameSceneUIManager.FindUIObject("FailedLookPanel").SetActive(true);
            }
        }
    }
    
}
