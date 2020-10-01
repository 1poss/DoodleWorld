using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Level : MonoBehaviour {

        IUIManager ui;
        IWorldManager world;

        public string levelTitle;
        public string levelUid;
        public Transform startPos;
        Vector2 defaultPos;

        public MapBorder mapBorder;

        protected virtual void Awake() {

            defaultPos = startPos.position;

        }

        public void Inject(IUIManager ui, IWorldManager world) {
            this.ui = ui;
            this.world = world;
        }

        public void LoadLevel(Player player) {

            player.transform.position = defaultPos;

        }

        public void FinishedGame(Player player) {

            ui.FinishGame();
            player.Pause();

        }

        void OnDestroy() {

        }

    }
}