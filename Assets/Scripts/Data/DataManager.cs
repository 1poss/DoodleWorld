using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class DataManager : MonoBehaviour, IDataManager {

        GameData data;

        public void Init() {

            data = new GameData(Application.dataPath, "/uid");

        }

        public void Inject() {

        }

        public void NewId(string uid, string username) {

            data.uid = uid;
            data.username = username;
            data.SaveData();

        }

        public void NewGame() {

            data.Reset();
            
        }

        public void AddLevelTime(float time) {

            data.AddTime(time);

        }

        public void AddDeadTimes(int times) {

            data.AddDeadTimes(times);

        }

        public GameData GetData() => data;

    }
}