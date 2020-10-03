using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class InputNameWindow : MonoBehaviour {

        IWebManager web;
        IUIManager ui;

        public InputField nameInputField;
        public Text wrongText;
        public Button yesButton;
        public Button noButton;

        public void Inject(IUIManager ui, IWebManager web) {

            this.ui = ui;
            this.web = web;

        }

        public void Init() {

            yesButton.onClick.AddListener(async () => {

                string nname = nameInputField.text;

                bool hasBlock = WordFilterUtil.IsBlockWord(nname);

                if (!hasBlock) {

                    bool isSucc = await web.PostRegister(nameInputField.text);

                    if (!isSucc) {

                        wrongText.text = "网络连接不佳";

                    }

                } else {

                    wrongText.text = "名字包含非法关键词";

                }

            });

            noButton.onClick.AddListener(() => {

                ui.EnterTitle("");

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