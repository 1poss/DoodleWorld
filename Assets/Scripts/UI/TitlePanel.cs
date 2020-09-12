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

        void Awake() {

            startGameButton.onClick.AddListener(() => {
                UIController.OnStartGameEvent(this, EventArgs.Empty);
            });

            exitGameButton.onClick.AddListener(() => {
                Application.Quit();
            });

        }

        void OnDestroy() {

            startGameButton.onClick.RemoveAllListeners();
            exitGameButton.onClick.RemoveAllListeners();
            
        }
    }
}