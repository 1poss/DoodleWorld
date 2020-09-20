using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public sealed class App : MonoBehaviour {

        static App m_instance;
        public static App Instance => m_instance;

        // ---- WEB ----
        public HttpHelper httpHelper;
        public Account account;

        // ---- GAME ----
        public Player playerPrefab;
        Player player;

        Dictionary<string, Level> levelPrefabDic;
        public Level currentLevel;

        public string debugLevel;
        public GameObject debugMapEditor;

        Camera cam;

        public float passGameTime;
        bool isStartTimer;

        void Start() {

            if (m_instance == null) {
                m_instance = this;
            }

            Application.targetFrameRate = 120;

            DontDestroyOnLoad(gameObject);

            InitGame();

            if (debugMapEditor != null && debugMapEditor.activeSelf) {

                Destroy(debugMapEditor);

            }

            // TODO WebRequest
            // httpHelper = new HttpHelper("http://127.0.0.1:9105");
            // account = new Account(httpHelper);
            // account.username = "cw";
            // account.pwd = "chenwansal";
            // account.verifyCode = "334422";
            // account.Login((err) => {

            //     DebugUtil.LogError(err);

            // },(result) => {

            //     DebugUtil.Log(result);

            // });

        }

        void FixedUpdate() {

            if (isStartTimer) {

                passGameTime += Time.fixedDeltaTime;

            }

        }

        void InitGame() {

            // 缓存所有关卡预置体
            levelPrefabDic = new Dictionary<string, Level>();

            Level[] levelPrefabs = Resources.LoadAll<Level>("Levels");
            for (int i = 0; i < levelPrefabs.Length; i += 1) {
                Level lv = levelPrefabs[i];
                lv.transform.position = Vector3.zero;
                levelPrefabDic.Add(lv.levelUid, lv);
            }

        }

        public void LoadLevel(string levelUid) {

            // 载入玩家
            if (player == null) {

                player = Instantiate(playerPrefab);

            }

            player.ResetPhysics();
            player.InitValue();

            // 载入关卡
            if (currentLevel != null) {

                Destroy(currentLevel.gameObject);

            }

            Level lvPrefab = levelPrefabDic.GetValue(levelUid);
            currentLevel = Instantiate(lvPrefab);
            currentLevel.LoadLevel(this, player);

            // 加载UI
            UIController.OnLoadLifeEvent(this, player);

            // 相机跟随
            cam = cam ?? Camera.main;
            cam.FollowTargetLimited(true, player.transform.position, currentLevel.mapBorder.borderTilemap, currentLevel.mapBorder.bounds, ConfigCollection.cameraOffset);

        }

        public void StartTimer() {

            isStartTimer = true;
            passGameTime = 0;

        }

        public void StopTimer() {

            isStartTimer = false;

        }

    }

}