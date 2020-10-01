using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public interface IWorldManager {

        void Dead();
        string GetNewGameLevel();
        void LoadLevel();
        void LoadLevel(string levelId);
        void SetPlayer(Player player);
        Player GetPlayer();
        void RestorePause();
        Level GetLevel();
        void SetMap(MapBorder map);
        MapBorder GetMap();


    }

}