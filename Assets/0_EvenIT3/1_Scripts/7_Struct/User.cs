using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    public Commodities Commodities;
    public int milkItem;
    public int clockItem;
    public int maskItem;
    public string nickName;

    public void NewUser(string nickName)
    {
        this.nickName = nickName;
        Commodities = new Commodities(0, 0);
        milkItem = 10;
        clockItem = 10;
        maskItem = 10;
    }
}
