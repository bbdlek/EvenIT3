using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DarkTonic.MasterAudio;
using Toast.Gamebase;
using UnityEngine;
using UnityEngine.Networking;
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
    public bool isFirst = true;
    
    public InGameSceneUIManager inGameSceneUIManager;
    public Stage curStage;
    public Player player;
    public TeacherController teacher;

    public int stageNum;

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
    public int maxSnack;

    public override void Awake()
    {
        if(AppManagerScript.Instance.sceneName == SceneName.InGameScene_Easy)
            MasterAudio.ChangePlaylistByName("BGM_Stage_Easy");
        else if(AppManagerScript.Instance.sceneName == SceneName.InGameScene_Hard)
            MasterAudio.ChangePlaylistByName("BGM_Stage_Hard");
        inGameSceneUIManager = FindObjectOfType<InGameSceneUIManager>();
        inGameSceneUIManager.InitSetup(gameObject);
        player = GetComponent<Player>();
        teacher = GetComponent<TeacherController>();
        stageNum = (AppManagerScript.Instance.selectedChapter - 1) * 4 + AppManagerScript.Instance.selectedStage - 1;
        CheckIsFirst();
        //Stage
        SetStageInfo();
        SetStageUI();
        teacher.SetUpTeacher();
    }

    private void Start()
    {
        SelectSnack();
        InitStage();
        gameState = GameState.InGame;

        if (AppManagerScript.Instance.isStageTutorial)
        {
            inGameSceneUIManager.FindUIObject("Tutorial3").SetActive(true);
            inGameSceneUIManager.FindUIObject("Tutorial_Teacher").SetActive(true);
            gameState = GameState.Pause;
            Time.timeScale = 0;
        }
        
        if(stageNum == 12)
        {
            if (UserManager.Instance.userData.starList.Count < stageNum + 1)
            {
                if(!UserManager.Instance.userData.lookHardOpening)
                {
                    UserManager.Instance.userData.lookHardOpening = true;
                    FBManagerScript.Instance.UpdateCurrentUser();
                    Instantiate(Resources.Load<GameObject>("Story/HardOpening"), inGameSceneUIManager.transform);
                    gameState = GameState.Pause;
                    Time.timeScale = 0;
                }
            }
        }
        
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

    private void CheckIsFirst()
    {
        isFirst = UserManager.Instance.userData.starList.Count < stageNum + 1;
    }

    //Set Stage

    private void InitStage()
    {
        shieldItem = 1;
        timerItem = 1;
        milkItem = AppManagerScript.Instance.selectedItem[0] ? 1 : 0;
        clockItem = AppManagerScript.Instance.selectedItem[1] ? 1 : 0;
        maskItem = AppManagerScript.Instance.selectedItem[2] ? 1 : 0;
        inGameSceneUIManager.FindUIObject("Item2Btn").GetComponent<Button>().interactable = AppManagerScript.Instance.selectedItem[0];
        inGameSceneUIManager.FindUIObject("Item1Btn").GetComponent<Button>().interactable = AppManagerScript.Instance.selectedItem[1];
        inGameSceneUIManager.FindUIObject("Item3Btn").GetComponent<Button>().interactable = AppManagerScript.Instance.selectedItem[2];
        

        //Timer
        curTime = setTime;
    }

    private void SetStageUI()
    {
        if (DBManagerScript.Instance.stageDB[stageNum].teacherNo < 4)
        {
            teacher.SetTeacherImg(0);
            inGameSceneUIManager.FindUIObject("BG_Board").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Stage/art_languageteacher_board");
        }
        else if (DBManagerScript.Instance.stageDB[stageNum].teacherNo < 8)
        {
            teacher.SetTeacherImg(1);
            inGameSceneUIManager.FindUIObject("BG_Board").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Stage/art_history teacher_board");
        }
        else if (DBManagerScript.Instance.stageDB[stageNum].teacherNo < 12)
        {
            teacher.SetTeacherImg(2);
            inGameSceneUIManager.FindUIObject("BG_Board").GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Stage/art_music teacher_board");
        }
        else if (DBManagerScript.Instance.stageDB[stageNum].teacherNo < 16)
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
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 30 / 120, -44);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 40 / 120, -44);
                break;
            case 6:
                inGameSceneUIManager.FindUIObject("2StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 10 / 140, -44);
                inGameSceneUIManager.FindUIObject("3StarIcon").GetComponent<RectTransform>().anchoredPosition = new Vector2(1500 * 20 / 140, -44);
                break;
        }
    }
    
    private void SetStageInfo()
    {
        curStage = DBManagerScript.Instance.stageDB[stageNum];
        setTime = DBManagerScript.Instance.stageDB[stageNum].stageTime;
        maxDecibel = DBManagerScript.Instance.teacherDB[curStage.teacherNo].maxDecibel;
        float decibelBuff = 0;
        if (AppManagerScript.Instance.buff[2]) decibelBuff += DBManagerScript.Instance.buffDB[2].NN;
        maxDecibel += maxDecibel * decibelBuff / 100;
        maxSnack = 3;
        if (DBManagerScript.Instance.stageDB[stageNum].snack3 == -1) maxSnack = 2;
        if (DBManagerScript.Instance.stageDB[stageNum].snack2 == -1) maxSnack = 1;
        curSnack = 0;
    }
    

    private void SelectSnack()
    {
        int select = 0;
        int selectNext = 0;
        switch (curSnack)
        {
            case 0:
                select = DBManagerScript.Instance.stageDB[stageNum].snack1;
                if (maxSnack > 1)
                {
                    selectNext = DBManagerScript.Instance.stageDB[stageNum].snack2;
                    inGameSceneUIManager.FindUIObject("QuantitySnackIconNext").SetActive(true);
                    inGameSceneUIManager.FindUIObject("QuantitySnackIconNext").GetComponent<Image>().sprite =
                        Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[selectNext].name);
                }
                else
                {
                    inGameSceneUIManager.FindUIObject("QuantitySnackIconNext").SetActive(false);
                }
                break;
            case 1:
                select = DBManagerScript.Instance.stageDB[stageNum].snack2;
                if (maxSnack > 2)
                {
                    selectNext = DBManagerScript.Instance.stageDB[stageNum].snack3;
                    inGameSceneUIManager.FindUIObject("QuantitySnackIconNext").SetActive(true);
                    inGameSceneUIManager.FindUIObject("QuantitySnackIconNext").GetComponent<Image>().sprite =
                        Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[selectNext].name);
                }
                else
                {
                    inGameSceneUIManager.FindUIObject("QuantitySnackIconNext").SetActive(false);
                }
                break;
            case 2:
                select = DBManagerScript.Instance.stageDB[stageNum].snack3;
                inGameSceneUIManager.FindUIObject("QuantitySnackIconNext").SetActive(false);
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
            UserManager.Instance.userData.achievementCount[46] += 1;
            UserManager.Instance.userData.achievementCount[47] += 1;
            UserManager.Instance.userData.achievementCount[48] += 1;
            UserManager.Instance.userData.achievementCount[49] += 1;
            curSnack++;
            SelectSnack();
        }
        else
        {
            remainTime = curTime;
            Debug.Log(remainTime);
            Debug.Log(LeaderboardManagerScript.Instance.UploadLeaderboard(stageNum, setTime - remainTime));
            MasterAudio.PlaySound("GameClear");
            inGameSceneUIManager.FindUIObject("ListeningEffect").SetActive(false);
            inGameSceneUIManager.FindUIObject("KoreanSkill").SetActive(false);
            inGameSceneUIManager.FindUIObject("HistorySkill").SetActive(false);
            //Achievement
            UserManager.Instance.userData.achievementCount[stageNum] = 1;
            if (stageNum == DBManagerScript.Instance.stageDB.Length - 1)
            {
                UserManager.Instance.userData.achievementCount[54] = 1;
            }
            
            int chapter = AppManagerScript.Instance.selectedChapter - 1;
            switch (AppManagerScript.Instance.selectedStage - 1)
            {
                case 0:
                    AppManagerScript.Instance.continuousStage[chapter] = 1;
                    break;
                case 1:
                    if (AppManagerScript.Instance.continuousStage[chapter] == 1)
                    {
                        AppManagerScript.Instance.continuousStage[chapter] = 2;
                    }
                    break;
                case 2:
                    if (AppManagerScript.Instance.continuousStage[chapter] == 2)
                    {
                        AppManagerScript.Instance.continuousStage[chapter] = 3;
                    }
                    break;
                case 3:
                    if (AppManagerScript.Instance.continuousStage[chapter] == 3)
                    {
                        AppManagerScript.Instance.continuousStage[chapter] = 4;
                        UserManager.Instance.userData.achievementCount[24 + chapter] = 1;
                    }
                    break;
            }
            
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

    public bool isMiniTutorialOn;

    private IEnumerator FailedMotion(int type) // type 0: Timer, Decibel, Turn
    {
        player.playerState = Player.State.Idle;
        inGameSceneUIManager.FindUIObject("SurpriseEffect").SetActive(true);
        inGameSceneUIManager.FindUIObject("ListeningEffect").SetActive(false);
        inGameSceneUIManager.FindUIObject("KoreanSkill").SetActive(false);
        inGameSceneUIManager.FindUIObject("HistorySkill").SetActive(false);
        yield return new WaitForSeconds(1f);
        teacher.teacherObj.GetComponent<Animator>().enabled = false;
        teacher.teacherState = TeacherController.TeacherState.End;
        yield return new WaitForSeconds(0.5f);
        switch (type)
        {
            case 0: //시간초과
                if (timerItem == 0)
                {
                    MasterAudio.PlaySound("GameOver");
                    UserManager.Instance.userData.achievementCount[30] += 1;
                    UserManager.Instance.userData.achievementCount[31] += 1;
                    UserManager.Instance.userData.achievementCount[32] += 1;
                    inGameSceneUIManager.FindUIObject("FailPanel").SetActive(true);
                    AppManagerScript.Instance.continuousStage[AppManagerScript.Instance.selectedChapter - 1] = 0;
                    UserManager.Instance.userData.energy -= 1;
                    FBManagerScript.Instance.UpdateCurrentUser();
                }
                else
                {
                    if (!UserManager.Instance.userData.tutorialMini)
                    {
                        inGameSceneUIManager.FindUIObject("MiniTutorial").SetActive(true);
                        isMiniTutorialOn = true;
                    }
                    inGameSceneUIManager.FindUIObject("FailedOverPanel").SetActive(true);
                }
                break;
            case 1: //데시벨
                if (shieldItem == 0)
                {
                    MasterAudio.PlaySound("GameOver");
                    UserManager.Instance.userData.achievementCount[36] += 1;
                    UserManager.Instance.userData.achievementCount[37] += 1;
                    UserManager.Instance.userData.achievementCount[38] += 1;
                    inGameSceneUIManager.FindUIObject("FailPanel").SetActive(true);
                    AppManagerScript.Instance.continuousStage[AppManagerScript.Instance.selectedChapter - 1] = 0;
                    UserManager.Instance.userData.energy -= 1;
                    FBManagerScript.Instance.UpdateCurrentUser();
                }
                else
                {
                    if (!UserManager.Instance.userData.tutorialMini)
                    {
                        inGameSceneUIManager.FindUIObject("MiniTutorial").SetActive(true);
                        isMiniTutorialOn = true;
                    }

                    inGameSceneUIManager.FindUIObject("FailedDecibelPanel").SetActive(true);
                }
                break;
            case 2: //뒤돌기
                if (shieldItem == 0)
                {
                    MasterAudio.PlaySound("GameOver");
                    UserManager.Instance.userData.achievementCount[33] += 1;
                    UserManager.Instance.userData.achievementCount[34] += 1;
                    UserManager.Instance.userData.achievementCount[35] += 1;
                    inGameSceneUIManager.FindUIObject("FailPanel").SetActive(true);
                    AppManagerScript.Instance.continuousStage[AppManagerScript.Instance.selectedChapter - 1] = 0;
                    UserManager.Instance.userData.energy -= 1;
                    FBManagerScript.Instance.UpdateCurrentUser();
                }
                else
                {
                    if (!UserManager.Instance.userData.tutorialMini)
                    {
                        inGameSceneUIManager.FindUIObject("MiniTutorial").SetActive(true);
                        isMiniTutorialOn = true;
                    }

                    inGameSceneUIManager.FindUIObject("FailedLookPanel").SetActive(true);
                }
                break;
        }

        Time.timeScale = 0;
    }

}
