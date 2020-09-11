using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class InGameMenuWindow : MonoBehaviour {

        public GameObject bd;

        // 标题语
        public Button pauseReturnButton;
        public Button congratulationButton;
        public Button gameOverButton;

        // 通用菜单
        public Button exitButton;
        public Button retryButton;

        void Awake() {

            pauseReturnButton.onClick.AddListener(() => {
                UIController.OnReturnGameEvent(this, EventArgs.Empty);
            });

            exitButton.onClick.AddListener(() => 
                UIController.OnBackToTitleEvent(this, EventArgs.Empty)
            );

            retryButton.onClick.AddListener(() =>
                UIController.OnRetryEvent(this, EventArgs.Empty)
            );

            this.Hide();

        }

        public void PopupPause(object sender, EventArgs args) {

            if (bd.activeSelf) {

                bd.SetActive(false);
                PlayerController.OnRestorePauseEvent(this, EventArgs.Empty);

            } else {

                bd.SetActive(true);

                pauseReturnButton.Show();
                congratulationButton.Hide();
                gameOverButton.Hide();

            }

        }

        public void PopupGameOver(object sender, EventArgs args) {

            bd.SetActive(true);
            pauseReturnButton.Hide();
            congratulationButton.Hide();
            gameOverButton.Show();

        }

        public void PopupFinishedGame(object sender, EventArgs args) {

            bd.SetActive(true);
            pauseReturnButton.Hide();
            congratulationButton.Show();
            gameOverButton.Hide();

        }

    }
}