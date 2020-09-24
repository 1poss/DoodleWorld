using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class TitlePanel : MonoBehaviour {

        public Button startGameButton;
        public Button exitGameButton;
        public Button showAdButton;

        public UnityAd ad;

        void Awake() {

            startGameButton.onClick.AddListener(() => {
                UIController.OnStartGameEvent(this, EventArgs.Empty);
            });

            exitGameButton.onClick.AddListener(() => {
                Application.Quit();
            });

        }

        public void Init() {

            showAdButton.onClick.AddListener(() => {
                ad.ShowRewardedVideo();
            });

        }

        void OnDestroy() {

            startGameButton.onClick.RemoveAllListeners();
            exitGameButton.onClick.RemoveAllListeners();
            
        }
    }
}