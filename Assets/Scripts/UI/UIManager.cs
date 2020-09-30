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
        public InputNameWindow inputNameWindow;

        public Text timerTxt;

        void Awake() {

            // 标题

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

        }

        public void Inject(IWorldManager world, IWebManager web) {

            this.world = world;
            this.web = web;

            titlePanel.Inject(this);
            lifePanel.Inject(this);
            inputNameWindow.Inject(this, web);
            inGameMenuWindow.Inject(this);

        }

        public void Init() {

            titlePanel.Init();
            inputNameWindow.Init();

            EnterRegister();

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

        public void EnterRegister() {

            // 找存档
            // 如果有则读取, 并执行IWeb.Login(string uid)
            gameData = new GameData(Application.dataPath, "data.db");
            if (gameData.uid != "") {

                EnterTitle(gameData.username);

            // 如果无存档, 显示注册窗
            } else {

                // 弹出输入名称的UI
                inputNameWindow.Show();
                inputNameWindow.Reset();
                UIController.OnPopUsernameInputFieldEvent(this, EventArgs.Empty);

            }

        }

        public void RegisterFailed(string msg) {

            inputNameWindow.RegisterFailed(msg);

        }

        public void LoginFailed(string msg) {

            // 显示重试 / 离线模式
            print("LoginFailed: " + msg);

        }

        public void EnterTitle(string username) {

            titlePanel.Show();
            inputNameWindow.Hide();
            inGameMenuWindow.Hide();
            lifePanel.Hide();

            timerTxt.Hide();

            AudioController.OnPlayBGMEvent(this, false);
            
        }

        public void EnterGame() {

            titlePanel.Hide();
            inGameMenuWindow.Hide();

            timerTxt.Show();

            AudioController.OnPlayBGMEvent(this, true);

            world.LoadLevel(App.Instance.debugLevel);

        }

    }
}