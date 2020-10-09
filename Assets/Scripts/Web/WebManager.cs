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

        public async Task GetBestBoard() {

            ui.WebConnecting("正在获取速通榜");

            string res = await http.PostAsync("/GetBestBoard", new Dictionary<string, string>(){
                { "uid", data.GetData().uid }
            });

            ui.WebConnectingOver();

            print(res);

            BoardInfo info = JsonConvert.DeserializeObject<BoardInfo>(res);

            if (info == null) {

                ui.Alert("无数据");

                return;

            }

            ui.ShowBestBoard(info);

        }

        public async Task GetDeadBoard() {

            ui.WebConnecting("正在获取英灵榜");

            string res = await http.PostAsync("/GetDeadBoard", new Dictionary<string, string>(){
                { "uid", data.GetData().uid }
            });

            ui.WebConnectingOver();

            BoardInfo info = JsonConvert.DeserializeObject<BoardInfo>(res);

            if (info == null) {

                ui.Alert("无数据");

                return;

            }

            ui.ShowDeadBoard(info);

        }

        public async Task<bool> PostRegister(string username) {

            ui.WebConnecting("正在注册");

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

            ui.WebConnectingOver();

            if (any == null) {

                ui.RegisterFailed("无法连接服务器");
                return false;
                
            }

            if (any.status == false) {

                ui.RegisterFailed(any.msg);
                return false;

            } else {

                data.NewId(any.uid, username);
                await PostLogin(any.uid);
                ui.EnterTitle();
                return true;

            }

        }

        public async Task<bool> PostLogin(string uid) {

            ui.WebConnecting("正在登录");

            string res = await http.PostAsync("/Login", new Dictionary<string, string>() {
                {"uid", uid}
            });

            var any = JsonConvert.DeserializeAnonymousType(res, new {
                username = "",
                status = false,
                deadTimes = 0,
                msg = ""
            });

            ui.WebConnectingOver();

            if (any == null) {

                ui.LoginFailed("网络无法连接");
                return false;

            }

            if (any.status == false) {

                ui.LoginFailed(any.msg);
                return false;

            } else {

                data.GetData().totalDeadTimes = any.deadTimes;
                ui.LoginSuccess(any.username);
                return true;

            }

        }

        public async Task PostFinalData() {

            ui.WebConnecting("正在提交游戏数据");

            GameData gd = data.GetData();

            string res = await http.PostAsync("/RecordFinal", new Dictionary<string, string>{
                {"uid", gd.uid},
                {"username", gd.username},
                {"bestTime", gd.currentTime.ToString()},
                {"deadTimes", gd.totalDeadTimes.ToString()}
            });

            ui.WebConnectingOver();

            var any = JsonConvert.DeserializeAnonymousType(res, new {
                status = false,
                msg = ""
            });

            if (any == null) {

                return;

            }

            if (any.status) {

            } else {

            }

        }

    }
}