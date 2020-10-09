using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class InputNameWindow : MonoBehaviour {

        public WebManager web;
        public UIManager ui;

        public InputField nameInputField;
        public Text wrongText;
        public Button yesButton;
        public Button noButton;

        public void Init() {

            yesButton.onClick.AddListener(async () => {

                string nname = nameInputField.text;

                bool hasBlock = WordFilterUtil.IsBlockWord(nname);

                if (!hasBlock) {

                    bool isSucc = await web.PostRegister(nameInputField.text);

                } else {

                    wrongText.text = "名字包含非法关键词";

                }

            });

            noButton.onClick.AddListener(() => {

                ui.EnterTitle();

            });

        }

        public void Reset() {

            nameInputField.text = "";
            wrongText.text = "";

        }

        public void RegisterFailed(string msg) {

            wrongText.text = msg;
            
        }

        void OnDestroy() {

            yesButton.onClick.RemoveAllListeners();

        }

    }
}