using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;
using UnityEngine;
using UnityEngine.Networking;


public class DBManagerScript : Singleton<DBManagerScript>
{
    public Snack[] snackDB;
    public Teacher[] teacherDB;
    public Stage[] stageDB;
    public Item[] itemDB;
    public SnackType[] snackTypeDB;

    [SerializeField] private string stageUrl;
    [SerializeField] private string teacherUrl;
    [SerializeField] private string snackUrl;
    [SerializeField] private string itemUrl;
    [SerializeField] private string snackTypeUrl;

    private void Start()
    {
        StartCoroutine(DownloadTest());
    }

    IEnumerator DownloadTest() {
        var uwr_Stage = new UnityWebRequest(stageUrl, UnityWebRequest.kHttpVerbGET);
        string path_Stage = Path.Combine(Application.persistentDataPath, "Stage.json");
        uwr_Stage.downloadHandler = new DownloadHandlerFile(path_Stage);
        yield return uwr_Stage.SendWebRequest();
        if (uwr_Stage.isNetworkError || uwr_Stage.isHttpError)
            Debug.LogError(uwr_Stage.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path_Stage);
            var stageData = File.ReadAllText(Application.persistentDataPath + "/Stage.json");
            //stageDB = JsonConvert.DeserializeObject<Stage[]>(stageData);
            var stageDataBase = JsonUtility.FromJson<StageDB>("{\"stage\":" + stageData + "}");
            stageDB = stageDataBase.stage;
        }
        
        var uwr_Teacher = new UnityWebRequest(teacherUrl, UnityWebRequest.kHttpVerbGET);
        string path_Teacher = Path.Combine(Application.persistentDataPath, "Teacher.json");
        uwr_Teacher.downloadHandler = new DownloadHandlerFile(path_Teacher);
        yield return uwr_Teacher.SendWebRequest();
        if (uwr_Teacher.isNetworkError || uwr_Teacher.isHttpError)
            Debug.LogError(uwr_Teacher.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path_Teacher);
            var teacherData = File.ReadAllText(Application.persistentDataPath + "/Teacher.json");
            //teacherDB = JsonConvert.DeserializeObject<Teacher[]>(teacherData);
            var teacherDataBase = JsonUtility.FromJson<TeacherDB>("{\"teacher\":" + teacherData + "}");
            teacherDB = teacherDataBase.teacher;
        }
        
        var uwr_Snack = new UnityWebRequest(snackUrl, UnityWebRequest.kHttpVerbGET);
        string path_Snack = Path.Combine(Application.persistentDataPath, "Snack.json");
        uwr_Snack.downloadHandler = new DownloadHandlerFile(path_Snack);
        yield return uwr_Snack.SendWebRequest();
        if (uwr_Snack.isNetworkError || uwr_Snack.isHttpError)
            Debug.LogError(uwr_Snack.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path_Snack);
            var snackData = File.ReadAllText(Application.persistentDataPath + "/Snack.json");
            //snackDB = JsonConvert.DeserializeObject<Snack[]>(snackData);
            var snackDataBase = JsonUtility.FromJson<SnackDB>("{\"snack\":" + snackData + "}");
            snackDB = snackDataBase.snack;
        }
        
        var uwr_Item = new UnityWebRequest(itemUrl, UnityWebRequest.kHttpVerbGET);
        string path_Item = Path.Combine(Application.persistentDataPath, "Item.json");
        uwr_Item.downloadHandler = new DownloadHandlerFile(path_Item);
        yield return uwr_Item.SendWebRequest();
        if (uwr_Item.isNetworkError || uwr_Item.isHttpError)
            Debug.LogError(uwr_Item.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path_Item);
            var itemData = File.ReadAllText(Application.persistentDataPath + "/Item.json");
            //itemDB = JsonConvert.DeserializeObject<Item[]>(itemData);
            var itemDataBase = JsonUtility.FromJson<ItemDB>("{\"item\":" + itemData + "}");
            itemDB = itemDataBase.item;
        }
        
        var uwr_SnackType = new UnityWebRequest(snackTypeUrl, UnityWebRequest.kHttpVerbGET);
        string path_SnackType = Path.Combine(Application.persistentDataPath, "SnackType.json");
        uwr_SnackType.downloadHandler = new DownloadHandlerFile(path_SnackType);
        yield return uwr_SnackType.SendWebRequest();
        if (uwr_SnackType.isNetworkError || uwr_SnackType.isHttpError)
            Debug.LogError(uwr_SnackType.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path_SnackType);
            var snackTypeData = File.ReadAllText(Application.persistentDataPath + "/SnackType.json");
            //snackTypeDB = JsonConvert.DeserializeObject<SnackType[]>(snackTypeData);
            var snackTypeDataBase = JsonUtility.FromJson<SnackTypeDB>("{\"snackType\":" + snackTypeData + "}");
            snackTypeDB = snackTypeDataBase.snackType;
        }
        
        GetComponent<LogInManager>().LoginForLastLoggedInProvider();
    }
    

}
