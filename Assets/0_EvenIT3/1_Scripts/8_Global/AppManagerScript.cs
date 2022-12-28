using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AppManagerScript : Singleton<AppManagerScript>
{
    private GamabaseManager _gamabaseManager;
    private DBManagerScript _dbManager;
    
    public override void Awake()
    {
        RemoveDuplicates();
        _dbManager = GetComponent<DBManagerScript>();
        _gamabaseManager = GetComponent<GamabaseManager>();
    }

    private void Start()
    {
        _dbManager.InitFirebase();
        _gamabaseManager.Initialize();
    }
}
