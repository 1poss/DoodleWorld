using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public sealed class UIManager : MonoBehaviour, IUIManager {

        [NonSerialized]
        IWorldManager world;
        [NonSerialized]
        IWebManager web;

        public UnityAd ad;

        public GameData gameData;

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

        public void Inject(IWorldManager world, IWebManager web) {

            this.world = world;
            this.web = web;

            titlePanel.Inject(this);
            lifePanel.Inject(this);
            inGameMenuWindow.Inject(this);

        }

        public void Init() {

            titlePanel.Init();

        }

        void FixedUpdate() {

            if (App.Instance == null) {

                return;

            }

            // timerTxt.text = string.Format("{0:f2}", App.Instance.passGameTime);

        }

        void ReturnGame(object sender, EventArgs args) {

            PlayerController.OnRestorePauseEvent(this, args);

        }

        void RetryLevel(object sender, EventArgs args) {

           world.LoadLevel();

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

            world.LoadLevel(App.Instance.debugLevel);

        }

        public void EnterRegister() {

            // 找存档
            // 如果有则读取, 并执行IWeb.Login(string uid)
            gameData = new GameData(Application.dataPath, "data.db");
            if (gameData.uid != "") {

                EnterTitle(gameData.username);

            // 如果无存档, 显示注册窗
            } else {

                // 弹出输入名称的UI
                UIController.OnPopUsernameInputFieldEvent(this, EventArgs.Empty);

            }

        }

        public void RegisterFailed(string msg) {

            print("Register Failed: " + msg);

        }

        public void LoginFailed(string msg) {

            // 显示重试 / 离线模式
            print("LoginFailed: " + msg);

        }

        public void EnterTitle(string username) {
            
        }

        public void EnterGame() {

        }

    }
}