using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Teacher
{
    public int no;
    public string name;
    public string name_kr;
    public float watchingTime;
    public float maxDecibel;
    public float minDelay;
    public float maxDelay;
    public string skillName;
    public string skillType;
    public int minCool;
    public int maxCool;
    public float NN;
    public string explain;
    public string art_front;
    public string art_back;
    public string art_angry;
    public string sound_angry;
}

[Serializable]
public class TeacherDB
{
    public Teacher[] teacher;
}