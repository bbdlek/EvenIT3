using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

[Serializable]
public class Commodities
{
    public int Gold;
    public int Silver;

    public Commodities(int gold, int silver)
    {
        Gold = gold;
        Silver = silver;
    }

    public Dictionary<string, Object> ToDictionary()
    {
        Dictionary<string, Object> result = new Dictionary<string, object>();
        result["Gold"] = Gold;
        result["Silver"] = Silver;

        return result;
    }
}
