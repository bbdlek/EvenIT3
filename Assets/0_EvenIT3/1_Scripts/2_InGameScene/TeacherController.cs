using System;
using System.Collections;
using System.Collections.Generic;
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
    
    [SerializeField] private GameObject teacherObj;
    public TeacherState teacherState;
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


    private int _stageNum;

    public void SetUpTeacher()
    {
        teacherImg = teacherObj.GetComponent<Image>();
        teacherState = TeacherState.Idle;
        _minDelay = DBManagerScript.Instance.teacherDB[GameManager.Instance.curStage.teacherNo - 1].minDelay;
        _maxDelay = DBManagerScript.Instance.teacherDB[GameManager.Instance.curStage.teacherNo - 1].maxDelay;
        _watchingTime = DBManagerScript.Instance.teacherDB[GameManager.Instance.curStage.teacherNo - 1].watchingTime;

        StartCoroutine(LookCoroutine());
        _stageNum = (AppManagerScript.Instance.selectedChapter - 1) * 4 + AppManagerScript.Instance.selectedStage - 1;
        SetTeacherSkill();
    }

    private int _teacherNo;
    private void SetTeacherSkill()
    {
         _teacherNo = DBManagerScript.Instance.stageDB[_stageNum].teacherNo;
        if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 5)
        {
            _minDelay -= DBManagerScript.Instance.teacherDB[_teacherNo - 1].NN;
        }
        else if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 9)
        {
            GameManager.Instance.player.decibelAmount += GameManager.Instance.player.decibelAmount * DBManagerScript.Instance.teacherDB[_teacherNo - 1].NN;
        }
        else if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 13)
        {
            GameManager.Instance.maxDecibel -= DBManagerScript.Instance.teacherDB[_teacherNo - 1].NN;
        }
        else if (DBManagerScript.Instance.stageDB[_stageNum].teacherNo < 17)
        {
            StartCoroutine(EnglishSkill());
        }
    }

    private IEnumerator EnglishSkill()
    {
        yield return new WaitForSeconds(DBManagerScript.Instance.teacherDB[_teacherNo - 1].NN);
        GameManager.Instance.inGameSceneUIManager.FindUIObject("ListeningEffect").SetActive(true);
        GameManager.Instance.maxDecibel += 30f;
        yield return new WaitForSeconds(3f);
        GameManager.Instance.inGameSceneUIManager.FindUIObject("ListeningEffect").SetActive(false);
        GameManager.Instance.maxDecibel -= 30f;
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
        teacherBack = teacherBacks[teacherNo];
        teacherFront = teacherFronts[teacherNo];
        teacherAngry = teacherAngrySprites[teacherNo];
    }

    private IEnumerator LookCoroutine()
    {
        float turnTime = Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(turnTime);
        teacherState = TeacherState.BeforeLook;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TeacherBubbleTxt").GetComponent<TMPro.TMP_Text>().text =
            "큼큼...";
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(false);
        teacherState = TeacherState.Look;
        yield return new WaitForSeconds(_watchingTime);
        teacherState = TeacherState.Idle;
        StartCoroutine(LookCoroutine());
    }

}
