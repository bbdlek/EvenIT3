using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    public string nickName;
    
    public Commodities Commodities;
    
    public void NewUser(string nickName)
    {
        this.nickName = nickName;
        Commodities = new Commodities(0, 0);
    }
}
