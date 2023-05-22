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
        Init();
    }

    #region UserData

    public void ClearUserManager()
    {
        userID = null;
        userData = null;
    }

    #endregion

    #region Energy
    
    //public int userData.energy = 5; //보유 하트 개수
    public DateTime m_AppQuitTime = new DateTime(1970, 1, 1).ToLocalTime();
    private const int MAX_HEART = int.MaxValue; //하트 최대값
    public int HeartRechargeInterval = 1800;// 하트 충전 간격(단위:초)
    private Coroutine m_RechargeTimerCoroutine = null;
    public int m_RechargeRemainTime = 0;

    //게임 초기화, 중간 이탈, 중간 복귀 시 실행되는 함수
    public void OnApplicationFocus(bool value)
    {
        Debug.Log("OnApplicationFocus() : " + value);
        if (value)
        {
            LoadHeartInfo();
            LoadAppQuitTime();
            SetRechargeScheduler();
        }
        else
        {
            SaveHeartInfo();
            SaveAppQuitTime();
            FBManagerScript.Instance.UpdateCurrentUser();
        }
    }
    //게임 종료 시 실행되는 함수
    public void OnApplicationQuit()
    {
        Debug.Log("GoodsRechargeTester: OnApplicationQuit()");
        SaveHeartInfo();
        SaveAppQuitTime();
        FBManagerScript.Instance.UpdateCurrentUser();
    }
    //버튼 이벤트에 이 함수를 연동한다.
    public void OnClickUseHeart()
    {
        Debug.Log("OnClickUseHeart");
        UseHeart();
    }
    
    public void Init()
    {
        //m_RechargeRemainTime = 0;
        m_AppQuitTime = new DateTime(1970, 1, 1).ToLocalTime();
        Debug.Log("heartRechargeTimer : " + m_RechargeRemainTime + "s");
        //heartRechargeTimer.text = string.Format("Timer : {0} s", m_RechargeRemainTime);
    }

    public void LoadFromDB()
    {
        Debug.Log(userData.lastDate);
        Debug.Log(m_AppQuitTime);
        m_AppQuitTime = DateTime.FromBinary(Convert.ToInt64(userData.lastDate));
        SetRechargeScheduler();
    }
    
    public bool LoadHeartInfo()
    {
        Debug.Log("LoadHeartInfo");
        bool result = false;
        try
        {
            if (PlayerPrefs.HasKey("HeartAmount"))
            {
                userData.energy = PlayerPrefs.GetInt("HeartAmount");
                if (userData.energy < 0)
                {
                    userData.energy = 0;
                }
            }
            else
            {
                userData.energy = 5;
            }
            //heartAmountLabel.text = userData.energy.ToString();
            result = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("LoadHeartInfo Failed (" + e.Message + ")");
        }
        return result;
    }
    public bool SaveHeartInfo()
    {
        Debug.Log("SaveHeartInfo");
        bool result = false;
        try
        {
            PlayerPrefs.SetInt("HeartAmount", userData.energy);
            PlayerPrefs.Save();
            userData.energy = userData.energy;
            result = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("SaveHeartInfo Failed (" + e.Message + ")");
        }
        return result;
    }
    public bool LoadAppQuitTime()
    {
        Debug.Log("LoadAppQuitTime");
        bool result = false;
        try
        {
            if (PlayerPrefs.HasKey("AppQuitTime"))
            {
                var appQuitTime = string.Empty;
                appQuitTime = PlayerPrefs.GetString("AppQuitTime");
                m_AppQuitTime = DateTime.FromBinary(Convert.ToInt64(appQuitTime));
            }
            //appQuitTimeLabel.text = string.Format("AppQuitTime : {0}", m_AppQuitTime.ToString());
            result = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("LoadAppQuitTime Failed (" + e.Message + ")");
        }
        return result;
    }
    public bool SaveAppQuitTime()
    {
        Debug.Log("SaveAppQuitTime");
        bool result = false;
        try
        {
            var appQuitTime = DateTime.Now.ToLocalTime().ToBinary().ToString();
            PlayerPrefs.SetString("AppQuitTime", appQuitTime);
            PlayerPrefs.Save();
            userData.lastDate = appQuitTime;
            //FBManagerScript.Instance.UpdateCurrentUser();
            result = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("SaveAppQuitTime Failed (" + e.Message + ")");
        }
        return result;
    }
    public void SetRechargeScheduler(Action onFinish = null)
    {
        if (m_RechargeTimerCoroutine != null)
        {
            StopCoroutine(m_RechargeTimerCoroutine);
        }
        var timeDifferenceInSec = (int)((DateTime.Now.ToLocalTime() - m_AppQuitTime).TotalSeconds);
        Debug.Log(timeDifferenceInSec);
        var heartToAdd = timeDifferenceInSec / HeartRechargeInterval;
        Debug.Log(m_RechargeRemainTime);
        Debug.Log(timeDifferenceInSec % HeartRechargeInterval);
        var remainTime = m_RechargeRemainTime - timeDifferenceInSec % HeartRechargeInterval;
        Debug.Log(heartToAdd);
        if (userData.energy < 5)
        {
            int tempHeart = userData.energy + heartToAdd;
            if (tempHeart > 5) tempHeart = 5;
            userData.energy = tempHeart;
        }
        m_RechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(remainTime, onFinish));
        //heartAmountLabel.text = string.Format("Hearts : {0}", userData.energy.ToString());
    }
    public void UseHeart(Action onFinish = null)
    {
        if (userData.energy <= 0)
        {
            return;
        }
        
        if(userData.energy == 5)
        {
            if (m_RechargeTimerCoroutine != null)
            {
                StopCoroutine(m_RechargeTimerCoroutine);
            }
        }
        
        userData.energy--;
        //heartAmountLabel.text = string.Format("Hearts : {0}", userData.energy.ToString());
        if (m_RechargeTimerCoroutine == null)
        {
            m_RechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(HeartRechargeInterval));
        }
        if (onFinish != null)
        {
            onFinish();
        }
    }

    public void AddHeartByAD()
    {
        userData.energy++;
        SetRechargeScheduler();
    }
    private IEnumerator DoRechargeTimer(int remainTime, Action onFinish = null)
    {
        if (userData.energy < 5)
        {
            if (remainTime <= 0)
            {
                m_RechargeRemainTime = HeartRechargeInterval;
            }
            else
            {
                m_RechargeRemainTime = remainTime;
            }
            //heartRechargeTimer.text = string.Format("Timer : {0} s", m_RechargeRemainTime);

            while (m_RechargeRemainTime > 0)
            {
                //heartRechargeTimer.text = string.Format("Timer : {0} s", m_RechargeRemainTime);
                m_RechargeRemainTime -= 1;
                yield return new WaitForSeconds(1f);
            }

            userData.energy++;
        }
        if (userData.energy >= 5)
        {
            m_RechargeRemainTime = 0;
            //heartRechargeTimer.text = string.Format("Timer : {0} s", m_RechargeRemainTime);
            m_RechargeTimerCoroutine = null;
        }
        else
        {
            m_RechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(HeartRechargeInterval, onFinish));
        }
        //heartAmountLabel.text = string.Format("Hearts : {0}", userData.energy.ToString());
    }

    #endregion

}
