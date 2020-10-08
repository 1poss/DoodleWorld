using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class WorldManager : MonoBehaviour {

        public UIManager ui;
        public WebManager web;
        public AudioManager audioPlayer;
        public DataManager data;

        public string newGameLevel;

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

            if (player == null) {

                player = Instantiate(playerPrefab);

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

        public string GetNewGameLevel() => newGameLevel;

        public void Dead() {

            currentLevel?.LoadLevel(player);

        }

        public void LoadLevel() {

            LoadLevel(currentLevel.levelUid);

        }

        public void LoadLevel(string levelUid) {

            // 载入玩家
            player.ResetPhysics();
            player.InitValue();

            // 载入关卡
            if (currentLevel != null) {

                Destroy(currentLevel.gameObject);

            }

            Level lvPrefab = levelPrefabDic.GetValue(levelUid);
            currentLevel = Instantiate(lvPrefab);
            currentLevel.LoadLevel(player);
            currentLevel.Inject(ui, this);
            data.GetData().currentLevel = currentLevel.levelUid;

            // 加载UI
            ui.LoadLife(player);

            // 相机跟随
            cam = cam ?? Camera.main;
            cam.FollowTargetLimited(true, player.transform.position, currentLevel.mapBorder.borderTilemap, currentLevel.mapBorder.bounds, ConfigCollection.cameraOffset);

        }

        public void SetPlayer(Player player) => this.player = player;
        public Level GetLevel() => currentLevel;

        public Player GetPlayer() => player;

        public void RestorePause() {

            player.RestorePause();

        }

        public void SetMap(MapBorder map) => this.map = map;

        public MapBorder GetMap() => map;

    }

}