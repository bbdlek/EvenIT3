using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Singleton<Player>
{
    public enum State
    {
        Idle, Eating
    }

    [SerializeField] private GameObject playerObj;

    public State playerState;

    public float desDecibelAmount = 20;
    public float eatingSpeed;
    public float decibelAmount;
    public float curDecibelAmount;
    public float curQuantity;
    public bool isMilk = false;

    private void Start()
    {
        playerState = State.Idle;
        playerObj = GameManager.Instance.inGameSceneUIManager.FindUIObject("Player");
        curDecibelAmount = 0;
    }

    private void Update()
    {
        Eating();
    }

    public void SetBasePlayerStat()
    {
        decibelAmount = DBManagerScript.Instance.snackTypeDB[GameManager.Instance.selectedSnack.type].decibel;
        float decibelBuff = 0;
        if (AppManagerScript.Instance.buff[1]) decibelBuff += DBManagerScript.Instance.buffDB[1].NN;
        if (AppManagerScript.Instance.buff[3]) decibelBuff += DBManagerScript.Instance.buffDB[3].NN;
        decibelAmount -= desDecibelAmount * decibelBuff / 100;
        GameManager.Instance.quantity  = DBManagerScript.Instance.snackTypeDB[GameManager.Instance.selectedSnack.type].quantity;
        if (AppManagerScript.Instance.buff[0]) GameManager.Instance.quantity -= GameManager.Instance.quantity * DBManagerScript.Instance.buffDB[0].NN / 100;
        eatingSpeed = DBManagerScript.Instance.snackTypeDB[GameManager.Instance.selectedSnack.type].eatingSpeed;
        if (AppManagerScript.Instance.buff[4]) eatingSpeed += DBManagerScript.Instance.buffDB[4].NN;
        
        curQuantity = 0;
    }
    

    private void Eating()
    {
        if (playerState == State.Eating)
        {
            if (GameManager.Instance.selectedSnack.type is 1 or 5 or 9 or 13)
            {
                MasterAudio.PlaySound("Eating_Candy");
            }
            else
            {
                MasterAudio.PlaySound("Eating_Cookie");
            }
            playerObj.GetComponent<Animator>().SetBool("isEating", true);
            if(isMilk)
            {
                playerObj.transform.GetChild(1).gameObject.SetActive(false);
                playerObj.transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                playerObj.transform.GetChild(1).gameObject.SetActive(true);
                playerObj.transform.GetChild(2).gameObject.SetActive(false);
            }
            curDecibelAmount += Time.deltaTime * decibelAmount;
            curQuantity += Time.deltaTime * GameManager.Instance.quantity * eatingSpeed / 100;
        }
        else if(playerState == State.Idle)
        {
            MasterAudio.StopBus("Eating");
            playerObj.GetComponent<Animator>().SetBool("isEating", false);
            playerObj.transform.GetChild(1).gameObject.SetActive(false);
            playerObj.transform.GetChild(2).gameObject.SetActive(false);
            curDecibelAmount -= Time.deltaTime * desDecibelAmount;
        }

        if (curDecibelAmount < 0) curDecibelAmount = 0;
    }

    [SerializeField] private Sprite timerNormal;
    [SerializeField] private Sprite timerIce;

    public IEnumerator Buff_Ice()
    {
        MasterAudio.PlaySound("Item_Clock");
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item1Btn").GetComponent<UnityEngine.UI.Button>().interactable = false;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item1BtnActive").SetActive(true);
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TimerGauge").GetComponent<UnityEngine.UI.Image>().sprite = timerIce;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TimerGaugeFill").GetComponent<UnityEngine.UI.Image>().sprite = timerIce;
        GameManager.Instance._isTimer = false;
        yield return new WaitForSeconds(DBManagerScript.Instance.itemDB[0].NN);
        GameManager.Instance._isTimer = true;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TimerGaugeFill").GetComponent<UnityEngine.UI.Image>().sprite = timerNormal;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("TimerGauge").GetComponent<UnityEngine.UI.Image>().sprite = timerNormal;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item1BtnActive").SetActive(false);
        //GameManager.Instance.inGameSceneUIManager.FindUIObject("Item1Btn").GetComponent<UnityEngine.UI.Button>().interactable = true;
    }

    public IEnumerator Buff_Milk()
    {
        MasterAudio.PlaySound("Item_Milk");
        isMilk = true;
        float prevEatingSpeed = eatingSpeed;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item2Btn").GetComponent<UnityEngine.UI.Button>().interactable = false;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item2BtnActive").SetActive(true);
        eatingSpeed += eatingSpeed * DBManagerScript.Instance.itemDB[2].NN / 100;
        yield return new WaitForSeconds(3f);
        eatingSpeed = prevEatingSpeed;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item2BtnActive").SetActive(false);
        isMilk = false;
        //GameManager.Instance.inGameSceneUIManager.FindUIObject("Item2Btn").GetComponent<UnityEngine.UI.Button>().interactable = true;
    }

    public IEnumerator Buff_Mask()
    {
        MasterAudio.PlaySound("Item_Mask");
        GameManager.Instance.inGameSceneUIManager.FindUIObject("DecibelMask").SetActive(true);
        float prevDecibelAmount = decibelAmount;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item3Btn").GetComponent<UnityEngine.UI.Button>().interactable = false;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item3BtnActive").SetActive(true);
        decibelAmount -= decibelAmount * DBManagerScript.Instance.itemDB[1].NN / 100;
        yield return new WaitForSeconds(3f);
        decibelAmount = prevDecibelAmount;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item3BtnActive").SetActive(false);
        GameManager.Instance.inGameSceneUIManager.FindUIObject("DecibelMask").SetActive(false);
        //GameManager.Instance.inGameSceneUIManager.FindUIObject("Item3Btn").GetComponent<UnityEngine.UI.Button>().interactable = true;
    }
    
    
}
