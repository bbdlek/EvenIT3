using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
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
    
    //필요 변수
    public float quantity;
    public Snack selectedSnack;

    private void Start()
    {
        inGameSceneUIManager = FindObjectOfType<InGameSceneUIManager>();
        inGameSceneUIManager.InitSetup(gameObject);
        player = GetComponent<Player>();
        teacher = GetComponent<TeacherController>();
        gameState = GameState.InGame;
        InitStage();
    }

    private void Update()
    {
        if (gameState == GameState.InGame)
        {
            TimerCount();
            CheckDecibel();
            CheckQuantity();
        }
    }

    //Set Stage

    private void InitStage()
    {
        //Stage
        SetStageInfo();
        SelectSnack();

        //Timer
        curTime = setTime;
        
        //GameStart
        _isTimer = true;
    }
    
    private void SetStageInfo()
    {
        curStage = new Stage();
        curStage.no = DBManagerScript.Instance.stageDB[0].no;
        curStage.name = DBManagerScript.Instance.stageDB[0].name;
        curStage.teacher = DBManagerScript.Instance.stageDB[0].teacher;
        curStage.snackList = DBManagerScript.Instance.stageDB[0].snackList.ToList();
        curStage.reward_1 = DBManagerScript.Instance.stageDB[0].reward_1;
        curStage.reward_2 = DBManagerScript.Instance.stageDB[0].reward_2;
        curStage.reward_3 = DBManagerScript.Instance.stageDB[0].reward_3;
    }

    private void SelectSnack()
    {
        int select = Random.Range(0, curStage.snackList.Count);
        selectedSnack = curStage.snackList[select];
        player.SetBasePlayerStat();
    }
    
    //Timer
    public float setTime = 60f;
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
                inGameSceneUIManager.FindUIObject("FailedOverPanel").SetActive(true);
            }
        }
    }
    
    //Decibel
    private void CheckDecibel()
    {
        float decibel = player.curDecibelAmount;
        inGameSceneUIManager.FindUIObject("DecibelTxt").GetComponent<TMPro.TMP_Text>().text =
            Mathf.Round(decibel * 10) / 10 + " db";
        if (curStage.teacher.maxDecibel <= decibel)
        {
            Debug.Log("Failed");
            gameState = GameState.Pause;
            Time.timeScale = 0;
            inGameSceneUIManager.FindUIObject("FailedLookPanel").SetActive(true);
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
    
}
