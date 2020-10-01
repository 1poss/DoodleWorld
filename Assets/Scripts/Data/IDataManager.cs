using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public interface IDataManager {

        void NewId(string uid, string username);
        void AddLevelTime(float time);
        void AddDeadTimes(int times);

        GameData GetData();

    }
}