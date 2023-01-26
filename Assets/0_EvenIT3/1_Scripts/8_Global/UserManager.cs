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

    #region UserData

    public void ClearUserManager()
    {
        userID = null;
        userData = null;
    }

    #endregion

    #region Energy
    
    

    #endregion

}
