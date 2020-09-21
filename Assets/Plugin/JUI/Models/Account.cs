using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JackUtil {

    [Serializable]
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

        public async Task<bool> Login(Action<string> errCallback, Action<bool> resultCallback) {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("username", username);
            param.Add("pwd", pwd);
            param.Add("verifyCode", verifyCode);

            verifyCode = string.Empty;
            pwd = string.Empty;

            string res = await helper.PostAsync("/Login", param);
            bool b = bool.Parse(res);
            return b;

        }

        public void Logout() {

            isLogined = false;
            pwd = string.Empty;
            verifyCode = string.Empty;

        }
        
    }
}