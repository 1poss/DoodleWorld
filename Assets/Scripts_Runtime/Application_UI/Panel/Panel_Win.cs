using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameFunctions;

namespace DoodleWorldNS.UIApplication {

    public class Panel_Win : MonoBehaviour {

        [SerializeField] TextMeshProUGUI timeTxt;
        [SerializeField] Button winBtn;

        public Action OnWinConfirmHandle;

        public void Ctor() {

            {
                var txt = winBtn.GetComponentInChildren<TextMeshProUGUI>();
                txt.text = TextConst.P_Win_Btn_Win;
            }

            winBtn.onClick.AddListener(() => {
                OnWinConfirmHandle.Invoke();
            });

        }

        public void TearDown() {
            GameObject.Destroy(gameObject);
        }

        public void SetTime(float time) {
            timeTxt.text = $"耗时：{time.ToString("F3")} 秒";
        }

    }
}