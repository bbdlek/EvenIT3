using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SnackType
{
    Bread, Cookie, Snack, Candy 
}

[Serializable]
public class Snack
{
    public string no;
    public string name;
    public string name_kr;
    public SnackType type;
    public string P2A;
    public int iconNo;
    public string explain;
    public string amulet_icon;
}
