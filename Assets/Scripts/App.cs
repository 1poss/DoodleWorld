using System;
using System.Threading.Tasks;
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
        public JcpHelper jcp;
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

        // ---- AD ----
        // public MyAd myAd;

        // ---- UI ----
        public UIManager uiManager;

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

            // HttpClient Example
            // httpHelper = new HttpHelper("http://127.0.0.1:9106");

            // TcpClient Example
            // jcp = new JcpHelper("127.0.0.1", 9107);
            // jcp.AddEventListener("Test", packet => {
            //     DebugUtil.Log("从服务端收到: " + packet.o);
            // });
            // jcp.StartRecieving();

            // ---- 载入广告 ----
            // myAd.Init();
            uiManager.Init();

        }

        void FixedUpdate() {

            if (isStartTimer) {

                passGameTime += Time.fixedDeltaTime;

            }

            if (Input.GetAxisRaw("Jump") != 0) {

                jcp.EmitEvent("Test", "nihao");

            }

            if (Input.GetAxisRaw("Vertical") != 0) {

                jcp.Abort();

            }

            if (Input.GetAxisRaw("Horizontal") != 0) {

                jcp.StartRecieving();

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

        void OnDestroy() {

            print("Abort");
            jcp?.Abort();
            
        }

    }

}