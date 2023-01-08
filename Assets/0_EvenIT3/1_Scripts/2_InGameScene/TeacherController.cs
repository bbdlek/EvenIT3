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
        Idle, BeforeLook, Look
    }
    
    [SerializeField] private GameObject teacherObj;
    public TeacherState teacherState;
    private float _minDelay = 3;
    private float _maxDelay = 12;
    private float _watchingTime;
    public Sprite teacherBack;
    public Sprite teacherFront;
    private Image _teacherImg; 


    private void Start()
    {
        _teacherImg = teacherObj.GetComponent<Image>();
        teacherState = TeacherState.Idle;
        _minDelay = GameManager.Instance.curStage.teacher.minDelay;
        _maxDelay = GameManager.Instance.curStage.teacher.maxDelay;
        _watchingTime = GameManager.Instance.curStage.teacher.watchingTime;

        StartCoroutine(LookCoroutine());
    }

    private void Update()
    {
        if (teacherState == TeacherState.Look)
        {
            _teacherImg.sprite = teacherFront;
        }
        else
        {
            _teacherImg.sprite = teacherBack;
        }
    }

    private IEnumerator LookCoroutine()
    {
        float turnTime = Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(turnTime);
        teacherState = TeacherState.BeforeLook;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TeacherBubbleTxt").GetComponent<TMPro.TMP_Text>().text =
            "큼큼...";
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(true);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TeacherBubble").SetActive(false);
        teacherState = TeacherState.Look;
        yield return new WaitForSeconds(_watchingTime);
        teacherState = TeacherState.Idle;
    }

}
