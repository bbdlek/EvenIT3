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
    public int shieldItem;
    public int brokenClockItem;
    public int normalTicket;
    public int epicTicket;
    public string nickName;
    public int profileImageIndex;
    public int profileEdgeIndex;

    public List<int> starList;
    public List<int> snackList;
    public List<bool> achievementList;
    public List<int> achievementCount;

    public int energy;
    public string lastDate;

    public void NewUser(string nickName)
    {
        this.nickName = nickName;
        Commodities = new Commodities(0, 10000);
        milkItem = 10;
        clockItem = 10;
        maskItem = 10;
        shieldItem = 5;
        brokenClockItem = 5;
        normalTicket = 0;
        epicTicket = 0;
        starList = new List<int>();
        snackList = new List<int>(DBManagerScript.Instance.snackDB.Length);
        achievementList = new List<bool>(DBManagerScript.Instance.achievementDB.Length);
        achievementCount = new List<int>(DBManagerScript.Instance.achievementDB.Length);

        energy = 5;
        lastDate = DateTime.Now.ToLocalTime().ToBinary().ToString();

        profileImageIndex = 0;
        profileEdgeIndex = 0;
    }
}
