using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stage
{
    public int no;
    public string name;
    public int teacherNo;
    public int snack1;
    public int snack2;
    public int snack3;
    public int reward_1;
    public int reward_2;
    public int reward_3;
    public float stageTime;
}

[Serializable]
public class StageDB
{
    public Stage[] stage;
}