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
    public int profileImageIndex;
    public int profileEdgeIndex;

    public List<int> starList;
    public List<int> snackList;

    public void NewUser(string nickName)
    {
        this.nickName = nickName;
        Commodities = new Commodities(33333, 33333);
        milkItem = 333;
        clockItem = 333;
        maskItem = 333;
        starList = new List<int>();
        snackList = new List<int>(DBManagerScript.Instance.snackDB.Length);

        profileImageIndex = 0;
        profileEdgeIndex = 0;
    }
}
