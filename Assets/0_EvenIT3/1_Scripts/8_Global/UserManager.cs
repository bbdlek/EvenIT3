using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : Singleton<UserManager>
{
    public string userID;
    public string nickName;

    public void ClearUserManager()
    {
        userID = null;
        nickName = null;
    }
}
