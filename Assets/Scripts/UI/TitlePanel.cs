using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class TitlePanel : MonoBehaviour {

        [NonSerialized]
        IUIManager ui;

        public Button startGameButton;
        public Button exitGameButton;
        public Button showAdButton;

        public void Inject(IUIManager ui) {
            this.ui = ui;
            startGameButton.onClick.AddListener(ui.EnterGame);
            exitGameButton.onClick.AddListener(Application.Quit);
        }

        public void Init() {

            // showAdButton.onClick.AddListener(() => {
            //     ad.ShowRewardedVideo();
            // });

        }

        void OnDestroy() {

            startGameButton.onClick.RemoveAllListeners();
            exitGameButton.onClick.RemoveAllListeners();
            
        }
    }
}