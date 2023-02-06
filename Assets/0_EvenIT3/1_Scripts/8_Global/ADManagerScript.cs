using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Serialization;

public class ADManagerScript : Singleton<ADManagerScript>
{
    private RewardedAd _adEnergyReward;

    [SerializeField] private string adEnergyRewardID;
    [SerializeField] private string adEnergyRewardIDTest;

    private void Start()
    {
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
                .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);
        
        MobileAds.Initialize(initStatus => { });
        
        _adEnergyReward = new RewardedAd(adEnergyRewardIDTest);
        //_adEnergyReward = new RewardedAd(adEnergyRewardID);

        AdRequest request = new AdRequest.Builder().Build();
        this._adEnergyReward.LoadAd(request);
        
        // Called when an ad request has successfully loaded.
        this._adEnergyReward.OnAdLoaded += HandleEnergyRewardedAdLoaded;
        // Called when an ad request failed to load.
        this._adEnergyReward.OnAdFailedToLoad += HandleEnergyRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this._adEnergyReward.OnAdOpening += HandleEnergyRewardedAdOpening;
        // Called when an ad request failed to show.
        this._adEnergyReward.OnAdFailedToShow += HandleEnergyRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this._adEnergyReward.OnUserEarnedReward += HandleUserEarnedEnergyReward;
        // Called when the ad is closed.
        this._adEnergyReward.OnAdClosed += HandleEnergyRewardedAdClosed;
    }
    
    public void CreateAndLoadRewardedAd()
    {
        this._adEnergyReward = new RewardedAd(adEnergyRewardIDTest);
        //this._adEnergyReward = new RewardedAd(adEnergyRewardID);

        this._adEnergyReward.OnAdLoaded += HandleEnergyRewardedAdLoaded;
        this._adEnergyReward.OnUserEarnedReward += HandleUserEarnedEnergyReward;
        this._adEnergyReward.OnAdClosed += HandleEnergyRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this._adEnergyReward.LoadAd(request);
    }
    
    public void HandleEnergyRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Received");
        MonoBehaviour.print("HandleEnergyRewardedAdLoaded event received");
    }

    public void HandleEnergyRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleEnergyRewardedAdFailedToLoad event received with message: "
            + args);
    }

    public void HandleEnergyRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleEnergyRewardedAdOpening event received");
    }

    public void HandleEnergyRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleEnergyRewardedAdFailedToShow event received with message: "
            + args.Message);
    }

    public void HandleEnergyRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleEnergyRewardedAdClosed event received");
        CreateAndLoadRewardedAd();
    }

    public void HandleUserEarnedEnergyReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleEnergyRewardedAdRewarded event received for "
            + amount.ToString() + " " + type);
        UserManager.Instance.userData.energy += 1;
        FBManagerScript.Instance.UpdateCurrentUser();
        FindObjectOfType<MainMenuSceneUIManager>().FindUIObject("EnergyBuyPanel").SetActive(false);
    }

    public void ShowEnergyRewardAd()
    {
        Debug.Log("Show");
        _adEnergyReward.Show();
    }
}
