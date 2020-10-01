using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class InGameMenuWindow : MonoBehaviour {

        [NonSerialized]
        IUIManager ui;

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

        public void Inject(IUIManager ui) {
            this.ui = ui;
        }

        public void Init() {

            // ---- Victory ----
            newGameButton.onClick.AddListener(() => {
                ui.EnterGame(true);
            });

            showTimeBoardButton.onClick.AddListener(() => {

            });

            showDeadBoardButton.onClick.AddListener(() => {

            });

            // ---- GameOver ----
            showAdButton.onClick.AddListener(ui.ShowAd);

            newGameInGameOverButton.onClick.AddListener(() => {
                ui.EnterGame(true);
            });

            showDeadBoardInGameOverButton.onClick.AddListener(() => {
                
            });

            // ---- Pause ----
            retryButton.onClick.AddListener(ui.RetryLevel);

            continueButton.onClick.AddListener(ui.RestorePauseGame);

            showDeadBoardInPauseButton.onClick.AddListener(() => {

            });

        }

        public void PopupPause() {

            if (gameObject.activeSelf) {

                this.Hide();
                ui.RestorePauseGame();

            } else {

                this.Show();

                pauseBD.SetActive(true);
                gameOverBD.SetActive(false);
                victoryBD.SetActive(false);

            }

        }

        public void PopupGameOver() {

            this.Show();

            pauseBD.SetActive(false);
            gameOverBD.SetActive(true);
            victoryBD.SetActive(false);

        }

        public void PopupFinishedGame() {

            this.Show();
            pauseBD.SetActive(false);
            gameOverBD.SetActive(false);
            victoryBD.SetActive(true);

        }

    }
}