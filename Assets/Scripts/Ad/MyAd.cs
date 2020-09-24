// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using JackUtil;
// using ByteDance;
// using ByteDance.Union;

// namespace DoodleWorldNS {

//     public class MyAd : MonoBehaviour {

//         static MyAd m_instance;
//         public static MyAd Instance => m_instance;

//         public AdNative adNative;
//         public AdSlot adSlot;
//         public RewardAd rewardAd;

//         public Text adLogText;

//         void Awake() {

//             if (m_instance == null) {
//                 m_instance = this;
//             }
//         }

//         public void Init() {

//             adNative = SDK.CreateAdNative();
//             SDK.RequestPermissionIfNecessary();

//             adSlot = new AdSlot.Builder()
//                 .SetCodeId("945483518")
//                 .SetImageAcceptedSize(640, 320)
//                 .SetSupportDeepLink(true)
//                 .SetAdCount(3)
//                 .SetRewardName("复活")
//                 .SetRewardAmount(6)
//                 .SetUserID("")
//                 .SetOrientation(AdOrientation.Vertical)
//                 .Build();
//             rewardAd = new RewardAd();

//             adNative.LoadRewardVideoAd(adSlot, rewardAd);

//         }
//     }

//     public class RewardAd : IRewardVideoAdListener {

//         public RewardVideoAd ad;

//         /// <summary>
//         /// Invoke when load Ad error.
//         /// </summary>
//         public void OnError(int code, string message) {

//             MyAd.Instance.adLogText.text = "广告载入出错: " + code + ", " + message;

//         }

//         /// <summary>
//         /// Invoke when the Ad load success.
//         /// </summary>
//         public void OnRewardVideoAdLoad(RewardVideoAd ad) {

//             MyAd.Instance.adLogText.text = "广告载入成功: " + ad.ToString();
//             this.ad = ad;

//         }

//         /// <summary>
//         /// The Ad loaded locally, user can play local video directly.
//         /// </summary>
//         public void OnRewardVideoCached() {

//             // ad.ShowRewardVideoAd();

//         }

//         /// <summary>
//         /// Invoke when the Ad load success.
//         /// </summary>
//         public void OnExpressRewardVideoAdLoad(ExpressRewardVideoAd ad) {

//             ad.ShowRewardVideoAd();

//         }

//     }
// }