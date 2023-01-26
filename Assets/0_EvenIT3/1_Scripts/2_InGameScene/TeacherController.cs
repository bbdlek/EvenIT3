using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TeacherController : MonoBehaviour
{
    public enum TeacherState
    {
        Idle, BeforeLook, Look, End
    }

    private TeacherState _teacherState;
    
    public GameObject teacherObj;

    public TeacherState teacherState
    {
        get
        {
            return _teacherState;
        }
        set
        {
            _teacherState = value;
            if (value == TeacherState.End)
            {
                MasterAudio.PlaySound("Teacher_Annoying");
            }
        }
    }
    private float _minDelay = 3;
    private float _maxDelay = 12;
    private float _watchingTime;
    public Sprite teacherBack;
    public Sprite teacherFront;
    public Sprite teacherAngry;
    public Sprite[] teacherBacks;
    public Sprite[] teacherFronts;
    public Sprite[] teacherAngrySprites;
    public Image teacherImg;

    [SerializeField] private bool isEnglishSkill = false;

    private int _stageNum;

    public void SetUpTeacher()
    {
        teacherImg = teacherObj.GetComponent<Image>();
        teacherState = TeacherState.Idle;
        _minDelay = DBManagerScript.Instance.teacherDB[GameManager.Instance.curStage.teacherNo].minDelay;
        _maxDelay = DBManagerScript.Instance.teacherDB[GameManager.Instance.curStage.teacherNo].maxDelay;
        _watchingTime = DBManagerScript.Instance.teacherDB[GameManager.Instance.curStage.teacherNo].watchingTime;

        StartCoroutine(LookCoroutine());
        _stageNum = (AppManagerScript.Instance.selectedChapter - 1) * 4 + AppManagerScript.Instance.selectedStage - 1;
        SetTeacherSkill();
    }

    private int _teacherNo;
    private void SetTeacherSkill()
    {
         _teacherNo = DBManagerScript.Instance.stageDB[_stageNum].teacherNo;
        if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 4)
        {
            _minDelay -= DBManagerScript.Instance.teacherDB[_teacherNo].NN;
        }
        else if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 8)
        {
            GameManager.Instance.player.decibelAmount += GameManager.Instance.player.decibelAmount *
                DBManagerScript.Instance.teacherDB[_teacherNo].NN / 100;
        }
        else if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 12)
        {
            GameManager.Instance.maxDecibel -= DBManagerScript.Instance.teacherDB[_teacherNo].NN;
        }
        else if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 16)
        {
            StartCoroutine(EnglishSkill());
        }
    }

    private IEnumerator EnglishSkill()
    {
        yield return new WaitForSeconds(DBManagerScript.Instance.teacherDB[_teacherNo].NN);
        if (teacherState != TeacherState.Idle)
        {
            StartCoroutine(EnglishSkill());
            yield break;
        }
        GameManager.Instance.inGameSceneUIManager.FindUIObject("ListeningEffect").SetActive(true);
        MasterAudio.PlaySound("Skill_English");
        GameManager.Instance.maxDecibel += 30f;
        isEnglishSkill = true;
        yield return new WaitForSeconds(3f);
        GameManager.Instance.inGameSceneUIManager.FindUIObject("ListeningEffect").SetActive(false);
        GameManager.Instance.player.curDecibelAmount -= 30f;
        GameManager.Instance.maxDecibel -= 30f;
        isEnglishSkill = false;
        StartCoroutine(EnglishSkill());
    }

    private void Update()
    {
        if (teacherState == TeacherState.Look)
        {
            teacherImg.sprite = teacherFront;
        }
        else if(teacherState == TeacherState.End)
        {
            teacherImg.sprite = teacherAngry;
        }
        else
        {
            teacherImg.sprite = teacherBack;
        }
    }

    public void SetTeacherImg(int teacherNo)
    {
        Debug.Log(teacherNo);
        teacherBack = teacherBacks[teacherNo];
        teacherFront = teacherFronts[teacherNo];
        teacherAngry = teacherAngrySprites[teacherNo];
        teacherObj.GetComponent<Animator>().SetInteger("StageNum", AppManagerScript.Instance.selectedStage - 1);
        teacherObj.GetComponent<Animator>().enabled = true;
    }

    private IEnumerator LookCoroutine()
    {
        float turnTime = Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(turnTime);
        if (isEnglishSkill)
        {
            StartCoroutine(LookCoroutine());
            yield break;
        }
        teacherState = TeacherState.BeforeLook;
        if (_teacherNo < 8) MasterAudio.PlaySound("ManTeacher");
        else MasterAudio.PlaySound("WomanTeacher");
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TeacherBubbleTxt").GetComponent<TMPro.TMP_Text>().text =
            "큼큼...";
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(false);
        teacherState = TeacherState.Look;
        teacherObj.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(_watchingTime);
        teacherState = TeacherState.Idle;
        teacherObj.GetComponent<Animator>().enabled = true;
        StartCoroutine(LookCoroutine());
    }

}
