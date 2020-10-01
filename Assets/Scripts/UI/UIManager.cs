using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public sealed class UIManager : MonoBehaviour, IUIManager {

        IWorldManager world;
        IWebManager web;
        IDataManager data;

        public UnityAd ad;

        public TitlePanel titlePanel;
        public LifePanel lifePanel;
        public InGameMenuWindow inGameMenuWindow;
        public InputNameWindow inputNameWindow;

        public Text timerTxt;

        public void Inject(IWorldManager world, IWebManager web) {

            this.world = world;
            this.web = web;

            titlePanel.Inject(this);
            lifePanel.Inject(this);
            inputNameWindow.Inject(this, web);
            inGameMenuWindow.Inject(this);
            ad.Inject(this);

        }

        public void Init() {

            titlePanel.Init();
            inputNameWindow.Init();
            inGameMenuWindow.Init();

            EnterRegister();

        }

        void FixedUpdate() {

            if (App.Instance == null) {

                return;

            }

            // timerTxt.text = string.Format("{0:f2}", App.Instance.passGameTime);

        }

        public void PauseGame() {

            inGameMenuWindow.PopupPause();

        }

        public void RestorePauseGame() {

            inGameMenuWindow.PopupPause();
            world.RestorePause();

        }

        public void RetryLevel() {

            world.LoadLevel();

            inGameMenuWindow.Hide();

        }

        public void EnterRegister() {

            // 找存档
            // 如果有则读取, 并执行IWeb.Login(string uid)
            GameData gameData = data.GetData();
            if (gameData.uid != "" && gameData.uid.Length >= 32) {

                EnterTitle(gameData.username);

            // 如果无存档, 显示注册窗
            } else {

                // 弹出输入名称的UI
                inputNameWindow.Show();
                inputNameWindow.Reset();

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

            print("进入Title, 昵称是: " + username);

            titlePanel.Show();
            inputNameWindow.Hide();
            inGameMenuWindow.Hide();
            lifePanel.Hide();

            timerTxt.Hide();

            AudioController.OnPlayBGMEvent(this, false);
            
        }

        public void EnterGame(bool isNewGame = false) {

            titlePanel.Hide();
            inGameMenuWindow.Hide();

            timerTxt.Show();

            AudioController.OnPlayBGMEvent(this, true);

            if (isNewGame) {

                world.LoadLevel(world.GetNewGameLevel());

            } else {

                world.LoadLevel(world.GetStartLevel());

            }

        }

        public void LoadLife(Player player) {

            lifePanel.LoadLife(player);

        }

        public void AddLife(Player player, int number = 1) {

            lifePanel.AddLife(player, number);

        }

        public void ReduceLife(Player player, int number = 1) {

            lifePanel.ReduceLife(player, number);

        }

        public void GameOver() {

            inGameMenuWindow.PopupGameOver();

        }

        public void FinishGame() {

            inGameMenuWindow.PopupFinishedGame();

        }

        public void ShowAd() {

            world.SetStartLevel(world.GetLevel().levelUid);
            ad.ShowRewardedVideo();

        }

        public void AdFinished() {

            EnterGame(false);

        }

        public void AdSkiped() {

        }

    }
}