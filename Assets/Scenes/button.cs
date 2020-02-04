using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class button : MonoBehaviour {

    private RewardBasedVideoAd rewardBasedVideo;

    void Start () {
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        this.RequestRewardBasedVideo();
    }

    private void RequestRewardBasedVideo()
    {
        string adUnitId = "ca-app-pub-3010029359415397/4697035240";

        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardBasedVideo.LoadAd(request, adUnitId);
        Debug.Log("ccccccccc");
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        rewardBasedVideo.Show();
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("bbbbbbb");
    }
}
