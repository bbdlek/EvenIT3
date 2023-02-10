using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FailedPanelController : MonoBehaviour
{
    [SerializeField] private int type; // 0: LookPanel, 1: DecibelPanel, 2:OverPanel
    [SerializeField] private TMP_Text timerTxt;
    
    [SerializeField] private int panelTimer = 10;

    private Coroutine _timerCoroutine;
    
    private void OnEnable()
    {
        panelTimer = 10;
        _timerCoroutine = StartCoroutine(Timer());
    }

    private void OnDisable()
    {
        StopCoroutine(_timerCoroutine);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1f);
        if(!GameManager.Instance.isMiniTutorialOn)
            panelTimer -= 1;
        timerTxt.text = panelTimer.ToString();
        if (panelTimer == 0)
        {
            switch (type)
            {
                case 0:
                    GameManager.Instance.inGameSceneUIManager.OnClickFailedLookPanelRefuseBtn();
                    break;
                case 1:
                    GameManager.Instance.inGameSceneUIManager.OnClickFailedDecibelPanelRefuseBtn();
                    break;
                case 2:
                    GameManager.Instance.inGameSceneUIManager.OnClickFailedOverPanelRefuseBtn();
                    break;
            }
        }
        else
        {
            _timerCoroutine = StartCoroutine(Timer());
        }
    }
}
