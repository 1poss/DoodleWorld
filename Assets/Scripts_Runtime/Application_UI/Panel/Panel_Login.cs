using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodleWorldNS {

    public class Panel_Login : MonoBehaviour {

        [SerializeField] Button startGameButton;
        [SerializeField] Button exitGameButton;

        public Action OnStartHandle;
        public Action OnExitHandle;

        public void Ctor() {

            startGameButton.onClick.AddListener(() => {
                OnStartHandle.Invoke();
            });

            exitGameButton.onClick.AddListener(() => {
                OnExitHandle.Invoke();
            });

        }

        public void Destory() {
            GameObject.Destroy(gameObject);
        }

        void OnDestroy() {
            startGameButton.onClick.RemoveAllListeners();
            exitGameButton.onClick.RemoveAllListeners();
        }

    }
}