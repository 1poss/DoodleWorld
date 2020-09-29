using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class WebManager : MonoBehaviour, IWebManager {

        IUIManager ui;
        HttpHelper http;

        void Awake() {

            http = new HttpHelper("127.0.0.1:9101");

        }

        public void Init() {

        }

        public void GetBestBoard(string uid) {

        }

        public async Task Register(string username) {

            string res = await http.PostAsync("/Register", new Dictionary<string, string>(){
                {"username", username}
            });

            var any = JsonConvert.DeserializeAnonymousType(res, new {
                uid = "",
                status = false,
                msg = ""
            });

        }

        public void Login(string uid) {

        }

    }
}