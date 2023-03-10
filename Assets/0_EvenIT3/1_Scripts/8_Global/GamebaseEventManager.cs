using System.Collections;
using System.Collections.Generic;
using Toast.Gamebase;
using UnityEngine;

public class GamebaseEventManager : MonoBehaviour
{
    private void Start()
        {
            Gamebase.AddEventHandler(GamebaseEventHandler);
        }

        private void GamebaseEventHandler(GamebaseResponse.Event.GamebaseEventMessage message)
        {
            switch (message.category)
            {
                case GamebaseEventCategory.IDP_REVOKED:
                {
                    GamebaseResponse.Event.GamebaseEventIdPRevokedData idPRevokedData = GamebaseResponse.Event.GamebaseEventIdPRevokedData.From(message.data);
                    if (idPRevokedData != null)
                    {
                        ProcessIdPRevoked(idPRevokedData);
                    }

                    break;
                }
                case GamebaseEventCategory.LOGGED_OUT:
                {
                    GamebaseResponse.Event.GamebaseEventLoggedOutData loggedData = GamebaseResponse.Event.GamebaseEventLoggedOutData.From(message.data);
                    if (loggedData != null)
                    {
                        // There was a problem with the access token.
                        // Call login again.
                    }

                    break;
                }
                case GamebaseEventCategory.SERVER_PUSH_APP_KICKOUT_MESSAGE_RECEIVED:
                case GamebaseEventCategory.SERVER_PUSH_APP_KICKOUT:
                case GamebaseEventCategory.SERVER_PUSH_TRANSFER_KICKOUT:
                {
                    GamebaseResponse.Event.GamebaseEventServerPushData serverPushData = GamebaseResponse.Event.GamebaseEventServerPushData.From(message.data);
                    if (serverPushData != null)
                    {
                        CheckServerPush(message.category, serverPushData);
                    }

                    break;
                }
                case GamebaseEventCategory.OBSERVER_LAUNCHING:
                {
                    GamebaseResponse.Event.GamebaseEventObserverData observerData = GamebaseResponse.Event.GamebaseEventObserverData.From(message.data);
                    if (observerData != null)
                    {
                        CheckLaunchingStatus(observerData);
                    }

                    break;
                }
                case GamebaseEventCategory.OBSERVER_NETWORK:
                {
                    GamebaseResponse.Event.GamebaseEventObserverData observerData = GamebaseResponse.Event.GamebaseEventObserverData.From(message.data);
                    if (observerData != null)
                    {
                        CheckNetwork(observerData);
                    }

                    break;
                }
                case GamebaseEventCategory.OBSERVER_HEARTBEAT:
                {
                    GamebaseResponse.Event.GamebaseEventObserverData observerData = GamebaseResponse.Event.GamebaseEventObserverData.From(message.data);
                    if (observerData != null)
                    {
                        CheckHeartbeat(observerData);
                    }

                    break;
                }
                case GamebaseEventCategory.OBSERVER_WEBVIEW:
                {
                    GamebaseResponse.Event.GamebaseEventObserverData observerData = GamebaseResponse.Event.GamebaseEventObserverData.From(message.data);
                    if (observerData != null)
                    {
                        CheckWebView(observerData);
                    }

                    break;
                }

                // Introspect error
                case GamebaseEventCategory.OBSERVER_INTROSPECT:
                {
                    GamebaseResponse.Event.GamebaseEventObserverData observerData = GamebaseResponse.Event.GamebaseEventObserverData.From(message.data);
                    Debug.LogError($"{observerData.code} : {observerData.message}");
                    break;
                }
                case GamebaseEventCategory.PURCHASE_UPDATED:
                {
                    GamebaseResponse.Event.PurchasableReceipt purchasableReceipt = GamebaseResponse.Event.PurchasableReceipt.From(message.data);
                    if (purchasableReceipt != null)
                    {
                        // If the user got item by 'Promotion Code',
                        // this event will be occurred.
                    }

                    break;
                }
                case GamebaseEventCategory.PUSH_RECEIVED_MESSAGE:
                {
                    GamebaseResponse.Event.PushMessage pushMessage = GamebaseResponse.Event.PushMessage.From(message.data);
                    if (pushMessage != null)
                    {
                        // When you received push message.

                        // By converting the extras field of the push message to JSON,
                        // you can get the custom information added by the user when sending the push.
                        // (For Android, an 'isForeground' field is included so that you can check if received in the foreground state.)
                    }

                    break;
                }
                case GamebaseEventCategory.PUSH_CLICK_MESSAGE:
                {
                    GamebaseResponse.Event.PushMessage pushMessage = GamebaseResponse.Event.PushMessage.From(message.data);
                    if (pushMessage != null)
                    {
                        // When you clicked push message.
                    }

                    break;
                }
                case GamebaseEventCategory.PUSH_CLICK_ACTION:
                {
                    GamebaseResponse.Event.PushAction pushAction = GamebaseResponse.Event.PushAction.From(message.data);
                    if (pushAction != null)
                    {
                        // When you clicked action button by 'Rich Message'.
                    }

                    break;
                }
            }
        }

