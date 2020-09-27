using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace DoodleWorldNS {

    [Serializable]
    public class GameData {

        [NonSerialized]
        GameData lastData;
        public string username;
        public string currentLevel;

        public float totalTime;
        public float totalDeadTimes;
        public Dictionary<string, float> levelBestTimeDic;
        public Dictionary<string, int> levelDeadTimesDic;

        public GameData() {

            GameData gd = LoadWithSearching();

            if (gd == null) {

                username = "";
                currentLevel = "";
                totalTime = 999999999;
                totalDeadTimes = 0;
                levelBestTimeDic = new Dictionary<string, float>();
                levelDeadTimesDic = new Dictionary<string, int>();
                lastData = null;

            } else {

                username = gd.username;
                currentLevel = gd.currentLevel;
                totalTime = gd.totalTime;
                totalDeadTimes = gd.totalDeadTimes;
                levelBestTimeDic = gd.levelBestTimeDic;
                levelDeadTimesDic = gd.levelDeadTimesDic;
                lastData = gd;

            }

        }

        GameData LoadWithSearching() {

            string[] gdFiles = Directory.GetFiles(Application.dataPath, "data.gd");

            if (gdFiles.Length == 0) {

                return null;

            } else {

                string file = gdFiles[0];
                GameData gd = FileUtil.LoadData<GameData>(file);
                if (gd == null) {
                    File.Delete(file);
                    return null;
                }
                return gd;

            }

        }

        public void SaveData() {

            FileUtil.SaveFile(this, Application.dataPath, "/data.gd");
            
        }

    }
}