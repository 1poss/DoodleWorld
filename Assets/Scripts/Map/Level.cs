using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class Level : MonoBehaviour {

        public string levelTitle;
        public string levelUid;
        public Transform startPos;
        Vector2 defaultPos;

        public MapBorder mapBorder;

        protected virtual void Awake() {

            LevelController.ReloadLevelEvent += LoadLevel;

            defaultPos = startPos.position;

        }

        public void LoadLevel(object sender, Player player) {

            player.transform.position = defaultPos;

        }

        public void FinishedGame() {

            App.Instance.StopTimer();
            UIController.OnPopupFinishedGameEvent(this, EventArgs.Empty);
            PlayerController.OnPauseEvent(this, EventArgs.Empty);

        }

        void OnDestroy() {

            LevelController.ReloadLevelEvent -= LoadLevel;

        }

    }
}