        private void ProcessIdPRevoked(GamebaseResponse.Event.GamebaseEventIdPRevokedData data)
        {
            var revokedIdP = data.idPType;
            switch (data.code)
            {
                case GamebaseIdPRevokedCode.WITHDRAW:
                {
                    // ?????? ?????? ????????? IdP??? ??????????????? ??????, ????????? IdP ????????? ?????? ?????? ???????????????.
                    // ???????????? ?????? ????????? ???????????? ???????????????.
                    Gamebase.Withdraw((_) => { });
                    break;
                }
                case GamebaseIdPRevokedCode.OVERWRITE_LOGIN_AND_REMOVE_MAPPING:
                {
                    // ?????? ?????? ????????? IdP??? ??????????????? ??????, ?????? ????????? IdP ?????? ?????? IdP??? ???????????? ?????? ????????? ???????????????.
                    // ????????? authMappingList ??? ?????? IdP??? ?????? ???????????? ??? ????????????, ????????? IdP??? ???????????? ?????? ?????? ????????? IdP??? ???????????? ?????? ?????? ???????????????.
                    var selectedIdP = "????????? ????????? IdP";
                    var additionalInfo = new Dictionary<string, object>() {{GamebaseAuthProviderCredential.IGNORE_ALREADY_LOGGED_IN, true}};

                    Gamebase.Login(selectedIdP, additionalInfo, (_, loginError) =>
                    {
                        if (Gamebase.IsSuccess(loginError))
                        {
                            Gamebase.RemoveMapping(revokedIdP, (_) => { });
                        }
                    });
                    break;
                }
                case GamebaseIdPRevokedCode.REMOVE_MAPPING:
                {
                    // ?????? ????????? ????????? IdP ??? ?????? ????????? IdP??? ?????? ????????? ???????????????.
                    // ???????????? ?????? ???????????? ?????? ????????? IdP??? ?????? ???????????? ???????????????.
                    Gamebase.RemoveMapping(revokedIdP, (_) => { });
                    break;
                }
            }
        }

        private void CheckServerPush(string category, GamebaseResponse.Event.GamebaseEventServerPushData data)
        {
            Debug.Log(data);
            if (category.Equals(GamebaseEventCategory.SERVER_PUSH_APP_KICKOUT))
            {
                // Kicked out from Gamebase server.(Maintenance, banned or etc.)
                // And the game user closes the kick out pop-up.
                // Return to title and initialize Gamebase again.
            }
            else if (category.Equals(GamebaseEventCategory.SERVER_PUSH_APP_KICKOUT_MESSAGE_RECEIVED))
            {
                // Currently, the kick out pop-up is displayed.
                // If your game is running, stop it.
            }
            else if (category.Equals(GamebaseEventCategory.SERVER_PUSH_TRANSFER_KICKOUT))
            {
                // If the user wants to move the guest account to another device,
                // if the account transfer is successful,
                // the login of the previous device is released,
                // so go back to the title and try to log in again.
            }
        }

        private void CheckLaunchingStatus(GamebaseResponse.Event.GamebaseEventObserverData observerData)
        {
            switch (observerData.code)
            {
                case GamebaseLaunchingStatus.IN_SERVICE:
                {
                    // Service is now normally provided.
                    break;
                }
                // ... 
                case GamebaseLaunchingStatus.INTERNAL_SERVER_ERROR:
                {
                    // Error in internal server.
                    break;
                }
            }
        }

        private void CheckNetwork(GamebaseResponse.Event.GamebaseEventObserverData observerData)
        {
            switch ((GamebaseNetworkType) observerData.code)
            {
                case GamebaseNetworkType.TYPE_NOT:
                {
                    // Network disconnected.
                    break;
                }
                case GamebaseNetworkType.TYPE_MOBILE:
                case GamebaseNetworkType.TYPE_WIFI:
                case GamebaseNetworkType.TYPE_ANY:
                {
                    // Network connected.
                    break;
                }
            }
        }

        private void CheckHeartbeat(GamebaseResponse.Event.GamebaseEventObserverData observerData)
        {
            switch (observerData.code)
            {
                case GamebaseErrorCode.INVALID_MEMBER:
                {
                    // You can check the invalid user session in here.
                    // ex) After transferred account to another device.
                    break;
                }
                case GamebaseErrorCode.BANNED_MEMBER:
                {
                    // You can check the banned user session in here.
                    break;
                }
            }
        }

        private void CheckWebView(GamebaseResponse.Event.GamebaseEventObserverData observerData)
        {
            switch (observerData.code)
            {
                case GamebaseWebViewEventType.OPENED:
                {
                    // WebView opened.
                    break;
                }
                case GamebaseWebViewEventType.CLOSED:
                {
                    // WebView closed.
                    break;
                }
            }
        }
}
