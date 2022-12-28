using System.Collections;
using System.Collections.Generic;
using Toast.Gamebase;
using UnityEngine;

public class LogInManager : MonoBehaviour
{
    // 이전 로그인
    public void LoginForLastLoggedInProvider()
    {
        Gamebase.LoginForLastLoggedInProvider((authToken, error) =>
        {
            if (Gamebase.IsSuccess(error))
            {
                Debug.Log("Login succeeded.");
            }
            else
            {
                // Check the error code and handle the error appropriately.
                Debug.Log(string.Format("Login failed. error is {0}", error));
                if (error.code == (int)GamebaseErrorCode.SOCKET_ERROR || error.code == (int)GamebaseErrorCode.SOCKET_RESPONSE_TIMEOUT)
                {
                    Debug.Log(string.Format("Retry LoginForLastLoggedInProvider or notify an error message to the user. : {0}", error.message));
                }
                else if (error.code == GamebaseErrorCode.BANNED_MEMBER)
                {
                    GamebaseResponse.Auth.BanInfo banInfo = GamebaseResponse.Auth.BanInfo.From(error);
                    if (banInfo != null)
                    {
                    }
                }
                else
                {
                    Debug.Log("Try to login using a specifec IdP");
                    //Gamebase.Login("ProviderName", (authToken, error) => {});
                }
            }
        });
    }

    // 게스트 로그인
    public void GuestLogin()
    {
        Gamebase.Login(GamebaseAuthProvider.GUEST, (authToken, error) =>
        {
            if (Gamebase.IsSuccess(error))
            {
                string userId = authToken.member.userId;
                Debug.Log(string.Format("Login succeeded. Gamebase userId is {0}", userId));
                AfterLogin();
            }
            else
            {
                // Check the error code and handle the error appropriately.
                Debug.Log(string.Format("Login failed. error is {0}", error));
                if (error.code == (int)GamebaseErrorCode.SOCKET_ERROR || error.code == (int)GamebaseErrorCode.SOCKET_RESPONSE_TIMEOUT)
                {
                    Debug.Log(string.Format("Retry Login or notify an error message to the user. : {0}", error.message));
                }
                else if (error.code == GamebaseErrorCode.BANNED_MEMBER)
                {
                    GamebaseResponse.Auth.BanInfo banInfo = GamebaseResponse.Auth.BanInfo.From(error);
                    if (banInfo != null)
                    {
                    }
                }
            }
        });
    }

    // 구글 로그인
    public void GoogleLogin()
    {
        Gamebase.Login(GamebaseAuthProvider.GOOGLE, (authToken, error) =>
        {
            if (Gamebase.IsSuccess(error))
            {
                string userId = authToken.member.userId;
                Debug.Log(string.Format("Login succeeded. Gamebase userId is {0}", userId));
                AfterLogin();
            }
            else
            {
                // Check the error code and handle the error appropriately.
                Debug.Log(string.Format("Login failed. error is {0}", error));
                if (error.code == (int)GamebaseErrorCode.SOCKET_ERROR || error.code == (int)GamebaseErrorCode.SOCKET_RESPONSE_TIMEOUT)
                {
                    Debug.Log(string.Format("Retry Login or notify an error message to the user. : {0}", error.message));
                }
                else if (error.code == GamebaseErrorCode.BANNED_MEMBER)
                {
                    GamebaseResponse.Auth.BanInfo banInfo = GamebaseResponse.Auth.BanInfo.From(error);
                    if (banInfo != null)
                    {
                    }
                }
            }
        });
    }
    
    // 약관 표시
    static GamebaseRequest.Push.PushConfiguration _savedPushConfiguration = null;
    
    public void ShowTermsView()
    {
        var configuration = new GamebaseRequest.Terms.GamebaseTermsConfiguration
        {
            forceShow = true
        };

        Gamebase.Terms.ShowTermsView(configuration, (data, error) => 
        {
            if (Gamebase.IsSuccess(error) == true)
            {
                Debug.Log("ShowTermsView succeeded.");

                GamebaseResponse.Terms.ShowTermsViewResult result = GamebaseResponse.Terms.ShowTermsViewResult.From(data);

                // Save the 'PushConfiguration' and use it for Gamebase.Push.RegisterPush() after Gamebase.Login().
                _savedPushConfiguration = result.pushConfiguration;

                // Wheter the TermsUI was displayed.
                bool isTermsUIOpened = result.isTermsUIOpened;
            }
            else
            {
                Debug.Log(string.Format("ShowTermsView failed. error:{0}", error));
            }
        });
    }

    public void AfterLogin()
    {
        if (_savedPushConfiguration != null)
        {
            Debug.Log("RegisterPush");
            Gamebase.Push.RegisterPush(_savedPushConfiguration, (error) =>
            {
                
            });
        }
    }
}
