using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Toast.Gamebase;
using UnityEngine;

public class FBManagerScript : Singleton<FBManagerScript>
{
    public static FirebaseApp FirebaseApp;
    
    public void InitFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available) {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                FirebaseApp = FirebaseApp.DefaultInstance;

                InitDatabase();
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            } else {
                Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private DatabaseReference _mDatabaseRef;
    
    private void InitDatabase()
    {
        _mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    #region User

    public async Task<bool> CheckNewUser(string userId)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Users");
        DataSnapshot snapshot = null;
        await reference.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                snapshot = task.Result;
                // Do something with snapshot...
                var json = snapshot.GetRawJsonValue();
                UserManager.Instance.userData = JsonUtility.FromJson<User>(json);
                return snapshot.HasChild(userId);
            }
            return snapshot != null && snapshot.HasChild(userId);
        });
        return snapshot.HasChild(userId);
    }

    public void WriteNewUser(string userId, string nickName)
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users");
        UserManager.Instance.userData = new User();
        UserManager.Instance.userData.NewUser(nickName);
        string json = JsonUtility.ToJson(UserManager.Instance.userData);
        
        reference.Child(userId).Child("UserData").SetRawJsonValueAsync(json);
        reference.Child(userId).Child("Energy").Child("EnergyAmount").SetValueAsync(5);
        reference.Child(userId).Child("Energy").Child("AppQuitTime").SetValueAsync(new DateTime(1970, 1, 1).ToLocalTime().ToBinary().ToString());
    }

    public void DeleteCurrentUser(string userId)
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users").Child(userId);
        reference.RemoveValueAsync();
    }

    public void GetUserData()
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users").Child("UserData");
        reference.Child(UserManager.Instance.userID).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Error");
            }else if (task.IsCompleted)
            {
                var snapshot = task.Result;
                string json = snapshot.GetRawJsonValue();
                Debug.Log(json);
                UserManager.Instance.userData = JsonUtility.FromJson<User>(json);
            }
        });
    }

    public void UpdateCurrentUser()
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users");
        string json = JsonUtility.ToJson(UserManager.Instance.userData);

        reference.Child(Gamebase.GetUserID()).Child("UserData").SetRawJsonValueAsync(json);
    }

    public void UpdateNickName()
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users").Child(Gamebase.GetUserID());
        string key = reference.Push().Key;
    }

    public void GetEnergyAmount(string uid)
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users").Child(uid);
        reference.Child("Energy").Child("EnergyAmount").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Get Energy Error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                UserManager.Instance.energy = (int)snapshot.Value;
            }
        });
    }

    public void SaveEnergyAmount(string uid, int energyAmount)
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users").Child(uid);
        reference.Child("Energy").Child("EnergyAmount").SetValueAsync(energyAmount);
    }

    public string GetQuitTime(string uid)
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users").Child(uid);
        reference.Child("Energy").Child("AppQuitTime").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Get QuitTime Error");
                return DateTime.Now.ToLocalTime().ToBinary().ToString();
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                return snapshot.Value;
            }

            return DateTime.Now.ToLocalTime().ToBinary().ToString();
        });
        return DateTime.Now.ToLocalTime().ToBinary().ToString();
    }

    public void SaveQuitTime(string uid, string quitTime)
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users").Child(uid);
        reference.Child("Energy").Child("AppQuitTime").SetValueAsync(quitTime);
    }

    #endregion
}
