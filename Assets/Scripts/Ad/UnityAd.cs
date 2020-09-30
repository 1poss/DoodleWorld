using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using JackUtil;

namespace DoodleWorldNS {

    public class UnityAd : MonoBehaviour, IUnityAdsListener {

        string gameId = "3836325";
        string myPlacementId = "Dead";
        bool testMode = true;

        void Start() {

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);

        }

        public void ShowRewardedVideo() {

            if (Advertisement.IsReady(myPlacementId)) {
                Advertisement.Show(myPlacementId);
            } else {
                DebugUtil.Log("Not Ready");
            }
        }

        public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
            // Define conditional logic for each ad completion status:
            if (showResult == ShowResult.Finished) {
                // Reward the user for watching the ad to completion.
            } else if (showResult == ShowResult.Skipped) {
                // Do not reward the user for skipping the ad.
            } else if (showResult == ShowResult.Failed) {
                Debug.LogWarning ("The ad did not finish due to an error.");
            }
        }

        public void OnUnityAdsReady (string placementId) {
            // If the ready Placement is rewarded, show the ad:
            if (placementId == myPlacementId) {
                // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
                DebugUtil.Log("广告准备好:" + placementId);
            }
        }

        public void OnUnityAdsDidError (string message) {
            // Log the error.
            DebugUtil.Log("广告出错: " + message);
        }

        public void OnUnityAdsDidStart (string placementId) {
            // Optional actions to take when the end-users triggers an ad.
            DebugUtil.Log("广告开始:" + placementId);
        } 

        // When the object that subscribes to ad events is destroyed, remove the listener:
        public void OnDestroy() {
            Advertisement.RemoveListener(this);
        }

    }
}