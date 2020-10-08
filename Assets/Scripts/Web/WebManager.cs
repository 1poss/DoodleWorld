using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DG.Tweening;
using JackUtil;

namespace DoodleWorldNS {

    public class WebManager : MonoBehaviour {

        public UIManager ui;
        public WorldManager world;
        public DataManager data;

        HttpHelper http;

        void Start() {

            http = new HttpHelper("http://127.0.0.1:9101");

        }

        public void GetBestBoard(string uid) {

        }

        public async Task<bool> PostRegister(string username) {

            string res = await http.PostAsync("/Register", new Dictionary<string, string>(){
                {"username", username}
            }, errCode => {
                ui.RegisterFailed(errCode);
            });

            var any = JsonConvert.DeserializeAnonymousType(res, new {
                uid = "",
                status = false,
                msg = ""
            });

            if (any == null) {

                return false;
                
            }

            if (any.status == false) {

                ui.RegisterFailed(any.msg);
                return false;

            } else {

                data.NewId(any.uid, username);
                await PostLogin(any.uid);
                ui.EnterTitle(username);
                return true;

            }

        }

        public async Task<bool> PostLogin(string uid) {

            string res = await http.PostAsync("/Login", new Dictionary<string, string>() {
                {"uid", uid}
            });

            var any = JsonConvert.DeserializeAnonymousType(res, new {
                username = "",
                status = false,
                deadTimes = 0,
                msg = ""
            });

            if (any == null) {

                ui.LoginFailed("网络无法连接");
                return false;

            }

            if (any.status == false) {

                ui.LoginFailed(any.msg);
                return false;

            } else {

                data.GetData().totalDeadTimes = any.deadTimes;
                return true;

            }

        }

        public async Task PostFinalData() {

            GameData gd = data.GetData();

            string res = await http.PostAsync("/RecordFinal", new Dictionary<string, string>{
                {"uid", gd.uid},
                {"username", gd.username},
                {"bestTime", gd.currentTime.ToString()},
                {"deadTimes", gd.totalDeadTimes.ToString()}
            });

            var any = JsonConvert.DeserializeAnonymousType(res, new {
                status = false,
                msg = ""
            });

            if (any.status) {

            } else {

            }

        }

    }
}