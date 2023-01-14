using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SnackType
{
    public int no;
    public string type;
    public float decibel;
    public float quantity;
    public int eatingSpeed;
}

[Serializable]
public class SnackTypeDB
{
    public SnackType[] snackType;
}
