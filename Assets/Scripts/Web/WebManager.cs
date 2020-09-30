using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class WebManager : MonoBehaviour, IWebManager {

        [NonSerialized]
        IUIManager ui;
        [NonSerialized]
        IWorldManager world;

        HttpHelper http;

        void Start() {

            http = new HttpHelper("http://127.0.0.1:9101");

        }

        public void Init() {

        }

        public void Inject(IUIManager ui, IWorldManager world) {
            this.ui = ui;
            this.world = world;
        }

        public void GetBestBoard(string uid) {

        }

        public async Task PostRegister(string username) {

            string res = await http.PostAsync("/Register", new Dictionary<string, string>(){
                {"username", username}
            });

            var any = JsonConvert.DeserializeAnonymousType(res, new {
                uid = "",
                status = false,
                msg = ""
            });

            if (any.status == false) {

                ui.RegisterFailed(any.msg);

            } else {

                ui.EnterTitle(username);

            }

        }

        public async Task PostLogin(string uid) {

            string res = await http.PostAsync("/Login", new Dictionary<string, string>(){
                {"uid", uid}
            });

            var any = JsonConvert.DeserializeAnonymousType(res, new {
                username = "",
                status = false,
                msg = ""
            });

            if (any.status == false) {

                ui.LoginFailed(any.msg);

            } else {

                ui.EnterTitle(any.username);

            }

        }

    }
}