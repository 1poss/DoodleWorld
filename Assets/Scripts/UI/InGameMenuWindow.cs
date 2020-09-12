using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class InGameMenuWindow : MonoBehaviour {

        // 标题语
        public Button pauseReturnButton;
        public Button congratulationButton;
        public Button gameOverButton;
        public Text passGameTimeTxt;

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

            // this.Hide();

        }

        public void PopupPause(object sender, EventArgs args) {

            print(gameObject.activeSelf);

            if (gameObject.activeSelf) {

                this.Hide();
                PlayerController.OnRestorePauseEvent(this, EventArgs.Empty);

            } else {

                this.Show();

                pauseReturnButton.Show();
                congratulationButton.Hide();
                gameOverButton.Hide();

            }

        }

        public void PopupGameOver(object sender, EventArgs args) {

            this.Show();
            pauseReturnButton.Hide();
            congratulationButton.Hide();
            gameOverButton.Show();

        }

        public void PopupFinishedGame(object sender, EventArgs args) {

            this.Show();
            pauseReturnButton.Hide();
            congratulationButton.Show();
            passGameTimeTxt.text = App.Instance.passGameTime.ToString();
            gameOverButton.Hide();

        }

    }
}