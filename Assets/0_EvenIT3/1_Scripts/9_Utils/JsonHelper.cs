using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonHelper 
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.data;
    }
    
    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.data = array;
        return JsonUtility.ToJson(wrapper);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] data;
    }

    public static void SaveSettings(Settings settings)
    {
        string savePath = Application.persistentDataPath + "/Settings/";
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);

            string saveJson = JsonUtility.ToJson(settings);

            string saveFilePath = savePath + "settings.json";
            
            File.WriteAllText(saveFilePath, saveJson);
            Debug.Log("Save Success: " + saveFilePath);
        }
    }
    
    public static Settings Load()
    {
        string savePath = Application.persistentDataPath + "/Settings/";
        string saveFilePath = savePath + "settings.json";
			
        if(!File.Exists(saveFilePath))
        {
            Debug.LogError("No such saveFile exists");
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        Settings saveData = JsonUtility.FromJson<Settings>(saveFile);
        return saveData;
    }
}
