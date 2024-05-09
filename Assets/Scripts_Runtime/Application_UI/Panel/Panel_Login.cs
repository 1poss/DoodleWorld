using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DoodleWorldNS {

    public class Panel_Login : MonoBehaviour {

        [SerializeField] TextMeshProUGUI titleTxt;
        [SerializeField] Button newGameButton;
        [SerializeField] Button exitGameButton;

        public Action OnNewGameHandle;
        public Action OnExitHandle;

        public void Ctor() {

            {
                titleTxt.text = TextConst.Game_GameName;
            }
            {
                var txt = newGameButton.GetComponentInChildren<TextMeshProUGUI>();
                txt.text = TextConst.P_Login_Btn_StartGame;
            }
            {
                var txt = exitGameButton.GetComponentInChildren<TextMeshProUGUI>();
                txt.text = TextConst.P_Login_Btn_Exit;
            }

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