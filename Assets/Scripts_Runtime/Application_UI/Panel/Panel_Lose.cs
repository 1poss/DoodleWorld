using System;
using UnityEngine;
using UnityEngine.UI;

namespace DoodleWorldNS.UIApplication {

    public class Panel_Lose : MonoBehaviour {

        [SerializeField] Button btnSeeAd;
        [SerializeField] Button btnRestart;

        public Action OnSeeAdHandle;
        public Action OnRestartHandle;

        public void Ctor() {
            btnSeeAd.onClick.AddListener(() => {
                OnSeeAdHandle?.Invoke();
            });
            btnRestart.onClick.AddListener(() => {
                OnRestartHandle?.Invoke();
            });
        }

        public void TearDown() {
            btnSeeAd.onClick.RemoveAllListeners();
            btnRestart.onClick.RemoveAllListeners();
            GameObject.Destroy(gameObject);
        }

    }
}