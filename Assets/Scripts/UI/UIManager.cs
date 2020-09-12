using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public sealed class UIManager : MonoBehaviour {

        public TitlePanel titlePanel;
        public LifePanel lifePanel;
        public InGameMenuWindow inGameMenuWindow;

        void Awake() {

            // 标题
            UIController.StartGameEvent += StartGame;

            // 生命值
            UIController.LoadLifeEvent += lifePanel.LoadLife;
            UIController.AddLifeEvent += lifePanel.AddLife;
            UIController.ReduceLifeEvent += lifePanel.ReduceLife;

            // 弹出菜单
            UIController.PopupPauseEvent += inGameMenuWindow.PopupPause;
            UIController.PopupGameOverEvent += inGameMenuWindow.PopupGameOver;
            UIController.PopupFinishedGameEvent += inGameMenuWindow.PopupFinishedGame;

            // 菜单行为
            UIController.RetryEvent += RetryLevel;
            UIController.BackToTitleEvent += BackToTitle;

            BackToTitle(this, EventArgs.Empty);

        }

        void ReturnGame(object sender, EventArgs args) {

            PlayerController.OnRestorePauseEvent(this, args);

        }

        void RetryLevel(object sender, EventArgs args) {

            App.Instance.LoadLevel(App.Instance.currentLevel.levelUid);

            inGameMenuWindow.Hide();

        }

        void BackToTitle(object sender, EventArgs args) {

            inGameMenuWindow.Hide();

            lifePanel.bd.SetActive(false);

            titlePanel.Show();

            AudioController.OnPlayBGMEvent(this, false);

        }

        void StartGame(object sender, EventArgs args) {

            titlePanel.Hide();

            AudioController.OnPlayBGMEvent(this, true);

            App.Instance.LoadLevel("C0L0A");

        }

    }
}