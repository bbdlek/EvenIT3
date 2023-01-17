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
    public int milkItem;
    public int clockItem;
    public int maskItem;
    public float maxDecibel;
    [SerializeField] private int curSnack;
    [SerializeField] private int maxSnack;

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
        timerItem = 1;
        milkItem = AppManagerScript.Instance.selectedItem[0] ? 1 : 0;
        clockItem = AppManagerScript.Instance.selectedItem[1] ? 1 : 0;
        maskItem = AppManagerScript.Instance.selectedItem[2] ? 1 : 0;
        

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
        setTime = DBManagerScript.Instance.stageDB[_stageNum].stageTime;
        maxDecibel = DBManagerScript.Instance.teacherDB[curStage.teacherNo].maxDecibel;
        maxSnack = 3;
        if (DBManagerScript.Instance.stageDB[_stageNum].snack3 == -1) maxSnack = 2;
        if (DBManagerScript.Instance.stageDB[_stageNum].snack2 == -1) maxSnack = 1;
        curSnack = 0;
    }

    private void SelectSnack()
    {
        int select = 0;
        switch (curSnack)
        {
            case 0:
                select = DBManagerScript.Instance.stageDB[_stageNum].snack1;
                break;
            case 1:
                select = DBManagerScript.Instance.stageDB[_stageNum].snack2;
                break;
            case 2:
                select = DBManagerScript.Instance.stageDB[_stageNum].snack3;
                break;
        }
        selectedSnack = DBManagerScript.Instance.snackDB[select];
        inGameSceneUIManager.FindUIObject("QuantitySnackIcon").GetComponent<Image>().fillAmount = 1;
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
                if(gameState == GameState.InGame)
                    StartCoroutine(FailedMotion(0));
                gameState = GameState.Pause;
            }
        }
    }
    
    //Decibel
    public Gradient gradient;
    private void CheckDecibel()
    {
        /*inGameSceneUIManager.FindUIObject("DecibelImg_eating").SetActive(false);
        inGameSceneUIManager.FindUIObject("DecibelImg_normal").SetActive(false);
        inGameSceneUIManager.FindUIObject("DecibelImg_warning").SetActive(false);*/
        float decibel = player.curDecibelAmount;
        float decibelPercent = decibel / maxDecibel;
        inGameSceneUIManager.FindUIObject("DecibelImg_Color").GetComponent<Image>().color =
            gradient.Evaluate(decibelPercent);
        if (maxDecibel - 15f <= decibel)
        {
            if( teacher.teacherState == TeacherController.TeacherState.Idle)
            {
                inGameSceneUIManager.FindUIObject("TeacherBubbleTxt").GetComponent<TMPro.TMP_Text>().text =
                    "무슨 소리가 들리는 것 같은데...";
                inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(true);
            }
            //inGameSceneUIManager.FindUIObject("DecibelImg_warning").SetActive(true);
        }
        else 
        {
            if(teacher.teacherState == TeacherController.TeacherState.Idle)
            {
                inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(false);
            }
            /*if(player.playerState == Player.State.Eating)
                inGameSceneUIManager.FindUIObject("DecibelImg_eating").SetActive(true);
            else
                inGameSceneUIManager.FindUIObject("DecibelImg_normal").SetActive(true);*/
        }
        if (maxDecibel <= decibel)
        {
            if(teacher.teacherState == TeacherController.TeacherState.Idle)
            {
                inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(false);
            }
            Debug.Log("Failed");
            if(gameState == GameState.InGame)
                StartCoroutine(FailedMotion(1));
            gameState = GameState.Pause;
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
        }
    }

    [SerializeField] private float remainTime;
    private void CheckSucceed()
    {
        if (curSnack< maxSnack - 1)
        {
            curSnack++;
            SelectSnack();
        }
        else
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
                    else if (remainTime >= 30 && remainTime < 40)
                    {
                        inGameSceneUIManager.SetUpStarIcons(2);
                    }
                    else if (remainTime < 30)
                    {
                        inGameSceneUIManager.SetUpStarIcons(1);
                    }

                    break;
                case 2:
                    if (remainTime >= 30)
                    {
                        inGameSceneUIManager.SetUpStarIcons(3);
                    }
                    else if (remainTime >= 20 && remainTime < 30)
                    {
                        inGameSceneUIManager.SetUpStarIcons(2);
                    }
                    else if (remainTime < 20)
                    {
                        inGameSceneUIManager.SetUpStarIcons(1);
                    }

                    break;
                case 3:
                    if (remainTime >= 20)
                    {
                        inGameSceneUIManager.SetUpStarIcons(3);
                    }
                    else if (remainTime >= 10 && remainTime < 20)
                    {
                        inGameSceneUIManager.SetUpStarIcons(2);
                    }
                    else if (remainTime < 10)
                    {
                        inGameSceneUIManager.SetUpStarIcons(1);
                    }

                    break;
                case 4:
                    if (remainTime >= 40)
                    {
                        inGameSceneUIManager.SetUpStarIcons(3);
                    }
                    else if (remainTime >= 30 && remainTime < 40)
                    {
                        inGameSceneUIManager.SetUpStarIcons(2);
                    }
                    else if (remainTime < 30)
                    {
                        inGameSceneUIManager.SetUpStarIcons(1);
                    }

                    break;
                case 5:
                    if (remainTime >= 30)
                    {
                        inGameSceneUIManager.SetUpStarIcons(3);
                    }
                    else if (remainTime >= 20 && remainTime < 30)
                    {
                        inGameSceneUIManager.SetUpStarIcons(2);
                    }
                    else if (remainTime < 20)
                    {
                        inGameSceneUIManager.SetUpStarIcons(1);
                    }

                    break;
                case 6:
                    if (remainTime >= 20)
                    {
                        inGameSceneUIManager.SetUpStarIcons(3);
                    }
                    else if (remainTime >= 10 && remainTime < 20)
                    {
                        inGameSceneUIManager.SetUpStarIcons(2);
                    }
                    else if (remainTime < 10)
                    {
                        inGameSceneUIManager.SetUpStarIcons(1);
                    }

                    break;
            }
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
                if(gameState == GameState.InGame)
                    StartCoroutine(FailedMotion(1));
                gameState = GameState.Pause;
            }
        }
    }

    private IEnumerator FailedMotion(int type) // type 0: Timer, Decibel
    {
        player.playerState = Player.State.Idle;
        inGameSceneUIManager.FindUIObject("SurpriseEffect").SetActive(true);
        yield return new WaitForSeconds(1f);
        teacher.teacherState = TeacherController.TeacherState.End;
        yield return new WaitForSeconds(0.5f);
        switch (type)
        {
            case 0:
                if (timerItem == 0)
                {
                    inGameSceneUIManager.FindUIObject("EasyFailPanel").SetActive(true);
                }
                else
                {
                    inGameSceneUIManager.FindUIObject("FailedOverPanel").SetActive(true);
                }
                break;
            case 1:
                if (shieldItem == 0)
                {
                    inGameSceneUIManager.FindUIObject("EasyFailPanel").SetActive(true);
                }
                else
                {
                    inGameSceneUIManager.FindUIObject("FailedDecibelPanel").SetActive(true);
                }
                break;
        }
        
        Time.timeScale = 0;
    }
    
}
