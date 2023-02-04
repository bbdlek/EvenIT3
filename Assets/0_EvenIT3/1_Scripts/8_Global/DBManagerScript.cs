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
    public bool isDBReady;
    public Snack[] snackDB;
    public Teacher[] teacherDB;
    public Stage[] stageDB;
    public Item[] itemDB;
    public SnackType[] snackTypeDB;
    public Buff[] buffDB;
    public Achievements[] achievementDB;
    public AchievementsType[] achievementTypeDB;

    [SerializeField] private string stageUrl;
    [SerializeField] private string teacherUrl;
    [SerializeField] private string snackUrl;
    [SerializeField] private string itemUrl;
    [SerializeField] private string snackTypeUrl;
    [SerializeField] private string buffUrl;
    [SerializeField] private string achievementUrl;
    [SerializeField] private string achievementTypeUrl;

    private void Start()
    {
        isDBReady = false;
        downloadCor = StartCoroutine(DownloadTest());
    }

    private Coroutine downloadCor;

    IEnumerator DownloadTest() {
        var uwr_Stage = new UnityWebRequest(stageUrl, UnityWebRequest.kHttpVerbGET);
        string path_Stage = Path.Combine(Application.persistentDataPath, "Stage.json");
        uwr_Stage.downloadHandler = new DownloadHandlerFile(path_Stage);
        yield return uwr_Stage.SendWebRequest();
        if (uwr_Stage.isNetworkError || uwr_Stage.isHttpError)
        {
            Debug.LogError(uwr_Stage.error);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo").SetActive(false);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo_Error").SetActive(true);
            StopCoroutine(downloadCor);
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
        else if(uwr_Stage.isDone)
        {
            Debug.Log("File successfully downloaded and saved to " + path_Stage);
            var stageData = File.ReadAllText(Application.persistentDataPath + "/Stage.json");
            //stageDB = JsonConvert.DeserializeObject<Stage[]>(stageData);
            //var stageDataBase = JsonUtility.FromJson<StageDB>("{\"stage\":" + stageData + "}");
            var stageDataBase = JsonConvert.DeserializeObject<StageDB>("{\"stage\":" + stageData + "}");
            stageDB = stageDataBase.stage;
        }
        
        var uwr_Teacher = new UnityWebRequest(teacherUrl, UnityWebRequest.kHttpVerbGET);
        string path_Teacher = Path.Combine(Application.persistentDataPath, "Teacher.json");
        uwr_Teacher.downloadHandler = new DownloadHandlerFile(path_Teacher);
        yield return uwr_Teacher.SendWebRequest();
        if (uwr_Teacher.isNetworkError || uwr_Teacher.isHttpError)
        {
            Debug.LogError(uwr_Teacher.error);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo").SetActive(false);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo_Error").SetActive(true);
            StopCoroutine(downloadCor);
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
        else if(uwr_Stage.isDone)
        {
            Debug.Log("File successfully downloaded and saved to " + path_Teacher);
            var teacherData = File.ReadAllText(Application.persistentDataPath + "/Teacher.json");
            //teacherDB = JsonConvert.DeserializeObject<Teacher[]>(teacherData);
            //var teacherDataBase = JsonUtility.FromJson<TeacherDB>("{\"teacher\":" + teacherData + "}");
            var teacherDataBase = JsonConvert.DeserializeObject<TeacherDB>("{\"teacher\":" + teacherData + "}");
            teacherDB = teacherDataBase.teacher;
        }
        
        var uwr_Snack = new UnityWebRequest(snackUrl, UnityWebRequest.kHttpVerbGET);
        string path_Snack = Path.Combine(Application.persistentDataPath, "Snack.json");
        uwr_Snack.downloadHandler = new DownloadHandlerFile(path_Snack);
        yield return uwr_Snack.SendWebRequest();
        if (uwr_Snack.isNetworkError || uwr_Snack.isHttpError)
        {
            Debug.LogError(uwr_Snack.error);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo").SetActive(false);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo_Error").SetActive(true);
            StopCoroutine(downloadCor);
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
        else if(uwr_Stage.isDone)
        {
            Debug.Log("File successfully downloaded and saved to " + path_Snack);
            var snackData = File.ReadAllText(Application.persistentDataPath + "/Snack.json");
            //snackDB = JsonConvert.DeserializeObject<Snack[]>(snackData);
            //var snackDataBase = JsonUtility.FromJson<SnackDB>("{\"snack\":" + snackData + "}");
            var snackDataBase = JsonConvert.DeserializeObject<SnackDB>("{\"snack\":" + snackData + "}");
            snackDB = snackDataBase.snack;
        }
        
        var uwr_Item = new UnityWebRequest(itemUrl, UnityWebRequest.kHttpVerbGET);
        string path_Item = Path.Combine(Application.persistentDataPath, "Item.json");
        uwr_Item.downloadHandler = new DownloadHandlerFile(path_Item);
        yield return uwr_Item.SendWebRequest();
        if (uwr_Item.isNetworkError || uwr_Item.isHttpError)
        {
            Debug.LogError(uwr_Item.error);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo").SetActive(false);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo_Error").SetActive(true);
            StopCoroutine(downloadCor);
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
        else if(uwr_Stage.isDone)
        {
            Debug.Log("File successfully downloaded and saved to " + path_Item);
            var itemData = File.ReadAllText(Application.persistentDataPath + "/Item.json");
            //itemDB = JsonConvert.DeserializeObject<Item[]>(itemData);
            //var itemDataBase = JsonUtility.FromJson<ItemDB>("{\"item\":" + itemData + "}");
            var itemDataBase = JsonConvert.DeserializeObject<ItemDB>("{\"item\":" + itemData + "}");
            itemDB = itemDataBase.item;
        }
        
        var uwr_SnackType = new UnityWebRequest(snackTypeUrl, UnityWebRequest.kHttpVerbGET);
        string path_SnackType = Path.Combine(Application.persistentDataPath, "SnackType.json");
        uwr_SnackType.downloadHandler = new DownloadHandlerFile(path_SnackType);
        yield return uwr_SnackType.SendWebRequest();
        if (uwr_SnackType.isNetworkError || uwr_SnackType.isHttpError)
        {
            Debug.LogError(uwr_SnackType.error);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo").SetActive(false);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo_Error").SetActive(true);
            StopCoroutine(downloadCor);
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
        else if(uwr_Stage.isDone)
        {
            Debug.Log("File successfully downloaded and saved to " + path_SnackType);
            var snackTypeData = File.ReadAllText(Application.persistentDataPath + "/SnackType.json");
            //snackTypeDB = JsonConvert.DeserializeObject<SnackType[]>(snackTypeData);
            //var snackTypeDataBase = JsonUtility.FromJson<SnackTypeDB>("{\"snackType\":" + snackTypeData + "}");
            var snackTypeDataBase = JsonConvert.DeserializeObject<SnackTypeDB>("{\"snackType\":" + snackTypeData + "}");
            snackTypeDB = snackTypeDataBase.snackType;
        }
        
        var uwr_Buff = new UnityWebRequest(buffUrl, UnityWebRequest.kHttpVerbGET);
        string path_Buff = Path.Combine(Application.persistentDataPath, "Buff.json");
        uwr_Buff.downloadHandler = new DownloadHandlerFile(path_Buff);
        yield return uwr_Buff.SendWebRequest();
        if (uwr_Buff.isNetworkError || uwr_Buff.isHttpError)
        {
            Debug.LogError(uwr_Buff.error);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo").SetActive(false);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo_Error").SetActive(true);
            StopCoroutine(downloadCor);
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
        else if(uwr_Stage.isDone)
        {
            Debug.Log("File successfully downloaded and saved to " + path_Buff);
            var buffData = File.ReadAllText(Application.persistentDataPath + "/Buff.json");
            //snackTypeDB = JsonConvert.DeserializeObject<SnackType[]>(snackTypeData);
            //var buffDataBase = JsonUtility.FromJson<BuffDB>("{\"buff\":" + buffData + "}");
            var buffDataBase = JsonConvert.DeserializeObject<BuffDB>("{\"buff\":" + buffData + "}");
            buffDB = buffDataBase.buff;
        }
        
        var uwr_Achievement = new UnityWebRequest(achievementUrl, UnityWebRequest.kHttpVerbGET);
        string path_Achievement = Path.Combine(Application.persistentDataPath, "Achievements.json");
        uwr_Achievement.downloadHandler = new DownloadHandlerFile(path_Achievement);
        yield return uwr_Achievement.SendWebRequest();
        if (uwr_Achievement.isNetworkError || uwr_Achievement.isHttpError)
        {
            Debug.LogError(uwr_Achievement.error);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo").SetActive(false);
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo_Error").SetActive(true);
            StopCoroutine(downloadCor);
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
        else if(uwr_Stage.isDone)
        {
            Debug.Log("File successfully downloaded and saved to " + path_Achievement);
            var achievementData = File.ReadAllText(Application.persistentDataPath + "/Achievements.json");
            //snackTypeDB = JsonConvert.DeserializeObject<SnackType[]>(snackTypeData);
            var achievementDataBase = JsonUtility.FromJson<AchievementsDB>("{\"achievements\":" + achievementData + "}");
            //var achievementDataBase = JsonConvert.DeserializeObject<AchievementsDB>("{\"achievements\":" + achievementData + "}");
            achievementDB = achievementDataBase.achievements;
            isDBReady = true;
        }
        
        /*
        var uwr_AchievementType = new UnityWebRequest(achievementTypeUrl, UnityWebRequest.kHttpVerbGET);
        string path_AchievementType = Path.Combine(Application.persistentDataPath, "AchievementsType.json");
        uwr_AchievementType.downloadHandler = new DownloadHandlerFile(path_AchievementType);
        yield return uwr_AchievementType.SendWebRequest();
        if (uwr_AchievementType.isNetworkError || uwr_AchievementType.isHttpError)
            Debug.LogError(uwr_AchievementType.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path_AchievementType);
            var achievementTypeData = File.ReadAllText(Application.persistentDataPath + "/AchievementsType.json");
            Debug.Log(achievementTypeData);
            //snackTypeDB = JsonConvert.DeserializeObject<SnackType[]>(snackTypeData);
            var achievementTypeDataBase = JsonUtility.FromJson<AchievementsTypeDB>("{\"AchievementsType\":" + achievementTypeData + "}");
            achievementTypeDB = achievementTypeDataBase.achievementTypes;
            isDBReady = true;
        }*/
        
        
        if(isDBReady)
        {
            GetComponent<LogInManager>().LoginForLastLoggedInProvider();
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .TitleOpened();
        }
        else
        {
            AppManagerScript.Instance.sceneManagerObject.GetComponent<StartSceneManagerScript>().startSceneUIManager
                .FindUIObject("DBInfo").GetComponent<TMPro.TMP_Text>().text = "서버에 문제가 있습니다. 잠시후 재접속 해주세요.";
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
    }
    

}
