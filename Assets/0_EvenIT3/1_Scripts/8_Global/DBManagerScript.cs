using System;
using System.Collections;
using System.Collections.Generic;
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
        
    }
    
    IEnumerator ObtainSheetData()
    {
        UnityWebRequest www =
            UnityWebRequest.Get(
                "https://opensheet.elk.sh/1FRIyCWP4AwuW2Sv7gSotXzDETzmF8vrdexVR93YsfgQ/snack");
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
