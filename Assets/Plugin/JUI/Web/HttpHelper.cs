using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace JackUtil {

    [Serializable]
    public class HttpHelper {

        HttpClient client;

        ///<summary>
        ///uri = "http://xxx.xxx.xxx.xxx:port"
        ///</summary>
        public HttpHelper(string uri) {

            client = new HttpClient();
            client.BaseAddress = new Uri(uri);

        }

        // Get
        public async Task<string> GetAsync(string uri, Dictionary<string, string> paramData) {

            if (paramData != null) {

                uri += "?";

                foreach (var kv in paramData) {
                    string key = kv.Key;
                    string value = kv.Value;
                    uri += key + "=" + value + "&";
                }

            }
            
            string r = string.Empty;

            await client.GetStringAsync(uri).ContinueWith(async t => {
               
                if (t.IsFaulted) {

                    r = await t;
                    DebugUtil.LogError(r);
                    
                } else {

                    r = await t;

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

            await client.PostAsync(uri, new FormUrlEncodedContent(paramData)).ContinueWith(async t => {

                HttpResponseMessage res = await t;

                if (t.IsFaulted) {

                    r = "错误:" + res.StatusCode.ToString();

                } else {

                    r = res.Content.ReadAsStringAsync().Result;

                }

            });

            return r;

        }

    }
}