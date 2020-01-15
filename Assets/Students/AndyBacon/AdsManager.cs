using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public Action OnAdReady;
    string gameId = "1234567";
    bool testMode = true;
    string myPlacementId = "rewardedVideo";

    public static AdsManager adsManager;
    public static AdsManager instance
    {
        get
        {
            if (!adsManager)
            {
                adsManager = FindObjectOfType(typeof(AdsManager)) as AdsManager;

                if (!adsManager)
                {
                    adsManager = new GameObject("AdsManager").AddComponent<AdsManager>();
                }

                adsManager.Setup();
            }

            return adsManager;
        }
    }

    private void Awake()
    {
        Setup();
    }

    void Setup()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            Debug.Log("Ads ready");
            OnAdReady?.Invoke();
        }
    }

    public bool IsAdReady()
    {
        return Advertisement.IsReady(myPlacementId);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            Debug.Log("Watched the ad.");
            CollectableManager.instance.CollectCoin(50);
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            Debug.Log("Skipped the ad.");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
        Debug.Log("Unity Ads error");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
        Debug.Log("Unity Ads start");
    }
}
