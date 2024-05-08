using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodleWorldNS {

    public class Panel_Login : MonoBehaviour {

        [SerializeField] Button newGameButton;
        [SerializeField] Button exitGameButton;

        public Action OnNewGameHandle;
        public Action OnExitHandle;

        public void Ctor() {

            newGameButton.onClick.AddListener(() => {
                OnNewGameHandle.Invoke();
            });

            exitGameButton.onClick.AddListener(() => {
                OnExitHandle.Invoke();
            });

        }

        public void TearDown() {
            GameObject.Destroy(gameObject);
        }

        void OnDestroy() {
            newGameButton.onClick.RemoveAllListeners();
            exitGameButton.onClick.RemoveAllListeners();
        }

    }
}