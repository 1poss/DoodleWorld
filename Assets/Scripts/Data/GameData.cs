using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using JackUtil;

namespace DoodleWorldNS {

    [Serializable]
    public class GameData {

        static string dirPath;
        static string filePath;

        [NonSerialized]
        GameData lastData;
        public string uid;
        public string username;
        public string currentLevel;

        public float totalTime;
        public float totalDeadTimes;
        public Dictionary<string, float> levelBestTimeDic;
        public Dictionary<string, int> levelDeadTimesDic;

        public GameData(string dirPath, string filePath) {

            GameData.dirPath = dirPath;
            GameData.filePath = filePath;

            GameData gd = LoadWithSearching();

            if (gd == null) {

                uid = "";
                username = "";
                currentLevel = "";
                totalTime = 999999999;
                totalDeadTimes = 0;
                levelBestTimeDic = new Dictionary<string, float>();
                levelDeadTimesDic = new Dictionary<string, int>();
                lastData = null;

            } else {

                uid = gd.uid;
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

            string[] gdFiles = Directory.GetFiles(dirPath, "data.gd");

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

            FileUtil.SaveFile(this, dirPath, filePath);
            
        }

    }
}