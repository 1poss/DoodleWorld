using System;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;
using ByteDance;
using ByteDance.Union;

namespace DoodleWorldNS {

    public class MyAd : MonoBehaviour {

        AdNative adNative;
        AdSlot adSlot;
        RewardAd rewardAd;

        public void Init() {

            adNative = SDK.CreateAdNative();
            SDK.RequestPermissionIfNecessary();

            adSlot = new AdSlot.Builder()
                .SetCodeId("945483518")
                .SetImageAcceptedSize(640, 320)
                .SetSupportDeepLink(true)
                .SetAdCount(3)
                .SetRewardName("复活")
                .SetRewardAmount(6)
                .SetUserID("")
                .SetOrientation(AdOrientation.Vertical)
                .Build();
            rewardAd = new RewardAd();

            adNative.LoadRewardVideoAd(adSlot, rewardAd);

        }
    }

    public class RewardAd : IRewardVideoAdListener {

        /// <summary>
        /// Invoke when load Ad error.
        /// </summary>
        public void OnError(int code, string message) {

            DebugUtil.Log("广告载入出错: " + code + ", " + message);

        }

        /// <summary>
        /// Invoke when the Ad load success.
        /// </summary>
        public void OnRewardVideoAdLoad(RewardVideoAd ad) {

            ad.ShowRewardVideoAd();

        }

        /// <summary>
        /// The Ad loaded locally, user can play local video directly.
        /// </summary>
        public void OnRewardVideoCached() {

        }

        /// <summary>
        /// Invoke when the Ad load success.
        /// </summary>
        public void OnExpressRewardVideoAdLoad(ExpressRewardVideoAd ad) {

        }

    }
}