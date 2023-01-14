using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Snack
{
    public int no;
    public string name;
    public string name_kr;
    public int type;
    public int P2A;
    public string icon;
    public string explain;
}

[Serializable]
public class SnackDB
{
    public Snack[] snack;
}
