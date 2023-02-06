using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LeaderboardUserInfo
{
    public int resultCode;
    public string userId;
    public double score;
    public int rank;
    public int preRank;
    public string extra;
    public string date;
    public int totalUserCountInFactor;

    public LeaderboardUserInfo()
    {
        resultCode = 0;
        userId = "None";
        score = 0;
        rank = 0;
        preRank = 0;
        extra = string.Empty;
        date = string.Empty;
        totalUserCountInFactor = 0;
    }
}

[Serializable]
public class LeaderboardUserInfoDB
{
    public LeaderboardUserInfo[] userInfo;
}
