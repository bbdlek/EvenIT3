using System;
using System.Collections;
using System.Collections.Generic;
using Toast.Gamebase;
using UnityEngine;

public class UserManager : Singleton<UserManager>
{
    public string userID;
    public User userData;

    public override void Awake()
    {
        base.Awake();
        RemoveDuplicates();
    }

    private void Start()
    {
        //InitEnergy();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        //EnergyApplicationFocus(hasFocus);
    }

    private void OnApplicationQuit()
    {
        //SaveEnergyInfo();
        //SaveAppQuitTime();
    }

    #region UserData

    public void ClearUserManager()
    {
        userID = null;
        userData = null;
    }

    #endregion


    #region Energy

    public int energy;
    private DateTime _appQuitTime = new DateTime(1970, 1, 1).ToLocalTime();
    private const int MAX_ENERGY = 5;

    public int heartRechargeInterval = 1;
    private Coroutine _rechargeTimerCoroutine = null;
    private int _rechargeRemainTime = 0;

    private void EnergyApplicationFocus(bool value)
    {
        if (value)
        {
            LoadEnergyInfo();
            LoadAppQuitTime();
            SetRechargeScheduler();
        }
        else
        {
            SaveEnergyInfo();
            SaveAppQuitTime();
        }
    }

    public void InitEnergy()
    {
        FBManagerScript.Instance.GetEnergyAmount(userID);
        _rechargeRemainTime = 0;
        _appQuitTime = DateTime.FromBinary(Convert.ToInt64(FBManagerScript.Instance.GetQuitTime(userID)));
    }

    public void LoadEnergyInfo()
    {
        FBManagerScript.Instance.GetEnergyAmount(userID);
    }

    public void SaveEnergyInfo()
    {
        if(!AppManagerScript.Instance.isWithDraw)
            FBManagerScript.Instance.SaveEnergyAmount(userID, energy);
    }

    public void LoadAppQuitTime()
    {
        _appQuitTime = DateTime.FromBinary(Convert.ToInt64(FBManagerScript.Instance.GetQuitTime(userID)));
    }

    public void SaveAppQuitTime()
    {
        if(!AppManagerScript.Instance.isWithDraw)
            FBManagerScript.Instance.SaveQuitTime(userID, DateTime.Now.ToLocalTime().ToBinary().ToString());
    }

    public void SetRechargeScheduler(Action onFinish = null)
    {
        if (_rechargeTimerCoroutine != null)
        {
            StopCoroutine(_rechargeTimerCoroutine);
        }

        var timeDifferenceInSec = (int)(DateTime.Now.ToLocalTime() - _appQuitTime).TotalSeconds;
        var energyToAdd = timeDifferenceInSec / heartRechargeInterval;
        var remainTime = timeDifferenceInSec % heartRechargeInterval;
        energy += energyToAdd;
        if (energy >= MAX_ENERGY)
        {
            energy = MAX_ENERGY;
        }
        else
        {
            _rechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(remainTime, onFinish));
        }
    }

    public void UseEnergy(Action onFinish = null)
    {
        if (energy <= 0)
        {
            return;
        }

        energy--;

        if (_rechargeTimerCoroutine == null)
        {
            _rechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(_rechargeRemainTime, onFinish));
        }

        if (onFinish != null)
        {
            onFinish();
        }
    }

    private IEnumerator DoRechargeTimer(int remainTime, Action onFinish = null)
    {
        if (remainTime <= 0)
        {
            _rechargeRemainTime = heartRechargeInterval;
        }
        else
        {
            _rechargeRemainTime = remainTime;
        }

        while (_rechargeRemainTime > 0)
        {
            _rechargeRemainTime -= 1;
            yield return new WaitForSeconds(1f);
        }

        energy++;
        if (energy >= MAX_ENERGY)
        {
            energy = MAX_ENERGY;
            _rechargeRemainTime = 0;
            _rechargeTimerCoroutine = null;
        }
        else
        {
            _rechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(heartRechargeInterval, onFinish));
        }
    }
    
    #endregion
    
    
    

}
