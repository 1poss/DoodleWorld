using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public sealed class UIManager : MonoBehaviour, IUIManager {

        IWebManager web;

        public TitlePanel titlePanel;
        public LifePanel lifePanel;
        public InGameMenuWindow inGameMenuWindow;

        public Text timerTxt;

        void Awake() {

            // 标题
            UIController.StartGameEvent += StartGame;

            // 生命值
            UIController.LoadLifeEvent += lifePanel.LoadLife;
            UIController.AddLifeEvent += lifePanel.AddLife;
            UIController.ReduceLifeEvent += lifePanel.ReduceLife;

            // 弹出菜单
            UIController.PopupPauseEvent += inGameMenuWindow.PopupPause;
            UIController.ReturnGameEvent += inGameMenuWindow.PopupPause;
            UIController.PopupGameOverEvent += inGameMenuWindow.PopupGameOver;
            UIController.PopupFinishedGameEvent += inGameMenuWindow.PopupFinishedGame;

            // 菜单行为
            UIController.RetryEvent += RetryLevel;
            UIController.BackToTitleEvent += BackToTitle;

            BackToTitle(this, EventArgs.Empty);

        }

        public void Init() {

            titlePanel.Init();
            
        }

        void FixedUpdate() {

            if (App.Instance == null) {

                return;

            }

            timerTxt.text = string.Format("{0:f2}", App.Instance.passGameTime);

        }

        void ReturnGame(object sender, EventArgs args) {

            PlayerController.OnRestorePauseEvent(this, args);

        }

        void RetryLevel(object sender, EventArgs args) {

            App.Instance.LoadLevel(App.Instance.currentLevel.levelUid);

            inGameMenuWindow.Hide();

        }

        void BackToTitle(object sender, EventArgs args) {

            titlePanel.Show();
            inGameMenuWindow.Hide();

            lifePanel.Hide();

            timerTxt.Hide();

            AudioController.OnPlayBGMEvent(this, false);

        }

        void StartGame(object sender, EventArgs args) {

            titlePanel.Hide();
            inGameMenuWindow.Hide();

            timerTxt.Show();

            AudioController.OnPlayBGMEvent(this, true);

            App.Instance.LoadLevel(App.Instance.debugLevel);
            App.Instance.StartTimer();

        }

    }
}