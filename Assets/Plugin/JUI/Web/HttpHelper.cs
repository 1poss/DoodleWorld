using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace JackUtil {

    public class HttpHelper {

        HttpClient client;

        public HttpHelper(string uri) {

            client = new HttpClient();
            client.BaseAddress = new Uri(uri);

        }

        // Get
        public async void GetAsync(string uri, Dictionary<string, string> paramData, Action<string> errCallback, Action<string> resultCallback) {

            if (paramData != null) {

                uri += "?";

                foreach (var kv in paramData) {
                    string key = kv.Key;
                    string value = kv.Value;
                    uri += key + "=" + value + "&";
                }

            }

            await client.GetStringAsync(uri).ContinueWith(t => {
               
                if (t.IsFaulted) {

                    // ShowMsg(t.Result);
                    errCallback?.Invoke(t.Result);
                    
                } else {

                    // ShowMsg(t.Result);
                    resultCallback?.Invoke(t.Result);

                }

            });

        }

        // Post
        public async void PostAsync(string uri, Dictionary<string, string> paramData, Action<string> errCallback, Action<string> resultCallback) {

            await client.PostAsync(uri, new FormUrlEncodedContent(paramData)).ContinueWith(t => {

                if (t.IsFaulted) {

                    errCallback.Invoke("错误:" + t.Result.StatusCode.ToString());
                    DebugUtil.LogError("err");

                } else {

                    HttpResponseMessage res = t.Result;
                    string jsonstring = res.Content.ReadAsStringAsync().Result;
                    resultCallback.Invoke(jsonstring);

                }
            });
        }

    }
}