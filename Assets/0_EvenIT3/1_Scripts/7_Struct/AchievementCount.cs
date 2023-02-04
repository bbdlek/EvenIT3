using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementCount
{
    public List<int> ContinuousChapter;
    public int FailTurn;
    public int FailTime;
    public int FailDecibel;
    public int ItemFreeUsage;
    public int ItemPaidUsage;
    public int EatingCount;
    public int BujeokNBum;
    public int NormalGachaCount;
    public int EpicGachaCount;

    public AchievementCount()
    {
        ContinuousChapter = new List<int>(6);
        FailTurn = 0;
        FailTime = 0;
        FailDecibel = 0;
        ItemFreeUsage = 0;
        ItemPaidUsage = 0;
        EatingCount = 0;
        BujeokNBum = 0;
        NormalGachaCount = 0;
        EpicGachaCount = 0;
    }
}
