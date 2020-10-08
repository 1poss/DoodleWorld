using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class TitlePanel : MonoBehaviour {

        public UIManager ui;

        public Button startGameButton;
        public Button exitGameButton;
        public Button showAdButton;

        public void Init() {

            showAdButton.onClick.AddListener(ui.ShowAd);

            startGameButton.onClick.AddListener(() => {
                ui.EnterGame(true);
            });
            
            exitGameButton.onClick.AddListener(Application.Quit);

        }

        void OnDestroy() {

            startGameButton.onClick.RemoveAllListeners();
            exitGameButton.onClick.RemoveAllListeners();
            
        }
    }
}