using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class WorldManager : MonoBehaviour, IWorldManager {

        [NonSerialized]
        IUIManager ui;
        [NonSerialized]
        IWebManager web;

        public Player playerPrefab;
        Player player;
        MapBorder map;
        Camera cam;

        Dictionary<string, Level> levelPrefabDic;
        [HideInInspector]
        public Level currentLevel;

        void Awake() {

            // 缓存所有关卡预置体
            levelPrefabDic = new Dictionary<string, Level>();

            Level[] levelPrefabs = Resources.LoadAll<Level>("Levels");
            for (int i = 0; i < levelPrefabs.Length; i += 1) {
                Level lv = levelPrefabs[i];
                lv.transform.position = Vector3.zero;
                levelPrefabDic.Add(lv.levelUid, lv);
            }

        }

        void Update() {

            if (player == null) {

                return;

            }

            // 相机跟随
            if (currentLevel != null) {

                cam.FollowTargetLimited(false, player.transform.position, currentLevel.mapBorder.borderTilemap, currentLevel.mapBorder.bounds, ConfigCollection.cameraOffset);

            }

        }

        public void Inject(IUIManager ui, IWebManager web) {

            this.ui = ui;
            this.web = web;

        }

        public void LoadLevel() {

            LoadLevel(currentLevel.levelUid);

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

        public void SetPlayer(Player player) {
            
            this.player = player;

        }

        public Player GetPlayer() => player;

        public void SetMap(MapBorder map) {

            this.map = map;

        }

        public MapBorder GetMap() => map;

    }

}