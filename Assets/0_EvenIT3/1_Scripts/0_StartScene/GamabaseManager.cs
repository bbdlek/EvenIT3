using System;
using System.Collections;
using System.Collections.Generic;
using Toast.Gamebase;
using Unity.VisualScripting;
using UnityEngine;

public class GamabaseManager : MonoBehaviour
{
    [SerializeField] private bool isDebugMode = true;
    [SerializeField] private string appID;

    public void Initialize()
    {
        Gamebase.SetDebugMode(isDebugMode);
        
        var configuration = new GamebaseRequest.GamebaseConfiguration();
        configuration.appID = appID;
        configuration.appVersion = Application.version;
        configuration.displayLanguageCode = GamebaseDisplayLanguageCode.Korean;
    #if UNITY_ANDROID
        configuration.storeCode = GamebaseStoreCode.GOOGLE;
    #elif UNITY_IOS
        configuration.storeCode = GamebaseStoreCode.APPSTORE;
    #elif UNITY_WEBGL
        configuration.storeCode = GamebaseStoreCode.WEBGL;
    #elif UNITY_STANDALONE
        configuration.storeCode = GamebaseStoreCode.WINDOWS;
    #else
        configuration.storeCode = GamebaseStoreCode.WINDOWS;
    #endif
        configuration.enablePopup = true;
        configuration.enableLaunchingStatusPopup = true;
        configuration.enableBanPopup = true;
        
        Gamebase.Initialize(configuration, (launchingInfo, error) =>
        {
            if (Gamebase.IsSuccess(error) == true)
            {
                Debug.Log("Initialization succeeded.");

                //Following notices are registered in the Gamebase Console
                var notice = launchingInfo.launching.notice;
                if (notice != null)
                {
                    if (string.IsNullOrEmpty(notice.message) == false)
                    {
                        Debug.Log(string.Format("title:{0}", notice.title));
                        Debug.Log(string.Format("message:{0}", notice.message));
                        Debug.Log(string.Format("url:{0}", notice.url));
                    }
                }

                //Status information of game app version set in the Gamebase Unity SDK initialization.
                var status = launchingInfo.launching.status;
                
                if (status.code == GamebaseLaunchingStatus.IN_SERVICE)
                {
                    // 정상 서비스 중
                    Debug.Log("IN_SERVICE");
                    transform.AddComponent<GamebaseEventManager>();
                }
                else
                {
                    switch (status.code)
                    {
                        case GamebaseLaunchingStatus.RECOMMEND_UPDATE:
                        {
                            // 업데이트 권장
                            transform.AddComponent<GamebaseEventManager>();
                            break;
                        }
                        case GamebaseLaunchingStatus.IN_SERVICE_BY_QA_WHITE_LIST:
                        {
                            // QA 단말기용
                            transform.AddComponent<GamebaseEventManager>();
                            break;
                        }
                        case GamebaseLaunchingStatus.IN_TEST:
                        {
                            // 테스트 중
                            Debug.Log("IN_TEST");
                            transform.AddComponent<GamebaseEventManager>();
                            //GetComponent<LogInManager>().LoginForLastLoggedInProvider();
                            break;
                        }
                        case GamebaseLaunchingStatus.IN_REVIEW:
                        {
                            // 심사 중
                            break;
                        }
                        case GamebaseLaunchingStatus.IN_BETA:
                        {
                            // 베타 서버 환경
                            transform.AddComponent<GamebaseEventManager>();
                            break;
                        }
                        case GamebaseLaunchingStatus.REQUIRE_UPDATE:
                        {
                            // 업데이트 필수
                            break;
                        }
                        case GamebaseLaunchingStatus.BLOCKED_USER:
                        {
                            // 차단 단말기
                            break;
                        }
                        case GamebaseLaunchingStatus.TERMINATED_SERVICE:
                        {
                            //서비스 종료
                            break;
                        }
                        case GamebaseLaunchingStatus.INSPECTING_SERVICE:
                        {
                            // 서비스 점검 중
                            break;
                        }
                        case GamebaseLaunchingStatus.INSPECTING_ALL_SERVICES:
                        {
                            // 전체 서비스 점검 중
                            break;
                        }
                        case GamebaseLaunchingStatus.INTERNAL_SERVER_ERROR:
                        {
                            // 내부 서버 오류
                            break;
                        }
                    }
                }
            }
            else
            {
                // Check the error code and handle the error appropriately.
                Debug.Log(string.Format("Initialization failed. error is {0}", error));

                if (error.code == GamebaseErrorCode.LAUNCHING_UNREGISTERED_CLIENT)
                {
                    GamebaseResponse.Launching.UpdateInfo updateInfo = GamebaseResponse.Launching.UpdateInfo.From(error);
                    if (updateInfo != null)
                    {
                        // Update is require.
                    }
                }
            }
        });
    }
}
