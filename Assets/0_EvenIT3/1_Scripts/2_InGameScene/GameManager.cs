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

    [SerializeField] private int _stageNum;
    
    //필요 변수
    public float quantity;
    public Snack selectedSnack;
    public int shieldItem;
    public int timerItem;
    public float maxDecibel;

    public override void Awake()
    {
        inGameSceneUIManager = FindObjectOfType<InGameSceneUIManager>();
        inGameSceneUIManager.InitSetup(gameObject);
        player = GetComponent<Player>();
        teacher = GetComponent<TeacherController>();
        _stageNum = (AppManagerScript.Instance.selectedChapter - 1) * 4 + AppManagerScript.Instance.selectedStage - 1;
        //Stage
        SetStageInfo();
    }

    private void Start()
    {
        SelectSnack();
        SetStageUI();
        InitStage();
        teacher.SetUpTeacher();
        gameState = GameState.InGame;
        
        //GameStart
        _isTimer = true;
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
        shieldItem = 1;

        //Timer
        curTime = setTime;
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
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 30 / 100, -44);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 40 / 100, -44);
                break;
            case 2:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 20 / 120, -44);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 30 / 120, -44);
                break;
            case 3:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 10 / 140, -44);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 20 / 140, -44);
                break;
            case 4:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 30 / 100, -44);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 40 / 100, -44);
                break;
            case 5:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 20 / 120, -44);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 30 / 120, -44);
                break;
            case 6:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 10 / 140, -44);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 20 / 140, -44);
                break;
        }
    }
    
    private void SetStageInfo()
    {
        curStage = DBManagerScript.Instance.stageDB[_stageNum];
        /*curStage = new Stage();
        curStage.no = DBManagerScript.Instance.stageDB[_stageNum].no;
        curStage.name = DBManagerScript.Instance.stageDB[_stageNum].name;
        curStage.teacherNo = DBManagerScript.Instance.stageDB[_stageNum].teacherNo;
        curStage.snackNoList = DBManagerScript.Instance.stageDB[_stageNum].snackNoList.ToList();
        curStage.reward_1 = DBManagerScript.Instance.stageDB[_stageNum].reward_1;
        curStage.reward_2 = DBManagerScript.Instance.stageDB[_stageNum].reward_2;
        curStage.reward_3 = DBManagerScript.Instance.stageDB[_stageNum].reward_3;*/
        setTime = DBManagerScript.Instance.stageDB[_stageNum].stageTime;
        maxDecibel = DBManagerScript.Instance.teacherDB[curStage.teacherNo - 1].maxDecibel;
    }

    private void SelectSnack()
    {
        Debug.Log(curStage.snackNoList.Count);
        Debug.Log(_stageNum);
        int rand = Random.Range((int)0, (int)DBManagerScript.Instance.stageDB[_stageNum].snackNoList.Count);
        Debug.Log(rand);
        int select = DBManagerScript.Instance.stageDB[_stageNum].snackNoList[rand];
        Debug.Log(select);
        selectedSnack = DBManagerScript.Instance.snackDB[select - 1];
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
            inGameSceneUIManager.TimerUpdate(curTime / setTime);
            curTime -= Time.deltaTime;
            if (curTime <= 0)
            {
                _isTimer = false;
                curTime = 0;
                Time.timeScale = 0;
                if (timerItem == 0)
                {
                    inGameSceneUIManager.FindUIObject("EasyFailPanel").SetActive(true);
                }
                else
                {
                    inGameSceneUIManager.FindUIObject("FailedOverPanel").SetActive(true);
                }
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
        if (maxDecibel - 15f <= decibel)
        {
            if( teacher.teacherState == TeacherController.TeacherState.Idle)
            {
                inGameSceneUIManager.FindUIObject("TeacherBubbleTxt").GetComponent<TMPro.TMP_Text>().text =
                    "무슨 소리가 들리는 것 같은데...";
                inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(true);
            }
            inGameSceneUIManager.FindUIObject("DecibelImg_warning").SetActive(true);
        }
        else 
        {
            if(teacher.teacherState == TeacherController.TeacherState.Idle)
            {
                inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(false);
            }
            if(player.playerState == Player.State.Eating)
                inGameSceneUIManager.FindUIObject("DecibelImg_eating").SetActive(true);
            else
                inGameSceneUIManager.FindUIObject("DecibelImg_normal").SetActive(true);
        }
        if (maxDecibel <= decibel)
        {
            if(teacher.teacherState == TeacherController.TeacherState.Idle)
            {
                inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(false);
            }
            Debug.Log("Failed");
            gameState = GameState.Pause;
            Time.timeScale = 0;
            if (shieldItem == 0)
            {
                inGameSceneUIManager.FindUIObject("EasyFailPanel").SetActive(true);
            }
            else
            {
                inGameSceneUIManager.FindUIObject("FailedDecibelPanel").SetActive(true);
            }
        }
    }

    private void CheckQuantity()
    {
        float curQuantity = player.curQuantity;
        inGameSceneUIManager.QuantityUpdate(curQuantity / quantity);
        if (quantity <= curQuantity)
        {
            Debug.Log("Succeed");
            CheckSucceed();
            gameState = GameState.Pause;
            Time.timeScale = 0;
        }
    }

    [SerializeField] private float remainTime;
    private void CheckSucceed()
    {
        remainTime = curTime;
        Debug.Log(remainTime);
        switch (AppManagerScript.Instance.selectedChapter)
        {
            case 1:
                if (remainTime >= 40)
                {
                    inGameSceneUIManager.SetUpStarIcons(3);
                }
                else if(remainTime >= 30 && remainTime < 40)
                {
                    inGameSceneUIManager.SetUpStarIcons(2);
                }
                else if(remainTime < 30)
                {
                    inGameSceneUIManager.SetUpStarIcons(1);
                }
                break;
            case 2:
                if (remainTime >= 30)
                {
                    inGameSceneUIManager.SetUpStarIcons(3);
                }
                else if(remainTime >= 20 && remainTime < 30)
                {
                    inGameSceneUIManager.SetUpStarIcons(2);
                }
                else if(remainTime < 20)
                {
                    inGameSceneUIManager.SetUpStarIcons(1);
                }
                break;
            case 3:
                if (remainTime >= 20)
                {
                    inGameSceneUIManager.SetUpStarIcons(3);
                }
                else if(remainTime >= 10 && remainTime < 20)
                {
                    inGameSceneUIManager.SetUpStarIcons(2);
                }
                else if(remainTime < 10)
                {
                    inGameSceneUIManager.SetUpStarIcons(1);
                }
                break;
            case 4:
                if (remainTime >= 40)
                {
                    inGameSceneUIManager.SetUpStarIcons(3);
                }
                else if(remainTime >= 30 && remainTime < 40)
                {
                    inGameSceneUIManager.SetUpStarIcons(2);
                }
                else if(remainTime < 30)
                {
                    inGameSceneUIManager.SetUpStarIcons(1);
                }
                break;
            case 5:
                if (remainTime >= 30)
                {
                    inGameSceneUIManager.SetUpStarIcons(3);
                }
                else if(remainTime >= 20 && remainTime < 30)
                {
                    inGameSceneUIManager.SetUpStarIcons(2);
                }
                else if(remainTime < 20)
                {
                    inGameSceneUIManager.SetUpStarIcons(1);
                }
                break;
            case 6:
                if (remainTime >= 20)
                {
                    inGameSceneUIManager.SetUpStarIcons(3);
                }
                else if(remainTime >= 10 && remainTime < 20)
                {
                    inGameSceneUIManager.SetUpStarIcons(2);
                }
                else if(remainTime < 10)
                {
                    inGameSceneUIManager.SetUpStarIcons(1);
                }
                break;
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
                if (shieldItem == 0)
                {
                    inGameSceneUIManager.FindUIObject("EasyFailPanel").SetActive(true);
                }
                else
                {
                    inGameSceneUIManager.FindUIObject("FailedDecibelPanel").SetActive(true);
                }
            }
        }
    }
    
}
