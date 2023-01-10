using System;
using System.Collections;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

using Data = Google.Apis.Sheets.v4.Data;

public class DBManagerScript : Singleton<DBManagerScript>
{
    public List<Snack> snackDB;
    public List<Teacher> teacherDB;
    public List<Stage> stageDB;
    public List<Item> itemDB;

    private void GetSnackTypeDB()
    {
        
    }

    private SheetsService sheetsService;

    private void Start()
    {
        sheetsService = new SheetsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = GetCredential(),
            ApplicationName = "SheetTest",
        });

        string spreadsheetId = "1u1h-5dEZUSupamAgJ_fJEN3vbqc6RB7sgfkOjaiZGJg";
        
        List<Data.Request> requests = new List<Data.Request>();
        Data.BatchUpdateSpreadsheetRequest requestBody = new Data.BatchUpdateSpreadsheetRequest();
        requestBody.Requests = requests;

        SpreadsheetsResource.BatchUpdateRequest request =
            sheetsService.Spreadsheets.BatchUpdate(requestBody, spreadsheetId);

        Data.BatchUpdateSpreadsheetResponse response = request.Execute();
        
        Debug.Log(JsonConvert.SerializeObject(response));
        //StartCoroutine(ObtainSheetData());
    }

    IEnumerator ObtainSheetData()
    {
        UnityWebRequest www =
            UnityWebRequest.Get(
                "https://sheets.googleapis.com/v4/spreadsheets/1u1h-5dEZUSupamAgJ_fJEN3vbqc6RB7sgfkOjaiZGJg/values/SheetTest?key=AIzaSyBkbHNmywT0HvikSLPZpAD9jMhGsVuxOlY");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("ERROR: " + www.error);
        }
        else
        {
            string json = JsonConvert.SerializeObject(www.downloadHandler.text);
            json.Replace("]", "");
            Debug.Log(json);
        }
    }

    public static UserCredential GetCredential()
    {
        return null;
    }

}
