using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JackUtil {

    public class Account {

        public HttpHelper helper;
        public string username;
        public string pwd;
        public string verifyCode;
        public bool isLogined;

        public Account(HttpHelper helper) {
            this.helper = helper;
            username = string.Empty;
            pwd = string.Empty;
            verifyCode = string.Empty;
            isLogined = false;
        }

        public void Login(Action<string> errCallback, Action<bool> resultCallback) {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("username", username);
            param.Add("pwd", pwd);
            param.Add("verifyCode", verifyCode);

            verifyCode = string.Empty;
            pwd = string.Empty;

            helper.PostAsync("/Login", param, errCallback, (result) => {
                bool b = JsonConvert.DeserializeObject<bool>(result);
                resultCallback?.Invoke(b);
                isLogined = true;
            });

        }

        public void Logout() {

            isLogined = false;
            pwd = string.Empty;
            verifyCode = string.Empty;

        }
        
    }
}