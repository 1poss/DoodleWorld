using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public sealed class UIManager : MonoBehaviour {

        public LifePanel lifePanel;
        public InGameMenuWindow inGameMenuWindow;

        void Awake() {

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

        }

        void ReturnGame(object sender, EventArgs args) {

            PlayerController.OnRestorePauseEvent(this, args);

        }

        void RetryLevel(object sender, EventArgs args) {

            App.Instance.LoadLevel(App.Instance.currentLevel.levelUid);

            inGameMenuWindow.bd.SetActive(false);

        }

        void BackToTitle(object sender, EventArgs args) {

            inGameMenuWindow.bd.SetActive(false);

            print("未实现");

        }

    }
}