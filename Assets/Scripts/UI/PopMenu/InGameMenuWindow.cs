using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class InGameMenuWindow : MonoBehaviour {

        // 按钮
        // ---- Victory ----
        [Header("Victory")]
        public GameObject victoryBD;
        public Button newGameButton; // 新游戏
        public Button showTimeBoardButton; // 查看速通榜
        public Button showDeadBoardButton; // 查看死亡次数榜

        // ---- GameOver ----
        [Header("GameOver")]
        public GameObject gameOverBD;
        public Button showAdButton; // 看广告复活
        public Button newGameInGameOverButton; // 新游戏
        public Button showDeadBoardInGameOverButton; // 查看死亡次数榜

        // ---- Pause ----
        [Header("Pause")]
        public GameObject pauseBD;
        public Button retryButton; // 重玩本关
        public Button continueButton; // 继续游戏
        public Button showDeadBoardInPauseButton; // 查看死亡次数榜

        void Awake() {

            // ---- Victory ----
            newGameButton.onClick.AddListener(() => {
                UIController.OnStartGameEvent(this, EventArgs.Empty);
            });

            showTimeBoardButton.onClick.AddListener(() => {

            });

            showDeadBoardButton.onClick.AddListener(() => {

            });

            // ---- GameOver ----
            showAdButton.onClick.AddListener(() => {
                UIController.OnRetryEvent(this, EventArgs.Empty);
            });

            newGameInGameOverButton.onClick.AddListener(() => {
                UIController.OnStartGameEvent(this, EventArgs.Empty);
            });


            showDeadBoardInGameOverButton.onClick.AddListener(() => {
                
            });

            // ---- Pause ----
            retryButton.onClick.AddListener(() => {
                UIController.OnRetryEvent(this, EventArgs.Empty);
            });

            continueButton.onClick.AddListener(() => {
                UIController.OnReturnGameEvent(this, EventArgs.Empty);
            });

            showDeadBoardInPauseButton.onClick.AddListener(() => {

            });

        }

        public void PopupPause(object sender, EventArgs args) {

            print(gameObject.activeSelf);

            if (gameObject.activeSelf) {

                this.Hide();
                PlayerController.OnRestorePauseEvent(this, EventArgs.Empty);

            } else {

                this.Show();

                pauseBD.SetActive(true);
                gameOverBD.SetActive(false);
                victoryBD.SetActive(false);

            }

        }

        public void PopupGameOver(object sender, EventArgs args) {

            this.Show();

            pauseBD.SetActive(false);
            gameOverBD.SetActive(true);
            victoryBD.SetActive(false);

        }

        public void PopupFinishedGame(object sender, EventArgs args) {

            this.Show();
            pauseBD.SetActive(false);
            gameOverBD.SetActive(false);
            victoryBD.SetActive(true);

        }

    }
}