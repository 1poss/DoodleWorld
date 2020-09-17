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

        public void ShowMsg(string msg) {

            var obj = JsonConvert.DeserializeAnonymousType(msg, new { bb = 0});
            DebugUtil.Log(obj.bb);

        }

        public void ShowResponse(HttpResponseMessage res) {

            DebugUtil.Log(res.Content.ReadAsStringAsync());

        }

        // Get
        public void GetAsync(string uri, Dictionary<string, string> paramData, Action<string> errCallback, Action<string> resultCallback) {

            client.GetStringAsync(uri).ContinueWith(t => {
               
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
        public void PostAsync(string uri, Dictionary<string, string> paramData, Action<string> errCallback, Action<string> resultCallback) {

            client.PostAsync(uri, new FormUrlEncodedContent(paramData)).ContinueWith(t => {
                
                if (t.IsFaulted) {

                    errCallback?.Invoke(t.Result.StatusCode.ToString());

                } else {

                    HttpResponseMessage res = t.Result;
                    resultCallback?.Invoke(res.Content.ReadAsStringAsync().Result);

                }
            });
        }

    }
}