using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stage
{
    public int no;
    public string name;
    public Teacher teacher;
    public List<Snack> snackList;
    public int reward_1;
    public int reward_2;
    public int reward_3;
    public float stageTime;
}