using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace JackUtil {

    [Serializable]
    public class HttpHelper {

        HttpClient client;

        public HttpHelper(string uri) {

            client = new HttpClient();
            client.BaseAddress = new Uri(uri);

        }

        // Get
        public async Task<string> GetAsync(string uri, Dictionary<string, string> paramData, Action<string> errCallback, Action<string> resultCallback) {

            if (paramData != null) {

                uri += "?";

                foreach (var kv in paramData) {
                    string key = kv.Key;
                    string value = kv.Value;
                    uri += key + "=" + value + "&";
                }

            }
            
            string r = string.Empty;

            await client.GetStringAsync(uri).ContinueWith(t => {
               
                if (t.IsFaulted) {

                    // ShowMsg(t.Result);
                    r = t.Result;
                    
                } else {

                    // ShowMsg(t.Result);
                    r = t.Result;

                }

            });

            return r;

        }

        // Post
        public async Task<string> PostAsync(string uri, Dictionary<string, string> paramData) {

            if (paramData == null) {
                paramData = new Dictionary<string, string>();
            }

            string r = string.Empty;

            await client.PostAsync(uri, new FormUrlEncodedContent(paramData)).ContinueWith(t => {

                if (t.IsFaulted) {

                    r = "错误:" + t.Result.StatusCode.ToString();

                } else {

                    HttpResponseMessage res = t.Result;
                    r = res.Content.ReadAsStringAsync().Result;

                }

            });

            return r;

        }

    }
}