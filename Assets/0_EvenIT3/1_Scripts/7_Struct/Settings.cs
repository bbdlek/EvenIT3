using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Settings
{
    public Settings(float _bgVolume, float _effectVolume, bool _isVibration)
    {
        BgmVolume = _bgVolume;
        EffectVolume = _effectVolume;
        IsVibration = _isVibration;
    }
    
    //배경음악
    public float BgmVolume;
    //효과음
    public float EffectVolume;
    //진동효과
    public bool IsVibration;
}