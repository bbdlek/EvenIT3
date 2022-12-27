using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneUIManager : MonoBehaviour
{
    #region Btns

    public void OnClickGLogInBtn()
    {
        AppManagerScript.Instance.GetComponent<LogInManager>().GoogleLogin();
    }

    public void OnClickGuestLogin()
    {
        AppManagerScript.Instance.GetComponent<LogInManager>().GuestLogin();
    }

    #endregion
}
