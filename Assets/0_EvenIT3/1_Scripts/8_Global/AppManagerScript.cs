using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AppManagerScript : Singleton<AppManagerScript>
{
    private GamabaseManager _gamabaseManager;
    
    public override void Awake()
    {
        RemoveDuplicates();
        _gamabaseManager = GetComponent<GamabaseManager>();
    }

    private void Start()
    {
        _gamabaseManager.Initialize();
    }
}
