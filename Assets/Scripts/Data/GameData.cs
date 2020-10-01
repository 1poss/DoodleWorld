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

        public string uid;
        public string username;
        public string currentLevel;

        public float currentTime;
        public float currentDeadTimes;

        public GameData(string dirPath, string filePath) {

            GameData.dirPath = dirPath;
            GameData.filePath = filePath;

            GameData gd = LoadWithSearching();

            if (gd == null) {

                uid = "";
                username = "";
                currentLevel = "";
                currentTime = 0;
                currentDeadTimes = 0;

            } else {

                uid = gd.uid;
                username = gd.username;
                currentLevel = gd.currentLevel;
                currentTime = gd.currentTime;
                currentDeadTimes = gd.currentDeadTimes;

            }

        }

        public void Reset() {

            currentLevel = App.Instance.world.GetStartLevel();
            currentTime = 0;
            currentDeadTimes = 0;

        }

        public void AddTime(float time) {
            currentTime += time;
        }

        public void AddDeadTimes(int times) {
            currentDeadTimes += times;
        }

        GameData LoadWithSearching() {

            string[] gdFiles = Directory.GetFiles(dirPath, filePath);

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