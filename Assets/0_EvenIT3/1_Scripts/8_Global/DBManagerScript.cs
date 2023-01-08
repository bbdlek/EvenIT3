using System;
using System.Collections;
using System.Collections.Generic;
using Google.Apis.Services;
using UnityEngine;
using UnityEngine.Networking;

public class DBManagerScript : Singleton<DBManagerScript>
{
    public List<Snack> snackDB;
    public List<Teacher> teacherDB;
    public List<Stage> stageDB;
    public List<Item> itemDB;

    private void GetSnackTypeDB()
    {
        
    }

    private void Start()
    {
        BaseClientService.Initializer initializer = new BaseClientService.Initializer();
        initializer.ApiKey = "AIzaSyBkbHNmywT0HvikSLPZpAD9jMhGsVuxOlY";
    }
    
    IEnumerator ObtainSheetData()
    {
        UnityWebRequest www =
            UnityWebRequest.Get(
                "https://drive.google.com/uc?export=download&id=1u1h-5dEZUSupamAgJ_fJEN3vbqc6RB7sgfkOjaiZGJg");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("ERROR: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text.Replace("[", "");
            json.Replace("]", "");
            Debug.Log(json);
        }
    }

}
