using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Achievements
{
    public int no;
    public string name;
    public int type;
    public float NN;
    public string reward;
    public int rewardN;
}

public class AchievementsDB
{
    public Achievements[] achievements;
}

[Serializable]
public class AchievementsType
{
    public int no;
    public string type;
    public string explain;
}

public class AchievementsTypeDB
{
    public AchievementsType[] achievementTypes;
}
