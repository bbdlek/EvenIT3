using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Toast.Gamebase;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardManagerScript : Singleton<LeaderboardManagerScript>
{
    [SerializeField] private string appID;
    [SerializeField] private string appSecretKey;

    [SerializeField] private LeaderboardUserInfo[] userDB;
    [SerializeField] private LeaderboardUserInfo[] myRankDB;
    public List<LeaderboardUserInfo[]> RankUserDB;

    public List<LeaderboardUserInfo> GetTop5Users(int stageNum)
    {
        string responseText = string.Empty;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api-gamebase.nhncloudservice.com/tcgb-leaderboard/v1.3/apps/{appID}/factors/{stageNum + 1}/users?start=1&size=5");
        request.Method = "GET";
        request.Timeout = 30 * 1000; // 30초
        request.ContentType = "application/json";
        request.Headers.Add("X-Secret-Key", appSecretKey); // 헤더 추가 방법

        using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
        {
            HttpStatusCode status = resp.StatusCode;
            Console.WriteLine(status);  // 정상이면 "OK"

            Stream respStream = resp.GetResponseStream();
            using (StreamReader sr = new StreamReader(respStream))
            {
                responseText = sr.ReadToEnd();
            }
        }
        
        int index = responseText.IndexOf("[", StringComparison.Ordinal);
        int indexLast = responseText.IndexOf("]", StringComparison.Ordinal);
        
        var userData = responseText.Substring(index, indexLast - index + 1);

        var userDataBase = JsonConvert.DeserializeObject<LeaderboardUserInfoDB>("{\"userInfo\":" + userData + "}");
        userDB = userDataBase.userInfo;
        
        List<LeaderboardUserInfo> leaderboardUserInfos = new List<LeaderboardUserInfo>();
        for (int i = 0; i < userDB.Length; i++)
        {
            leaderboardUserInfos.Add(userDB[i]);
        }

        int count = leaderboardUserInfos.Count;

        for (int i = 0; i < 5 - count; i++)
        {
            leaderboardUserInfos.Add(new LeaderboardUserInfo());
            Debug.Log("Added");
        }
        
        return leaderboardUserInfos;
    }

    public LeaderboardUserInfo GetMyRank(int stageNum)
    {
        string responseText = string.Empty;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api-gamebase.nhncloudservice.com/tcgb-leaderboard/v1.3/apps/{appID}/factors/{stageNum + 1}/users?userId={UserManager.Instance.userID}");
        request.Method = "GET";
        request.Timeout = 30 * 1000; // 30초
        request.ContentType = "application/json";
        request.Headers.Add("X-Secret-Key", appSecretKey); // 헤더 추가 방법

        using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
        {
            HttpStatusCode status = resp.StatusCode;
            Console.WriteLine(status);  // 정상이면 "OK"

            Stream respStream = resp.GetResponseStream();
            using (StreamReader sr = new StreamReader(respStream))
            {
                responseText = sr.ReadToEnd();
            }

            if (status != HttpStatusCode.OK)
            {
                return new LeaderboardUserInfo();
            }
        }

        Debug.Log(responseText);

        int index = responseText.IndexOf("userInfo", StringComparison.Ordinal);

        var userData = responseText.Substring(index + 10, responseText.Length - index - 11);
        Debug.Log(userData);

        var userDataBase = JsonConvert.DeserializeObject<LeaderboardUserInfoDB>("{\"userInfo\":[" + userData + "]}");
        myRankDB = userDataBase.userInfo;
        
        return myRankDB[0];
    }

    public string UploadLeaderboard(int stageNum, float remainTime)
    {
        string responseText = string.Empty;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api-gamebase.nhncloudservice.com/tcgb-leaderboard/v1.3/apps/{appID}/factors/{stageNum + 1}/users/{UserManager.Instance.userID}/score");
        request.Method = "POST";
        request.Timeout = 30 * 1000; // 30초
        request.ContentType = "application/json";
        request.Headers.Add("X-Secret-Key", appSecretKey); // 헤더 추가 방법
        
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            string json = "{\"score\" : " + remainTime +"}";
            
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
        {
            HttpStatusCode status = resp.StatusCode;
            Console.WriteLine(status);  // 정상이면 "OK"

            Stream respStream = resp.GetResponseStream();
            using (StreamReader sr = new StreamReader(respStream))
            {
                responseText = sr.ReadToEnd();
            }
        }

        return responseText;
    }
    
    [SerializeField]
    
    public void GetHallOfFameUser(int season)
    {
        for (int i = 1; i < 25; i++)
        {
            string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api-gamebase.nhncloudservice.com/tcgb-leaderboard/v1.3/apps/{appID}/factors/{i}/users?isPast=true&start=1&size=5");
            request.Method = "GET";
            request.Timeout = 30 * 1000; // 30초
            request.ContentType = "application/json";
            request.Headers.Add("X-Secret-Key", appSecretKey); // 헤더 추가 방법

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                Console.WriteLine(status);  // 정상이면 "OK"

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }
        
            int index = responseText.IndexOf("[", StringComparison.Ordinal);
            int indexLast = responseText.IndexOf("]", StringComparison.Ordinal);
        
            var userData = responseText.Substring(index, indexLast - index + 1);
            var userDataBase = JsonConvert.DeserializeObject<LeaderboardUserInfoDB>("{\"userInfo\":" + userData + "}");
            RankUserDB.Add(userDataBase.userInfo);
        }

        List<LeaderboardUserInfo> leaderboardUserInfos = new List<LeaderboardUserInfo>();
        for (int i = 0; i < userDB.Length; i++)
        {
            leaderboardUserInfos.Add(userDB[i]);
        }

        int count = leaderboardUserInfos.Count;

        for (int i = 0; i < 5 - count; i++)
        {
            leaderboardUserInfos.Add(new LeaderboardUserInfo());
            Debug.Log("Added");
        }
    }
}
