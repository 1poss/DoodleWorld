using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public sealed class UIManager : MonoBehaviour {

        public WorldManager world;
        public WebManager web;
        public DataManager data;

        public UnityAd ad;

        public bool isGaming;
        public TitlePanel titlePanel;
        public LifePanel lifePanel;
        public InGameMenuWindow inGameMenuWindow;
        public InputNameWindow inputNameWindow;

        public Text timerTxt;

        public Text debugText;

        public void Init() {

            titlePanel.Init();
            inputNameWindow.Init();
            inGameMenuWindow.Init();

            EnterRegister();

        }

        void Update() {

            if (isGaming) {

                data.AddLevelTime(Time.deltaTime);

            }

            if (data != null && data.GetData() != null) {

                GameData gd =  data.GetData();

                debugText.text = "uid: " + gd.uid
                                + "\n\rusername: " + gd.username
                                + "\n\rtime: " + gd.currentTime 
                                + "\n\rcurrentDeadTime: " + gd.currentDeadTimes
                                + "\n\rtotalDeadTimes: " + gd.totalDeadTimes;

            }

        }

        public void PauseGame() {

            inGameMenuWindow.PopupPause();
            isGaming = false;

        }

        public void RestorePauseGame() {

            inGameMenuWindow.PopupPause();
            world.RestorePause();
            isGaming = true;

        }

        public void RetryLevel() {

            world.LoadLevel();

            inGameMenuWindow.Hide();
            isGaming = true;

        }

        public async void EnterRegister() {

            // 找存档
            // 如果有则读取, 并执行IWeb.Login(string uid)
            GameData gameData = data.GetData();
            if (gameData.uid != "" && gameData.uid.Length >= 32) {

                await web.PostLogin(gameData.uid);
                EnterTitle(gameData.username);

            // 如果无存档, 显示注册窗
            } else {

                // 弹出输入名称的UI
                inputNameWindow.Show();
                inputNameWindow.Reset();

            }

            isGaming = false;

        }

        public void RegisterFailed(string msg) {

            inputNameWindow.RegisterFailed(msg);

        }

        public void LoginFailed(string msg) {

            // 显示重试 / 离线模式
            print("LoginFailed: " + msg);

        }

        public void EnterTitle(string username) {

            // 进入标题时 读取用户数据(死亡次数)
            titlePanel.Show();
            inputNameWindow.Hide();
            inGameMenuWindow.Hide();
            lifePanel.Hide();

            timerTxt.Hide();

            AudioController.OnPlayBGMEvent(this, false);
            isGaming = false;
            
        }

        public void EnterGame(bool isNewGame = false) {

            titlePanel.Hide();
            inGameMenuWindow.Hide();

            timerTxt.Show();

            AudioController.OnPlayBGMEvent(this, true);

            if (isNewGame) {

                data.NewGame();
                world.LoadLevel(world.GetNewGameLevel());

            } else {

                world.LoadLevel(data.GetData().currentLevel);

            }

            isGaming = true;

        }

        public void LoadLife(Player player) {

            lifePanel.LoadLife(player);

        }

        public void AddLife(Player player, int number = 1) {

            lifePanel.AddLife(player, number);

        }

        public void ReduceLife(Player player, int number = 1) {

            lifePanel.ReduceLife(player, number);
            data.AddDeadTimes(1);

        }

        public void GameOver() {

            inGameMenuWindow.PopupGameOver();

        }

        public async void FinishGame() {

            inGameMenuWindow.PopupFinishedGame();
            isGaming = false;
            data.GetData().SaveData();
            await web.PostFinalData();

        }

        public void ShowAd() {

            ad.ShowRewardedVideo();

        }

        public void AdFinished() {

            EnterGame(false);

        }

        public void AdSkiped() {

        }

    }
}