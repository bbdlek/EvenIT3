using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;

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
        if (AppManagerScript.Instance.buff[1]) decibelAmount -= desDecibelAmount * 0.07f;
        GameManager.Instance.quantity  = DBManagerScript.Instance.snackTypeDB[GameManager.Instance.selectedSnack.type].quantity;
        if (AppManagerScript.Instance.buff[0]) GameManager.Instance.quantity -= GameManager.Instance.quantity * 0.05f;
        eatingSpeed = DBManagerScript.Instance.snackTypeDB[GameManager.Instance.selectedSnack.type].eatingSpeed;
        curQuantity = 0;
    }

    private void Eating()
    {
        if (playerState == State.Eating)
        {
            switch (GameManager.Instance.selectedSnack.type)
            {
                case 0:
                    StartCoroutine(MasterAudio.PlaySoundAndWaitUntilFinished("Eating_Bread"));
                    break;
                case 1:
                    StartCoroutine(MasterAudio.PlaySoundAndWaitUntilFinished("Eating_Candy"));
                    break;
                case 2:
                    StartCoroutine(MasterAudio.PlaySoundAndWaitUntilFinished("Eating_Snack"));
                    break;
                case 3:
                    StartCoroutine(MasterAudio.PlaySoundAndWaitUntilFinished("Eating_Cookie"));
                    break;
                
            }
            playerObj.GetComponent<Animator>().SetBool("isEating", true);
            playerObj.transform.GetChild(1).gameObject.SetActive(true);
            curDecibelAmount += Time.deltaTime * decibelAmount;
            curQuantity += Time.deltaTime * GameManager.Instance.quantity * eatingSpeed / 100;
        }
        else if(playerState == State.Idle)
        {
            playerObj.GetComponent<Animator>().SetBool("isEating", false);
            playerObj.transform.GetChild(1).gameObject.SetActive(false);
            curDecibelAmount -= Time.deltaTime * desDecibelAmount;
        }

        if (curDecibelAmount < 0) curDecibelAmount = 0;
    }

    public IEnumerator Buff_Ice()
    {
        MasterAudio.PlaySound("Item_Clock");
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item1Btn").GetComponent<UnityEngine.UI.Button>().interactable = false;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item1BtnActive").SetActive(true);
        GameManager.Instance._isTimer = false;
        yield return new WaitForSeconds(DBManagerScript.Instance.itemDB[0].NN);
        GameManager.Instance._isTimer = true;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item1BtnActive").SetActive(false);
        //GameManager.Instance.inGameSceneUIManager.FindUIObject("Item1Btn").GetComponent<UnityEngine.UI.Button>().interactable = true;
    }

    public IEnumerator Buff_Milk()
    {
        MasterAudio.PlaySound("Item_Milk");
        float prevEatingSpeed = eatingSpeed;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item2Btn").GetComponent<UnityEngine.UI.Button>().interactable = false;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item2BtnActive").SetActive(true);
        eatingSpeed += eatingSpeed * DBManagerScript.Instance.itemDB[2].NN / 100;
        yield return new WaitForSeconds(3f);
        eatingSpeed = prevEatingSpeed;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item2BtnActive").SetActive(false);
        //GameManager.Instance.inGameSceneUIManager.FindUIObject("Item2Btn").GetComponent<UnityEngine.UI.Button>().interactable = true;
    }

    public IEnumerator Buff_Mask()
    {
        MasterAudio.PlaySound("Item_Mask");
        float prevDecibelAmount = decibelAmount;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item3Btn").GetComponent<UnityEngine.UI.Button>().interactable = false;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item3BtnActive").SetActive(true);
        decibelAmount -= decibelAmount * DBManagerScript.Instance.itemDB[1].NN / 100;
        yield return new WaitForSeconds(3f);
        decibelAmount = prevDecibelAmount;
        GameManager.Instance.inGameSceneUIManager.FindUIObject("Item3BtnActive").SetActive(false);
        //GameManager.Instance.inGameSceneUIManager.FindUIObject("Item3Btn").GetComponent<UnityEngine.UI.Button>().interactable = true;
    }
    
    
}
