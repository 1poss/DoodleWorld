using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public interface IWorldManager {

        void Inject(IUIManager ui, IWebManager web);
        void LoadLevel();
        void LoadLevel(string levelId);
        void SetPlayer(Player player);
        Player GetPlayer();
        void SetMap(MapBorder map);
        MapBorder GetMap();


    }

}