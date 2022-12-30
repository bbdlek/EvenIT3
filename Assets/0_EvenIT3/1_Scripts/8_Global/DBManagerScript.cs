using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class DBManagerScript : Singleton<DBManagerScript>
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
                return snapshot.HasChild(userId);
            }
            return snapshot != null && snapshot.HasChild(userId);
        });
        return snapshot.HasChild(userId);
    }

    public void WriteNewUser(string userId, string nickName)
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users");
        User user = new User(nickName);
        string json = JsonUtility.ToJson(user);
        
        reference.Child(userId).SetRawJsonValueAsync(json);
    }

    public void DeleteCurrentUser(string userId)
    {
        var reference = FirebaseDatabase.DefaultInstance.GetReference("Users").Child(userId);
        reference.RemoveValueAsync();
    }

    #endregion
}
